using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormTurnos : Form
    {
        // ==================== Parámetros de validación ====================
        private readonly TimeSpan _horaInicio = TimeSpan.FromHours(8);   // 08:00
        private readonly TimeSpan _horaFin = TimeSpan.FromHours(20);  // 20:00
        private const int _slotMinutos = 15;                             // tamaño de bloque
        private const int _motivoMin = 5;
        private const int _motivoMax = 120;
        private const int _obsMax = 500;

        private readonly ErrorProvider _ep;

        public FormTurnos()
        {
            InitializeComponent();

            // ErrorProvider independiente del contenedor del diseñador
            _ep = new ErrorProvider
            {
                ContainerControl = this,
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            ConfigurarControles();
            ConectarEventos();

            // Asegurar fecha mínima/valor en orden correcto
            var hoy = DateTime.Today;
            if (dtpFecha.MinDate.Date != hoy)
                dtpFecha.MinDate = hoy;

            if (dtpFecha.Value.Date < dtpFecha.MinDate.Date)
                dtpFecha.Value = dtpFecha.MinDate;

            // Fijar hora inicial alineada a bloque válido y nunca 24:00
            var snapped = SnapToStep(DateTime.Now.TimeOfDay, _slotMinutos, clampToDayEnd: false);
            dtpHora.Value = DateTime.Today.Add(snapped);
        }

        // =========================== Configuración ===========================

        private void ConfigurarControles()
        {
            // Longitudes
            txtMotivo.MaxLength = _motivoMax;
            txtObs.MaxLength = _obsMax;

            // El diseñador ya trae formatos; reforzamos up/down
            dtpHora.ShowUpDown = true;

            // Botones y teclas
            btnGuardar.Click += async (s, e) => await OnGuardarAsync();
            btnCancelar.Click += (s, e) => this.Close();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) this.Close();
            };
        }

        private void ConectarEventos()
        {
            // Validación por control (suave: no bloquea Load)
            cboPaciente.Validating += (s, e) => RequireSelected(cboPaciente, "Seleccioná un paciente");
            cboMedico.Validating += (s, e) => RequireSelected(cboMedico, "Seleccioná un médico");
            dtpFecha.Validating += (s, e) => ValidateFecha();
            dtpHora.Validating += (s, e) => ValidateHora();
            txtMotivo.Validating += (s, e) => ValidateMotivo();

            // Correcciones activas y limpieza de errores
            dtpFecha.ValueChanged += (s, e) =>
            {
                ClearError(dtpFecha);
                ValidateFecha();
            };

            dtpHora.ValueChanged += (s, e) =>
            {
                var t = dtpHora.Value.TimeOfDay;
                var snapped = SnapToStep(t, _slotMinutos);
                if (snapped != t)
                    dtpHora.Value = dtpHora.Value.Date.Add(snapped);

                ClearError(dtpHora);
                ValidateHora();
            };

            txtMotivo.TextChanged += (s, e) => ClearError(txtMotivo);
            txtObs.TextChanged += (s, e) =>
            {
                if (txtObs.Text.Length <= _obsMax) ClearError(txtObs);
            };
        }

        // =========================== Validaciones ===========================

        private bool ValidateForm()
        {
            bool ok = true;
            ok &= RequireSelected(cboPaciente, "Seleccioná un paciente");
            ok &= RequireSelected(cboMedico, "Seleccioná un médico");
            ok &= ValidateFecha();
            ok &= ValidateHora();
            ok &= ValidateMotivo();
            ok &= ValidateObs();
            return ok;
        }

        private bool RequireSelected(ComboBox cbo, string msg)
        {
            if (cbo.SelectedIndex < 0)
            {
                _ep.SetError(cbo, msg);
                return false;
            }
            _ep.SetError(cbo, null);
            return true;
        }

        private bool ValidateFecha()
        {
            var fecha = dtpFecha.Value.Date;
            if (fecha < DateTime.Today)
            {
                _ep.SetError(dtpFecha, "La fecha no puede ser en el pasado");
                return false;
            }
            _ep.SetError(dtpFecha, null);
            return true;
        }

        private bool ValidateHora()
        {
            var time = dtpHora.Value.TimeOfDay;

            if (time < _horaInicio || time > _horaFin)
            {
                _ep.SetError(dtpHora, $"La hora debe estar entre {_horaInicio:hh\\:mm} y {_horaFin:hh\\:mm}");
                return false;
            }

            if ((time.TotalMinutes % _slotMinutos) != 0)
            {
                _ep.SetError(dtpHora, $"La hora debe caer en bloques de {_slotMinutos} minutos");
                return false;
            }

            _ep.SetError(dtpHora, null);
            return true;
        }

        private bool ValidateMotivo()
        {
            string txt = (txtMotivo.Text ?? "").Trim();

            if (txt.Length < _motivoMin)
            {
                _ep.SetError(txtMotivo, $"Ingresá un motivo (mínimo {_motivoMin} caracteres)");
                return false;
            }
            if (txt.Length > _motivoMax)
            {
                _ep.SetError(txtMotivo, $"Máximo permitido: {_motivoMax} caracteres");
                return false;
            }

            // Aplicar Trim al control una sola vez cuando está correcto
            if (txtMotivo.Text != txt) txtMotivo.Text = txt;

            _ep.SetError(txtMotivo, null);
            return true;
        }

        private bool ValidateObs()
        {
            string obs = txtObs.Text ?? "";
            if (obs.Length > _obsMax)
            {
                _ep.SetError(txtObs, $"Observaciones: máximo {_obsMax} caracteres");
                return false;
            }
            _ep.SetError(txtObs, null);
            return true;
        }

        private void ClearError(Control c) => _ep.SetError(c, null);

        // ===================== Guardado + Disponibilidad =====================

        private async Task OnGuardarAsync()
        {
            if (!ValidateForm())
            {
                // Foco al primer control con error
                var firstWithError = new Control[] { cboPaciente, cboMedico, dtpFecha, dtpHora, txtMotivo, txtObs }
                    .FirstOrDefault(c => !string.IsNullOrEmpty(_ep.GetError(c)));
                firstWithError?.Focus();

                MessageBox.Show("Revisá los campos marcados en rojo.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fecha = dtpFecha.Value.Date;
            var hora = dtpHora.Value.TimeOfDay;
            var fechaHora = fecha.Add(hora);

            // Toma SelectedValue si lo cargaste con ValueMember, si no, usa SelectedIndex como fallback
            var pacienteId = (cboPaciente.SelectedValue ?? cboPaciente.SelectedIndex)?.ToString();
            var medicoId = (cboMedico.SelectedValue ?? cboMedico.SelectedIndex)?.ToString();
            var motivo = txtMotivo.Text.Trim();
            var obs = (txtObs.Text ?? "").Trim();

            // Chequeo de disponibilidad (reemplazá por acceso real a datos)
            bool disponible = await IsTurnoDisponibleAsync(medicoId ?? "", fechaHora, _slotMinutos);
            if (!disponible)
            {
                _ep.SetError(dtpHora, "El médico ya tiene un turno en este horario.");
                MessageBox.Show("El horario seleccionado no está disponible para ese médico.", "Conflicto de agenda",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpHora.Focus();
                return;
            }

            // TODO: Guardar en base de datos con tu servicio/repositorio.
            // _turnoService.Crear(new TurnoDTO { ... });

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Hook de disponibilidad. Implementalo consultando tus turnos (solapamiento por médico).
        /// </summary>
        private Task<bool> IsTurnoDisponibleAsync(string medicoId, DateTime fechaHora, int duracionMin)
        {
            // Ejemplo esperado en implementación real:
            // var inicio = fechaHora;
            // var fin = fechaHora.AddMinutes(duracionMin);
            // return Task.FromResult(!_repoTurnos.ExisteSolapamiento(medicoId, inicio, fin));
            return Task.FromResult(true); // sin integración, dejamos pasar
        }

        // ============================== Helpers ==============================

        /// <summary>
        /// Redondea un TimeSpan al múltiplo más cercano de 'stepMinutos'.
        /// Nunca devuelve 24:00; en su lugar, clamp a último bloque o 23:59.
        /// </summary>
        private static TimeSpan SnapToStep(TimeSpan time, int stepMinutos, bool clampToDayEnd = true)
        {
            var step = Math.Max(1, stepMinutos);
            var total = (int)Math.Round(time.TotalMinutes / step) * step;

            if (total >= 24 * 60)
                total = clampToDayEnd ? (24 * 60 - step) : (24 * 60 - 1);

            if (total < 0) total = 0;
            return TimeSpan.FromMinutes(total);
        }
    }
}

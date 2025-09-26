using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormHC : Form
    {
        // ==================== Parámetros de validación ====================
        private const int _motivoMin = 5;
        private const int _motivoMax = 200;

        private const int _txMaxCorta = 400;   // para impresiones/diagnóstico en versión resumida
        private const int _txMaxLarga = 2000; // para indicaciones/antecedentes/evolución/exámenes

        private readonly ErrorProvider _ep;

        public FormHC()
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
        }

        // =========================== Configuración ===========================

        private void ConfigurarControles()
        {
            // Longitudes máximas
            txtMotivoConsulta.MaxLength = _motivoMax;
            txtImpresionDiag.MaxLength = _txMaxCorta;
            txtDiagnostico.MaxLength = _txMaxCorta;
            txtIndicaciones.MaxLength = _txMaxLarga;
            txtAntecedentes.MaxLength = _txMaxLarga;
            txtEvolucion.MaxLength = _txMaxLarga;
            txtImpresionGral.MaxLength = _txMaxCorta;
            txtExamenes.MaxLength = _txMaxLarga;
            txtTipoConsulta.MaxLength = 120;

            // DTP ya está con formato custom en el diseñador; reforzamos up/down
            dtpFechaHora.ShowUpDown = true;

            // Botones y teclas
            bGuardar.Click += async (s, e) => await OnGuardarAsync();
            bCancelar.Click += (s, e) => this.Close();
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };
        }

        private void ConectarEventos()
        {
            // Validación por control
            cboPaciente.Validating += (s, e) => RequireSelected(cboPaciente, "Seleccioná un paciente");
            cboEstado.Validating += (s, e) => RequireSelected(cboEstado, "Seleccioná el estado de la consulta");
            txtMotivoConsulta.Validating += (s, e) => ValidateMotivo();
            dtpFechaHora.Validating += (s, e) => ValidateFechaHora();
            txtDiagnostico.Validating += (s, e) => ValidateDiagnosticoCondicional();

            // Limpieza de errores al modificar
            cboPaciente.SelectedIndexChanged += (s, e) => ClearError(cboPaciente);
            cboEstado.SelectedIndexChanged += (s, e) => { ClearError(cboEstado); ValidateDiagnosticoCondicional(); };
            txtMotivoConsulta.TextChanged += (s, e) => ClearError(txtMotivoConsulta);
            dtpFechaHora.ValueChanged += (s, e) => ClearError(dtpFechaHora);

            txtImpresionDiag.TextChanged += (s, e) => ClearIfLenOk(txtImpresionDiag, _txMaxCorta);
            txtDiagnostico.TextChanged += (s, e) => ClearIfLenOk(txtDiagnostico, _txMaxCorta);
            txtIndicaciones.TextChanged += (s, e) => ClearIfLenOk(txtIndicaciones, _txMaxLarga);
            txtAntecedentes.TextChanged += (s, e) => ClearIfLenOk(txtAntecedentes, _txMaxLarga);
            txtEvolucion.TextChanged += (s, e) => ClearIfLenOk(txtEvolucion, _txMaxLarga);
            txtImpresionGral.TextChanged += (s, e) => ClearIfLenOk(txtImpresionGral, _txMaxCorta);
            txtExamenes.TextChanged += (s, e) => ClearIfLenOk(txtExamenes, _txMaxLarga);
            txtTipoConsulta.TextChanged += (s, e) => ClearError(txtTipoConsulta);
        }

        private void ClearIfLenOk(Control c, int max)
        {
            var txt = (c as TextBox)?.Text ?? "";
            if (txt.Length <= max) ClearError(c);
        }

        // =========================== Validaciones ===========================

        private bool ValidateForm()
        {
            bool ok = true;
            ok &= RequireSelected(cboPaciente, "Seleccioná un paciente");
            ok &= RequireSelected(cboEstado, "Seleccioná el estado de la consulta");
            ok &= ValidateMotivo();
            ok &= ValidateFechaHora();
            ok &= ValidateLargos();
            ok &= ValidateDiagnosticoCondicional();
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

        private bool ValidateMotivo()
        {
            string txt = (txtMotivoConsulta.Text ?? "").Trim();

            if (txt.Length < _motivoMin)
            {
                _ep.SetError(txtMotivoConsulta, $"Ingresá el motivo (mínimo {_motivoMin} caracteres)");
                return false;
            }
            if (txt.Length > _motivoMax)
            {
                _ep.SetError(txtMotivoConsulta, $"Motivo demasiado largo (máximo {_motivoMax})");
                return false;
            }

            if (txtMotivoConsulta.Text != txt) txtMotivoConsulta.Text = txt; // aplica Trim
            _ep.SetError(txtMotivoConsulta, null);
            return true;
        }

        private bool ValidateFechaHora()
        {
            var now = DateTime.Now.AddMinutes(5);
            if (dtpFechaHora.Value > now)
            {
                _ep.SetError(dtpFechaHora, "La fecha y hora no puede ser en el futuro");
                return false;
            }
            _ep.SetError(dtpFechaHora, null);
            return true;
        }

        private bool ValidateLargos()
        {
            if (!CheckMax(txtImpresionDiag, _txMaxCorta, "Impresión diagnóstica")) return false;
            if (!CheckMax(txtDiagnostico, _txMaxCorta, "Diagnóstico")) return false;
            if (!CheckMax(txtIndicaciones, _txMaxLarga, "Indicaciones")) return false;
            if (!CheckMax(txtAntecedentes, _txMaxLarga, "Antecedentes")) return false;
            if (!CheckMax(txtEvolucion, _txMaxLarga, "Evolución")) return false;
            if (!CheckMax(txtImpresionGral, _txMaxCorta, "Impresión general")) return false;
            if (!CheckMax(txtExamenes, _txMaxLarga, "Exámenes")) return false;
            if (!CheckMax(txtTipoConsulta, 120, "Tipo de consulta")) return false;

            return true;
        }

        private bool CheckMax(TextBox txt, int max, string etiqueta)
        {
            var len = (txt.Text ?? string.Empty).Length;
            if (len > max)
            {
                _ep.SetError(txt, $"{etiqueta}: máximo {max} caracteres");
                return false;
            }
            _ep.SetError(txt, null);
            return true;
        }

        private bool ValidateDiagnosticoCondicional()
        {
            var estado = (cboEstado.SelectedItem?.ToString() ?? "").ToLowerInvariant();
            bool exigeDiagnostico =
                estado.Contains("cerrad") ||
                estado.Contains("alta") ||
                estado.Contains("complet");

            if (exigeDiagnostico)
            {
                var diag = (txtDiagnostico.Text ?? "").Trim();
                if (diag.Length < 3)
                {
                    _ep.SetError(txtDiagnostico, "Para cerrar/alta/completado debés ingresar un diagnóstico.");
                    return false;
                }
            }

            _ep.SetError(txtDiagnostico, null);
            return true;
        }

        private void ClearError(Control c) => _ep.SetError(c, null);

        // ===================== Guardado =====================

        private async System.Threading.Tasks.Task OnGuardarAsync()
        {
            if (!ValidateForm())
            {
                var firstWithError = new Control[]
                {
                    cboPaciente, cboEstado, txtMotivoConsulta, dtpFechaHora,
                    txtImpresionDiag, txtDiagnostico, txtIndicaciones, txtAntecedentes,
                    txtEvolucion, txtImpresionGral, txtExamenes, txtTipoConsulta
                }.FirstOrDefault(c => !string.IsNullOrEmpty(_ep.GetError(c)));

                firstWithError?.Focus();

                MessageBox.Show("Revisá los campos marcados en rojo.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Guardar en DB
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormHC_Load(object? sender, EventArgs e)
        {
            // Configuración adicional si es necesario
        }
    }
}

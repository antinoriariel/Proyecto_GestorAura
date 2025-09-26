using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormTurnosMedico : Form
    {
        private readonly BindingList<TurnoVM> _turnos = new();
        private readonly BindingSource _bs = new();

        public FormTurnosMedico()
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarEventos();
            ConfigurarBinding();
            CargarDatosIniciales(); // demo – reemplazá por tu servicio/repositorio
        }

        // =================== UI / Binding ===================

        private void CargarCombos()
        {
            // Estados estándar
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "En curso", "Completado", "Cancelado" });
            cboEstado.SelectedIndex = 0;

            // Fecha por defecto: hoy
            var hoy = DateTime.Today;
            if (dtpFecha.MinDate.Date != hoy) dtpFecha.MinDate = hoy.AddYears(-1); // permitir revisar histórico hasta -1 año
            if (dtpFecha.Value.Date < dtpFecha.MinDate.Date) dtpFecha.Value = DateTime.Today;
        }

        private void ConfigurarEventos()
        {
            btnHoy.Click += (s, e) => { dtpFecha.Value = DateTime.Today; AplicarFiltros(); };
            btnLimpiar.Click += (s, e) =>
            {
                cboEstado.SelectedIndex = 0;
                txtBuscar.Clear();
                chkSoloPendientes.Checked = false;
                dtpFecha.Value = DateTime.Today;
                AplicarFiltros();
            };
            btnActualizar.Click += (s, e) => AplicarFiltros();

            dtpFecha.ValueChanged += (s, e) => AplicarFiltros();
            cboEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();
            chkSoloPendientes.CheckedChanged += (s, e) => AplicarFiltros();

            dgvTurnos.CellContentClick += DgvTurnos_CellContentClick;
            dgvTurnos.CellFormatting += DgvTurnos_CellFormatting;
            dgvTurnos.DoubleClick += (s, e) => AbrirTurnoSeleccionado();
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };
        }

        private void ConfigurarBinding()
        {
            _bs.DataSource = _turnos;
            dgvTurnos.DataSource = _bs;
        }

        // =================== Datos (ejemplo) ===================

        private void CargarDatosIniciales()
        {
            // Demo: reemplazá por llamada a tu repositorio filtrando por médico logueado.
            var hoy = DateTime.Today;
            _turnos.Clear();
            foreach (var t in DatosDemo(hoy))
                _turnos.Add(t);

            AplicarFiltros();
        }

        private IEnumerable<TurnoVM> DatosDemo(DateTime baseDay)
        {
            return new[]
            {
                new TurnoVM(baseDay.AddHours(9),  "Ana Gómez",       "Control de presión", "Pendiente"),
                new TurnoVM(baseDay.AddHours(9.5),"Bruno Martínez",  "Dolor abdominal",    "Pendiente"),
                new TurnoVM(baseDay.AddHours(10), "Carla López",     "Resultado de estudio","En curso"),
                new TurnoVM(baseDay.AddHours(11), "Diego Pérez",     "Consulta general",   "Completado"),
                new TurnoVM(baseDay.AddDays(1).AddHours(8.5), "Elena Ríos", "Chequeo anual", "Pendiente"),
                new TurnoVM(baseDay.AddHours(12.5), "Facundo Ruiz",  "Gripe y fiebre",     "Cancelado"),
            };
        }

        // =================== Filtros ===================

        private void AplicarFiltros()
        {
            var fechaFiltro = dtpFecha.Value.Date;
            var estado = (cboEstado.SelectedItem?.ToString() ?? "Todos");
            var q = (txtBuscar.Text ?? "").Trim().ToLowerInvariant();
            var soloPend = chkSoloPendientes.Checked;

            IEnumerable<TurnoVM> query = _turnos;

            // Filtrar por día (solo el día seleccionado)
            query = query.Where(t => t.FechaHora.Date == fechaFiltro);

            // Estado
            if (estado != "Todos")
                query = query.Where(t => t.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));

            if (soloPend)
                query = query.Where(t => t.Estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase));

            // Texto
            if (q.Length > 0)
                query = query.Where(t =>
                    (t.Paciente?.ToLowerInvariant().Contains(q) ?? false) ||
                    (t.Motivo?.ToLowerInvariant().Contains(q) ?? false));

            _bs.DataSource = query.ToList();
            _bs.ResetBindings(false);
        }

        // =================== Grilla: formato + acciones ===================

        private void DgvTurnos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTurnos.Columns[e.ColumnIndex].DataPropertyName == "Estado")
            {
                var estado = e.Value?.ToString() ?? "";
                var row = dgvTurnos.Rows[e.RowIndex];

                // Reset básico
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

                switch (estado)
                {
                    case "Pendiente":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 249, 228); // amarillito
                        break;
                    case "En curso":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(232, 245, 233); // verdoso
                        break;
                    case "Completado":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                        break;
                    case "Cancelado":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(252, 231, 230); // rojizo suave
                        break;
                }
            }
        }

        private void DgvTurnos_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvTurnos.Columns[e.ColumnIndex];
            var turno = dgvTurnos.Rows[e.RowIndex].DataBoundItem as TurnoVM;
            if (turno == null) return;

            if (col is DataGridViewButtonColumn)
            {
                if (col.HeaderText == "Atender")
                {
                    AbrirTurno(turno);
                }
                else if (col.HeaderText == "Cancelar")
                {
                    CancelarTurno(turno);
                }
            }
        }

        private void AbrirTurnoSeleccionado()
        {
            if (_bs.Current is TurnoVM t)
                AbrirTurno(t);
        }

        // =================== Hooks para integrar con tu app ===================

        private void AbrirTurno(TurnoVM t)
        {
            // Aquí abrís el formulario de atención / historia clínica, pasando el ID.
            // Ejemplo:
            // using var f = new FormHC(t.TurnoId);
            // f.ShowDialog(this);

            MessageBox.Show($"Abrir turno de {t.Paciente} ({t.Fecha} {t.Hora})", "Atender",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CancelarTurno(TurnoVM t)
        {
            var r = MessageBox.Show($"¿Cancelar el turno de {t.Paciente} ({t.Fecha} {t.Hora})?",
                "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                // Aquí invocarías a tu repositorio/servicio para cancelar por ID
                // _turnosService.Cancelar(t.TurnoId);

                t.Estado = "Cancelado";
                _bs.ResetBindings(false);
            }
        }
    }

    // =================== ViewModel para la grilla ===================

    public class TurnoVM
    {
        public Guid TurnoId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Fecha => FechaHora.ToString("dd/MM/yyyy");
        public string Hora => FechaHora.ToString("HH:mm");
        public string Paciente { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }

        public TurnoVM() { }

        public TurnoVM(DateTime fechaHora, string paciente, string motivo, string estado)
        {
            TurnoId = Guid.NewGuid();
            FechaHora = fechaHora;
            Paciente = paciente;
            Motivo = motivo;
            Estado = estado;
        }
    }
}

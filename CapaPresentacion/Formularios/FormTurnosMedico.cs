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

            // Optimización visual
            this.DoubleBuffered = true;
            typeof(DataGridView)
              .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
              ?.SetValue(dgvTurnos, true, null);

            ConfigurarEventos();
            ConfigurarBinding();
            CargarDatosIniciales();
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

            dgvTurnos.CellFormatting += DgvTurnos_CellFormatting;
            dgvTurnos.DoubleClick += (s, e) => AbrirTurnoSeleccionado();

            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };
        }

        private void ConfigurarBinding()
        {
            _bs.DataSource = _turnos;
            dgvTurnos.AutoGenerateColumns = true;
            dgvTurnos.DataSource = _bs;
        }

        private void CargarDatosIniciales()
        {
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
                new TurnoVM(baseDay.AddHours(9),   "Ana Gómez",    "Control de presión",  "Pendiente"),
                new TurnoVM(baseDay.AddHours(9.5),"Bruno Martínez","Dolor abdominal",     "Pendiente"),
                new TurnoVM(baseDay.AddHours(10),  "Carla López",  "Resultado de estudio","En curso"),
                new TurnoVM(baseDay.AddHours(11),  "Diego Pérez",  "Consulta general",    "Completado"),
                new TurnoVM(baseDay.AddHours(12.5),"Facundo Ruiz", "Gripe y fiebre",      "Cancelado"),
            };
        }

        private void AplicarFiltros()
        {
            var fechaFiltro = dtpFecha.Value.Date;
            var estado = (cboEstado.SelectedItem?.ToString() ?? "Todos");
            var q = (txtBuscar.Text ?? "").Trim().ToLowerInvariant();
            var soloPend = chkSoloPendientes.Checked;

            IEnumerable<TurnoVM> query = _turnos;
            query = query.Where(t => t.FechaHora.Date == fechaFiltro);

            if (estado != "Todos")
                query = query.Where(t => t.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));

            if (soloPend)
                query = query.Where(t => t.Estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase));

            if (q.Length > 0)
                query = query.Where(t =>
                    (t.Paciente?.ToLowerInvariant().Contains(q) ?? false) ||
                    (t.Motivo?.ToLowerInvariant().Contains(q) ?? false));

            _bs.DataSource = query.ToList();
            _bs.ResetBindings(false);
        }

        private void DgvTurnos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTurnos.Columns[e.ColumnIndex].HeaderText == "Estado")
            {
                var estado = e.Value?.ToString() ?? "";
                var row = dgvTurnos.Rows[e.RowIndex];

                switch (estado)
                {
                    case "Pendiente":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 249, 228);
                        break;
                    case "En curso":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(232, 245, 233);
                        break;
                    case "Completado":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
                        break;
                    case "Cancelado":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(252, 231, 230);
                        break;
                }
            }
        }

        private void AbrirTurnoSeleccionado()
        {
            if (_bs.Current is TurnoVM t)
                MessageBox.Show($"Abrir turno de {t.Paciente} ({t.Fecha} {t.Hora})",
                    "Atender", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

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

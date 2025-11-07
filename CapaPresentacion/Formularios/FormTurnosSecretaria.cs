using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormTurnosSecretaria : Form
    {
        private readonly TurnoNegocio _turnoNegocio = new TurnoNegocio();
        private DataTable _tablaTurnos = new();

        public FormTurnosSecretaria()
        {
            InitializeComponent();

            // Optimización visual
            this.DoubleBuffered = true;
            typeof(DataGridView)
              .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
              ?.SetValue(dgvTurnos, true, null);

            ConfigurarEventos();
            CargarEstados();
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
            btnActualizar.Click += (s, e) => CargarTurnos();

            dtpFecha.ValueChanged += (s, e) => AplicarFiltros();
            cboEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();
            chkSoloPendientes.CheckedChanged += (s, e) => AplicarFiltros();

            dgvTurnos.CellFormatting += DgvTurnos_CellFormatting;
            dgvTurnos.DoubleClick += (s, e) => AbrirTurnoSeleccionado();

            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };
        }

        private void CargarEstados()
        {
            cboEstado.Items.Clear();
            cboEstado.Items.Add("Todos");
            cboEstado.Items.Add("Pendiente");
            cboEstado.Items.Add("En curso");
            cboEstado.Items.Add("Completado");
            cboEstado.Items.Add("Cancelado");
            cboEstado.SelectedIndex = 0;
        }

        private void CargarDatosIniciales()
        {
            dtpFecha.Value = DateTime.Today;
            CargarTurnos();
        }

        private void CargarTurnos()
        {
            try
            {
                _tablaTurnos = _turnoNegocio.ObtenerTurnos();
                dgvTurnos.DataSource = _tablaTurnos;
                ConfigurarGrilla();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los turnos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla()
        {
            if (_tablaTurnos.Columns.Contains("id_turno"))
                dgvTurnos.Columns["id_turno"].HeaderText = "ID";
            if (_tablaTurnos.Columns.Contains("fecha_turno"))
                dgvTurnos.Columns["fecha_turno"].HeaderText = "Fecha";
            if (_tablaTurnos.Columns.Contains("hora_turno"))
                dgvTurnos.Columns["hora_turno"].HeaderText = "Hora";
            if (_tablaTurnos.Columns.Contains("paciente"))
                dgvTurnos.Columns["paciente"].HeaderText = "Paciente";
            if (_tablaTurnos.Columns.Contains("medico"))
                dgvTurnos.Columns["medico"].HeaderText = "Médico";
            if (_tablaTurnos.Columns.Contains("estado"))
                dgvTurnos.Columns["estado"].HeaderText = "Estado";
            if (_tablaTurnos.Columns.Contains("motivo"))
                dgvTurnos.Columns["motivo"].HeaderText = "Motivo";
        }

        private void AplicarFiltros()
        {
            if (_tablaTurnos == null || _tablaTurnos.Rows.Count == 0)
                return;

            var fechaFiltro = dtpFecha.Value.Date;
            var estado = (cboEstado.SelectedItem?.ToString() ?? "Todos");
            var q = (txtBuscar.Text ?? "").Trim().ToLowerInvariant();
            var soloPend = chkSoloPendientes.Checked;

            string filtro = "";

            // Filtro por fecha
            if (_tablaTurnos.Columns.Contains("fecha_turno"))
            {
                filtro = $"fecha_turno = '{fechaFiltro:yyyy-MM-dd}'";
            }

            // Filtro por estado
            if (estado != "Todos" && _tablaTurnos.Columns.Contains("estado"))
            {
                if (filtro.Length > 0) filtro += " AND ";
                filtro += $"estado = '{estado}'";
            }

            // Filtro solo pendientes (tiene prioridad sobre el combo)
            if (soloPend && _tablaTurnos.Columns.Contains("estado"))
            {
                if (filtro.Length > 0) filtro += " AND ";
                filtro += "estado = 'Pendiente'";
            }

            // Filtro por búsqueda de texto
            if (q.Length > 0)
            {
                if (filtro.Length > 0) filtro += " AND ";

                string busquedaFiltro = "(";
                bool primerCampo = true;

                if (_tablaTurnos.Columns.Contains("paciente"))
                {
                    busquedaFiltro += $"paciente LIKE '%{q}%'";
                    primerCampo = false;
                }
                if (_tablaTurnos.Columns.Contains("motivo"))
                {
                    if (!primerCampo) busquedaFiltro += " OR ";
                    busquedaFiltro += $"motivo LIKE '%{q}%'";
                    primerCampo = false;
                }
                if (_tablaTurnos.Columns.Contains("medico"))
                {
                    if (!primerCampo) busquedaFiltro += " OR ";
                    busquedaFiltro += $"medico LIKE '%{q}%'";
                }

                busquedaFiltro += ")";
                filtro += busquedaFiltro;
            }

            try
            {
                var vista = _tablaTurnos.DefaultView;
                vista.RowFilter = filtro;
                dgvTurnos.DataSource = vista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar filtros: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvTurnos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTurnos.Columns[e.ColumnIndex].Name == "estado")
            {
                var estado = e.Value?.ToString() ?? "";
                var row = dgvTurnos.Rows[e.RowIndex];

                switch (estado)
                {
                    case "Pendiente":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 228);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "En curso":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case "Completado":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 100);
                        break;
                    case "Cancelado":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(252, 231, 230);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void AbrirTurnoSeleccionado()
        {
            if (dgvTurnos.CurrentRow == null) return;

            try
            {
                int id = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["id_turno"].Value);
                var frm = new TurnoEditor(id);
                if (frm.ShowDialog() == DialogResult.OK)
                    CargarTurnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el turno: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
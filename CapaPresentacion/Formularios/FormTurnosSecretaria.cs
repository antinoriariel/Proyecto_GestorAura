using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormTurnosSecretaria : Form
    {
        private readonly TurnoNegocio _turnoNegocio = new();
        private DataTable _dtTurnos = new();

        public FormTurnosSecretaria()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object? sender, EventArgs e)
        {
            InicializarUI();
            ConectarEventos();
            CargarTurnos();
        }

        // ====================================================
        // Inicialización
        // ====================================================
        private void InicializarUI()
        {
            try
            {
                if (cboEstado != null && cboEstado.Items.Count == 0)
                {
                    cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                    cboEstado.Items.AddRange(new[] { "Todos", "programado", "confirmado", "atendido", "cancelado" });
                    cboEstado.SelectedIndex = 0;
                }

                dtpFecha.Value = DateTime.Today;
                dgvTurnos.AutoGenerateColumns = true;
                dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTurnos.MultiSelect = false;
                dgvTurnos.ReadOnly = true;
            }
            catch { }
        }

        private void ConectarEventos()
        {
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();
            cboEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
            dtpFecha.ValueChanged += (s, e) => AplicarFiltros();
            chkSoloPendientes.CheckedChanged += (s, e) => AplicarFiltros();

            btnHoy.Click += (s, e) => { dtpFecha.Value = DateTime.Today; AplicarFiltros(); };
            btnLimpiar.Click += (s, e) => LimpiarFiltros();
            btnActualizar.Click += (s, e) => CargarTurnos();

            btnAgregar.Click += BtnAgregar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
        }

        // ====================================================
        // Cargar y configurar grilla
        // ====================================================
        private void CargarTurnos()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _dtTurnos = _turnoNegocio.ObtenerTurnos() ?? new DataTable();
                _dtTurnos.CaseSensitive = false;
                dgvTurnos.DataSource = _dtTurnos;

                ConfigurarGrilla();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ConfigurarGrilla()
        {
            if (dgvTurnos.Columns.Contains("id_turno"))
            {
                dgvTurnos.Columns["id_turno"].HeaderText = "ID";
                dgvTurnos.Columns["id_turno"].Width = 60;
            }

            if (dgvTurnos.Columns.Contains("fecha_turno"))
            {
                dgvTurnos.Columns["fecha_turno"].HeaderText = "Fecha";
                dgvTurnos.Columns["fecha_turno"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvTurnos.Columns["fecha_turno"].Width = 90;
            }

            if (dgvTurnos.Columns.Contains("hora_turno"))
            {
                dgvTurnos.Columns["hora_turno"].HeaderText = "Hora";
                dgvTurnos.Columns["hora_turno"].Width = 70;
            }

            if (dgvTurnos.Columns.Contains("paciente"))
                dgvTurnos.Columns["paciente"].HeaderText = "Paciente";

            if (dgvTurnos.Columns.Contains("medico"))
                dgvTurnos.Columns["medico"].HeaderText = "Médico";

            if (dgvTurnos.Columns.Contains("estado"))
                dgvTurnos.Columns["estado"].HeaderText = "Estado";

            if (dgvTurnos.Columns.Contains("motivo"))
                dgvTurnos.Columns["motivo"].HeaderText = "Motivo";

            // 🔹 Manejamos formato de hora manualmente
            dgvTurnos.CellFormatting -= DgvTurnos_CellFormatting;
            dgvTurnos.CellFormatting += DgvTurnos_CellFormatting;
        }

        private void DgvTurnos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTurnos.Columns[e.ColumnIndex].Name == "hora_turno" && e.Value != null)
            {
                try
                {
                    // Si viene como TimeSpan
                    if (e.Value is TimeSpan ts)
                    {
                        e.Value = ts.ToString(@"hh\:mm");
                        e.FormattingApplied = true;
                    }
                    // Si viene como DateTime
                    else if (e.Value is DateTime dt)
                    {
                        e.Value = dt.ToString("HH:mm");
                        e.FormattingApplied = true;
                    }
                    // Si viene como string
                    else if (e.Value is string s && TimeSpan.TryParse(s, out var t))
                    {
                        e.Value = t.ToString(@"hh\:mm");
                        e.FormattingApplied = true;
                    }
                }
                catch
                {
                    // Si no se puede convertir, no formatear nada
                    e.FormattingApplied = false;
                }
            }
        }

        // ====================================================
        // Filtros
        // ====================================================
        private void LimpiarFiltros()
        {
            txtBuscar.Text = "";
            cboEstado.SelectedIndex = 0;
            chkSoloPendientes.Checked = false;
            dtpFecha.Value = DateTime.Today;
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (_dtTurnos.Rows.Count == 0)
                return;

            try
            {
                var filtros = new System.Collections.Generic.List<string>();

                // Fecha
                if (_dtTurnos.Columns.Contains("fecha_turno"))
                {
                    DateTime f0 = dtpFecha.Value.Date;
                    DateTime f1 = f0.AddDays(1);
                    string s0 = f0.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    string s1 = f1.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                    filtros.Add($"fecha_turno >= #{s0}# AND fecha_turno < #{s1}#");
                }

                // Estado
                var estado = (cboEstado.SelectedItem?.ToString() ?? "Todos").Trim();
                if (estado != "Todos" && _dtTurnos.Columns.Contains("estado"))
                    filtros.Add($"estado = '{estado.Replace("'", "''")}'");

                // Pendientes
                if (chkSoloPendientes.Checked)
                    filtros.Add("estado IN ('programado','confirmado')");

                // Texto
                string q = txtBuscar.Text.Trim();
                if (!string.IsNullOrEmpty(q))
                {
                    q = EscapeLike(q);
                    var sub = new System.Collections.Generic.List<string>();
                    if (_dtTurnos.Columns.Contains("paciente")) sub.Add($"paciente LIKE '%{q}%'");
                    if (_dtTurnos.Columns.Contains("medico")) sub.Add($"medico LIKE '%{q}%'");
                    if (_dtTurnos.Columns.Contains("motivo")) sub.Add($"motivo LIKE '%{q}%'");
                    if (sub.Count > 0) filtros.Add("(" + string.Join(" OR ", sub) + ")");
                }

                _dtTurnos.DefaultView.RowFilter = string.Join(" AND ", filtros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar filtros:\n" + ex.Message, "Filtro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string EscapeLike(string value)
        {
            return value.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]").Replace("*", "[*]").Replace("'", "''");
        }

        // ====================================================
        // CRUD (botones)
        // ====================================================
        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            var frm = new TurnoEditor();
            if (frm.ShowDialog() == DialogResult.OK)
                CargarTurnos();
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["id_turno"].Value);
            var frm = new TurnoEditor(id);
            if (frm.ShowDialog() == DialogResult.OK)
                CargarTurnos();
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["id_turno"].Value);

            if (MessageBox.Show("¿Eliminar el turno seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_turnoNegocio.EliminarTurno(id))
                {
                    MessageBox.Show("Turno eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTurnos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el turno.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

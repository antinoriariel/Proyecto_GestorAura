using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class InicioSecre : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();
        private readonly TurnoNegocio _turnoNegocio = new TurnoNegocio();
        private DataTable _turnosHoy = new();

        public string NombreUsuario { get; set; } = string.Empty;
        public string RolUsuario { get; set; } = "Secretaria";

        public InicioSecre()
        {
            InitializeComponent();
            Load += OnLoad;

            // Smoother DataGridView scrolling
            this.DoubleBuffered = true;
            typeof(DataGridView)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgvTurnos, true, null);
        }

        private void OnLoad(object? sender, EventArgs e)
        {
            CargarDatosSecretaria();
            MostrarInformacionGeneral();
            CargarMedicos();
            CargarTurnosDelDia();

            // Configurar eventos de filtros
            btnActualizar.Click += (s, e) => CargarTurnosDelDia();
            btnHoy.Click += (s, e) => { dtpFecha.Value = DateTime.Today; CargarTurnosDelDia(); };
            btnLimpiar.Click += (s, e) =>
            {
                txtBuscar.Clear();
                cmbMedicos.SelectedIndex = 0;
                dtpFecha.Value = DateTime.Today;
                CargarTurnosDelDia();
            };

            txtBuscar.TextChanged += (s, e) => AplicarFiltros();
            dtpFecha.ValueChanged += (s, e) => CargarTurnosDelDia();
            cmbMedicos.SelectedIndexChanged += (s, e) => CargarTurnosDelDia();

            dgvTurnos.CellFormatting += DgvTurnos_CellFormatting;
        }

        private void CargarDatosSecretaria()
        {
            try
            {
                DataTable datos = _usuarioNegocio.ObtenerDatosSecretaria(NombreUsuario);
                if (datos.Rows.Count > 0)
                {
                    var fila = datos.Rows[0];
                    lblNombreSecretaria.Text = $"{fila["nombre"]} {fila["apellido"]}";
                    lblRolSecretaria.Text = fila["rol"].ToString();
                    lblEmailSecretaria.Text = fila["email"].ToString();
                }
                else
                {
                    lblNombreSecretaria.Text = "<usuario no encontrado>";
                    lblRolSecretaria.Text = RolUsuario;
                    lblEmailSecretaria.Text = "—";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos de la secretaria: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarInformacionGeneral()
        {
            lblVersionSistema.Text = "GestorAura v1.0";
            lblEstadoServidor.Text = "🟢 Servidor activo";
            lblFraseMotivacional.Text =
                $"📅 Hoy es {DateTime.Now:dddd, dd MMMM yyyy} - \"La organización es la clave del éxito\"";
        }

        private void CargarMedicos()
        {
            try
            {
                DataTable medicos = _turnoNegocio.ObtenerMedicos();

                // Opción "Todos"
                DataRow filaTodos = medicos.NewRow();
                filaTodos["nombreCompleto"] = "Todos los médicos";
                medicos.Rows.InsertAt(filaTodos, 0);

                cmbMedicos.DataSource = medicos;
                cmbMedicos.DisplayMember = "nombreCompleto";
                cmbMedicos.ValueMember = "nombreCompleto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar médicos: " + ex.Message);
            }
        }

        private void CargarTurnosDelDia()
        {
            try
            {
                string? nombreMedico = cmbMedicos.SelectedValue?.ToString();
                if (string.IsNullOrWhiteSpace(nombreMedico) || nombreMedico == "Todos los médicos")
                    nombreMedico = null;

                _turnosHoy = _turnoNegocio.ObtenerTurnosDelDiaPorNombre(dtpFecha.Value.Date, nombreMedico);
                dgvTurnos.DataSource = _turnosHoy;
                ConfigurarGrilla();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos del día: " + ex.Message);
            }
        }

        private void ConfigurarGrilla()
        {
            if (dgvTurnos.Columns.Count > 0)
            {
                dgvTurnos.Columns["id_turno"].HeaderText = "ID";
                dgvTurnos.Columns["hora_turno"].HeaderText = "Hora";
                dgvTurnos.Columns["paciente"].HeaderText = "Paciente";
                dgvTurnos.Columns["medico"].HeaderText = "Médico";
                dgvTurnos.Columns["estado"].HeaderText = "Estado";
                dgvTurnos.Columns["motivo"].HeaderText = "Motivo";
            }
        }

        private void AplicarFiltros()
        {
            if (_turnosHoy == null || _turnosHoy.Rows.Count == 0) return;

            var q = (txtBuscar.Text ?? "").Trim().ToLowerInvariant();
            if (q.Length == 0)
            {
                dgvTurnos.DataSource = _turnosHoy;
                return;
            }

            try
            {
                var vista = _turnosHoy.DefaultView;
                string filtro = $"paciente LIKE '%{q}%' OR medico LIKE '%{q}%' OR motivo LIKE '%{q}%'";
                vista.RowFilter = filtro;
                dgvTurnos.DataSource = vista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
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
                    case "programado":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 228);
                        break;
                    case "confirmado":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
                        break;
                    case "atendido":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(100, 100, 100);
                        break;
                    case "cancelado":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(252, 231, 230);
                        break;
                }
            }
        }
    }
}

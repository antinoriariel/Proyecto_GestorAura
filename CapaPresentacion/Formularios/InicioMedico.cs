using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class InicioMedico : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new();
        private readonly TurnoNegocio _turnoNegocio = new();
        private readonly PacienteNegocio _pacienteNegocio = new();

        private string _nombreMedicoCompleto = string.Empty;

        // Propiedades que recibe desde Dashboard
        public string NombreUsuario { get; set; } = string.Empty;
        public string RolUsuario { get; set; } = "Médico";
        public int IdUsuarioActual { get; set; }

        public InicioMedico()
        {
            InitializeComponent();
            Load += InicioMedico_Load;

            // Scroll suave en DataGridViews
            this.DoubleBuffered = true;
            typeof(DataGridView)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgvTurnos, true, null);
            typeof(DataGridView)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgvPacientes, true, null);
        }

        private void InicioMedico_Load(object? sender, EventArgs e)
        {
            try
            {
                BackColor = ColorTranslator.FromHtml("#eeeeee");

                CargarDatosMedico();
                MostrarInformacionGeneral();
                CargarTurnosDelDia();
                CargarPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inicio del médico:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // DATOS DEL MÉDICO
        // ============================================================
        private void CargarDatosMedico()
        {
            try
            {
                DataTable datos = _usuarioNegocio.ObtenerDatosMedico(NombreUsuario);
                if (datos.Rows.Count > 0)
                {
                    var fila = datos.Rows[0];
                    lblNombreMedico.Text = $"Dr. {fila["nombre"]} {fila["apellido"]}";
                    lblEspecialidadValor.Text = fila["especialidad"]?.ToString() ?? "—";

                    string matProv = fila["matricula_provincial"]?.ToString() ?? "—";
                    string matNac = fila["matricula_nacional"]?.ToString() ?? "—";
                    lblMatriculaValor.Text = $"Prov. {matProv} | Nac. {matNac}";

                    _nombreMedicoCompleto = $"{fila["apellido"]}, {fila["nombre"]}";
                    lblServidorValor.Text = "🟢 Servidor activo";
                }
                else
                {
                    lblNombreMedico.Text = $"Dr. Ariel Ant.";
                    lblEspecialidadValor.Text = "Cardiología";
                    lblMatriculaValor.Text = "9999";
                    lblServidorValor.Text = "⚠ Sin datos en BD";
                }
            }
            catch (Exception ex)
            {
                lblNombreMedico.Text = $"Dr. {NombreUsuario}";
                lblEspecialidadValor.Text = "—";
                lblMatriculaValor.Text = "—";
                lblServidorValor.Text = "⚠ Error";
                MessageBox.Show("Error al obtener datos del médico: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarInformacionGeneral()
        {
            lblVersionSistema.Text = "GestorAura v1.0";
            lblFechaHoy.Text = $"📅 {DateTime.Now:dddd, dd MMMM yyyy}";
        }

        // ============================================================
        // TURNOS DEL DÍA
        // ============================================================
        private void CargarTurnosDelDia()
        {
            try
            {
                DataTable turnos = _turnoNegocio.ObtenerTurnosDelDiaPorNombre(DateTime.Today, _nombreMedicoCompleto);
                dgvTurnos.DataSource = turnos;

                ConfigurarGrilla(dgvTurnos);
                if (dgvTurnos.Columns.Contains("hora_turno"))
                    dgvTurnos.Columns["hora_turno"].HeaderText = "Hora";
                if (dgvTurnos.Columns.Contains("paciente"))
                    dgvTurnos.Columns["paciente"].HeaderText = "Paciente";
                if (dgvTurnos.Columns.Contains("estado"))
                    dgvTurnos.Columns["estado"].HeaderText = "Estado";
                if (dgvTurnos.Columns.Contains("motivo"))
                    dgvTurnos.Columns["motivo"].HeaderText = "Motivo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los turnos del día: " + ex.Message);
            }
        }

        // ============================================================
        // PACIENTES
        // ============================================================
        private void CargarPacientes()
        {
            try
            {
                DataTable pacientes = _pacienteNegocio.ObtenerListaSimple(true);
                dgvPacientes.DataSource = pacientes;
                ConfigurarGrilla(dgvPacientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de pacientes: " + ex.Message);
            }
        }

        // ============================================================
        // CONFIGURACIÓN GENERAL DE GRILLAS
        // ============================================================
        private void ConfigurarGrilla(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DefaultCellStyle.Font = new Font("Consolas", 10F);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 10F, FontStyle.Bold);
        }
    }
}

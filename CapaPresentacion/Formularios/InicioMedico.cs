using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public class InicioMedico : Form
    {
        private readonly MedicoNegocio _medicoNegocio = new();
        private readonly TurnoNegocio _turnoNegocio = new();
        private readonly PacienteNegocio _pacienteNegocio = new();

        private string _nombreMedicoCompleto = string.Empty;

        // Recibidos desde Dashboard
        public int IdUsuarioActual { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string RolUsuario { get; set; } = "Médico";

        // ======= UI =======
        private TableLayoutPanel layoutMain;
        private Panel cardHeader;
        private Panel cardTurnos;
        private Panel cardPacientes;

        private Label lblNombreMedico;
        private Label lblServidorValor;
        private Label lblEspecialidadValor;
        private Label lblMatriculaValor;
        private Label lblVersionSistema;
        private Label lblFechaHoy;

        private DataGridView dgvTurnos;
        private DataGridView dgvPacientes;

        // ============================================================
        // CONSTRUCTORES
        // ============================================================
        public InicioMedico()
        {
            // Config general del form
            Text = "Inicio Médico";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1200, 720);
            Font = new Font("Consolas", 10F);
            BackColor = ColorTranslator.FromHtml("#eeeeee");
            DoubleBuffered = true;

            ConstruirInterfazMaterial();
            Load += InicioMedico_Load;

            // Scroll suave en DGV
            typeof(DataGridView)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgvTurnos, true, null);
            typeof(DataGridView)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgvPacientes, true, null);
        }

        public InicioMedico(int idUsuario, string username, string rol) : this()
        {
            IdUsuarioActual = idUsuario;
            NombreUsuario = username;
            RolUsuario = rol;
        }

        // ============================================================
        // BUILD UI (Material-like)
        // ============================================================
        private void ConstruirInterfazMaterial()
        {
            // -------- MAIN LAYOUT --------
            layoutMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(24, 18, 24, 18),
            };
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 150f)); // header
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));   // turnos
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));   // pacientes

            // -------- HEADER CARD --------
            cardHeader = CrearCardPanel();
            var headerLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 2,
                Padding = new Padding(10, 6, 10, 6)
            };
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f)); // nombre
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f)); // especialidad/mat
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f)); // servidor/fecha

            headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60f)); // fila principal
            headerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40f)); // versión / fecha

            // Nombre
            lblNombreMedico = new Label
            {
                Text = "Dr.",
                AutoSize = true,
                Dock = DockStyle.Left,
                Font = new Font("Consolas", 14F, FontStyle.Bold),
                Padding = new Padding(0, 4, 0, 0)
            };

            // Servidor (arriba derecha)
            lblServidorValor = new Label
            {
                Text = "● Activo",
                AutoSize = true,
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleRight
            };

            // Centro: layout para especialidad y matrícula
            var centerLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2
            };
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            var lblEspecialidad = new Label
            {
                Text = "Especialidad:",
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(0, 0, 6, 0)
            };
            lblEspecialidadValor = new Label
            {
                Text = "—",
                AutoSize = true,
                Anchor = AnchorStyles.Left
            };

            var lblMatricula = new Label
            {
                Text = "Matrícula:",
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(0, 0, 6, 0)
            };
            lblMatriculaValor = new Label
            {
                Text = "—",
                AutoSize = true,
                Anchor = AnchorStyles.Left
            };

            centerLayout.Controls.Add(lblEspecialidad, 0, 0);
            centerLayout.Controls.Add(lblEspecialidadValor, 1, 0);
            centerLayout.Controls.Add(lblMatricula, 0, 1);
            centerLayout.Controls.Add(lblMatriculaValor, 1, 1);

            // Abajo izquierda: versión
            lblVersionSistema = new Label
            {
                Text = "GestorAura v1.0",
                AutoSize = true,
                Anchor = AnchorStyles.Left
            };

            // Abajo derecha: fecha
            lblFechaHoy = new Label
            {
                Text = "—",
                AutoSize = true,
                Anchor = AnchorStyles.Right
            };

            // Agregar al layout header
            headerLayout.Controls.Add(lblNombreMedico, 0, 0);
            headerLayout.SetRowSpan(lblNombreMedico, 1);

            headerLayout.Controls.Add(centerLayout, 1, 0);
            headerLayout.Controls.Add(lblServidorValor, 2, 0);

            headerLayout.Controls.Add(lblVersionSistema, 0, 1);
            headerLayout.Controls.Add(lblFechaHoy, 2, 1);

            cardHeader.Controls.Add(headerLayout);

            // -------- CARD TURNOS --------
            cardTurnos = CrearCardPanel();
            var layoutTurnos = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            layoutTurnos.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
            layoutTurnos.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            var lblTurnosTitle = new Label
            {
                Text = "Turnos del día",
                AutoSize = true,
                Dock = DockStyle.Left,
                Font = new Font("Consolas", 11F, FontStyle.Bold),
                Padding = new Padding(4, 4, 0, 4)
            };

            dgvTurnos = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            layoutTurnos.Controls.Add(lblTurnosTitle, 0, 0);
            layoutTurnos.Controls.Add(dgvTurnos, 0, 1);
            cardTurnos.Controls.Add(layoutTurnos);

            // -------- CARD PACIENTES --------
            cardPacientes = CrearCardPanel();
            var layoutPacientes = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            layoutPacientes.RowStyles.Add(new RowStyle(SizeType.Absolute, 32f));
            layoutPacientes.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            var lblPacientesTitle = new Label
            {
                Text = "Pacientes",
                AutoSize = true,
                Dock = DockStyle.Left,
                Font = new Font("Consolas", 11F, FontStyle.Bold),
                Padding = new Padding(4, 4, 0, 4)
            };

            dgvPacientes = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            layoutPacientes.Controls.Add(lblPacientesTitle, 0, 0);
            layoutPacientes.Controls.Add(dgvPacientes, 0, 1);
            cardPacientes.Controls.Add(layoutPacientes);

            // -------- ADD CARDS TO MAIN --------
            layoutMain.Controls.Add(cardHeader, 0, 0);
            layoutMain.Controls.Add(cardTurnos, 0, 1);
            layoutMain.Controls.Add(cardPacientes, 0, 2);

            Controls.Add(layoutMain);
        }

        private Panel CrearCardPanel()
        {
            return new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 8, 0, 8),
                Padding = new Padding(12),
                BorderStyle = BorderStyle.FixedSingle
            };
        }

        // ============================================================
        // LOAD PRINCIPAL
        // ============================================================
        private void InicioMedico_Load(object? sender, EventArgs e)
        {
            try
            {
                CargarDatosMedico();
                MostrarInformacionGeneral();
                CargarTurnosDelDia();
                CargarPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inicio del médico:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // CARGA DE DATOS DEL MÉDICO (por ID de usuario)
        // ============================================================
        private void CargarDatosMedico()
        {
            try
            {
                if (IdUsuarioActual <= 0)
                {
                    lblNombreMedico.Text = string.IsNullOrWhiteSpace(NombreUsuario)
                        ? "Dr."
                        : $"Dr. {NombreUsuario}";

                    lblEspecialidadValor.Text = "—";
                    lblMatriculaValor.Text = "—";
                    lblServidorValor.Text = "⚠ ID inválido";
                    _nombreMedicoCompleto = NombreUsuario;
                    return;
                }

                Medico? medico = _medicoNegocio.ObtenerPorIdUsuario(IdUsuarioActual);

                if (medico == null)
                {
                    lblNombreMedico.Text = string.IsNullOrWhiteSpace(NombreUsuario)
                        ? "Dr."
                        : $"Dr. {NombreUsuario}";

                    lblEspecialidadValor.Text = "—";
                    lblMatriculaValor.Text = "—";
                    lblServidorValor.Text = "⚠ Sin datos en BD";
                    _nombreMedicoCompleto = NombreUsuario;
                    return;
                }

                // Nombre completo
                lblNombreMedico.Text = $"Dr. {medico.Nombre} {medico.Apellido}";
                _nombreMedicoCompleto = $"{medico.Apellido}, {medico.Nombre}";

                // Especialidad
                lblEspecialidadValor.Text = string.IsNullOrWhiteSpace(medico.Especialidad)
                    ? "—"
                    : medico.Especialidad;

                // Matrículas
                string matriculas = "—";
                if (!string.IsNullOrWhiteSpace(medico.MatriculaProvincial))
                    matriculas = $"Prov. {medico.MatriculaProvincial}";
                if (!string.IsNullOrWhiteSpace(medico.MatriculaNacional))
                {
                    if (matriculas != "—")
                        matriculas += " | ";
                    matriculas += $"Nac. {medico.MatriculaNacional}";
                }
                lblMatriculaValor.Text = matriculas;

                // Estado servidor
                lblServidorValor.Text = "● Activo";
            }
            catch (Exception ex)
            {
                lblNombreMedico.Text = string.IsNullOrWhiteSpace(NombreUsuario)
                    ? "Dr."
                    : $"Dr. {NombreUsuario}";

                lblEspecialidadValor.Text = "—";
                lblMatriculaValor.Text = "—";
                lblServidorValor.Text = "⚠ Error";

                MessageBox.Show("Error al obtener datos del médico:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // INFORMACIÓN GENERAL
        // ============================================================
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
                if (string.IsNullOrWhiteSpace(_nombreMedicoCompleto))
                    return;

                DataTable turnos = _turnoNegocio.ObtenerTurnosDelDiaPorNombre(
                    DateTime.Today,
                    _nombreMedicoCompleto
                );

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
                MessageBox.Show($"Error al cargar los turnos del día:\n{ex.Message}");
            }
        }

        // ============================================================
        // PACIENTES
        // ============================================================
        private void CargarPacientes()
        {
            try
            {
                dgvPacientes.DataSource = _pacienteNegocio.ObtenerListaSimple(true);
                ConfigurarGrilla(dgvPacientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la lista de pacientes:\n{ex.Message}");
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
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#eeeeee");
            dgv.EnableHeadersVisualStyles = false;
        }
    }
}

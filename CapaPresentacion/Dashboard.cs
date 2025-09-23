using System;
using System.Windows.Forms;
using CapaPresentacion.Controles;
using CapaPresentacion.Formularios;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario principal del sistema.
    /// Es un contenedor MDI que carga dinámicamente el menú lateral (sidebar)
    /// en función del rol del usuario que inició sesión.
    /// 
    /// Roles posibles:
    /// - administrador → AdminSidebar
    /// - medico → MedicoSidebar
    /// - secretaria → SecretariaSidebar
    /// </summary>
    public partial class Dashboard : Form
    {
        // Campo privado para almacenar el rol actual del usuario
        private readonly string _rolUsuario;

        /// <summary>
        /// Constructor principal.
        /// Recibe el rol del usuario logueado y carga el sidebar correspondiente.
        /// </summary>
        /// <param name="rolUsuario">Rol del usuario ("administrador", "medico", "secretaria").</param>
        public Dashboard(string rolUsuario)
        {
            InitializeComponent();

            // Guardamos el rol recibido
            _rolUsuario = rolUsuario;

            // Este formulario actúa como contenedor MDI
            this.IsMdiContainer = true;

            // Cargar el menú lateral según el rol del usuario
            CargarSidebar(_rolUsuario);
        }

        // ============================================================
        // MÉTODO: CargarSidebar
        // Se encarga de crear e insertar en el panel lateral el UserControl
        // correspondiente al rol actual (AdminSidebar, MedicoSidebar, SecretariaSidebar).
        // ============================================================
        private void CargarSidebar(string rol)
        {
            UserControl sidebar = null;

            switch (rol.ToLower())
            {
                case "administrador":
                    sidebar = new AdminSidebar();
                    ConfigurarEventosAdmin((AdminSidebar)sidebar);
                    break;

                case "medico":
                    sidebar = new MedicoSidebar();
                    ConfigurarEventosMedico((MedicoSidebar)sidebar);
                    break;

                case "secretaria":
                    sidebar = new SecretariaSidebar();
                    ConfigurarEventosSecretaria((SecretariaSidebar)sidebar);
                    break;

                default:
                    MessageBox.Show("Rol no reconocido. No se cargará el menú lateral.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Insertar el sidebar en el panel lateral
            sidebar.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(sidebar);
        }

        // ============================================================
        // MÉTODOS: ConfigurarEventos[Rol]
        // Cada uno conecta los botones del sidebar a formularios específicos
        // según el rol del usuario.
        // ============================================================

        /// <summary>
        /// Conecta los eventos del AdminSidebar con los formularios del administrador.
        /// </summary>
        private void ConfigurarEventosAdmin(AdminSidebar sidebar)
        {
            sidebar.BtnDashboardClick += (s, e) => MostrarForm(new FormDashboardAdmin());
            sidebar.BtnUsuariosClick += (s, e) => MostrarForm(new FormUsuarios());
            sidebar.BtnReportesClick += (s, e) => MostrarForm(new FormReportes());
            sidebar.BtnConfiguracionClick += (s, e) => MostrarForm(new FormConfiguracion());
            sidebar.BtnCerrarSesionClick += (s, e) => Application.Exit();
        }

        /// <summary>
        /// Conecta los eventos del MedicoSidebar con los formularios del médico.
        /// </summary>
        private void ConfigurarEventosMedico(MedicoSidebar sidebar)
        {
            sidebar.BtnDashboardClick += (s, e) => MostrarForm(new FormDashboardMedico());
            sidebar.BtnPacientesClick += (s, e) => MostrarForm(new FormPacientes());
            sidebar.BtnTurnosClick += (s, e) => MostrarForm(new FormTurnos());
            sidebar.BtnHistoriasClick += (s, e) => MostrarForm(new FormHC());
            sidebar.BtnCerrarSesionClick += (s, e) => Application.Exit();
        }

        /// <summary>
        /// Conecta los eventos del SecretariaSidebar con los formularios de la secretaria.
        /// </summary>
        private void ConfigurarEventosSecretaria(SecretariaSidebar sidebar)
        {
            sidebar.BtnDashboardClick += (s, e) => MostrarForm(new FormDashboardSecretaria());
            sidebar.BtnPacientesClick += (s, e) => MostrarForm(new FormPacientes());
            sidebar.BtnTurnosClick += (s, e) => MostrarForm(new FormTurnos());
            sidebar.BtnCerrarSesionClick += (s, e) => Application.Exit();
        }

        // ============================================================
        // MÉTODO AUXILIAR: MostrarForm
        // Abre un formulario como hijo MDI dentro del Dashboard.
        // Se asegura de que ocupe toda el área de trabajo.
        // ============================================================
        private void MostrarForm(Form form)
        {
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            form.ControlBox = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.Text = "";
            form.Dock = DockStyle.Fill;

            // Mostrar el formulario y traerlo al frente
            form.Show();
            form.BringToFront();
        }
    }
}

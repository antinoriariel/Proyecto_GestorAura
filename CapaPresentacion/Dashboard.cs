using System;
using System.Drawing;
using System.Windows.Forms;
using CapaPresentacion.Controles;
using CapaPresentacion.Formularios;

namespace CapaPresentacion
{
    /// <summary>
    /// Formulario principal del sistema.
    /// Es un contenedor MDI que carga dinámicamente el menú lateral (sidebar)
    /// en función del rol y nombre del usuario que inició sesión.
    /// 
    /// Roles posibles:
    /// - administrador → AdminSidebar
    /// - medico → MedicoSidebar
    /// - secretaria → SecretariaSidebar
    /// </summary>
    public partial class Dashboard : Form
    {
        // Campos privados para almacenar info del usuario
        private readonly string _rolUsuario;
        private readonly string _nombreUsuario;

        /// <summary>
        /// Constructor principal.
        /// Recibe el rol y nombre del usuario logueado y carga el sidebar correspondiente.
        /// </summary>
        /// <param name="rolUsuario">Rol del usuario ("administrador", "medico", "secretaria").</param>
        /// <param name="nombreUsuario">Nombre completo del usuario logueado.</param>
        public Dashboard(string rolUsuario, string nombreUsuario)
        {
            InitializeComponent();

            // Guardamos los datos recibidos
            _rolUsuario = rolUsuario;
            _nombreUsuario = nombreUsuario;

            // Este formulario actúa como contenedor MDI
            this.IsMdiContainer = true;

            // 🔹 Cambiar color del fondo del MDI
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient client)
                {
                    client.BackColor = ColorTranslator.FromHtml("#D7DADB"); // gris claro
                }
            }

            // Cargar el menú lateral según el rol del usuario
            CargarSidebar(_rolUsuario, _nombreUsuario);

            // 🔹 Configurar eventos de la barra superior
            navbarSuperior1.BtnCerrarSesionClick += (s, e) => Application.Exit();
            navbarSuperior1.BtnDarkModeClick += (s, e) =>
                MessageBox.Show("🌙 Cambiar a modo oscuro", "Info");
            navbarSuperior1.BtnNotificacionesClick += (s, e) =>
                MessageBox.Show("🔔 Notificaciones pendientes", "Info");
            navbarSuperior1.BtnAyudaClick += (s, e) =>
                MessageBox.Show("❓ Sección de ayuda", "Info");
        }

        // ============================================================
        // MÉTODO: CargarSidebar
        // ============================================================
        private void CargarSidebar(string rol, string nombreUsuario)
        {
            SidebarBase sidebar = null;

            switch (rol.ToLower())
            {
                case "administrador":
                    var adminSidebar = new AdminSidebar
                    {
                        Username = nombreUsuario,
                        RolUsuario = "Administrador"
                    };
                    adminSidebar.SetUserPanelImage(Properties.Resources.adminLogo);
                    ConfigurarEventosAdmin(adminSidebar);
                    sidebar = adminSidebar;
                    break;

                case "medico":
                    var medicoSidebar = new MedicoSidebar
                    {
                        Username = nombreUsuario,
                        RolUsuario = "Médico"
                    };
                    medicoSidebar.SetUserPanelImage(Properties.Resources.doctorLogo);
                    ConfigurarEventosMedico(medicoSidebar);
                    sidebar = medicoSidebar;
                    break;

                case "secretaria":
                    var secretariaSidebar = new SecretariaSidebar
                    {
                        Username = nombreUsuario,
                        RolUsuario = "Secretaria"
                    };
                    secretariaSidebar.SetUserPanelImage(Properties.Resources.secreLogo);
                    ConfigurarEventosSecretaria(secretariaSidebar);
                    sidebar = secretariaSidebar;
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
        // ============================================================

        private void ConfigurarEventosAdmin(AdminSidebar sidebar)
        {
            //sidebar.BtnDashboardClick += (s, e) => MostrarForm(new FormDashboardAdmin());
            //sidebar.BtnUsuariosClick += (s, e) => MostrarForm(new FormUsuarios());
            //sidebar.BtnReportesClick += (s, e) => MostrarForm(new FormReportes());
            //sidebar.BtnConfiguracionClick += (s, e) => MostrarForm(new FormConfiguracion());

            sidebar.BtnCerrarSesionClick += (s, e) => Application.Exit();
        }

        private void ConfigurarEventosMedico(MedicoSidebar sidebar)
        {
            //sidebar.BtnDashboardClick += (s, e) => MostrarForm(new FormDashboardMedico());
            //sidebar.BtnPacientesClick += (s, e) => MostrarForm(new FormPacientes());
            sidebar.BtnTurnosClick += (s, e) => MostrarForm(new FormTurnos());
            sidebar.BtnHistoriasClick += (s, e) => MostrarForm(new FormHC());
            sidebar.BtnCerrarSesionClick += (s, e) => Application.Exit();
        }

        private void ConfigurarEventosSecretaria(SecretariaSidebar sidebar)
        {
            //sidebar.BtnDashboardClick += (s, e) => MostrarForm(new FormDashboardSecretaria());
            //sidebar.BtnPacientesClick += (s, e) => MostrarForm(new FormPacientes());
            sidebar.BtnTurnosClick += (s, e) => MostrarForm(new FormTurnos());
            sidebar.BtnCerrarSesionClick += (s, e) => Application.Exit();
        }

        // ============================================================
        // MÉTODOS AUXILIARES
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

            form.Show();
            form.BringToFront();
        }

        private void MostrarFormUnico<T>() where T : Form, new()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is T)
                {
                    form.BringToFront();
                    form.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            T nuevoForm = new T
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                TopLevel = false
            };
            nuevoForm.Show();
            nuevoForm.BringToFront();
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics; // 👈 agregado
using CapaPresentacion.Controles;
using CapaPresentacion.Formularios;

namespace CapaPresentacion
{
    public partial class Dashboard : Form
    {
        private readonly string _rolUsuario;
        private readonly string _nombreUsuario;

        public Dashboard(string rolUsuario, string nombreUsuario)
        {
            InitializeComponent();

            _rolUsuario = rolUsuario;
            _nombreUsuario = nombreUsuario;

            this.IsMdiContainer = true;

            // 🔹 Color de fondo MDI
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient client)
                {
                    client.BackColor = ColorTranslator.FromHtml("#D7DADB");
                }
            }

            // Cargar sidebar según rol
            CargarSidebar(_rolUsuario, _nombreUsuario);

            // 🔹 Eventos navbar superior
            navbarSuperior1.BtnCambiarUserClick += (s, e) => VolverALogin();

            navbarSuperior1.BtnDarkModeClick += (s, e) =>
                MessageBox.Show("🌙 Cambiar a modo oscuro", "Info");

            navbarSuperior1.BtnNotificacionesClick += (s, e) =>
                MessageBox.Show("🔔 Notificaciones pendientes", "Info");

            navbarSuperior1.BtnAyudaClick += (s, e) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://github.com/antinoriariel/Proyecto_GestorAura",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir la página de ayuda: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // 👉 Si el usuario es administrador, cargar InicioAdmin automáticamente
            if (_rolUsuario.Equals("administrador", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioAdmin>();
            else if (_rolUsuario.Equals("medico", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioMedico>();
            else if (_rolUsuario.Equals("secretaria", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioSecre>();
        }

        // ============================================================
        // Método auxiliar: volver al login sin cerrar la app
        // ============================================================
        private void VolverALogin()
        {
            var login = new Login
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            // Cuando el login se cierre, cerramos también el dashboard
            login.FormClosed += (s, args) => this.Close();

            this.Hide();
            login.Show();
        }

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

            sidebar.Dock = DockStyle.Fill;
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(sidebar);
        }

        // ========== ADMIN ==========
        private void ConfigurarEventosAdmin(AdminSidebar sidebar)
        {
            sidebar.BtnCerrarSesionClick += (s, e) => VolverALogin();

            // 🔹 Inicio
            sidebar.BtnDashboardClick += (s, e) => MostrarFormUnico<InicioAdmin>();

            // 🔹 Usuarios
            sidebar.BtnUsuariosClick += (s, e) => MostrarFormUnico<FormCargaUsuarios>();
        }

        // ========== MÉDICO ==========
        private void ConfigurarEventosMedico(MedicoSidebar sidebar)
        {
            sidebar.BtnCerrarSesionClick += (s, e) => VolverALogin();

            // 🔹 Inicio
            sidebar.BtnDashboardClick += (s, e) => MostrarFormUnico<InicioMedico>();

            sidebar.BtnTurnosClick += (s, e) => MostrarForm(new FormTurnos());
            sidebar.BtnHistoriasClick += (s, e) => MostrarForm(new FormHC());
        }

        // ========== SECRETARIA ==========
        private void ConfigurarEventosSecretaria(SecretariaSidebar sidebar)
        {
            sidebar.BtnCerrarSesionClick += (s, e) => VolverALogin();

            // 🔹 Inicio
            sidebar.BtnDashboardClick += (s, e) => MostrarFormUnico<InicioSecre>();

            sidebar.BtnTurnosClick += (s, e) => MostrarForm(new FormTurnos());
        }

        // ============================================================
        // Helpers para mostrar formularios
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

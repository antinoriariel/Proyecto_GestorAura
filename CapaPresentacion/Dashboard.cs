using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaPresentacion.Controles;
using CapaPresentacion.Formularios;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Dashboard : Form
    {
        private readonly string rolUsuario;
        private readonly string nombreCompleto;
        private readonly string username; // nombre real de usuario

        public Dashboard(string rolUsuario, string nombreCompleto, string username)
        {
            InitializeComponent();

            this.rolUsuario = rolUsuario;
            this.nombreCompleto = nombreCompleto;
            this.username = username;

            this.IsMdiContainer = true;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient client)
                    client.BackColor = ColorTranslator.FromHtml("#D7DADB");
            }

            CargarSidebar(rolUsuario, nombreCompleto);

            navbarSuperior1.BtnCambiarUserClick += (s, e) => VolverALogin();
            navbarSuperior1.BtnDarkModeClick += (s, e) =>
                MessageBox.Show("🌙 Cambiar a modo oscuro (pendiente)", "Info");
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

            // Abrir formulario inicial según rol
            if (rolUsuario.Equals("administrador", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioAdmin>();
            else if (rolUsuario.Equals("medico", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioMedico>();
            else if (rolUsuario.Equals("secretaria", StringComparison.OrdinalIgnoreCase))
                AbrirInicioSecretaria();
        }

        private void VolverALogin()
        {
            var login = new Login
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            login.Show();
            this.Close();
        }

        private void CargarSidebar(string rol, string nombre)
        {
            SidebarBase sidebar = null;

            switch (rol.ToLower())
            {
                case "administrador":
                    var adminSidebar = new AdminSidebar
                    {
                        Username = nombre,
                        RolUsuario = "Administrador"
                    };
                    adminSidebar.SetUserPanelImage(Properties.Resources.adminLogo);
                    ConfigurarEventosAdmin(adminSidebar);
                    sidebar = adminSidebar;
                    break;

                case "medico":
                    var medicoSidebar = new MedicoSidebar
                    {
                        Username = nombre,
                        RolUsuario = "Médico"
                    };
                    medicoSidebar.SetUserPanelImage(Properties.Resources.doctorLogo);
                    ConfigurarEventosMedico(medicoSidebar);
                    sidebar = medicoSidebar;
                    break;

                case "secretaria":
                    var secreSidebar = new SecretariaSidebar
                    {
                        Username = nombre,
                        RolUsuario = "Secretaria"
                    };
                    secreSidebar.SetUserPanelImage(Properties.Resources.secreLogo);
                    ConfigurarEventosSecretaria(secreSidebar);
                    sidebar = secreSidebar;
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

        // ============================================================
        // EVENTOS SIDEBAR - ADMIN
        // ============================================================
        private void ConfigurarEventosAdmin(AdminSidebar sidebar)
        {
            sidebar.BtnCerrarSesionClick += (s, e) => VolverALogin();
            sidebar.BtnDashboardClick += (s, e) => MostrarFormUnico<InicioAdmin>();
            sidebar.BtnUsuariosClick += (s, e) => MostrarFormUnico<FormCargaUsuarios>();
            sidebar.BtnMedicosClick += (s, e) => MostrarFormUnico<FormMedicos>();
            sidebar.BtnPacientesClick += (s, e) => MostrarFormUnico<FormInternados>();
            sidebar.BtnBackupClick += (s, e) => MostrarFormUnico<FormBackup>();
            sidebar.BtnConfiguracionClick += (s, e) =>
                MessageBox.Show("⚙️ Configuración en desarrollo.", "Info");
        }

        // ============================================================
        // EVENTOS SIDEBAR - MÉDICO
        // ============================================================
        private void ConfigurarEventosMedico(MedicoSidebar sidebar)
        {
            sidebar.BtnCerrarSesionClick += (s, e) => VolverALogin();
            sidebar.BtnDashboardClick += (s, e) => MostrarFormUnico<InicioMedico>();
            sidebar.BtnTurnosClick += (s, e) => MostrarFormUnico<FormTurnosSecretaria>();

            // ✅ Corrección: pasar el ID real del médico a FormHC
            sidebar.BtnHistoriasClick += (s, e) =>
            {
                int idUsuario = ObtenerIdUsuarioActual();
                if (idUsuario == 0)
                {
                    MessageBox.Show("No se pudo obtener el ID del usuario médico.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear y abrir FormHC con el ID real
                var formHC = new FormHC { IdUsuarioActual = idUsuario };
                MostrarFormUnico(formHC);
            };

            sidebar.BtnSolicitudesClick += (s, e) => MostrarFormUnico<FormSolicitudes>();
            sidebar.BtnResultadosClick += (s, e) => MostrarFormUnico<FormResultados>();
            sidebar.BtnMensajesClick += (s, e) =>
            {
                int idUsuario = ObtenerIdUsuarioActual();
                MostrarFormUnico<FormMensajes>(idUsuario, rolUsuario);
            };
        }

        // ============================================================
        // EVENTOS SIDEBAR - SECRETARIA
        // ============================================================
        private void ConfigurarEventosSecretaria(SecretariaSidebar sidebar)
        {
            sidebar.BtnCerrarSesionClick += (s, e) => VolverALogin();
            sidebar.BtnDashboardClick += (s, e) => AbrirInicioSecretaria();
            sidebar.BtnTurnosClick += (s, e) => MostrarFormUnico<FormTurnosSecretaria>();
            sidebar.BtnPacientesClick += (s, e) => MostrarFormUnico<FormPacientesSecretaria>();
            sidebar.BtnNotasClick += (s, e) =>
            {
                int idSecretaria = ObtenerIdSecretariaLogueada();
                MostrarFormUnico<FormNotas>(idSecretaria);
            };
            sidebar.BtnMensajesClick += (s, e) =>
            {
                int idUsuario = ObtenerIdUsuarioActual();
                MostrarFormUnico<FormMensajes>(idUsuario, rolUsuario);
            };
        }

        // ============================================================
        // MÉTODO GENERALIZADO - MDI PARAMETRIZADO
        // ============================================================
        private void MostrarFormUnico<T>(params object[] args) where T : Form
        {
            var existente = MdiChildren.OfType<T>().FirstOrDefault();
            if (existente != null)
            {
                existente.BringToFront();
                existente.WindowState = FormWindowState.Normal;
                return;
            }

            Form nuevoForm;
            try
            {
                nuevoForm = (Form)Activator.CreateInstance(typeof(T), args);
            }
            catch (MissingMethodException)
            {
                nuevoForm = (Form)Activator.CreateInstance(typeof(T));
            }

            nuevoForm.MdiParent = this;
            nuevoForm.FormBorderStyle = FormBorderStyle.None;
            nuevoForm.Dock = DockStyle.Fill;
            nuevoForm.TopLevel = false;
            nuevoForm.Show();
            nuevoForm.BringToFront();
        }

        // ✅ Nueva sobrecarga para instancias ya creadas
        private void MostrarFormUnico(Form form)
        {
            var existente = MdiChildren.FirstOrDefault(f => f.GetType() == form.GetType());
            if (existente != null)
            {
                existente.BringToFront();
                existente.WindowState = FormWindowState.Normal;
                return;
            }

            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.Show();
            form.BringToFront();
        }

        // ============================================================
        // PANEL DE SECRETARIA
        // ============================================================
        private void AbrirInicioSecretaria()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is InicioSecre)
                {
                    f.BringToFront();
                    f.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            InicioSecre formSecre = new InicioSecre
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
                TopLevel = false,
                NombreUsuario = username,
                RolUsuario = rolUsuario
            };
            formSecre.Show();
            formSecre.BringToFront();
        }

        // ============================================================
        // OBTENER ID USUARIO LOGUEADO
        // ============================================================
        private int ObtenerIdUsuarioActual()
        {
            try
            {
                var usuarioNegocio = new UsuarioNegocio();
                return usuarioNegocio.ObtenerIdPorUsername(username);
            }
            catch
            {
                MessageBox.Show("No se pudo obtener el ID del usuario logueado.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private int ObtenerIdSecretariaLogueada()
        {
            return ObtenerIdUsuarioActual();
        }
    }
}

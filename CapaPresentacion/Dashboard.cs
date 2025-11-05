using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using CapaPresentacion.Controles;
using CapaPresentacion.Formularios;

namespace CapaPresentacion
{
    public partial class Dashboard : Form
    {
        private readonly string rolUsuario;
        private readonly string nombreCompleto;
        private readonly string username; // 👈 nombre real de usuario (para consultas a BD)

        public Dashboard(string rolUsuario, string nombreCompleto, string username)
        {
            InitializeComponent();

            this.rolUsuario = rolUsuario;
            this.nombreCompleto = nombreCompleto;
            this.username = username;

            this.IsMdiContainer = true;

            // 🔹 Color de fondo del contenedor MDI
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient client)
                    client.BackColor = ColorTranslator.FromHtml("#D7DADB");
            }

            // 🔹 Cargar sidebar correspondiente
            CargarSidebar(rolUsuario, nombreCompleto);

            // 🔹 Eventos navbar superior
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

            // 🔹 Abrir formulario inicial según rol
            if (rolUsuario.Equals("administrador", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioAdmin>();
            else if (rolUsuario.Equals("medico", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioMedico>();
            else if (rolUsuario.Equals("secretaria", StringComparison.OrdinalIgnoreCase))
                AbrirInicioSecretaria();
        }

        // ============================================================
        // MÉTODOS AUXILIARES
        // ============================================================
        private void VolverALogin()
        {
            // Crear nuevo formulario de login
            var login = new Login
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            // Mostrarlo antes de cerrar el dashboard
            login.Show();

            // Cerrar el dashboard actual
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
            sidebar.BtnAuditoriaClick += (s, e) =>
                MessageBox.Show("ℹ️ Módulo de auditoría pendiente de integración.", "Info");
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
            sidebar.BtnTurnosClick += (s, e) => MostrarFormUnico<FormTurnosMedico>();
            sidebar.BtnHistoriasClick += (s, e) => MostrarFormUnico<FormHC>();
            sidebar.BtnSolicitudesClick += (s, e) => MostrarFormUnico<FormSolicitudes>();
            sidebar.BtnResultadosClick += (s, e) => MostrarFormUnico<FormResultados>();
            sidebar.BtnInterconsultasClick += (s, e) =>
                MessageBox.Show("🩺 Módulo de interconsultas en desarrollo.", "Info");
            sidebar.BtnRecetasClick += (s, e) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://rcta.me/",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir la página de recetas: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            sidebar.BtnMensajesClick += (s, e) => MostrarFormUnico<FormMensajes>();
        }

        // ============================================================
        // EVENTOS SIDEBAR - SECRETARIA
        // ============================================================
        private void ConfigurarEventosSecretaria(SecretariaSidebar sidebar)
        {
            sidebar.BtnCerrarSesionClick += (s, e) => VolverALogin();
            sidebar.BtnDashboardClick += (s, e) => AbrirInicioSecretaria();
            sidebar.BtnTurnosClick += (s, e) => MostrarFormUnico<FormTurnosMedico>();
            sidebar.BtnPacientesClick += (s, e) => MostrarFormUnico<FormPacientesSecretaria>();
            sidebar.BtnNotasClick += (s, e) => MostrarFormUnico<FormNotas>();
            sidebar.BtnMensajesClick += (s, e) => MostrarFormUnico<FormMensajes>();
        }

        // ============================================================
        // FORMULARIOS MDI
        // ============================================================
        private void MostrarFormUnico<T>() where T : Form, new()
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is T)
                {
                    f.BringToFront();
                    f.WindowState = FormWindowState.Normal;
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

        // ============================================================
        // PANEL DE SECRETARIA (INICIO PERSONALIZADO)
        // ============================================================
        private void AbrirInicioSecretaria()
        {
            // 🔹 Evita duplicados si ya está abierto
            foreach (Form f in this.MdiChildren)
            {
                if (f is InicioSecre)
                {
                    f.BringToFront();
                    f.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            // 🔹 Crea y muestra el formulario de secretaria con su usuario real
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
    }
}

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
        private readonly string _rolUsuario;
        private readonly string _nombreUsuario;

        public Dashboard(string rolUsuario, string nombreUsuario)
        {
            InitializeComponent();

            _rolUsuario = rolUsuario;
            _nombreUsuario = nombreUsuario;

            this.IsMdiContainer = true;

            // Color de fondo MDI
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient client)
                    client.BackColor = ColorTranslator.FromHtml("#D7DADB");
            }

            // Cargar sidebar según rol
            CargarSidebar(_rolUsuario, _nombreUsuario);

            // Eventos navbar superior
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

            // Mostrar pantalla inicial según rol
            if (_rolUsuario.Equals("administrador", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioAdmin>(f => f.Text = "Inicio Administrador");
            else if (_rolUsuario.Equals("medico", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioMedico>(f => f.Text = "Inicio Médico");
            else if (_rolUsuario.Equals("secretaria", StringComparison.OrdinalIgnoreCase))
                MostrarFormUnico<InicioSecre>(f => f.NombreUsuario = _nombreUsuario);
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
            sidebar.BtnDashboardClick += (s, e) => MostrarFormUnico<InicioAdmin>(f => { });
            sidebar.BtnUsuariosClick += (s, e) => MostrarFormUnico<FormCargaUsuarios>(f => { });
            sidebar.BtnMedicosClick += (s, e) => MostrarFormUnico<FormMedicos>(f => { });
            sidebar.BtnPacientesClick += (s, e) => MostrarFormUnico<FormInternados>(f => { });
            sidebar.BtnBackupClick += (s, e) => MostrarFormUnico<FormBackup>(f => { });
            sidebar.BtnAuditoriaClick += (s, e) =>
                MessageBox.Show("ℹ️ Requiere integración DB", "Auditoría");
            sidebar.BtnConfiguracionClick += (s, e) =>
                MessageBox.Show("ℹ️ Requiere integración DB", "Ajustes");
        }

        // ========== MÉDICO ==========
        private void ConfigurarEventosMedico(MedicoSidebar sidebar)
        {
            sidebar.BtnCerrarSesionClick += (s, e) => VolverALogin();
            sidebar.BtnDashboardClick += (s, e) => MostrarFormUnico<InicioMedico>(f => { });
            sidebar.BtnTurnosClick += (s, e) => MostrarFormUnico<FormTurnosMedico>(f => { });
            sidebar.BtnHistoriasClick += (s, e) => MostrarFormUnico<FormHC>(f => { });
            sidebar.BtnSolicitudesClick += (s, e) => MostrarFormUnico<FormSolicitudes>(f => { });
            sidebar.BtnResultadosClick += (s, e) => MostrarFormUnico<FormResultados>(f => { });
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
            sidebar.BtnMensajesClick += (s, e) => MostrarFormUnico<FormMensajes>(f => { });
        }

        // ========== SECRETARIA ==========
        private void ConfigurarEventosSecretaria(SecretariaSidebar sidebar)
        {
            sidebar.BtnCerrarSesionClick += (s, e) => VolverALogin();
            sidebar.BtnDashboardClick += (s, e) =>
                MostrarFormUnico<InicioSecre>(f => f.NombreUsuario = _nombreUsuario);
            sidebar.BtnTurnosClick += (s, e) => MostrarFormUnico<FormTurnosMedico>(f => { });
            sidebar.BtnPacientesClick += (s, e) => MostrarFormUnico<FormInternados>(f => { });
            sidebar.BtnNotasClick += (s, e) => MostrarFormUnico<FormNotas>(f => { });
            sidebar.BtnMensajesClick += (s, e) => MostrarFormUnico<FormMensajes>(f => { });
        }

        // ============================================================
        // Método genérico y sobrecargado para mostrar un único formulario MDI
        // ============================================================
        private void MostrarFormUnico<T>(Action<T> configurador) where T : Form, new()
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

            configurador?.Invoke(nuevoForm); // 🔹 permite pasar datos como NombreUsuario

            nuevoForm.Show();
            nuevoForm.BringToFront();
        }
    }
}

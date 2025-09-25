using System;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public class AdminSidebar : SidebarBase
    {
        private Button btnDashboard, btnUsuarios, btnReportes, btnConfiguracion, btnCerrarSesion;

        public AdminSidebar() : base() { }

        protected override void CrearBotones()
        {
            // Inicio
            btnDashboard = new Button { Text = "Inicio", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnDashboard.Image = Properties.Resources.inicioIcon;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;

            // Usuarios
            btnUsuarios = new Button { Text = "Usuarios", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnUsuarios.Image = Properties.Resources.usuarioIcon;
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;

            // Médicos
            btnReportes = new Button { Text = "Médicos", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnReportes.Image = Properties.Resources.medicoIcon;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;

            // Ajustes
            btnConfiguracion = new Button { Text = "Ajustes", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnConfiguracion.Image = Properties.Resources.ajustesIcon;
            btnConfiguracion.ImageAlign = ContentAlignment.MiddleLeft;

            // Salir
            btnCerrarSesion = new Button { Text = "Salir", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnCerrarSesion.Image = Properties.Resources.salidaIcon;
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;

            // Aplicar estilos
            AplicarEstiloBoton(btnDashboard);
            AplicarEstiloBoton(btnUsuarios);
            AplicarEstiloBoton(btnReportes);
            AplicarEstiloBoton(btnConfiguracion);
            AplicarEstiloBoton(btnCerrarSesion, true);

            // Eventos
            btnDashboard.Click += (s, e) => BtnDashboardClick?.Invoke(this, e);
            btnUsuarios.Click += (s, e) => BtnUsuariosClick?.Invoke(this, e);
            btnReportes.Click += (s, e) => BtnReportesClick?.Invoke(this, e);
            btnConfiguracion.Click += (s, e) => BtnConfiguracionClick?.Invoke(this, e);
            btnCerrarSesion.Click += (s, e) => BtnCerrarSesionClick?.Invoke(this, e);

            // Agregar al layout
            tableLayoutPanelMenu.Controls.Add(btnDashboard, 0, 2);
            tableLayoutPanelMenu.Controls.Add(btnUsuarios, 0, 3);
            tableLayoutPanelMenu.Controls.Add(btnReportes, 0, 4);
            tableLayoutPanelMenu.Controls.Add(btnConfiguracion, 0, 5);
            tableLayoutPanelMenu.Controls.Add(btnCerrarSesion, 0, 7);
        }

        // Eventos públicos
        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnUsuariosClick;
        public event EventHandler BtnReportesClick;
        public event EventHandler BtnConfiguracionClick;
        public event EventHandler BtnCerrarSesionClick;
    }
}

using System;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public class MedicoSidebar : SidebarBase
    {
        private Button btnDashboard, btnPacientes, btnTurnos, btnHistorias, btnCerrarSesion;

        public MedicoSidebar() : base() { }

        protected override void CrearBotones()
        {
            // Inicio
            btnDashboard = new Button { Text = "Inicio", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnDashboard.Image = Properties.Resources.inicioIcon;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;

            // Pacientes
            btnPacientes = new Button { Text = "Pacientes", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnPacientes.Image = Properties.Resources.pacienteIcon;
            btnPacientes.ImageAlign = ContentAlignment.MiddleLeft;

            // Turnos
            btnTurnos = new Button { Text = "Turnos", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnTurnos.Image = Properties.Resources.turnosIcon;
            btnTurnos.ImageAlign = ContentAlignment.MiddleLeft;

            // Historias clínicas
            btnHistorias = new Button { Text = "Historias", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnHistorias.Image = Properties.Resources.hcIcon;
            btnHistorias.ImageAlign = ContentAlignment.MiddleLeft;

            // Salir
            btnCerrarSesion = new Button { Text = "Salir", Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 0) };
            btnCerrarSesion.Image = Properties.Resources.salidaIcon;
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;

            // Estilos
            AplicarEstiloBoton(btnDashboard);
            AplicarEstiloBoton(btnPacientes);
            AplicarEstiloBoton(btnTurnos);
            AplicarEstiloBoton(btnHistorias);
            AplicarEstiloBoton(btnCerrarSesion, true);

            // Eventos
            btnDashboard.Click += (s, e) => BtnDashboardClick?.Invoke(this, e);
            btnPacientes.Click += (s, e) => BtnPacientesClick?.Invoke(this, e);
            btnTurnos.Click += (s, e) => BtnTurnosClick?.Invoke(this, e);
            btnHistorias.Click += (s, e) => BtnHistoriasClick?.Invoke(this, e);
            btnCerrarSesion.Click += (s, e) => BtnCerrarSesionClick?.Invoke(this, e);

            // Insertar al layout
            tableLayoutPanelMenu.Controls.Add(btnDashboard, 0, 2);
            tableLayoutPanelMenu.Controls.Add(btnPacientes, 0, 3);
            tableLayoutPanelMenu.Controls.Add(btnTurnos, 0, 4);
            tableLayoutPanelMenu.Controls.Add(btnHistorias, 0, 5);
            tableLayoutPanelMenu.Controls.Add(btnCerrarSesion, 0, 7);
        }

        // Eventos públicos
        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnPacientesClick;
        public event EventHandler BtnTurnosClick;
        public event EventHandler BtnHistoriasClick;
        public event EventHandler BtnCerrarSesionClick;
    }
}

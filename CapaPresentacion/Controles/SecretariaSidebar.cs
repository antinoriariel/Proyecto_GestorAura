using System;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public class SecretariaSidebar : SidebarBase
    {
        private Button btnDashboard, btnPacientes, btnTurnos;

        public SecretariaSidebar() : base() { }

        protected override void CrearBotones()
        {
            btnDashboard = CrearBotonBase("Inicio", Properties.Resources.inicioIcon);
            btnPacientes = CrearBotonBase("Pacientes", Properties.Resources.pacienteIcon);
            btnTurnos = CrearBotonBase("Turnos", Properties.Resources.turnosIcon);

            btnDashboard.Click += (s, e) => BtnDashboardClick?.Invoke(this, e);
            btnPacientes.Click += (s, e) => BtnPacientesClick?.Invoke(this, e);
            btnTurnos.Click += (s, e) => BtnTurnosClick?.Invoke(this, e);

            AgregarBoton(btnDashboard);
            AgregarBoton(btnPacientes);
            AgregarBoton(btnTurnos);
        }

        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnPacientesClick;
        public event EventHandler BtnTurnosClick;
    }
}

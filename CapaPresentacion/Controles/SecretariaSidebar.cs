using System;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public class SecretariaSidebar : SidebarBase
    {
        private Button btnDashboard, btnPacientes, btnTurnos;
        private Button btnAgendaSemanal, btnNotas, btnMensajes;

        public SecretariaSidebar() : base() { }

        protected override void CrearBotones()
        {
            btnDashboard = CrearBotonBase("Inicio", Properties.Resources.inicioIcon);
            btnPacientes = CrearBotonBase("Pacientes", Properties.Resources.pacienteIcon);
            btnTurnos = CrearBotonBase("Turnos", Properties.Resources.turnosIcon);
            //btnAgendaSemanal = CrearBotonBase("xxxx", Properties.Resources.turnosIcon);
            btnNotas = CrearBotonBase("Notas", Properties.Resources.notaIcon);
            btnMensajes = CrearBotonBase("Mensajes", Properties.Resources.mensajeIcon);

            btnDashboard.Click += (s, e) => BtnDashboardClick?.Invoke(this, e);
            btnPacientes.Click += (s, e) => BtnPacientesClick?.Invoke(this, e);
            btnTurnos.Click += (s, e) => BtnTurnosClick?.Invoke(this, e);
            //btnAgendaSemanal.Click += (s, e) => BtnAgendaSemanalClick?.Invoke(this, e);
            btnNotas.Click += (s, e) => BtnNotasClick?.Invoke(this, e);
            btnMensajes.Click += (s, e) => BtnMensajesClick?.Invoke(this, e);

            AgregarBoton(btnDashboard);
            AgregarBoton(btnPacientes);
            AgregarBoton(btnTurnos);
            //AgregarBoton(btnAgendaSemanal);
            AgregarBoton(btnNotas);
            AgregarBoton(btnMensajes);
        }

        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnPacientesClick;
        public event EventHandler BtnTurnosClick;
        //public event EventHandler BtnAgendaSemanalClick;
        public event EventHandler BtnNotasClick;
        public event EventHandler BtnMensajesClick;
    }
}

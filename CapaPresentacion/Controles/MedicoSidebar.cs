using System;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public class MedicoSidebar : SidebarBase
    {
        private Button btnDashboard, btnPacientes, btnTurnos, btnHistorias;
        private Button btnInterconsultas, btnRecetas, btnSolicitudes, btnResultados, btnMensajes;

        public MedicoSidebar() : base() { }

        protected override void CrearBotones()
        {
            btnDashboard = CrearBotonBase("Inicio", Properties.Resources.inicioIcon);
            btnPacientes = CrearBotonBase("Pacientes", Properties.Resources.pacienteIcon);
            btnTurnos = CrearBotonBase("Turnos", Properties.Resources.turnosIcon);
            btnHistorias = CrearBotonBase("Historias", Properties.Resources.hcIcon);
            btnInterconsultas = CrearBotonBase("Intercons.", Properties.Resources.interconsultaIcon);
            btnRecetas = CrearBotonBase("Recetas", Properties.Resources.recetaIcon);
            btnSolicitudes = CrearBotonBase("Solicitudes", Properties.Resources.solicitudIcon);
            btnResultados = CrearBotonBase("Resultados", Properties.Resources.resultadoIcon);
            btnMensajes = CrearBotonBase("Mensajes", Properties.Resources.mensajeIcon);

            btnDashboard.Click += (s, e) => BtnDashboardClick?.Invoke(this, e);
            btnPacientes.Click += (s, e) => BtnPacientesClick?.Invoke(this, e);
            btnTurnos.Click += (s, e) => BtnTurnosClick?.Invoke(this, e);
            btnHistorias.Click += (s, e) => BtnHistoriasClick?.Invoke(this, e);
            btnInterconsultas.Click += (s, e) => BtnInterconsultasClick?.Invoke(this, e);
            btnRecetas.Click += (s, e) => BtnRecetasClick?.Invoke(this, e);
            btnSolicitudes.Click += (s, e) => BtnSolicitudesClick?.Invoke(this, e);
            btnResultados.Click += (s, e) => BtnResultadosClick?.Invoke(this, e);
            btnMensajes.Click += (s, e) => BtnMensajesClick?.Invoke(this, e);

            AgregarBoton(btnDashboard);
            AgregarBoton(btnPacientes);
            AgregarBoton(btnTurnos);
            AgregarBoton(btnHistorias);
            AgregarBoton(btnInterconsultas);
            AgregarBoton(btnRecetas);
            AgregarBoton(btnSolicitudes);
            AgregarBoton(btnResultados);
            AgregarBoton(btnMensajes);
        }

        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnPacientesClick;
        public event EventHandler BtnTurnosClick;
        public event EventHandler BtnHistoriasClick;
        public event EventHandler BtnInterconsultasClick;
        public event EventHandler BtnRecetasClick;
        public event EventHandler BtnSolicitudesClick;
        public event EventHandler BtnResultadosClick;
        public event EventHandler BtnMensajesClick;
    }
}

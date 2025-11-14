using System;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public class AdminSidebar : SidebarBase
    {
        private Button btnDashboard, btnUsuarios, btnMedicos, btnPacientes, btnTurnos;
        private Button btnListadoUsuarios;
        private Button btnBackup, btnConfiguracion;
        private Button btnPrueba;

        public AdminSidebar() : base() { }

        protected override void CrearBotones()
        {
            btnDashboard = CrearBotonBase("Inicio", Properties.Resources.inicioIcon);
            btnUsuarios = CrearBotonBase("Usuarios", Properties.Resources.usuarioIcon);
            btnListadoUsuarios = CrearBotonBase("Listado usuarios", Properties.Resources.usuarioIcon);
            btnMedicos = CrearBotonBase("Médicos", Properties.Resources.medicoIcon);
            btnPacientes = CrearBotonBase("Pacientes", Properties.Resources.pacienteIcon);
            //btnTurnos        = CrearBotonBase("Turnos",             Properties.Resources.turnosIcon);
            btnBackup = CrearBotonBase("Backup", Properties.Resources.backupdbIcon);
            btnConfiguracion = CrearBotonBase("Ajustes", Properties.Resources.ajustesIcon);

            // Eventos expuestos
            btnDashboard.Click += (s, e) => BtnDashboardClick?.Invoke(this, e);
            btnUsuarios.Click += (s, e) => BtnUsuariosClick?.Invoke(this, e);
            btnListadoUsuarios.Click += (s, e) => BtnListadoUsuariosClick?.Invoke(this, e);
            btnMedicos.Click += (s, e) => BtnMedicosClick?.Invoke(this, e);
            btnPacientes.Click += (s, e) => BtnPacientesClick?.Invoke(this, e);
            //btnTurnos.Click        += (s, e) => BtnTurnosClick?.Invoke(this, e);
            btnBackup.Click += (s, e) => BtnBackupClick?.Invoke(this, e);
            btnConfiguracion.Click += (s, e) => BtnConfiguracionClick?.Invoke(this, e);

            // Agregar al contenedor de botones (orden en el menú)
            AgregarBoton(btnDashboard);
            AgregarBoton(btnUsuarios);
            AgregarBoton(btnListadoUsuarios);
            AgregarBoton(btnMedicos);
            AgregarBoton(btnPacientes);
            //AgregarBoton(btnTurnos);
            AgregarBoton(btnBackup);
            AgregarBoton(btnConfiguracion);
        }

        // Eventos públicos
        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnUsuariosClick;
        public event EventHandler BtnListadoUsuariosClick;
        public event EventHandler BtnMedicosClick;
        public event EventHandler BtnPacientesClick;
        //public event EventHandler BtnTurnosClick;
        public event EventHandler BtnBackupClick;
        public event EventHandler BtnConfiguracionClick;

        // Nota: BtnCerrarSesionClick lo expone seguramente SidebarBase;
        // por eso no lo redefinimos acá, solo lo usás desde el Dashboard.
    }
}

using System;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public class AdminSidebar : SidebarBase
    {
        private Button btnDashboard, btnUsuarios, btnMedicos, btnPacientes, btnTurnos;
        private Button btnReportes, btnReportesAvanzados, btnAuditoria, btnBackup, btnConfiguracion;

        public AdminSidebar() : base() { }

        protected override void CrearBotones()
        {
            btnDashboard = CrearBotonBase("Inicio", Properties.Resources.inicioIcon);
            btnUsuarios = CrearBotonBase("Usuarios", Properties.Resources.usuarioIcon);
            btnMedicos = CrearBotonBase("Médicos", Properties.Resources.medicoIcon);
            btnPacientes = CrearBotonBase("Pacientes", Properties.Resources.pacienteIcon);
            btnTurnos = CrearBotonBase("Turnos", Properties.Resources.turnosIcon);
            btnReportes = CrearBotonBase("Reportes", Properties.Resources.ajustesIcon);
            btnReportesAvanzados = CrearBotonBase("Reportes Avanzados", Properties.Resources.ajustesIcon);
            btnAuditoria = CrearBotonBase("Auditoría", Properties.Resources.ajustesIcon);
            btnBackup = CrearBotonBase("Backup", Properties.Resources.ajustesIcon);
            btnConfiguracion = CrearBotonBase("Ajustes", Properties.Resources.ajustesIcon);

            // Eventos expuestos
            btnDashboard.Click += (s, e) => BtnDashboardClick?.Invoke(this, e);
            btnUsuarios.Click += (s, e) => BtnUsuariosClick?.Invoke(this, e);
            btnMedicos.Click += (s, e) => BtnMedicosClick?.Invoke(this, e);
            btnPacientes.Click += (s, e) => BtnPacientesClick?.Invoke(this, e);
            btnTurnos.Click += (s, e) => BtnTurnosClick?.Invoke(this, e);
            btnReportes.Click += (s, e) => BtnReportesClick?.Invoke(this, e);
            btnReportesAvanzados.Click += (s, e) => BtnReportesAvanzadosClick?.Invoke(this, e);
            btnAuditoria.Click += (s, e) => BtnAuditoriaClick?.Invoke(this, e);
            btnBackup.Click += (s, e) => BtnBackupClick?.Invoke(this, e);
            btnConfiguracion.Click += (s, e) => BtnConfiguracionClick?.Invoke(this, e);

            // Agregar al contenedor de botones
            AgregarBoton(btnDashboard);
            AgregarBoton(btnUsuarios);
            AgregarBoton(btnMedicos);
            AgregarBoton(btnPacientes);
            AgregarBoton(btnTurnos);
            AgregarBoton(btnReportes);
            AgregarBoton(btnReportesAvanzados);
            AgregarBoton(btnAuditoria);
            AgregarBoton(btnBackup);
            AgregarBoton(btnConfiguracion);
        }

        // Eventos públicos
        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnUsuariosClick;
        public event EventHandler BtnMedicosClick;
        public event EventHandler BtnPacientesClick;
        public event EventHandler BtnTurnosClick;
        public event EventHandler BtnReportesClick;
        public event EventHandler BtnReportesAvanzadosClick;
        public event EventHandler BtnAuditoriaClick;
        public event EventHandler BtnBackupClick;
        public event EventHandler BtnConfiguracionClick;
    }
}

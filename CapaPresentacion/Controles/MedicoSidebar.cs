using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public class MedicoSidebar : SidebarBase
    {
        private Button btnDashboard, btnPacientes, btnTurnos, btnHistorias;
        private Button btnHC;
        private Button btnRecetas, btnAdjuntos, btnMensajes;

        public MedicoSidebar() : base() { }

        protected override void CrearBotones()
        {
            btnDashboard = CrearBotonBase("Inicio", Properties.Resources.inicioIcon);
            btnPacientes = CrearBotonBase("Pacientes", Properties.Resources.pacienteIcon);
            btnTurnos = CrearBotonBase("Turnos", Properties.Resources.turnosIcon);
            btnHistorias = CrearBotonBase("Crear HC", Properties.Resources.hcIcon);
            btnHC = CrearBotonBase("Historias Clínicas", Properties.Resources.hcIcon);
            btnRecetas = CrearBotonBase("Recetas", Properties.Resources.recetaIcon);
            btnAdjuntos = CrearBotonBase("Adjuntos", Properties.Resources.resultadoIcon);
            btnMensajes = CrearBotonBase("Mensajes", Properties.Resources.mensajeIcon);

            // === Asignación de eventos ===
            btnDashboard.Click += (s, e) => BtnDashboardClick?.Invoke(this, e);
            btnPacientes.Click += (s, e) => BtnPacientesClick?.Invoke(this, e);
            btnTurnos.Click += (s, e) => BtnTurnosClick?.Invoke(this, e);
            btnHistorias.Click += (s, e) => BtnHistoriasClick?.Invoke(this, e);
            btnHC.Click += (s, e) => BtnHCClick?.Invoke(this, e);

            // 🔹 Botón Recetas: abrir enlace externo
            btnRecetas.Click += (s, e) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://rcta.me",
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo abrir el enlace.\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnAdjuntos.Click += (s, e) => BtnAdjuntosClick?.Invoke(this, e);
            btnMensajes.Click += (s, e) => BtnMensajesClick?.Invoke(this, e);

            // === Agregar al panel del SidebarBase ===
            AgregarBoton(btnDashboard);
            AgregarBoton(btnPacientes);
            AgregarBoton(btnTurnos);
            AgregarBoton(btnHistorias);
            AgregarBoton(btnHC);
            AgregarBoton(btnRecetas);
            AgregarBoton(btnAdjuntos);
            AgregarBoton(btnMensajes);
        }

        // ==== Eventos públicos expuestos ====
        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnPacientesClick;
        public event EventHandler BtnTurnosClick;
        public event EventHandler BtnHistoriasClick;
        public event EventHandler BtnAdjuntosClick;
        public event EventHandler BtnMensajesClick;
        public event EventHandler BtnHCClick;
    }
}

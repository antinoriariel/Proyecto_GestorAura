using System;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class MenuLateral : UserControl
    {
        public MenuLateral()
        {
            InitializeComponent();
        }

        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnPacientesClick;
        public event EventHandler BtnTurnosClick;
        public event EventHandler BtnHistoriasClick;
        public event EventHandler BtnCerrarSesionClick;

        private void btnDashboard_Click(object sender, EventArgs e) => BtnDashboardClick?.Invoke(this, e);
        private void btnPacientes_Click(object sender, EventArgs e) => BtnPacientesClick?.Invoke(this, e);
        private void btnTurnos_Click(object sender, EventArgs e) => BtnTurnosClick?.Invoke(this, e);
        private void btnHistorias_Click(object sender, EventArgs e) => BtnHistoriasClick?.Invoke(this, e);
        private void btnCerrarSesion_Click(object sender, EventArgs e) => BtnCerrarSesionClick?.Invoke(this, e);
    }
}

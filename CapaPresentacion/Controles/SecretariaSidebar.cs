using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class SecretariaSidebar : UserControl
    {
        public SecretariaSidebar()
        {
            InitializeComponent();

            foreach (Control ctrl in tableLayoutPanelMenu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.LightSeaGreen;
                    btn.ForeColor = Color.White;

                    btn.MouseEnter += (s, e) => btn.BackColor = Color.Teal;
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.LightSeaGreen;
                }
            }
        }

        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnPacientesClick;
        public event EventHandler BtnTurnosClick;
        public event EventHandler BtnCerrarSesionClick;

        private void btnDashboard_Click(object sender, EventArgs e) => BtnDashboardClick?.Invoke(this, e);
        private void btnPacientes_Click(object sender, EventArgs e) => BtnPacientesClick?.Invoke(this, e);
        private void btnTurnos_Click(object sender, EventArgs e) => BtnTurnosClick?.Invoke(this, e);
        private void btnCerrarSesion_Click(object sender, EventArgs e) => BtnCerrarSesionClick?.Invoke(this, e);
    }
}
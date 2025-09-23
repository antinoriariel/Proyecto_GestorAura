using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class AdminSidebar : UserControl
    {
        public AdminSidebar()
        {
            InitializeComponent();

            // Aplicar hover a todos los botones
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

        // Eventos públicos
        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnUsuariosClick;
        public event EventHandler BtnReportesClick;
        public event EventHandler BtnConfiguracionClick;
        public event EventHandler BtnCerrarSesionClick;

        // Métodos privados que disparan eventos
        private void btnDashboard_Click(object sender, EventArgs e)
            => BtnDashboardClick?.Invoke(this, e);

        private void btnUsuarios_Click(object sender, EventArgs e)
            => BtnUsuariosClick?.Invoke(this, e);

        private void btnReportes_Click(object sender, EventArgs e)
            => BtnReportesClick?.Invoke(this, e);

        private void btnConfiguracion_Click(object sender, EventArgs e)
            => BtnConfiguracionClick?.Invoke(this, e);

        private void btnCerrarSesion_Click(object sender, EventArgs e)
            => BtnCerrarSesionClick?.Invoke(this, e);
    }
}

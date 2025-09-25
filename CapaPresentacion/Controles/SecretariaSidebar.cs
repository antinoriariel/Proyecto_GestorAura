using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public partial class SecretariaSidebar : UserControl
    {
        public SecretariaSidebar()
        {
            InitializeComponent();

            // Estilizar userPanel
            userPanel.BackColor = Color.White;
            lblRolUsuario.ForeColor = Color.Black;

            // Estilo moderno a botones
            foreach (Control ctrl in tableLayoutPanelMenu.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = Color.Black;
                    btn.Font = new Font("Lucida Console", 9F, FontStyle.Bold);

                    if (btn == btnCerrarSesion)
                    {
                        btn.BackColor = ColorTranslator.FromHtml("#f0331f");
                        btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#C0392B");
                        btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#f0331f");
                    }
                    else
                    {
                        btn.BackColor = ColorTranslator.FromHtml("#27d9cf");
                        btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#1FA29C");
                        btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#27d9cf");
                    }

                    // Bordes redondeados en botones
                    btn.Paint += (s, e) =>
                    {
                        int radio = 15;
                        Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);

                        using (GraphicsPath path = new GraphicsPath())
                        {
                            path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                            path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                            path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                            path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                            path.CloseAllFigures();

                            btn.Region = new Region(path);

                            using (Pen pen = new Pen(Color.FromArgb(50, 0, 0, 0), 2))
                            {
                                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                e.Graphics.DrawPath(pen, path);
                            }
                        }
                    };
                }
            }

            // 🔹 Bordes redondeados al userPanel
            userPanel.Paint += (s, e) =>
            {
                int radio = 20;
                Rectangle rect = new Rectangle(0, 0, userPanel.Width, userPanel.Height);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                    path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                    path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                    path.CloseAllFigures();

                    userPanel.Region = new Region(path);
                }
            };
        }

        // Eventos públicos
        public event EventHandler BtnDashboardClick;
        public event EventHandler BtnPacientesClick;
        public event EventHandler BtnTurnosClick;
        public event EventHandler BtnCerrarSesionClick;

        // Propiedades
        public string Username
        {
            get => lblUsername.Text;
            set => lblUsername.Text = value;
        }

        public string RolUsuario
        {
            get => lblRolUsuario.Text;
            set => lblRolUsuario.Text = value;
        }

        // Métodos privados
        private void btnDashboard_Click(object sender, EventArgs e) => BtnDashboardClick?.Invoke(this, e);
        private void btnPacientes_Click(object sender, EventArgs e) => BtnPacientesClick?.Invoke(this, e);
        private void btnTurnos_Click(object sender, EventArgs e) => BtnTurnosClick?.Invoke(this, e);
        private void btnCerrarSesion_Click(object sender, EventArgs e) => BtnCerrarSesionClick?.Invoke(this, e);
    }
}

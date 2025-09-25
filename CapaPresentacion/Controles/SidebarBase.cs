using System.Drawing.Drawing2D;

namespace CapaPresentacion.Controles
{
    public abstract class SidebarBase : UserControl
    {
        protected TableLayoutPanel tableLayoutPanelMenu;
        protected Panel userPanel;
        protected TableLayoutPanel tableLayoutUser;
        protected Label lblRolUsuario;
        protected Label lblUsername;
        protected PictureBox pictureBox1;

        private Button? botonActivo; // trackea el seleccionado

        protected SidebarBase()
        {
            InicializarEstructura();
            AplicarEstilosGlobales();
            CrearBotones(); // 👈 cada sidebar define sus botones
        }

        private void InicializarEstructura()
        {
            tableLayoutPanelMenu = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                Padding = new Padding(5),
                RowCount = 8,
                Size = new Size(180, 500),
            };
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 152F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            // userPanel + tableLayoutUser
            userPanel = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Size = new Size(164, 146),
                Padding = new Padding(1) // ← deja espacio para el borde
            };

            tableLayoutUser = new TableLayoutPanel
            {
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            tableLayoutUser.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutUser.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));

            lblRolUsuario = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 9F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 13, 0, 0)
            };

            pictureBox1 = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            lblUsername = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 9F, FontStyle.Bold | FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 0, 0, 12)
            };

            tableLayoutUser.Controls.Add(lblRolUsuario, 0, 0);
            tableLayoutUser.Controls.Add(pictureBox1, 0, 1);
            tableLayoutUser.Controls.Add(lblUsername, 0, 2);

            userPanel.Controls.Add(tableLayoutUser);
            tableLayoutPanelMenu.Controls.Add(userPanel, 0, 0);

            Controls.Add(tableLayoutPanelMenu);
            Size = new Size(180, 500);
        }

        // Estilos comunes
        private void AplicarEstilosGlobales()
        {
            // Panel redondeado con borde negro fino
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
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // 👇 Negro fino (1px)
                    using (Pen pen = new Pen(Color.Black, 3))
                        e.Graphics.DrawPath(pen, path);
                }
            };
        }

        // 🔹 Cada sidebar concreta define sus botones aquí
        protected abstract void CrearBotones();

        // 🔹 Método común para dar estilo a un botón
        protected void AplicarEstiloBoton(Button btn, bool esSalir = false)
        {
            // Configuración base
            btn.FlatStyle = FlatStyle.Flat;
            btn.UseVisualStyleBackColor = false;
            btn.TabStop = false;
            btn.FlatAppearance.BorderSize = 0;

            btn.ForeColor = Color.Black;
            btn.Font = new Font("Lucida Console", 9F, FontStyle.Bold);

            if (esSalir)
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

            // 🔹 Redondeado con borde negro fino
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
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Aca hago la porqueria esa de los botones. LPM que cosa del diablo
                    using (Pen pen = new Pen(Color.Black, 2))
                        e.Graphics.DrawPath(pen, path);
                }
            };
        }

        // 🔹 Método para marcar botón activo
        public void MarcarActivo(Button btn, string colorHex = "#1FA29C")
        {
            if (botonActivo != null && botonActivo != btn)
            {
                // resetear borde (forzar repaint)
                botonActivo.Invalidate();
            }

            botonActivo = btn;

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
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    using (Pen pen = new Pen(ColorTranslator.FromHtml(colorHex), 2))
                        e.Graphics.DrawPath(pen, path);
                }
            };

            btn.Invalidate();
        }

        // Propiedades comunes
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

        // Cambia la imagen del PictureBox según el rol
        public void SetUserPanelImage(string rol)
        {
            switch (rol.ToLower())
            {
                case "administrador":
                    pictureBox1.Image = Properties.Resources.adminLogo;
                    break;
                case "medico":
                    pictureBox1.Image = Properties.Resources.doctorLogo;
                    break;
                case "secretaria":
                    pictureBox1.Image = Properties.Resources.secreLogo;
                    break;
                default:
                    pictureBox1.Image = null; // o una imagen genérica
                    break;
            }
        }

    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public abstract class SidebarBase : UserControl
    {
        // Layout principal
        private TableLayoutPanel mainLayout;

        // Zona superior (usuario)
        protected Panel userPanel;
        protected TableLayoutPanel tableLayoutUser;
        protected Label lblRolUsuario;
        protected Label lblUsername;
        protected PictureBox pictureBox1;

        // Zona central (lista de botones)
        private Panel botonesHost;                  // contenedor con scroll
        private TableLayoutPanel botonesLista;      // apila botones por filas

        // Pie (salir)
        protected Button btnCerrarSesion;

        private Button? botonActivo;

        protected SidebarBase()
        {
            InicializarEstructura();
            AplicarEstilosGlobales();
            CrearBotones();      // cada sidebar agrega aquí sus botones usando AgregarBoton(...)
        }

        private void InicializarEstructura()
        {
            // --- LAYOUT PRINCIPAL (3 filas: header / botones / salir) ---
            mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(5),
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 152F)); // header
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // botones
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));  // salir

            // --- HEADER (userPanel) ---
            userPanel = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(1)
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
                Padding = new Padding(0, 0, 0, 14)
            };

            tableLayoutUser.Controls.Add(lblRolUsuario, 0, 0);
            tableLayoutUser.Controls.Add(pictureBox1, 0, 1);
            tableLayoutUser.Controls.Add(lblUsername, 0, 2);
            userPanel.Controls.Add(tableLayoutUser);

            // --- ZONA BOTONES (scrollable) ---
            botonesHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            botonesLista = new TableLayoutPanel
            {
                Dock = DockStyle.Top,                  // para que crezca hacia abajo
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 1,
            };
            botonesLista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            botonesHost.Controls.Add(botonesLista);

            // --- BOTÓN SALIR ---
            btnCerrarSesion = CrearBotonBase("Salir", Properties.Resources.salidaIcon);
            btnCerrarSesion.Dock = DockStyle.Fill;   // ocupa toda la fila del pie
            AplicarEstiloBoton(btnCerrarSesion, true);
            btnCerrarSesion.Click += (s, e) => BtnCerrarSesionClick?.Invoke(this, e);

            // --- COMPOSICIÓN ---
            mainLayout.Controls.Add(userPanel, 0, 0);
            mainLayout.Controls.Add(botonesHost, 0, 1);
            mainLayout.Controls.Add(btnCerrarSesion, 0, 2);

            Controls.Add(mainLayout);
            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(0, 86, 94); // tu teal de fondo
            Width = 180;
        }

        private void AplicarEstilosGlobales()
        {
            // header redondeado + borde fino
            userPanel.Paint += (s, e) =>
            {
                int radio = 20;
                Rectangle rect = new Rectangle(0, 0, userPanel.Width - 1, userPanel.Height - 1);

                using var path = new GraphicsPath();
                path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                path.CloseAllFigures();

                userPanel.Region = new Region(path);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var pen = new Pen(Color.Black, 1);
                e.Graphics.DrawPath(pen, path);
            };
        }

        // ===== API para los sidebars concretos =====

        // Cada sidebar debe implementar y llamar AgregarBoton(...)
        protected abstract void CrearBotones();

        // Añade un botón a la lista (crea fila y lo estira horizontalmente)
        protected void AgregarBoton(Button btn)
        {
            AplicarEstiloBoton(btn);
            btn.Margin = new Padding(5, 6, 5, 6);
            btn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btn.MinimumSize = new Size(0, 40);

            int row = botonesLista.RowCount;
            botonesLista.RowCount++;
            botonesLista.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            botonesLista.Controls.Add(btn, 0, row);
        }

        // Crea un botón base con icono (útil para los sidebars)
        protected Button CrearBotonBase(string texto, Image icono)
        {
            return new Button
            {
                Text = texto,
                Image = icono,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Height = 40,
                AutoSize = false
            };
        }

        // Estilo común (colores, hover y borde redondeado 1px)
        protected void AplicarEstiloBoton(Button btn, bool esSalir = false)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false;
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

            // borde y redondeado
            btn.Paint += (s, e) =>
            {
                int radio = 15;
                var rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                using var path = new GraphicsPath();
                path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                path.CloseAllFigures();

                btn.Region = new Region(path);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var pen = new Pen(Color.Black, 1);
                e.Graphics.DrawPath(pen, path);
            };
        }

        public void MarcarActivo(Button btn, string colorHex = "#1FA29C")
        {
            if (botonActivo != null && botonActivo != btn)
                botonActivo.Invalidate();

            botonActivo = btn;

            btn.Paint += (s, e) =>
            {
                int radio = 15;
                var rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                using var path = new GraphicsPath();
                path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                path.CloseAllFigures();

                btn.Region = new Region(path);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var pen = new Pen(ColorTranslator.FromHtml(colorHex), 2);
                e.Graphics.DrawPath(pen, path);
            };

            btn.Invalidate();
        }

        // Props + utilidades
        public string Username { get => lblUsername.Text; set => lblUsername.Text = value; }
        public string RolUsuario { get => lblRolUsuario.Text; set => lblRolUsuario.Text = value; }
        public void SetUserPanelImage(Image img) => pictureBox1.Image = img;

        public event EventHandler BtnCerrarSesionClick;
    }
}

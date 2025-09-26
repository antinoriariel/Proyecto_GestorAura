using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public class NavbarSuperior : UserControl
    {
        private Label lblTitulo;
        private FlowLayoutPanel panelBotones;
        private Button btnDarkMode;
        private Button btnNotificaciones;
        private Button btnAyuda;
        private Button btnCerrarSesion;

        public NavbarSuperior()
        {
            Inicializar();
        }

        private void Inicializar()
        {
            this.Dock = DockStyle.Top;
            this.Height = 45;
            this.BackColor = Color.FromArgb(55, 71, 79); // gris oscuro

            // --- TableLayout para centrar el título ---
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F)); // izquierda
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F)); // centro
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));     // derecha (botones)

            // --- Label Título ---
            lblTitulo = new Label
            {
                Text = "Medic - Gestión hospitalaria",
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            };

            // --- Panel de botones (alineados a la derecha) ---
            panelBotones = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                Padding = new Padding(0, 7, 10, 0),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // --- Botones con íconos ---
            btnCerrarSesion = CrearBotonConIcono(Properties.Resources.ajustesIcon);
            btnCerrarSesion.Click += (s, e) => BtnCerrarSesionClick?.Invoke(this, e);

            btnAyuda = CrearBotonConIcono(Properties.Resources.ajustesIcon);
            btnAyuda.Click += (s, e) => BtnAyudaClick?.Invoke(this, e);

            btnNotificaciones = CrearBotonConIcono(Properties.Resources.ajustesIcon);
            btnNotificaciones.Click += (s, e) => BtnNotificacionesClick?.Invoke(this, e);

            btnDarkMode = CrearBotonConIcono(Properties.Resources.ajustesIcon);
            btnDarkMode.Click += (s, e) => BtnDarkModeClick?.Invoke(this, e);

            // Agregar botones al panel
            panelBotones.Controls.Add(btnCerrarSesion);
            panelBotones.Controls.Add(btnAyuda);
            panelBotones.Controls.Add(btnNotificaciones);
            panelBotones.Controls.Add(btnDarkMode);

            // Agregar al layout
            layout.Controls.Add(new Panel(), 0, 0); // columna vacía (izquierda)
            layout.Controls.Add(lblTitulo, 1, 0);   // título centrado
            layout.Controls.Add(panelBotones, 2, 0); // botones a la derecha

            this.Controls.Add(layout);
        }

        // ===== Estilo de botones redondeados (como SidebarBase) =====
        private Button CrearBotonConIcono(Image icono)
        {
            var btn = new Button
            {
                BackColor = ColorTranslator.FromHtml("#27d9cf"),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Height = 30,
                Width = 40,
                Margin = new Padding(5, 0, 0, 0),
                Image = icono,
                ImageAlign = ContentAlignment.MiddleCenter
            };

            btn.FlatAppearance.BorderSize = 0;

            // Hover
            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#1FA29C");
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml("#27d9cf");

            // Bordes redondeados
            btn.Paint += (s, e) =>
            {
                int radio = 10;
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

            return btn;
        }

        // Eventos expuestos
        public event EventHandler? BtnDarkModeClick;
        public event EventHandler? BtnNotificacionesClick;
        public event EventHandler? BtnAyudaClick;
        public event EventHandler? BtnCerrarSesionClick;
    }
}

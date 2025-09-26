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

            // Contenedor principal (layout sencillo: Right + Fill)
            var container = new Panel
            {
                Dock = DockStyle.Fill
            };

            // --- Panel de botones (alineados a la derecha) ---
            panelBotones = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,                 // <- clave
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                Padding = new Padding(0, 7, 10, 0),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // --- Label Título centrado ---
            lblTitulo = new Label
            {
                Text = "Medic - Gestión hospitalaria",
                ForeColor = Color.White,
                Dock = DockStyle.Fill,                  // <- ocupa el resto
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoEllipsis = true                     // recorta con "..." si no entra
            };

            // --- Botones con íconos (luego cambias los íconos reales) ---
            btnCerrarSesion = CrearBotonConIcono(Properties.Resources.ajustesIcon);
            btnCerrarSesion.Click += (s, e) => BtnCerrarSesionClick?.Invoke(this, e);

            btnAyuda = CrearBotonConIcono(Properties.Resources.ajustesIcon);
            btnAyuda.Click += (s, e) => BtnAyudaClick?.Invoke(this, e);

            btnNotificaciones = CrearBotonConIcono(Properties.Resources.ajustesIcon);
            btnNotificaciones.Click += (s, e) => BtnNotificacionesClick?.Invoke(this, e);

            btnDarkMode = CrearBotonConIcono(Properties.Resources.ajustesIcon);
            btnDarkMode.Click += (s, e) => BtnDarkModeClick?.Invoke(this, e);

            // Orden: de derecha a izquierda
            panelBotones.Controls.Add(btnCerrarSesion);
            panelBotones.Controls.Add(btnAyuda);
            panelBotones.Controls.Add(btnNotificaciones);
            panelBotones.Controls.Add(btnDarkMode);

            // Agregar primero el panel de botones (Right), luego el label (Fill)
            container.Controls.Add(panelBotones);
            container.Controls.Add(lblTitulo);

            this.Controls.Add(container);
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
                ImageAlign = ContentAlignment.MiddleCenter,
                TabStop = false
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

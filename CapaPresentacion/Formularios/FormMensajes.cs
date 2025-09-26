using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormMensajes : Form
    {
        // Header
        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        // Layout
        private SplitContainer split;
        private ListBox lstConversaciones;
        private Panel panelChat;
        private RichTextBox rtbHistorial;
        private TextBox txtMensaje;
        private Button btnEnviar;

        public FormMensajes()
        {
            Text = "Mensajes";
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            BackColor = Color.WhiteSmoke;
            DoubleBuffered = true;
            Padding = new Padding(10);

            BuildHeader("Mensajes", SystemIcons.Asterisk.ToBitmap());
            BuildChat();

            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            main.Controls.Add(headerPanel, 0, 0);
            main.Controls.Add(split, 0, 1);

            Controls.Add(main);

            Load += (s, e) => CargarMock();
        }

        private void BuildHeader(string titulo, Image icono)
        {
            headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(40, 56, 74),
                Padding = new Padding(12, 8, 12, 8)
            };
            picHeader = new PictureBox
            {
                Image = icono,
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 36,
                Height = 36,
                Dock = DockStyle.Left
            };
            lblHeader = new Label
            {
                Text = titulo,
                ForeColor = Color.White,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Controls.Add(picHeader);
        }

        private void BuildChat()
        {
            split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 260,
                FixedPanel = FixedPanel.Panel1
            };

            // Izquierda: conversaciones
            lstConversaciones = new ListBox
            {
                Dock = DockStyle.Fill,
                IntegralHeight = false
            };
            lstConversaciones.SelectedIndexChanged += (s, e) => CargarHistorialSeleccion();

            split.Panel1.Padding = new Padding(6);
            split.Panel1.Controls.Add(lstConversaciones);

            // Derecha: chat
            panelChat = new Panel { Dock = DockStyle.Fill, Padding = new Padding(6) };

            rtbHistorial = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.White,
                DetectUrls = true
            };

            var enviarPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Bottom,
                ColumnCount = 2,
                RowCount = 1,
                Height = 44
            };
            enviarPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            enviarPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));

            txtMensaje = new TextBox { Dock = DockStyle.Fill };
            btnEnviar = new Button { Text = "Enviar", Dock = DockStyle.Fill };

            btnEnviar.Click += (s, e) => Enviar();
            txtMensaje.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && !e.Shift)
                {
                    e.SuppressKeyPress = true;
                    Enviar();
                }
            };

            enviarPanel.Controls.Add(txtMensaje, 0, 0);
            enviarPanel.Controls.Add(btnEnviar, 1, 0);

            panelChat.Controls.Add(rtbHistorial);
            panelChat.Controls.Add(enviarPanel);

            split.Panel2.Controls.Add(panelChat);
        }

        private void CargarMock()
        {
            lstConversaciones.Items.AddRange(new object[]
            {
                "Secretaría • Mesa de entradas",
                "García, Laura (Paciente)",
                "Suárez, Martín (Paciente)"
            });
            lstConversaciones.SelectedIndex = 0;
        }

        private void CargarHistorialSeleccion()
        {
            rtbHistorial.Clear();
            var quien = lstConversaciones.SelectedItem?.ToString() ?? "";
            rtbHistorial.SelectionColor = Color.DimGray;
            rtbHistorial.AppendText($"Conversación con {quien}\n");
            rtbHistorial.SelectionColor = Color.Black;
            rtbHistorial.AppendText($"[{DateTime.Now.AddMinutes(-15):HH:mm}] Secretaría: Doctor, llegó un resultado nuevo.\n");
            rtbHistorial.AppendText($"[{DateTime.Now.AddMinutes(-10):HH:mm}] Usted: Perfecto, lo reviso.\n");
        }

        private void Enviar()
        {
            var msg = txtMensaje.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            rtbHistorial.SelectionColor = Color.Black;
            rtbHistorial.AppendText($"[{DateTime.Now:HH:mm}] Usted: {msg}\n");
            txtMensaje.Clear();
            txtMensaje.Focus();
        }
    }
}

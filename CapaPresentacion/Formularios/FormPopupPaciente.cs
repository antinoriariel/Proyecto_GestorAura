using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CapaNegocio;

// Alias iTextSharp
using iTextFont = iTextSharp.text.Font;
using iTextBaseColor = iTextSharp.text.BaseColor;
using iTextDoc = iTextSharp.text.Document;
using iTextParagraph = iTextSharp.text.Paragraph;
using iTextPageSize = iTextSharp.text.PageSize;
using iTextPdfWriter = iTextSharp.text.pdf.PdfWriter;

namespace CapaPresentacion.Formularios
{
    public partial class FormPopupPaciente : Form
    {
        private readonly string _infoPaciente;
        private readonly int _idUsuarioActual;
        private readonly int _idPaciente; // nuevo

        private Label lblDatos;
        private Button btnCerrar;
        private Button btnExportar;
        private Button btnAgregarHC;

        // 🔹 Constructor con idPaciente e idUsuarioActual
        public FormPopupPaciente(string info, int idPaciente, int idUsuarioActual = 0)
        {
            _infoPaciente = info;
            _idPaciente = idPaciente;
            _idUsuarioActual = idUsuarioActual;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Detalles del Paciente";
            BackColor = Color.FromArgb(241, 244, 246);
            Size = new Size(700, 500);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Font = new Font("Consolas", 10.5F, FontStyle.Regular);
            DoubleBuffered = true;
            MaximizeBox = false;
            MinimizeBox = false;

            // ======== HEADER ========
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(41, 57, 71)
            };

            var picIcon = new PictureBox
            {
                Image = Properties.Resources.pacienteIcon,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(16, 13),
                Size = new Size(36, 34)
            };

            var lblTitulo = new Label
            {
                Text = "Detalles del Paciente",
                AutoSize = true,
                Font = new Font("Consolas", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(60, 13)
            };

            header.Controls.Add(picIcon);
            header.Controls.Add(lblTitulo);

            // ======== BODY ========
            var panelBody = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(30, 20, 30, 20),
                AutoScroll = true
            };

            var grpDatos = new GroupBox
            {
                Text = "Datos del paciente:",
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 11F, FontStyle.Bold),
                Padding = new Padding(20),
                BackColor = Color.White
            };

            lblDatos = new Label
            {
                Text = _infoPaciente,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 11F, FontStyle.Regular),
                ForeColor = ColorTranslator.FromHtml("#333333"),
                AutoSize = false,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(249, 250, 251)
            };

            grpDatos.Controls.Add(lblDatos);
            panelBody.Controls.Add(grpDatos);

            // ======== FOOTER ========
            var footer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 90,
                BackColor = Color.FromArgb(245, 246, 248),
                Padding = new Padding(0, 12, 0, 12)
            };

            var flowButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 0, 30, 0),
                WrapContents = false
            };

            btnCerrar = CrearBoton("✖  Cerrar", "#666666");
            btnCerrar.Click += (s, e) => Close();

            btnExportar = CrearBoton("📄  Exportar PDF", "#0088cc");
            btnExportar.Click += BtnExportar_Click;

            btnAgregarHC = CrearBoton("🩺  Agregar Historia Clínica", "#00aa66");
            btnAgregarHC.Click += BtnAgregarHC_Click;

            flowButtons.Controls.AddRange(new Control[] { btnCerrar, btnExportar, btnAgregarHC });
            footer.Controls.Add(flowButtons);

            Controls.Add(panelBody);
            Controls.Add(footer);
            Controls.Add(header);
        }

        private Button CrearBoton(string texto, string colorHex)
        {
            var btn = new Button
            {
                Text = texto,
                Height = 44,
                Width = 190,
                BackColor = ColorTranslator.FromHtml(colorHex),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Consolas", 11F, FontStyle.Bold),
                Margin = new Padding(12, 10, 0, 10),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(btn.BackColor);
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml(colorHex);
            return btn;
        }

        private void BtnExportar_Click(object? sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new()
                {
                    Filter = "Archivo PDF (*.pdf)|*.pdf",
                    FileName = "Paciente_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf"
                };

                if (save.ShowDialog() != DialogResult.OK) return;

                using FileStream fs = new(save.FileName, FileMode.Create, FileAccess.Write);
                iTextDoc doc = new(iTextPageSize.A4, 50, 50, 60, 50);
                iTextPdfWriter.GetInstance(doc, fs);
                doc.Open();

                var fontTitulo = new iTextFont(iTextFont.FontFamily.COURIER, 18, iTextFont.BOLD, iTextBaseColor.BLACK);
                var fontTexto = new iTextFont(iTextFont.FontFamily.COURIER, 12, iTextFont.NORMAL, iTextBaseColor.BLACK);

                doc.Add(new iTextParagraph("Detalles del Paciente", fontTitulo)
                {
                    Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                    SpacingAfter = 20
                });
                doc.Add(new iTextParagraph(_infoPaciente, fontTexto));

                doc.Close();
                fs.Close();

                MessageBox.Show("Archivo PDF exportado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("¿Desea abrir el PDF ahora?", "Abrir archivo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Process.Start(new ProcessStartInfo(save.FileName) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar PDF:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // ABRIR FORMHC CON ID PACIENTE
        // =========================================================
        private void BtnAgregarHC_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idUsuarioActual <= 0 || _idPaciente <= 0)
                {
                    MessageBox.Show("Error: faltan datos de usuario o paciente.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 Abrimos el formulario con ambos IDs
                using var formHC = new FormHC(_idUsuarioActual, _idPaciente);
                formHC.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la historia clínica:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

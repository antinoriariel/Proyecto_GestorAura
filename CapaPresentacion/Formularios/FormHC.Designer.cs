using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormHC
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        // Contenido
        private GroupBox grpDatos;
        private Panel panelScroll;
        private TableLayoutPanel grid;

        private Label lblPaciente;
        private TextBox txtPaciente;

        private Label lblEstado;
        private ComboBox cboEstado;

        private Label lblMotivo;
        private TextBox txtMotivo;

        private Label lblFechaHora;
        private DateTimePicker dtpFechaHora;

        private Label lblImpDiag;
        private TextBox txtImpresionDiag;

        private Label lblDiagnostico;
        private TextBox txtDiagnostico;

        private Label lblIndicaciones;
        private TextBox txtIndicaciones;

        private Label lblAntecedentes;
        private TextBox txtAntecedentes;

        private Label lblObservaciones;
        private TextBox txtObservaciones;

        private Label lblTipoConsulta;
        private ComboBox cboTipoConsulta;

        // Footer
        private Panel footerPanel;
        private FlowLayoutPanel flowFooter;
        private Button btnGuardar;
        private Button btnCancelar;

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ====== Form ======
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(1100, 720);
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Historia Cl�nica";

            // ====== Header ======
            headerPanel = new Panel
            {
                BackColor = Color.FromArgb(41, 57, 71),
                Dock = DockStyle.Top,
                Location = new Point(21, 12),
                Name = "headerPanel",
                Size = new Size(1058, 48),
                TabIndex = 0
            };
            picHeader = new PictureBox
            {
                Image = Properties.Resources.hcIcon,
                Location = new Point(14, 9),
                Name = "picHeader",
                Size = new Size(35, 30),
                SizeMode = PictureBoxSizeMode.Zoom,
                TabStop = false
            };
            lblHeader = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(56, 14),
                Text = "Historia Cl�nica"
            };
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);

            // ====== Footer ======
            footerPanel = new Panel
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Bottom,
                Height = 56,
                Padding = new Padding(0, 8, 12, 8)
            };
            flowFooter = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false
            };
            btnCancelar = new Button
            {
                AutoSize = true,
                Text = "Cancelar",
                Margin = new Padding(8, 8, 0, 8)
            };
            btnGuardar = new Button
            {
                AutoSize = true,
                Text = "Guardar",
                Margin = new Padding(8, 8, 0, 8)
            };
            flowFooter.Controls.Add(btnCancelar);
            flowFooter.Controls.Add(btnGuardar);
            footerPanel.Controls.Add(flowFooter);

            // ====== Grupo Datos ======
            grpDatos = new GroupBox
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Location = new Point(21, 60),
                Padding = new Padding(14, 12, 14, 12),
                Text = "Datos de la HC"
            };

            panelScroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(0, 0, 12, 0) // espacio p/ iconos de ErrorProvider
            };

            grid = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top,
                ColumnCount = 2
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            // Definici�n de filas (alturas moderadas)
            grid.RowStyles.Clear();
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F)); // Paciente
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F)); // Estado
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F)); // Motivo
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F)); // FechaHora
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F)); // Imp. diag.
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F)); // Diagn�stico
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F)); // Indicaciones
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F)); // Antecedentes
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F)); // Observaciones
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F)); // Tipo consulta
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // relleno

            // Helper para labels
            Label MakeLabel(string text)
            {
                return new Label
                {
                    Text = text,
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Margin = new Padding(3, 6, 3, 6)
                };
            }

            // Controles
            lblPaciente = MakeLabel("Paciente");
            txtPaciente = new TextBox
            {
                Dock = DockStyle.Fill,
                PlaceholderText = "Nombre de paciente...",
                Margin = new Padding(3, 3, 12, 3)
            };

            lblEstado = MakeLabel("Estado");
            cboEstado = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                IntegralHeight = false,
                Anchor = AnchorStyles.Left,
                Width = 220
            };
            cboEstado.Items.AddRange(new object[] { "En curso", "Resuelto", "Pendiente", "Cerrado" });

            lblMotivo = MakeLabel("Motivo");
            txtMotivo = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Margin = new Padding(3, 3, 12, 3)
            };

            lblFechaHora = MakeLabel("Fecha y hora");
            dtpFechaHora = new DateTimePicker
            {
                CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy - HH:mm",
                Format = DateTimePickerFormat.Custom,
                Anchor = AnchorStyles.Left
            };

            lblImpDiag = MakeLabel("Impresi�n diagn�stica");
            txtImpresionDiag = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Vertical, Margin = new Padding(3, 3, 12, 3) };

            lblDiagnostico = MakeLabel("Diagn�stico");
            txtDiagnostico = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Vertical, Margin = new Padding(3, 3, 12, 3) };

            lblIndicaciones = MakeLabel("Indicaciones");
            txtIndicaciones = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Vertical, Margin = new Padding(3, 3, 12, 3) };

            lblAntecedentes = MakeLabel("Antecedentes");
            txtAntecedentes = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Vertical, Margin = new Padding(3, 3, 12, 3) };

            lblObservaciones = MakeLabel("Observaciones");
            txtObservaciones = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Vertical, Margin = new Padding(3, 3, 12, 3) };

            lblTipoConsulta = MakeLabel("Tipo de consulta");
            cboTipoConsulta = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                IntegralHeight = false,
                Anchor = AnchorStyles.Left,
                Width = 260
            };
            cboTipoConsulta.Items.AddRange(new object[]
            {
                "Consulta",
                "Control",
                "Urgencia",
                "Seguimiento",
                "Interconsulta",
                "Teleconsulta"
            });

            // Agregar a la grilla (fila, col)
            grid.Controls.Add(lblPaciente, 0, 0);
            grid.Controls.Add(txtPaciente, 1, 0);

            grid.Controls.Add(lblEstado, 0, 1);
            grid.Controls.Add(cboEstado, 1, 1);

            grid.Controls.Add(lblMotivo, 0, 2);
            grid.Controls.Add(txtMotivo, 1, 2);

            grid.Controls.Add(lblFechaHora, 0, 3);
            grid.Controls.Add(dtpFechaHora, 1, 3);

            grid.Controls.Add(lblImpDiag, 0, 4);
            grid.Controls.Add(txtImpresionDiag, 1, 4);

            grid.Controls.Add(lblDiagnostico, 0, 5);
            grid.Controls.Add(txtDiagnostico, 1, 5);

            grid.Controls.Add(lblIndicaciones, 0, 6);
            grid.Controls.Add(txtIndicaciones, 1, 6);

            grid.Controls.Add(lblAntecedentes, 0, 7);
            grid.Controls.Add(txtAntecedentes, 1, 7);

            grid.Controls.Add(lblObservaciones, 0, 8);
            grid.Controls.Add(txtObservaciones, 1, 8);

            grid.Controls.Add(lblTipoConsulta, 0, 9);
            grid.Controls.Add(cboTipoConsulta, 1, 9);

            panelScroll.Controls.Add(grid);
            grpDatos.Controls.Add(panelScroll);

            // Compose
            Controls.Add(grpDatos);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);

            // Accept/Cancel
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
        }
    }
}

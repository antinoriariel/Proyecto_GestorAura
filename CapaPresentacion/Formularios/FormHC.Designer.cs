namespace CapaPresentacion.Formularios
{
    partial class FormHC
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label lblHeader;

        // Contenido
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Panel panelScroll;
        private System.Windows.Forms.TableLayoutPanel grid;

        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cboPaciente;

        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;

        private System.Windows.Forms.Label lblMotivoConsulta;
        private System.Windows.Forms.TextBox txtMotivoConsulta;

        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;

        private System.Windows.Forms.Label lblImpDiag;
        private System.Windows.Forms.TextBox txtImpresionDiag;

        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;

        private System.Windows.Forms.Label lblIndicaciones;
        private System.Windows.Forms.TextBox txtIndicaciones;

        private System.Windows.Forms.Label lblAntecedentes;
        private System.Windows.Forms.TextBox txtAntecedentes;

        private System.Windows.Forms.Label lblEvolucion;
        private System.Windows.Forms.TextBox txtEvolucion;

        private System.Windows.Forms.Label lblImpGral;
        private System.Windows.Forms.TextBox txtImpresionGral;

        private System.Windows.Forms.Label lblExamenes;
        private System.Windows.Forms.TextBox txtExamenes;

        private System.Windows.Forms.Label lblTipoConsulta;
        private System.Windows.Forms.TextBox txtTipoConsulta;

        // Footer
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button bGuardar;
        private System.Windows.Forms.Button bCancelar;

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new System.Windows.Forms.Panel();
            picHeader = new System.Windows.Forms.PictureBox();
            lblHeader = new System.Windows.Forms.Label();
            grpDatos = new System.Windows.Forms.GroupBox();
            panelScroll = new System.Windows.Forms.Panel();
            grid = new System.Windows.Forms.TableLayoutPanel();

            lblPaciente = new System.Windows.Forms.Label();
            cboPaciente = new System.Windows.Forms.ComboBox();

            lblEstado = new System.Windows.Forms.Label();
            cboEstado = new System.Windows.Forms.ComboBox();

            lblMotivoConsulta = new System.Windows.Forms.Label();
            txtMotivoConsulta = new System.Windows.Forms.TextBox();

            lblFechaHora = new System.Windows.Forms.Label();
            dtpFechaHora = new System.Windows.Forms.DateTimePicker();

            lblImpDiag = new System.Windows.Forms.Label();
            txtImpresionDiag = new System.Windows.Forms.TextBox();

            lblDiagnostico = new System.Windows.Forms.Label();
            txtDiagnostico = new System.Windows.Forms.TextBox();

            lblIndicaciones = new System.Windows.Forms.Label();
            txtIndicaciones = new System.Windows.Forms.TextBox();

            lblAntecedentes = new System.Windows.Forms.Label();
            txtAntecedentes = new System.Windows.Forms.TextBox();

            lblEvolucion = new System.Windows.Forms.Label();
            txtEvolucion = new System.Windows.Forms.TextBox();

            lblImpGral = new System.Windows.Forms.Label();
            txtImpresionGral = new System.Windows.Forms.TextBox();

            lblExamenes = new System.Windows.Forms.Label();
            txtExamenes = new System.Windows.Forms.TextBox();

            lblTipoConsulta = new System.Windows.Forms.Label();
            txtTipoConsulta = new System.Windows.Forms.TextBox();

            footerPanel = new System.Windows.Forms.Panel();
            bGuardar = new System.Windows.Forms.Button();
            bCancelar = new System.Windows.Forms.Button();

            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).BeginInit();
            grpDatos.SuspendLayout();
            panelScroll.SuspendLayout();
            grid.SuspendLayout();
            footerPanel.SuspendLayout();
            SuspendLayout();

            // ===== Fuentes =====
            System.Drawing.Font baseFont = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);

            // ======================= HEADER =======================
            headerPanel.BackColor = System.Drawing.Color.FromArgb(41, 57, 71);
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Location = new System.Drawing.Point(24, 16);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new System.Drawing.Size(932, 64);
            headerPanel.TabIndex = 2;

            picHeader.Image = Properties.Resources.medicalNotesIcon;
            picHeader.Location = new System.Drawing.Point(16, 12);
            picHeader.Name = "picHeader";
            picHeader.Size = new System.Drawing.Size(40, 40);
            picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picHeader.TabStop = false;

            lblHeader.AutoSize = true;
            lblHeader.Font = baseFont;
            lblHeader.ForeColor = System.Drawing.Color.White;
            lblHeader.Location = new System.Drawing.Point(64, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new System.Drawing.Size(162, 19);
            lblHeader.Text = "Historia clínica";

            // ======================= GRUPO DATOS =======================
            grpDatos.BackColor = System.Drawing.Color.White;
            grpDatos.Controls.Add(panelScroll);
            grpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            grpDatos.Location = new System.Drawing.Point(24, 80);
            grpDatos.Padding = new System.Windows.Forms.Padding(16);
            grpDatos.Size = new System.Drawing.Size(932, 624);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos de la consulta";
            grpDatos.Font = baseFont;

            // Scroll
            panelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            panelScroll.AutoScroll = true;
            panelScroll.Controls.Add(grid);

            // ======================= GRID =======================
            grid.ColumnCount = 2;
            grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F)); // ancho etiquetas más justo
            grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            grid.Dock = System.Windows.Forms.DockStyle.Top;
            grid.AutoSize = false;
            grid.Padding = new System.Windows.Forms.Padding(0); // sin padding lateral
            grid.RowCount = 12;

            // Alturas de filas
            grid.RowStyles.Clear();
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));  // Paciente
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));  // Estado
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));  // Motivo
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));  // Fecha y hora
            for (int i = 0; i < 7; i++) // 7 campos grandes
                grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));  // Tipo consulta

            // Helper para labels
            void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto)
            {
                lbl.Text = texto;
                lbl.Font = baseFont;
                lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
                lbl.AutoSize = true;
            }

            // Helper para textboxes grandes
            void ConfigurarGrande(System.Windows.Forms.TextBox t)
            {
                t.Font = baseFont;
                t.Multiline = true;
                t.WordWrap = true;
                t.AcceptsReturn = true;
                t.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                t.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            // ===== Paciente
            ConfigurarLabel(lblPaciente, "Paciente");
            cboPaciente.Font = baseFont;
            cboPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPaciente.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grid.Controls.Add(lblPaciente, 0, 0);
            grid.Controls.Add(cboPaciente, 1, 0);

            // ===== Estado
            ConfigurarLabel(lblEstado, "Estado");
            cboEstado.Font = baseFont;
            cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEstado.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grid.Controls.Add(lblEstado, 0, 1);
            grid.Controls.Add(cboEstado, 1, 1);

            // ===== Motivo
            ConfigurarLabel(lblMotivoConsulta, "Motivo de consulta");
            txtMotivoConsulta.Font = baseFont;
            txtMotivoConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMotivoConsulta.PlaceholderText = "Ej.: control, dolor abdominal, seguimiento…";
            grid.Controls.Add(lblMotivoConsulta, 0, 2);
            grid.Controls.Add(txtMotivoConsulta, 1, 2);

            // ===== Fecha
            ConfigurarLabel(lblFechaHora, "Fecha y hora");
            dtpFechaHora.Font = baseFont;
            dtpFechaHora.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy - HH:mm";
            dtpFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpFechaHora.ShowUpDown = true;
            dtpFechaHora.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.Controls.Add(lblFechaHora, 0, 3);
            grid.Controls.Add(dtpFechaHora, 1, 3);

            // ===== Campos grandes
            ConfigurarLabel(lblImpDiag, "Impresión diagnóstica");
            ConfigurarGrande(txtImpresionDiag);
            grid.Controls.Add(lblImpDiag, 0, 4);
            grid.Controls.Add(txtImpresionDiag, 1, 4);

            ConfigurarLabel(lblDiagnostico, "Diagnóstico");
            ConfigurarGrande(txtDiagnostico);
            grid.Controls.Add(lblDiagnostico, 0, 5);
            grid.Controls.Add(txtDiagnostico, 1, 5);

            ConfigurarLabel(lblIndicaciones, "Indicaciones");
            ConfigurarGrande(txtIndicaciones);
            grid.Controls.Add(lblIndicaciones, 0, 6);
            grid.Controls.Add(txtIndicaciones, 1, 6);

            ConfigurarLabel(lblAntecedentes, "Antecedentes");
            ConfigurarGrande(txtAntecedentes);
            grid.Controls.Add(lblAntecedentes, 0, 7);
            grid.Controls.Add(txtAntecedentes, 1, 7);

            ConfigurarLabel(lblEvolucion, "Evolución");
            ConfigurarGrande(txtEvolucion);
            grid.Controls.Add(lblEvolucion, 0, 8);
            grid.Controls.Add(txtEvolucion, 1, 8);

            ConfigurarLabel(lblImpGral, "Impresión general");
            ConfigurarGrande(txtImpresionGral);
            grid.Controls.Add(lblImpGral, 0, 9);
            grid.Controls.Add(txtImpresionGral, 1, 9);

            ConfigurarLabel(lblExamenes, "Exámenes");
            ConfigurarGrande(txtExamenes);
            grid.Controls.Add(lblExamenes, 0, 10);
            grid.Controls.Add(txtExamenes, 1, 10);

            ConfigurarLabel(lblTipoConsulta, "Tipo de consulta");
            txtTipoConsulta.Font = baseFont;
            txtTipoConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grid.Controls.Add(lblTipoConsulta, 0, 11);
            grid.Controls.Add(txtTipoConsulta, 1, 11);

            // Ajuste alto
            int altoTotal = 4 * 48 + 7 * 160 + 48;
            grid.Size = new System.Drawing.Size(900, altoTotal);

            // ======================= FOOTER =======================
            footerPanel.Controls.Add(bGuardar);
            footerPanel.Controls.Add(bCancelar);
            footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            footerPanel.Location = new System.Drawing.Point(24, 640);
            footerPanel.Size = new System.Drawing.Size(932, 64);

            bGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bGuardar.AutoSize = true;
            bGuardar.Font = baseFont;
            bGuardar.Location = new System.Drawing.Point(760, 12);
            bGuardar.Text = "Guardar";

            bCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bCancelar.AutoSize = true;
            bCancelar.Font = baseFont;
            bCancelar.Location = new System.Drawing.Point(880, 12);
            bCancelar.Text = "Cancelar";

            // ======================= FORM =======================
            AcceptButton = bGuardar;
            BackColor = System.Drawing.Color.FromArgb(241, 244, 246);
            CancelButton = bCancelar;
            ClientSize = new System.Drawing.Size(980, 720);
            Controls.Add(footerPanel);
            Controls.Add(grpDatos);
            Controls.Add(headerPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            KeyPreview = true;
            Name = "FormHC";
            Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Historia clínica";
            Load += FormHC_Load;

            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).EndInit();
            grpDatos.ResumeLayout(false);
            panelScroll.ResumeLayout(false);
            panelScroll.PerformLayout();
            grid.ResumeLayout(false);
            grid.PerformLayout();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}

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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            picHeader = new PictureBox();
            lblHeader = new Label();
            grpDatos = new GroupBox();
            grid = new TableLayoutPanel();
            lblPaciente = new Label();
            cboPaciente = new ComboBox();
            lblEstado = new Label();
            cboEstado = new ComboBox();
            lblMotivoConsulta = new Label();
            txtMotivoConsulta = new TextBox();
            lblFechaHora = new Label();
            dtpFechaHora = new DateTimePicker();
            lblImpDiag = new Label();
            txtImpresionDiag = new TextBox();
            lblDiagnostico = new Label();
            txtDiagnostico = new TextBox();
            lblIndicaciones = new Label();
            txtIndicaciones = new TextBox();
            lblAntecedentes = new Label();
            txtAntecedentes = new TextBox();
            lblEvolucion = new Label();
            txtEvolucion = new TextBox();
            lblImpGral = new Label();
            txtImpresionGral = new TextBox();
            lblExamenes = new Label();
            txtExamenes = new TextBox();
            lblTipoConsulta = new Label();
            txtTipoConsulta = new TextBox();
            footerPanel = new Panel();
            bGuardar = new Button();
            bCancelar = new Button();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).BeginInit();
            grpDatos.SuspendLayout();
            grid.SuspendLayout();
            footerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(41, 57, 71);
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(24, 16);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(932, 64);
            headerPanel.TabIndex = 2;
            // 
            // picHeader
            // 
            picHeader.Image = Properties.Resources.medicalNotesIcon;
            picHeader.Location = new Point(16, 12);
            picHeader.Name = "picHeader";
            picHeader.Size = new Size(40, 40);
            picHeader.SizeMode = PictureBoxSizeMode.Zoom;
            picHeader.TabIndex = 0;
            picHeader.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(64, 18);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(197, 37);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Historia clínica";
            // 
            // grpDatos
            // 
            grpDatos.BackColor = Color.White;
            grpDatos.Controls.Add(grid);
            grpDatos.Dock = DockStyle.Fill;
            grpDatos.Location = new Point(24, 80);
            grpDatos.Name = "grpDatos";
            grpDatos.Padding = new Padding(16);
            grpDatos.Size = new Size(932, 624);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos de la consulta";
            // 
            // grid
            // 
            grid.ColumnCount = 2;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            grid.Controls.Add(lblPaciente, 0, 0);
            grid.Controls.Add(cboPaciente, 1, 0);
            grid.Controls.Add(lblEstado, 0, 1);
            grid.Controls.Add(cboEstado, 1, 1);
            grid.Controls.Add(lblMotivoConsulta, 0, 2);
            grid.Controls.Add(txtMotivoConsulta, 1, 2);
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
            grid.Controls.Add(lblEvolucion, 0, 8);
            grid.Controls.Add(txtEvolucion, 1, 8);
            grid.Controls.Add(lblImpGral, 0, 9);
            grid.Controls.Add(txtImpresionGral, 1, 9);
            grid.Controls.Add(lblExamenes, 0, 10);
            grid.Controls.Add(txtExamenes, 1, 10);
            grid.Controls.Add(lblTipoConsulta, 0, 11);
            grid.Controls.Add(txtTipoConsulta, 1, 11);
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(16, 36);
            grid.Name = "grid";
            grid.RowCount = 12;
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            grid.Size = new Size(900, 572);
            grid.TabIndex = 0;
            // 
            // lblPaciente
            // 
            lblPaciente.Anchor = AnchorStyles.Left;
            lblPaciente.AutoSize = true;
            lblPaciente.Location = new Point(3, 10);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(64, 20);
            lblPaciente.TabIndex = 0;
            lblPaciente.Text = "Paciente";
            // 
            // cboPaciente
            // 
            cboPaciente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboPaciente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaciente.Location = new Point(183, 6);
            cboPaciente.MaxDropDownItems = 12;
            cboPaciente.Name = "cboPaciente";
            cboPaciente.Size = new Size(714, 28);
            cboPaciente.TabIndex = 1;
            // 
            // lblEstado
            // 
            lblEstado.Anchor = AnchorStyles.Left;
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(3, 50);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(54, 20);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Estado";
            // 
            // cboEstado
            // 
            cboEstado.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Location = new Point(183, 46);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(714, 28);
            cboEstado.TabIndex = 3;
            // 
            // lblMotivoConsulta
            // 
            lblMotivoConsulta.Anchor = AnchorStyles.Left;
            lblMotivoConsulta.AutoSize = true;
            lblMotivoConsulta.Location = new Point(3, 90);
            lblMotivoConsulta.Name = "lblMotivoConsulta";
            lblMotivoConsulta.Size = new Size(136, 20);
            lblMotivoConsulta.TabIndex = 4;
            lblMotivoConsulta.Text = "Motivo de consulta";
            // 
            // txtMotivoConsulta
            // 
            txtMotivoConsulta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMotivoConsulta.Location = new Point(183, 86);
            txtMotivoConsulta.Name = "txtMotivoConsulta";
            txtMotivoConsulta.PlaceholderText = "Ej.: control, dolor abdominal, seguimiento…";
            txtMotivoConsulta.Size = new Size(714, 27);
            txtMotivoConsulta.TabIndex = 5;
            // 
            // lblFechaHora
            // 
            lblFechaHora.Anchor = AnchorStyles.Left;
            lblFechaHora.AutoSize = true;
            lblFechaHora.Location = new Point(3, 130);
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new Size(92, 20);
            lblFechaHora.TabIndex = 6;
            lblFechaHora.Text = "Fecha y hora";
            // 
            // dtpFechaHora
            // 
            dtpFechaHora.Anchor = AnchorStyles.Left;
            dtpFechaHora.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy - HH:mm";
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.Location = new Point(183, 126);
            dtpFechaHora.Name = "dtpFechaHora";
            dtpFechaHora.ShowUpDown = true;
            dtpFechaHora.Size = new Size(200, 27);
            dtpFechaHora.TabIndex = 7;
            // 
            // lblImpDiag
            // 
            lblImpDiag.Anchor = AnchorStyles.Left;
            lblImpDiag.AutoSize = true;
            lblImpDiag.Location = new Point(3, 190);
            lblImpDiag.Name = "lblImpDiag";
            lblImpDiag.Size = new Size(156, 20);
            lblImpDiag.TabIndex = 8;
            lblImpDiag.Text = "Impresión diagnóstica";
            // 
            // txtImpresionDiag
            // 
            txtImpresionDiag.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtImpresionDiag.Location = new Point(183, 186);
            txtImpresionDiag.Multiline = true;
            txtImpresionDiag.Name = "txtImpresionDiag";
            txtImpresionDiag.ScrollBars = ScrollBars.Vertical;
            txtImpresionDiag.Size = new Size(714, 27);
            txtImpresionDiag.TabIndex = 9;
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.Anchor = AnchorStyles.Left;
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Location = new Point(3, 270);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(89, 20);
            lblDiagnostico.TabIndex = 10;
            lblDiagnostico.Text = "Diagnóstico";
            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDiagnostico.Location = new Point(183, 266);
            txtDiagnostico.Multiline = true;
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.ScrollBars = ScrollBars.Vertical;
            txtDiagnostico.Size = new Size(714, 27);
            txtDiagnostico.TabIndex = 11;
            // 
            // lblIndicaciones
            // 
            lblIndicaciones.Anchor = AnchorStyles.Left;
            lblIndicaciones.AutoSize = true;
            lblIndicaciones.Location = new Point(3, 350);
            lblIndicaciones.Name = "lblIndicaciones";
            lblIndicaciones.Size = new Size(91, 20);
            lblIndicaciones.TabIndex = 12;
            lblIndicaciones.Text = "Indicaciones";
            // 
            // txtIndicaciones
            // 
            txtIndicaciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtIndicaciones.Location = new Point(183, 346);
            txtIndicaciones.Multiline = true;
            txtIndicaciones.Name = "txtIndicaciones";
            txtIndicaciones.ScrollBars = ScrollBars.Vertical;
            txtIndicaciones.Size = new Size(714, 27);
            txtIndicaciones.TabIndex = 13;
            // 
            // lblAntecedentes
            // 
            lblAntecedentes.Anchor = AnchorStyles.Left;
            lblAntecedentes.AutoSize = true;
            lblAntecedentes.Location = new Point(3, 430);
            lblAntecedentes.Name = "lblAntecedentes";
            lblAntecedentes.Size = new Size(99, 20);
            lblAntecedentes.TabIndex = 14;
            lblAntecedentes.Text = "Antecedentes";
            // 
            // txtAntecedentes
            // 
            txtAntecedentes.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtAntecedentes.Location = new Point(183, 426);
            txtAntecedentes.Multiline = true;
            txtAntecedentes.Name = "txtAntecedentes";
            txtAntecedentes.ScrollBars = ScrollBars.Vertical;
            txtAntecedentes.Size = new Size(714, 27);
            txtAntecedentes.TabIndex = 15;
            // 
            // lblEvolucion
            // 
            lblEvolucion.Anchor = AnchorStyles.Left;
            lblEvolucion.AutoSize = true;
            lblEvolucion.Location = new Point(3, 510);
            lblEvolucion.Name = "lblEvolucion";
            lblEvolucion.Size = new Size(73, 20);
            lblEvolucion.TabIndex = 16;
            lblEvolucion.Text = "Evolución";
            // 
            // txtEvolucion
            // 
            txtEvolucion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEvolucion.Location = new Point(183, 506);
            txtEvolucion.Multiline = true;
            txtEvolucion.Name = "txtEvolucion";
            txtEvolucion.ScrollBars = ScrollBars.Vertical;
            txtEvolucion.Size = new Size(714, 27);
            txtEvolucion.TabIndex = 17;
            // 
            // lblImpGral
            // 
            lblImpGral.Anchor = AnchorStyles.Left;
            lblImpGral.AutoSize = true;
            lblImpGral.Location = new Point(3, 590);
            lblImpGral.Name = "lblImpGral";
            lblImpGral.Size = new Size(129, 20);
            lblImpGral.TabIndex = 18;
            lblImpGral.Text = "Impresión general";
            // 
            // txtImpresionGral
            // 
            txtImpresionGral.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtImpresionGral.Location = new Point(183, 586);
            txtImpresionGral.Multiline = true;
            txtImpresionGral.Name = "txtImpresionGral";
            txtImpresionGral.ScrollBars = ScrollBars.Vertical;
            txtImpresionGral.Size = new Size(714, 27);
            txtImpresionGral.TabIndex = 19;
            // 
            // lblExamenes
            // 
            lblExamenes.Anchor = AnchorStyles.Left;
            lblExamenes.AutoSize = true;
            lblExamenes.Location = new Point(3, 670);
            lblExamenes.Name = "lblExamenes";
            lblExamenes.Size = new Size(75, 20);
            lblExamenes.TabIndex = 20;
            lblExamenes.Text = "Exámenes";
            // 
            // txtExamenes
            // 
            txtExamenes.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtExamenes.Location = new Point(183, 666);
            txtExamenes.Multiline = true;
            txtExamenes.Name = "txtExamenes";
            txtExamenes.ScrollBars = ScrollBars.Vertical;
            txtExamenes.Size = new Size(714, 27);
            txtExamenes.TabIndex = 21;
            // 
            // lblTipoConsulta
            // 
            lblTipoConsulta.Anchor = AnchorStyles.Left;
            lblTipoConsulta.AutoSize = true;
            lblTipoConsulta.Location = new Point(3, 740);
            lblTipoConsulta.Name = "lblTipoConsulta";
            lblTipoConsulta.Size = new Size(119, 20);
            lblTipoConsulta.TabIndex = 22;
            lblTipoConsulta.Text = "Tipo de consulta";
            // 
            // txtTipoConsulta
            // 
            txtTipoConsulta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTipoConsulta.Location = new Point(183, 736);
            txtTipoConsulta.Name = "txtTipoConsulta";
            txtTipoConsulta.Size = new Size(714, 27);
            txtTipoConsulta.TabIndex = 23;
            // 
            // footerPanel
            // 
            footerPanel.Controls.Add(bGuardar);
            footerPanel.Controls.Add(bCancelar);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(24, 640);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(0, 8, 0, 0);
            footerPanel.Size = new Size(932, 64);
            footerPanel.TabIndex = 0;
            // 
            // bGuardar
            // 
            bGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bGuardar.AutoSize = true;
            bGuardar.Location = new Point(1014, 12);
            bGuardar.Name = "bGuardar";
            bGuardar.Size = new Size(120, 36);
            bGuardar.TabIndex = 0;
            bGuardar.Text = "Guardar";
            // 
            // bCancelar
            // 
            bCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bCancelar.AutoSize = true;
            bCancelar.Location = new Point(1014, 12);
            bCancelar.Name = "bCancelar";
            bCancelar.Size = new Size(120, 36);
            bCancelar.TabIndex = 1;
            bCancelar.Text = "Cancelar";
            // 
            // FormHC
            // 
            AcceptButton = bGuardar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            CancelButton = bCancelar;
            ClientSize = new Size(980, 720);
            ControlBox = false;
            Controls.Add(footerPanel);
            Controls.Add(grpDatos);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormHC";
            Padding = new Padding(24, 16, 24, 16);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Historia clínica";
            Load += FormHC_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).EndInit();
            grpDatos.ResumeLayout(false);
            grid.ResumeLayout(false);
            grid.PerformLayout();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}

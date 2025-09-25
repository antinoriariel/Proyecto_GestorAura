namespace CapaPresentacion.Formularios
{
    partial class FormHC
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cboPaciente = new ComboBox();
            lblPaciente = new Label();
            lblAntecedentes = new Label();
            lblDiagnostico = new Label();
            textBox1 = new TextBox();
            txtDiagnostico = new TextBox();
            txtImpresionDiag = new TextBox();
            txtEvolución = new TextBox();
            label3 = new Label();
            lblEvolucion = new Label();
            lblIndicaciones = new Label();
            lblImpresionGral = new Label();
            lblExamenes = new Label();
            lblTipoConsulta = new Label();
            txtIndicaciones = new TextBox();
            txtImpresionGral = new TextBox();
            txtExamenes = new TextBox();
            txtTipoConsulta = new TextBox();
            cboEstado = new ComboBox();
            lblEstado = new Label();
            dtpFechaHora = new DateTimePicker();
            label1 = new Label();
            lblHc = new Label();
            label2 = new Label();
            txtMdc = new TextBox();
            bCancelar = new Button();
            bGuardar = new Button();
            SuspendLayout();
            // 
            // cboPaciente
            // 
            cboPaciente.FormattingEnabled = true;
            cboPaciente.Location = new Point(218, 81);
            cboPaciente.Name = "cboPaciente";
            cboPaciente.Size = new Size(151, 28);
            cboPaciente.TabIndex = 0;
            // 
            // lblPaciente
            // 
            lblPaciente.AutoSize = true;
            lblPaciente.Location = new Point(135, 84);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(64, 20);
            lblPaciente.TabIndex = 2;
            lblPaciente.Text = "Paciente";
            // 
            // lblAntecedentes
            // 
            lblAntecedentes.AutoSize = true;
            lblAntecedentes.Location = new Point(106, 422);
            lblAntecedentes.Name = "lblAntecedentes";
            lblAntecedentes.Size = new Size(99, 20);
            lblAntecedentes.TabIndex = 3;
            lblAntecedentes.Text = "Antecedentes";
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Location = new Point(109, 329);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(89, 20);
            lblDiagnostico.TabIndex = 4;
            lblDiagnostico.Text = "Diagnostico";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(219, 422);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(288, 27);
            textBox1.TabIndex = 5;
            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Location = new Point(219, 329);
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.Size = new Size(288, 27);
            txtDiagnostico.TabIndex = 6;
            // 
            // txtImpresionDiag
            // 
            txtImpresionDiag.Location = new Point(219, 283);
            txtImpresionDiag.Name = "txtImpresionDiag";
            txtImpresionDiag.Size = new Size(288, 27);
            txtImpresionDiag.TabIndex = 7;
            // 
            // txtEvolución
            // 
            txtEvolución.Location = new Point(219, 468);
            txtEvolución.Name = "txtEvolución";
            txtEvolución.Size = new Size(288, 27);
            txtEvolución.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 283);
            label3.Name = "label3";
            label3.Size = new Size(159, 20);
            label3.TabIndex = 9;
            label3.Text = "Impresion Diagnostico";
            label3.Click += label3_Click;
            // 
            // lblEvolucion
            // 
            lblEvolucion.AutoSize = true;
            lblEvolucion.Location = new Point(126, 471);
            lblEvolucion.Name = "lblEvolucion";
            lblEvolucion.Size = new Size(73, 20);
            lblEvolucion.TabIndex = 10;
            lblEvolucion.Text = "Evolución";
            // 
            // lblIndicaciones
            // 
            lblIndicaciones.AutoSize = true;
            lblIndicaciones.Location = new Point(114, 383);
            lblIndicaciones.Name = "lblIndicaciones";
            lblIndicaciones.Size = new Size(91, 20);
            lblIndicaciones.TabIndex = 11;
            lblIndicaciones.Text = "Indicaciones";
            // 
            // lblImpresionGral
            // 
            lblImpresionGral.AutoSize = true;
            lblImpresionGral.Location = new Point(83, 514);
            lblImpresionGral.Name = "lblImpresionGral";
            lblImpresionGral.Size = new Size(130, 20);
            lblImpresionGral.TabIndex = 12;
            lblImpresionGral.Text = "Impresion General";
            // 
            // lblExamenes
            // 
            lblExamenes.AutoSize = true;
            lblExamenes.Location = new Point(114, 561);
            lblExamenes.Name = "lblExamenes";
            lblExamenes.Size = new Size(75, 20);
            lblExamenes.TabIndex = 13;
            lblExamenes.Text = "Examenes";
            // 
            // lblTipoConsulta
            // 
            lblTipoConsulta.AutoSize = true;
            lblTipoConsulta.Location = new Point(105, 603);
            lblTipoConsulta.Name = "lblTipoConsulta";
            lblTipoConsulta.Size = new Size(100, 20);
            lblTipoConsulta.TabIndex = 14;
            lblTipoConsulta.Text = "Tipo Consulta";
            // 
            // txtIndicaciones
            // 
            txtIndicaciones.Location = new Point(219, 376);
            txtIndicaciones.Name = "txtIndicaciones";
            txtIndicaciones.Size = new Size(288, 27);
            txtIndicaciones.TabIndex = 15;
            // 
            // txtImpresionGral
            // 
            txtImpresionGral.Location = new Point(219, 514);
            txtImpresionGral.Name = "txtImpresionGral";
            txtImpresionGral.Size = new Size(288, 27);
            txtImpresionGral.TabIndex = 16;
            // 
            // txtExamenes
            // 
            txtExamenes.Location = new Point(219, 561);
            txtExamenes.Name = "txtExamenes";
            txtExamenes.Size = new Size(288, 27);
            txtExamenes.TabIndex = 17;
            // 
            // txtTipoConsulta
            // 
            txtTipoConsulta.Location = new Point(219, 600);
            txtTipoConsulta.Name = "txtTipoConsulta";
            txtTipoConsulta.Size = new Size(288, 27);
            txtTipoConsulta.TabIndex = 18;
            // 
            // cboEstado
            // 
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(218, 133);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(151, 28);
            cboEstado.TabIndex = 19;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(131, 141);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(54, 20);
            lblEstado.TabIndex = 20;
            lblEstado.Text = "Estado";
            // 
            // dtpFechaHora
            // 
            dtpFechaHora.Location = new Point(218, 234);
            dtpFechaHora.Name = "dtpFechaHora";
            dtpFechaHora.Size = new Size(289, 27);
            dtpFechaHora.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 234);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 22;
            label1.Text = "Fecha ";
            // 
            // lblHc
            // 
            lblHc.AutoSize = true;
            lblHc.Location = new Point(271, 20);
            lblHc.Name = "lblHc";
            lblHc.Size = new Size(131, 20);
            lblHc.TabIndex = 23;
            lblHc.Text = "HISTORIA CLINICA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 187);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 24;
            label2.Text = "Motivo Consulta";
            // 
            // txtMdc
            // 
            txtMdc.Location = new Point(219, 184);
            txtMdc.Name = "txtMdc";
            txtMdc.Size = new Size(288, 27);
            txtMdc.TabIndex = 25;
            // 
            // bCancelar
            // 
            bCancelar.Location = new Point(359, 668);
            bCancelar.Name = "bCancelar";
            bCancelar.Size = new Size(119, 41);
            bCancelar.TabIndex = 26;
            bCancelar.Text = "Cancelar";
            bCancelar.UseVisualStyleBackColor = true;
            // 
            // bGuardar
            // 
            bGuardar.Location = new Point(158, 668);
            bGuardar.Name = "bGuardar";
            bGuardar.Size = new Size(113, 41);
            bGuardar.TabIndex = 27;
            bGuardar.Text = "Guardar";
            bGuardar.UseVisualStyleBackColor = true;
            // 
            // FormHC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 736);
            ControlBox = false;
            Controls.Add(bGuardar);
            Controls.Add(bCancelar);
            Controls.Add(txtMdc);
            Controls.Add(label2);
            Controls.Add(lblHc);
            Controls.Add(label1);
            Controls.Add(dtpFechaHora);
            Controls.Add(lblEstado);
            Controls.Add(cboEstado);
            Controls.Add(txtTipoConsulta);
            Controls.Add(txtExamenes);
            Controls.Add(txtImpresionGral);
            Controls.Add(txtIndicaciones);
            Controls.Add(lblTipoConsulta);
            Controls.Add(lblExamenes);
            Controls.Add(lblImpresionGral);
            Controls.Add(lblIndicaciones);
            Controls.Add(lblEvolucion);
            Controls.Add(label3);
            Controls.Add(txtEvolución);
            Controls.Add(txtImpresionDiag);
            Controls.Add(txtDiagnostico);
            Controls.Add(textBox1);
            Controls.Add(lblDiagnostico);
            Controls.Add(lblAntecedentes);
            Controls.Add(lblPaciente);
            Controls.Add(cboPaciente);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormHC";
            Load += FormHC_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private ComboBox cboPaciente;
        private Label lblPaciente;
        private Label lblAntecedentes;
        private Label lblDiagnostico;
        private TextBox textBox1;
        private TextBox txtDiagnostico;
        private TextBox txtImpresionDiag;
        private TextBox txtEvolución;
        private Label label3;
        private Label lblEvolucion;
        private Label lblIndicaciones;
        private Label lblImpresionGral;
        private Label lblExamenes;
        private Label lblTipoConsulta;
        private TextBox txtIndicaciones;
        private TextBox txtImpresionGral;
        private TextBox txtExamenes;
        private TextBox txtTipoConsulta;
        private ComboBox cboEstado;
        private Label lblEstado;
        private DateTimePicker dtpFechaHora;
        private Label label1;
        private Label lblHc;
        private Label label2;
        private TextBox txtMdc;
        private Button bCancelar;
        private Button bGuardar;
    }
}

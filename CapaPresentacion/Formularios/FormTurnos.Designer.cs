namespace CapaPresentacion.Formularios
{
    partial class FormTurnos
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            txtMotivo = new TextBox();
            label1 = new Label();
            lblPaciente = new Label();
            lblMedico = new Label();
            dtpFecha = new DateTimePicker();
            label2 = new Label();
            lblHora = new Label();
            dtpHora = new DateTimePicker();
            lblMotivo = new Label();
            txtObs = new TextBox();
            lblObs = new Label();
            bGuardar = new Button();
            bCancelar = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(135, 86);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(177, 28);
            comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(135, 139);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(177, 28);
            comboBox2.TabIndex = 1;
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(135, 298);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(265, 27);
            txtMotivo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(188, 27);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 3;
            label1.Text = "AGENDA TURNO";
            // 
            // lblPaciente
            // 
            lblPaciente.AutoSize = true;
            lblPaciente.Location = new Point(52, 89);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(64, 20);
            lblPaciente.TabIndex = 4;
            lblPaciente.Text = "Paciente";
            // 
            // lblMedico
            // 
            lblMedico.AutoSize = true;
            lblMedico.Location = new Point(57, 142);
            lblMedico.Name = "lblMedico";
            lblMedico.Size = new Size(59, 20);
            lblMedico.TabIndex = 5;
            lblMedico.Text = "Medico";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(135, 191);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(299, 27);
            dtpFecha.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 196);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 7;
            label2.Text = "Fecha ";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(66, 250);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(42, 20);
            lblHora.TabIndex = 8;
            lblHora.Text = "Hora";
            // 
            // dtpHora
            // 
            dtpHora.Location = new Point(135, 245);
            dtpHora.Name = "dtpHora";
            dtpHora.Size = new Size(299, 27);
            dtpHora.TabIndex = 9;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(60, 298);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(56, 20);
            lblMotivo.TabIndex = 10;
            lblMotivo.Text = "Motivo";
            // 
            // txtObs
            // 
            txtObs.Location = new Point(135, 351);
            txtObs.Name = "txtObs";
            txtObs.Size = new Size(265, 27);
            txtObs.TabIndex = 11;
            // 
            // lblObs
            // 
            lblObs.AutoSize = true;
            lblObs.Location = new Point(23, 351);
            lblObs.Name = "lblObs";
            lblObs.Size = new Size(105, 20);
            lblObs.TabIndex = 12;
            lblObs.Text = "Observaciones";
            // 
            // bGuardar
            // 
            bGuardar.Location = new Point(123, 415);
            bGuardar.Name = "bGuardar";
            bGuardar.Size = new Size(116, 37);
            bGuardar.TabIndex = 13;
            bGuardar.Text = "Guardar";
            bGuardar.UseVisualStyleBackColor = true;
            // 
            // bCancelar
            // 
            bCancelar.Location = new Point(277, 415);
            bCancelar.Name = "bCancelar";
            bCancelar.Size = new Size(112, 37);
            bCancelar.TabIndex = 14;
            bCancelar.Text = "Cancelar";
            bCancelar.UseVisualStyleBackColor = true;
            // 
            // FormTurnos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 480);
            ControlBox = false;
            Controls.Add(bCancelar);
            Controls.Add(bGuardar);
            Controls.Add(lblObs);
            Controls.Add(txtObs);
            Controls.Add(lblMotivo);
            Controls.Add(dtpHora);
            Controls.Add(lblHora);
            Controls.Add(label2);
            Controls.Add(dtpFecha);
            Controls.Add(lblMedico);
            Controls.Add(lblPaciente);
            Controls.Add(label1);
            Controls.Add(txtMotivo);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTurnos";
            ResumeLayout(false);
            PerformLayout();
        }
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private TextBox txtMotivo;
        private Label label1;
        private Label lblPaciente;
        private Label lblMedico;
        private DateTimePicker dtpFecha;
        private Label label2;
        private Label lblHora;
        private DateTimePicker dtpHora;
        private Label lblMotivo;
        private TextBox txtObs;
        private Label lblObs;
        private Button bGuardar;
        private Button bCancelar;
    }
}

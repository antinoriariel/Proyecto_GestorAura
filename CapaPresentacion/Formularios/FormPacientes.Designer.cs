
namespace CapaPresentacion.Formularios
{
    partial class FormPacientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            lblNombre = new Label();
            lblApellido = new Label();
            label2 = new Label();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            cboSexo = new ComboBox();
            lblSexo = new Label();
            dtpNacimiento = new DateTimePicker();
            lblFechaNacimiento = new Label();
            lblTelefeno = new Label();
            txtTelefono = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDirección = new Label();
            txtDireccion = new TextBox();
            cboLocalidad = new ComboBox();
            lblLocalidad = new Label();
            cboGrupo = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            txtAlergias = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(126, 74);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(315, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(55, 77);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            lblNombre.Click += lblNombre_Click;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(53, 121);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 160);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 4;
            label2.Text = "Dni:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(126, 113);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(315, 23);
            txtApellido.TabIndex = 6;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(126, 157);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(315, 23);
            txtDni.TabIndex = 7;
            // 
            // cboSexo
            // 
            cboSexo.FormattingEnabled = true;
            cboSexo.Location = new Point(165, 198);
            cboSexo.Name = "cboSexo";
            cboSexo.Size = new Size(200, 23);
            cboSexo.TabIndex = 8;
            // 
            // lblSexo
            // 
            lblSexo.AutoSize = true;
            lblSexo.Location = new Point(53, 201);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(34, 15);
            lblSexo.TabIndex = 9;
            lblSexo.Text = "Sexo:";
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.Location = new Point(165, 231);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(200, 23);
            dtpNacimiento.TabIndex = 10;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(53, 237);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(106, 15);
            lblFechaNacimiento.TabIndex = 11;
            lblFechaNacimiento.Text = "Fecha Nacimiento:";
            // 
            // lblTelefeno
            // 
            lblTelefeno.AllowDrop = true;
            lblTelefeno.AutoSize = true;
            lblTelefeno.Location = new Point(53, 280);
            lblTelefeno.Name = "lblTelefeno";
            lblTelefeno.Size = new Size(56, 15);
            lblTelefeno.TabIndex = 12;
            lblTelefeno.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(126, 277);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(315, 23);
            txtTelefono.TabIndex = 13;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(53, 330);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(126, 327);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(315, 23);
            txtEmail.TabIndex = 15;
            // 
            // lblDirección
            // 
            lblDirección.AutoSize = true;
            lblDirección.Location = new Point(55, 380);
            lblDirección.Name = "lblDirección";
            lblDirección.Size = new Size(60, 15);
            lblDirección.TabIndex = 16;
            lblDirección.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(126, 377);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(315, 23);
            txtDireccion.TabIndex = 17;
            // 
            // cboLocalidad
            // 
            cboLocalidad.FormattingEnabled = true;
            cboLocalidad.Location = new Point(165, 422);
            cboLocalidad.Name = "cboLocalidad";
            cboLocalidad.Size = new Size(200, 23);
            cboLocalidad.TabIndex = 18;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(53, 425);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(61, 15);
            lblLocalidad.TabIndex = 19;
            lblLocalidad.Text = "Localidad:";
            // 
            // cboGrupo
            // 
            cboGrupo.FormattingEnabled = true;
            cboGrupo.Location = new Point(165, 464);
            cboGrupo.Name = "cboGrupo";
            cboGrupo.Size = new Size(200, 23);
            cboGrupo.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 464);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 21;
            label1.Text = "Grupo Sanguineo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 505);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 22;
            label3.Text = "Alergias:";
            // 
            // txtAlergias
            // 
            txtAlergias.Location = new Point(126, 502);
            txtAlergias.Name = "txtAlergias";
            txtAlergias.Size = new Size(315, 23);
            txtAlergias.TabIndex = 23;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(95, 569);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(114, 41);
            btnNuevo.TabIndex = 24;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(246, 570);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(119, 41);
            btnGuardar.TabIndex = 25;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(389, 571);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 40);
            btnCancelar.TabIndex = 26;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(275, 29);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 27;
            label4.Text = "Nuevo Paciente";
            // 
            // FormPacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 646);
            ControlBox = false;
            Controls.Add(label4);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtAlergias);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(cboGrupo);
            Controls.Add(lblLocalidad);
            Controls.Add(cboLocalidad);
            Controls.Add(txtDireccion);
            Controls.Add(lblDirección);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefeno);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(dtpNacimiento);
            Controls.Add(lblSexo);
            Controls.Add(cboSexo);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(label2);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPacientes";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblApellido;
        private Label label2;
        private TextBox txtApellido;
        private TextBox txtDni;
        private ComboBox cboSexo;
        private Label lblSexo;
        private DateTimePicker dtpNacimiento;
        private Label lblFechaNacimiento;
        private Label lblTelefeno;
        private TextBox txtTelefono;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblDirección;
        private TextBox txtDireccion;
        private ComboBox cboLocalidad;
        private Label lblLocalidad;
        private ComboBox cboGrupo;
        private Label label1;
        private Label label3;
        private TextBox txtAlergias;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label label4;
    }
}

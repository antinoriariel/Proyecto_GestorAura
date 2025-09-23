namespace CapaPresentacion
{
    partial class FormCargaUsuarios
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblEmail;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private Label lblFechaNacimiento;
        private Label lblTelefono;
        private Label lblRol;

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private TextBox txtTelefono;
        private DateTimePicker dtpFechaNacimiento;
        private ComboBox cmbRol;
        private Button btnGuardar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUsername = new Label();
            lblPassword = new Label();
            lblEmail = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDni = new Label();
            lblFechaNacimiento = new Label();
            lblTelefono = new Label();
            lblRol = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            txtTelefono = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            cmbRol = new ComboBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(30, 30);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Usuario:";
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(30, 70);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Contraseña:";
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(30, 110);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(30, 150);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(100, 23);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.Location = new Point(30, 190);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(100, 23);
            lblApellido.TabIndex = 8;
            lblApellido.Text = "Apellido:";
            // 
            // lblDni
            // 
            lblDni.Location = new Point(30, 230);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(100, 23);
            lblDni.TabIndex = 10;
            lblDni.Text = "DNI:";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.Location = new Point(30, 270);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(100, 23);
            lblFechaNacimiento.TabIndex = 12;
            lblFechaNacimiento.Text = "Fecha Nac.:";
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(30, 310);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(100, 23);
            lblTelefono.TabIndex = 14;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblRol
            // 
            lblRol.Location = new Point(30, 350);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(100, 23);
            lblRol.TabIndex = 16;
            lblRol.Text = "Rol:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(150, 30);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(150, 70);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(150, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(150, 150);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 7;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(150, 190);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 23);
            txtApellido.TabIndex = 9;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(150, 230);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(200, 23);
            txtDni.TabIndex = 11;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(150, 310);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(200, 23);
            txtTelefono.TabIndex = 15;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(150, 270);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 13;
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Items.AddRange(new object[] { "medico", "secretaria", "administrador" });
            cmbRol.Location = new Point(150, 350);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(200, 23);
            cmbRol.TabIndex = 17;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(150, 400);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 18;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormCargaUsuarios
            // 
            ClientSize = new Size(400, 480);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblDni);
            Controls.Add(txtDni);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblRol);
            Controls.Add(cmbRol);
            Controls.Add(btnGuardar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCargaUsuarios";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Carga de Usuarios";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

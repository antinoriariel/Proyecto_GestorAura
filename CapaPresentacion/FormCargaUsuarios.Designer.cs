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
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.lblEmail = new Label();
            this.lblNombre = new Label();
            this.lblApellido = new Label();
            this.lblDni = new Label();
            this.lblFechaNacimiento = new Label();
            this.lblTelefono = new Label();
            this.lblRol = new Label();

            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.txtEmail = new TextBox();
            this.txtNombre = new TextBox();
            this.txtApellido = new TextBox();
            this.txtDni = new TextBox();
            this.txtTelefono = new TextBox();

            this.dtpFechaNacimiento = new DateTimePicker();
            this.cmbRol = new ComboBox();
            this.btnGuardar = new Button();

            this.SuspendLayout();

            // Labels
            this.lblUsername.Text = "Usuario:";
            this.lblUsername.Location = new System.Drawing.Point(30, 30);

            this.lblPassword.Text = "Contraseña:";
            this.lblPassword.Location = new System.Drawing.Point(30, 70);

            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(30, 110);

            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(30, 150);

            this.lblApellido.Text = "Apellido:";
            this.lblApellido.Location = new System.Drawing.Point(30, 190);

            this.lblDni.Text = "DNI:";
            this.lblDni.Location = new System.Drawing.Point(30, 230);

            this.lblFechaNacimiento.Text = "Fecha Nac.:";
            this.lblFechaNacimiento.Location = new System.Drawing.Point(30, 270);

            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Location = new System.Drawing.Point(30, 310);

            this.lblRol.Text = "Rol:";
            this.lblRol.Location = new System.Drawing.Point(30, 350);

            // Textboxes
            this.txtUsername.Location = new System.Drawing.Point(150, 30);
            this.txtUsername.Width = 200;

            this.txtPassword.Location = new System.Drawing.Point(150, 70);
            this.txtPassword.Width = 200;
            this.txtPassword.PasswordChar = '*';

            this.txtEmail.Location = new System.Drawing.Point(150, 110);
            this.txtEmail.Width = 200;

            this.txtNombre.Location = new System.Drawing.Point(150, 150);
            this.txtNombre.Width = 200;

            this.txtApellido.Location = new System.Drawing.Point(150, 190);
            this.txtApellido.Width = 200;

            this.txtDni.Location = new System.Drawing.Point(150, 230);
            this.txtDni.Width = 200;

            this.dtpFechaNacimiento.Location = new System.Drawing.Point(150, 270);
            this.dtpFechaNacimiento.Width = 200;

            this.txtTelefono.Location = new System.Drawing.Point(150, 310);
            this.txtTelefono.Width = 200;

            this.cmbRol.Location = new System.Drawing.Point(150, 350);
            this.cmbRol.Width = 200;
            this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRol.Items.AddRange(new object[] { "medico", "secretaria", "administrador" });

            // Botón Guardar
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(150, 400);
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(400, 480);
            this.Controls.AddRange(new Control[]
            {
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                lblEmail, txtEmail,
                lblNombre, txtNombre,
                lblApellido, txtApellido,
                lblDni, txtDni,
                lblFechaNacimiento, dtpFechaNacimiento,
                lblTelefono, txtTelefono,
                lblRol, cmbRol,
                btnGuardar
            });

            this.Text = "Carga de Usuarios";
            this.ResumeLayout(false);
        }
    }
}

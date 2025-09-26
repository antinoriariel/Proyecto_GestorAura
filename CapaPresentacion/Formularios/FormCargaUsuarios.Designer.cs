namespace CapaPresentacion
{
    partial class FormCargaUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        private GroupBox grpDatos;
        private TableLayoutPanel grid;

        private Label lblUsername;
        private TextBox txtUsername;

        private Label lblPassword;
        private TextBox txtPassword;

        private Label lblEmail;
        private TextBox txtEmail;

        private Label lblNombre;
        private TextBox txtNombre;

        private Label lblApellido;
        private TextBox txtApellido;

        private Label lblDni;
        private TextBox txtDni;

        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;

        private Label lblTelefono;
        private TextBox txtTelefono;

        private Label lblRol;
        private ComboBox cmbRol;

        private Panel footerPanel;
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
            headerPanel = new Panel();
            picHeader = new PictureBox();
            lblHeader = new Label();
            grpDatos = new GroupBox();
            grid = new TableLayoutPanel();

            lblUsername = new Label();
            txtUsername = new TextBox();

            lblPassword = new Label();
            txtPassword = new TextBox();

            lblEmail = new Label();
            txtEmail = new TextBox();

            lblNombre = new Label();
            txtNombre = new TextBox();

            lblApellido = new Label();
            txtApellido = new TextBox();

            lblDni = new Label();
            txtDni = new TextBox();

            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();

            lblTelefono = new Label();
            txtTelefono = new TextBox();

            lblRol = new Label();
            cmbRol = new ComboBox();

            footerPanel = new Panel();
            btnGuardar = new Button();
            btnCancelar = new Button();

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
            headerPanel.Location = new Point(21, 12);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(676, 48);
            headerPanel.TabIndex = 0;
            // 
            // picHeader
            // 
            picHeader.Image = Properties.Resources.userAddIcon; // 👈 asegúrate de tener este recurso
            picHeader.Location = new Point(14, 9);
            picHeader.Name = "picHeader";
            picHeader.Size = new Size(35, 30);
            picHeader.SizeMode = PictureBoxSizeMode.Zoom;
            picHeader.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(56, 14);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(230, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Carga de usuarios";
            // 
            // grpDatos
            // 
            grpDatos.BackColor = Color.White;
            grpDatos.Controls.Add(grid);
            grpDatos.Dock = DockStyle.Top;
            grpDatos.Location = new Point(21, 60);
            grpDatos.Name = "grpDatos";
            grpDatos.Padding = new Padding(14, 12, 14, 12);
            grpDatos.Size = new Size(676, 400); // 👈 altura ajustada
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del usuario";
            // 
            // grid
            // 
            grid.ColumnCount = 2;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            grid.RowCount = 10;
            grid.RowStyles.Clear();
            for (int i = 0; i < 9; i++)
                grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            grid.Controls.Add(lblUsername, 0, 0);
            grid.Controls.Add(txtUsername, 1, 0);

            grid.Controls.Add(lblPassword, 0, 1);
            grid.Controls.Add(txtPassword, 1, 1);

            grid.Controls.Add(lblEmail, 0, 2);
            grid.Controls.Add(txtEmail, 1, 2);

            grid.Controls.Add(lblNombre, 0, 3);
            grid.Controls.Add(txtNombre, 1, 3);

            grid.Controls.Add(lblApellido, 0, 4);
            grid.Controls.Add(txtApellido, 1, 4);

            grid.Controls.Add(lblDni, 0, 5);
            grid.Controls.Add(txtDni, 1, 5);

            grid.Controls.Add(lblFechaNacimiento, 0, 6);
            grid.Controls.Add(dtpFechaNacimiento, 1, 6);

            grid.Controls.Add(lblTelefono, 0, 7);
            grid.Controls.Add(txtTelefono, 1, 7);

            grid.Controls.Add(lblRol, 0, 8);
            grid.Controls.Add(cmbRol, 1, 8);

            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(14, 28);
            grid.Name = "grid";
            grid.Size = new Size(648, 360);
            grid.TabIndex = 0;
            // 
            // Labels & Inputs
            // 
            lblUsername.Anchor = AnchorStyles.Left;
            lblUsername.Text = "Usuario";
            txtUsername.Dock = DockStyle.Fill;

            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.Text = "Contraseña";
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.PasswordChar = '*';

            lblEmail.Anchor = AnchorStyles.Left;
            lblEmail.Text = "Email";
            txtEmail.Dock = DockStyle.Fill;

            lblNombre.Anchor = AnchorStyles.Left;
            lblNombre.Text = "Nombre";
            txtNombre.Dock = DockStyle.Fill;

            lblApellido.Anchor = AnchorStyles.Left;
            lblApellido.Text = "Apellido";
            txtApellido.Dock = DockStyle.Fill;

            lblDni.Anchor = AnchorStyles.Left;
            lblDni.Text = "DNI";
            txtDni.Dock = DockStyle.Fill;

            lblFechaNacimiento.Anchor = AnchorStyles.Left;
            lblFechaNacimiento.Text = "Fecha de Nacimiento";
            dtpFechaNacimiento.Dock = DockStyle.Fill;
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;

            lblTelefono.Anchor = AnchorStyles.Left;
            lblTelefono.Text = "Teléfono";
            txtTelefono.Dock = DockStyle.Fill;

            lblRol.Anchor = AnchorStyles.Left;
            lblRol.Text = "Rol";
            cmbRol.Dock = DockStyle.Fill;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.IntegralHeight = false;
            cmbRol.DrawMode = DrawMode.OwnerDrawFixed;
            cmbRol.ItemHeight = 28;
            cmbRol.Font = new Font("Segoe UI", 10F);
            cmbRol.Items.AddRange(new object[] { "medico", "secretaria", "administrador" });
            cmbRol.DrawItem += cmbRol_DrawItem;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = Color.Transparent;
            footerPanel.Controls.Add(btnGuardar);
            footerPanel.Controls.Add(btnCancelar);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(21, 460);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(0, 6, 0, 0);
            footerPanel.Size = new Size(676, 48);
            footerPanel.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.AutoSize = true;
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(480, 10);
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.AutoSize = true;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(570, 10);
            btnCancelar.Click += (s, e) => this.Close();
            // 
            // FormCargaUsuarios
            // 
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(718, 520);
            ControlBox = false;
            Controls.Add(footerPanel);
            Controls.Add(grpDatos);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCargaUsuarios";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Carga de Usuarios";
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

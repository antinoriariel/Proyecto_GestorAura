namespace CapaPresentacion
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnLogin = new Button();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            imgMedic = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imgMedic).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(223, 157);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(151, 30);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += BtnLogin_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(223, 25);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(56, 19);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Usuario";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(223, 85);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 19);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(223, 47);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(151, 23);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(223, 107);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(151, 23);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // imgMedic
            // 
            imgMedic.Image = Properties.Resources.medic_1;
            imgMedic.Location = new Point(36, 12);
            imgMedic.Name = "imgMedic";
            imgMedic.Size = new Size(150, 193);
            imgMedic.SizeMode = PictureBoxSizeMode.Zoom;
            imgMedic.TabIndex = 6;
            imgMedic.TabStop = false;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(395, 218);
            Controls.Add(imgMedic);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(btnLogin);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(411, 257);
            MinimumSize = new Size(411, 257);
            Name = "loginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Medic - Inicio de sesión";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)imgMedic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private PictureBox imgMedic;
    }
}

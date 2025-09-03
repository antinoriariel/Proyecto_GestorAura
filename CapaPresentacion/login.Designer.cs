namespace CapaPresentacion
{
    partial class login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            btnClose = new Button();
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
            btnLogin.Location = new Point(254, 166);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(96, 31);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(369, 166);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(96, 31);
            btnClose.TabIndex = 1;
            btnClose.Text = "Salir";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(254, 33);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(109, 15);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Nombre de usuario";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(254, 97);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(254, 51);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(211, 23);
            txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(254, 115);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(211, 23);
            txtPassword.TabIndex = 5;
            // 
            // imgMedic
            // 
            imgMedic.Location = new Point(12, 12);
            imgMedic.Name = "imgMedic";
            imgMedic.Size = new Size(201, 208);
            imgMedic.TabIndex = 6;
            imgMedic.TabStop = false;
            imgMedic.Click += this.imgMedic_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(506, 236);
            Controls.Add(imgMedic);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(btnClose);
            Controls.Add(btnLogin);
            Margin = new Padding(3, 2, 3, 2);
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Medic - Inicio de sesión";
            ((System.ComponentModel.ISupportInitialize)imgMedic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnClose;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private PictureBox imgMedic;
    }
}

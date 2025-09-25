namespace CapaPresentacion.Controles
{
    partial class SecretariaSidebar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnTurnos;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblRolUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutUser;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecretariaSidebar));
            tableLayoutPanelMenu = new TableLayoutPanel();
            btnDashboard = new Button();
            btnPacientes = new Button();
            btnTurnos = new Button();
            btnCerrarSesion = new Button();
            userPanel = new Panel();
            tableLayoutUser = new TableLayoutPanel();
            lblRolUsuario = new Label();
            pictureBox1 = new PictureBox();
            lblUsername = new Label();
            tableLayoutPanelMenu.SuspendLayout();
            userPanel.SuspendLayout();
            tableLayoutUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelMenu
            // 
            tableLayoutPanelMenu.ColumnCount = 1;
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.Controls.Add(btnDashboard, 0, 2);
            tableLayoutPanelMenu.Controls.Add(btnPacientes, 0, 3);
            tableLayoutPanelMenu.Controls.Add(btnTurnos, 0, 4);
            tableLayoutPanelMenu.Controls.Add(btnCerrarSesion, 0, 7);
            tableLayoutPanelMenu.Controls.Add(userPanel, 0, 0);
            tableLayoutPanelMenu.Dock = DockStyle.Fill;
            tableLayoutPanelMenu.Location = new Point(0, 0);
            tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            tableLayoutPanelMenu.Padding = new Padding(5);
            tableLayoutPanelMenu.RowCount = 8;
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 152F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMenu.Size = new Size(180, 500);
            tableLayoutPanelMenu.TabIndex = 0;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Fill;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.Image = (Image)resources.GetObject("btnDashboard.Image");
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(8, 180);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(15, 0, 0, 0);
            btnDashboard.Size = new Size(164, 36);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Inicio";
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnPacientes
            // 
            btnPacientes.Dock = DockStyle.Fill;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPacientes.Image = (Image)resources.GetObject("btnPacientes.Image");
            btnPacientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnPacientes.Location = new Point(8, 222);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Padding = new Padding(15, 0, 0, 0);
            btnPacientes.Size = new Size(164, 39);
            btnPacientes.TabIndex = 1;
            btnPacientes.Text = "Pacientes";
            btnPacientes.Click += btnPacientes_Click;
            // 
            // btnTurnos
            // 
            btnTurnos.Dock = DockStyle.Fill;
            btnTurnos.FlatStyle = FlatStyle.Flat;
            btnTurnos.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTurnos.Image = (Image)resources.GetObject("btnTurnos.Image");
            btnTurnos.ImageAlign = ContentAlignment.MiddleLeft;
            btnTurnos.Location = new Point(8, 267);
            btnTurnos.Name = "btnTurnos";
            btnTurnos.Padding = new Padding(15, 0, 0, 0);
            btnTurnos.Size = new Size(164, 38);
            btnTurnos.TabIndex = 2;
            btnTurnos.Text = "Turnos";
            btnTurnos.Click += btnTurnos_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Dock = DockStyle.Fill;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarSesion.Image = (Image)resources.GetObject("btnCerrarSesion.Image");
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.Location = new Point(8, 448);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(15, 0, 0, 0);
            btnCerrarSesion.Size = new Size(164, 44);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Salir";
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // userPanel
            // 
            userPanel.BackColor = SystemColors.ControlLightLight;
            userPanel.Controls.Add(tableLayoutUser);
            userPanel.Dock = DockStyle.Fill;
            userPanel.Location = new Point(8, 8);
            userPanel.Name = "userPanel";
            userPanel.Size = new Size(164, 146);
            userPanel.TabIndex = 6;
            // 
            // tableLayoutUser
            // 
            tableLayoutUser.ColumnCount = 1;
            tableLayoutUser.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutUser.Controls.Add(lblRolUsuario, 0, 0);
            tableLayoutUser.Controls.Add(pictureBox1, 0, 1);
            tableLayoutUser.Controls.Add(lblUsername, 0, 2);
            tableLayoutUser.Dock = DockStyle.Fill;
            tableLayoutUser.Location = new Point(0, 0);
            tableLayoutUser.Name = "tableLayoutUser";
            tableLayoutUser.RowCount = 3;
            tableLayoutUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutUser.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutUser.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutUser.Size = new Size(164, 146);
            tableLayoutUser.TabIndex = 0;
            // 
            // lblRolUsuario
            // 
            lblRolUsuario.BackColor = Color.Transparent;
            lblRolUsuario.Dock = DockStyle.Fill;
            lblRolUsuario.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRolUsuario.Location = new Point(3, 0);
            lblRolUsuario.Name = "lblRolUsuario";
            lblRolUsuario.Padding = new Padding(0, 13, 0, 0);
            lblRolUsuario.Size = new Size(158, 25);
            lblRolUsuario.TabIndex = 0;
            lblRolUsuario.Text = "Secretaria";
            lblRolUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblUsername
            // 
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Dock = DockStyle.Fill;
            lblUsername.Font = new Font("Consolas", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(3, 121);
            lblUsername.Name = "lblUsername";
            lblUsername.Padding = new Padding(0, 0, 0, 12);
            lblUsername.Size = new Size(158, 25);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Nombre Secretaria";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SecretariaSidebar
            // 
            Controls.Add(tableLayoutPanelMenu);
            Name = "SecretariaSidebar";
            Size = new Size(180, 500);
            tableLayoutPanelMenu.ResumeLayout(false);
            userPanel.ResumeLayout(false);
            tableLayoutUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}
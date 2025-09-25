namespace CapaPresentacion.Controles
{
    partial class AdminSidebar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnCerrarSesion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSidebar));
            tableLayoutPanelMenu = new TableLayoutPanel();
            btnDashboard = new Button();
            btnUsuarios = new Button();
            btnReportes = new Button();
            btnConfiguracion = new Button();
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
            tableLayoutPanelMenu.Controls.Add(btnUsuarios, 0, 3);
            tableLayoutPanelMenu.Controls.Add(btnReportes, 0, 4);
            tableLayoutPanelMenu.Controls.Add(btnConfiguracion, 0, 5);
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
            // btnUsuarios
            // 
            btnUsuarios.Dock = DockStyle.Fill;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarios.Image = (Image)resources.GetObject("btnUsuarios.Image");
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(8, 222);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(15, 0, 0, 0);
            btnUsuarios.Size = new Size(164, 39);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // btnReportes
            // 
            btnReportes.Dock = DockStyle.Fill;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.Image = (Image)resources.GetObject("btnReportes.Image");
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(8, 267);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(15, 0, 0, 0);
            btnReportes.Size = new Size(164, 38);
            btnReportes.TabIndex = 2;
            btnReportes.Text = "Médicos";
            btnReportes.Click += btnReportes_Click;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.Dock = DockStyle.Fill;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfiguracion.Image = (Image)resources.GetObject("btnConfiguracion.Image");
            btnConfiguracion.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.Location = new Point(8, 311);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Padding = new Padding(15, 0, 0, 0);
            btnConfiguracion.Size = new Size(164, 39);
            btnConfiguracion.TabIndex = 3;
            btnConfiguracion.Text = "Ajustes";
            btnConfiguracion.Click += btnConfiguracion_Click;
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
            btnCerrarSesion.TabIndex = 5;
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
            lblRolUsuario.Text = "Administrador";
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
            lblUsername.Text = "Leonel Alegre";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AdminSidebar
            // 
            Controls.Add(tableLayoutPanelMenu);
            Name = "AdminSidebar";
            Size = new Size(180, 500);
            tableLayoutPanelMenu.ResumeLayout(false);
            userPanel.ResumeLayout(false);
            tableLayoutUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
        private Panel userPanel;
        private Label lblRolUsuario;
        private PictureBox pictureBox1;
        private Label lblUsername;
        private TableLayoutPanel tableLayoutUser;
    }
}

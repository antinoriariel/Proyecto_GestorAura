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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecretariaSidebar));
            tableLayoutPanelMenu = new System.Windows.Forms.TableLayoutPanel();
            btnDashboard = new System.Windows.Forms.Button();
            btnPacientes = new System.Windows.Forms.Button();
            btnTurnos = new System.Windows.Forms.Button();
            btnCerrarSesion = new System.Windows.Forms.Button();
            userPanel = new System.Windows.Forms.Panel();
            lblUsername = new System.Windows.Forms.Label();
            lblRolUsuario = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            tableLayoutPanelMenu.SuspendLayout();
            userPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelMenu
            // 
            tableLayoutPanelMenu.ColumnCount = 1;
            tableLayoutPanelMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelMenu.Controls.Add(btnDashboard, 0, 1);
            tableLayoutPanelMenu.Controls.Add(btnPacientes, 0, 2);
            tableLayoutPanelMenu.Controls.Add(btnTurnos, 0, 3);
            tableLayoutPanelMenu.Controls.Add(btnCerrarSesion, 0, 5);
            tableLayoutPanelMenu.Controls.Add(userPanel, 0, 0);
            tableLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelMenu.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            tableLayoutPanelMenu.Padding = new System.Windows.Forms.Padding(5);
            tableLayoutPanelMenu.RowCount = 6;
            tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanelMenu.Size = new System.Drawing.Size(180, 500);
            tableLayoutPanelMenu.TabIndex = 0;
            // 
            // Botones
            // 
            btnDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDashboard.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            btnDashboard.Image = (System.Drawing.Image)resources.GetObject("btnDashboard.Image");
            btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnDashboard.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnDashboard.Text = "Inicio";
            btnDashboard.Click += btnDashboard_Click;

            btnPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPacientes.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            btnPacientes.Image = (System.Drawing.Image)resources.GetObject("btnPacientes.Image");
            btnPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPacientes.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnPacientes.Text = "Pacientes";
            btnPacientes.Click += btnPacientes_Click;

            btnTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            btnTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTurnos.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            btnTurnos.Image = (System.Drawing.Image)resources.GetObject("btnTurnos.Image");
            btnTurnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnTurnos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnTurnos.Text = "Turnos";
            btnTurnos.Click += btnTurnos_Click;

            btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Fill;
            btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrarSesion.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            btnCerrarSesion.Image = (System.Drawing.Image)resources.GetObject("btnCerrarSesion.Image");
            btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCerrarSesion.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnCerrarSesion.Text = "Salir";
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // userPanel con tableLayoutUser
            // 
            userPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            userPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            userPanel.Location = new System.Drawing.Point(8, 8);
            userPanel.Name = "userPanel";
            userPanel.Size = new System.Drawing.Size(164, 146);
            userPanel.TabIndex = 6;

            var tableLayoutUser = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutUser.ColumnCount = 1;
            tableLayoutUser.RowCount = 3;
            tableLayoutUser.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));

            lblRolUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            lblRolUsuario.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold);
            lblRolUsuario.Text = "Secretaria";
            lblRolUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");

            lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            lblUsername.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            lblUsername.Text = "Nombre Secretaria";
            lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            tableLayoutUser.Controls.Add(lblRolUsuario, 0, 0);
            tableLayoutUser.Controls.Add(pictureBox1, 0, 1);
            tableLayoutUser.Controls.Add(lblUsername, 0, 2);

            userPanel.Controls.Clear();
            userPanel.Controls.Add(tableLayoutUser);

            // 
            // SecretariaSidebar
            // 
            Controls.Add(tableLayoutPanelMenu);
            Name = "SecretariaSidebar";
            Size = new System.Drawing.Size(180, 500);
            tableLayoutPanelMenu.ResumeLayout(false);
            userPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}
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
        private System.Windows.Forms.Panel panelSeparador;

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
            panelSeparador = new Panel();
            btnCerrarSesion = new Button();
            tableLayoutPanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMenu
            // 
            tableLayoutPanelMenu.ColumnCount = 1;
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.Controls.Add(btnDashboard, 0, 0);
            tableLayoutPanelMenu.Controls.Add(btnPacientes, 0, 1);
            tableLayoutPanelMenu.Controls.Add(btnTurnos, 0, 2);
            tableLayoutPanelMenu.Controls.Add(panelSeparador, 0, 3);
            tableLayoutPanelMenu.Controls.Add(btnCerrarSesion, 0, 4);
            tableLayoutPanelMenu.Dock = DockStyle.Fill;
            tableLayoutPanelMenu.Location = new Point(0, 0);
            tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            tableLayoutPanelMenu.RowCount = 5;
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMenu.Size = new Size(180, 500);
            tableLayoutPanelMenu.TabIndex = 0;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Fill;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Image = (Image)resources.GetObject("btnDashboard.Image");
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(3, 3);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(15, 0, 0, 0);
            btnDashboard.Size = new Size(174, 44);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Inicio";
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnPacientes
            // 
            btnPacientes.Dock = DockStyle.Fill;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.Image = (Image)resources.GetObject("btnPacientes.Image");
            btnPacientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnPacientes.Location = new Point(3, 53);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Padding = new Padding(15, 0, 0, 0);
            btnPacientes.Size = new Size(174, 44);
            btnPacientes.TabIndex = 1;
            btnPacientes.Text = "Pacientes";
            btnPacientes.Click += btnPacientes_Click;
            // 
            // btnTurnos
            // 
            btnTurnos.Dock = DockStyle.Fill;
            btnTurnos.FlatStyle = FlatStyle.Flat;
            btnTurnos.Image = (Image)resources.GetObject("btnTurnos.Image");
            btnTurnos.ImageAlign = ContentAlignment.MiddleLeft;
            btnTurnos.Location = new Point(3, 103);
            btnTurnos.Name = "btnTurnos";
            btnTurnos.Padding = new Padding(15, 0, 0, 0);
            btnTurnos.Size = new Size(174, 44);
            btnTurnos.TabIndex = 2;
            btnTurnos.Text = "Turnos";
            btnTurnos.Click += btnTurnos_Click;
            // 
            // panelSeparador
            // 
            panelSeparador.BackColor = Color.WhiteSmoke;
            panelSeparador.Dock = DockStyle.Top;
            panelSeparador.Location = new Point(3, 153);
            panelSeparador.Name = "panelSeparador";
            panelSeparador.Size = new Size(174, 2);
            panelSeparador.TabIndex = 3;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Dock = DockStyle.Fill;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Image = (Image)resources.GetObject("btnCerrarSesion.Image");
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.Location = new Point(3, 453);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(15, 0, 0, 0);
            btnCerrarSesion.Size = new Size(174, 44);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // SecretariaSidebar
            // 
            Controls.Add(tableLayoutPanelMenu);
            Name = "SecretariaSidebar";
            Size = new Size(180, 500);
            tableLayoutPanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
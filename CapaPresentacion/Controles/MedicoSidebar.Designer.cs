namespace CapaPresentacion.Controles
{
    partial class MedicoSidebar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnTurnos;
        private System.Windows.Forms.Button btnHistorias;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicoSidebar));
            tableLayoutPanelMenu = new TableLayoutPanel();
            btnDashboard = new Button();
            btnPacientes = new Button();
            btnTurnos = new Button();
            btnHistorias = new Button();
            panelSeparador = new Panel();
            btnCerrarSesion = new Button();
            tableLayoutPanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMenu
            // 
            tableLayoutPanelMenu.ColumnCount = 1;
            tableLayoutPanelMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMenu.Controls.Add(btnCerrarSesion, 0, 5);
            tableLayoutPanelMenu.Controls.Add(btnDashboard, 0, 0);
            tableLayoutPanelMenu.Controls.Add(btnPacientes, 0, 1);
            tableLayoutPanelMenu.Controls.Add(btnTurnos, 0, 2);
            tableLayoutPanelMenu.Controls.Add(btnHistorias, 0, 3);
            tableLayoutPanelMenu.Controls.Add(panelSeparador, 0, 4);
            tableLayoutPanelMenu.Dock = DockStyle.Fill;
            tableLayoutPanelMenu.Location = new Point(0, 0);
            tableLayoutPanelMenu.Name = "tableLayoutPanelMenu";
            tableLayoutPanelMenu.RowCount = 6;
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
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
            // btnHistorias
            // 
            btnHistorias.Dock = DockStyle.Fill;
            btnHistorias.FlatStyle = FlatStyle.Flat;
            btnHistorias.Image = (Image)resources.GetObject("btnHistorias.Image");
            btnHistorias.ImageAlign = ContentAlignment.MiddleLeft;
            btnHistorias.Location = new Point(3, 153);
            btnHistorias.Name = "btnHistorias";
            btnHistorias.Padding = new Padding(15, 0, 0, 0);
            btnHistorias.Size = new Size(174, 44);
            btnHistorias.TabIndex = 3;
            btnHistorias.Text = "Historias";
            btnHistorias.Click += btnHistorias_Click;
            // 
            // panelSeparador
            // 
            panelSeparador.BackColor = Color.WhiteSmoke;
            panelSeparador.Dock = DockStyle.Top;
            panelSeparador.Location = new Point(3, 203);
            panelSeparador.Name = "panelSeparador";
            panelSeparador.Size = new Size(174, 2);
            panelSeparador.TabIndex = 4;
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
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // MedicoSidebar
            // 
            Controls.Add(tableLayoutPanelMenu);
            Name = "MedicoSidebar";
            Size = new Size(180, 500);
            tableLayoutPanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
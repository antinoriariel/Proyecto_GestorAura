namespace CapaPresentacion.Controles
{
    partial class MenuLateral
    {
        private TableLayoutPanel tableLayoutPanelMenu;
        private Button btnDashboard;
        private Button btnPacientes;
        private Button btnTurnos;
        private Button btnHistorias;
        private Button btnCerrarSesion;

        private void InitializeComponent()
        {
            tableLayoutPanelMenu = new TableLayoutPanel();
            btnDashboard = new Button();
            btnPacientes = new Button();
            btnTurnos = new Button();
            btnHistorias = new Button();
            btnCerrarSesion = new Button();

            // TableLayoutPanel
            tableLayoutPanelMenu.ColumnCount = 1;
            tableLayoutPanelMenu.Dock = DockStyle.Fill;
            tableLayoutPanelMenu.RowCount = 5;
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));


            tableLayoutPanelMenu.Controls.Add(btnDashboard, 0, 0);
            tableLayoutPanelMenu.Controls.Add(btnPacientes, 0, 1);
            tableLayoutPanelMenu.Controls.Add(btnTurnos, 0, 2);
            tableLayoutPanelMenu.Controls.Add(btnHistorias, 0, 3);
            tableLayoutPanelMenu.Controls.Add(btnCerrarSesion, 0, 4);

            // Botones
            btnDashboard.Text = "Inicio";
            btnDashboard.Dock = DockStyle.Fill;
            btnDashboard.Click += btnDashboard_Click;

            btnPacientes.Text = "Pacientes";
            btnPacientes.Dock = DockStyle.Fill;
            btnPacientes.Click += btnPacientes_Click;

            btnTurnos.Text = "Turnos";
            btnTurnos.Dock = DockStyle.Fill;
            btnTurnos.Click += btnTurnos_Click;

            btnHistorias.Text = "Historias";
            btnHistorias.Dock = DockStyle.Fill;
            btnHistorias.Click += btnHistorias_Click;

            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.Dock = DockStyle.Fill;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            // UserControl
            Controls.Add(tableLayoutPanelMenu);
            Name = "MenuLateral";
            Size = new System.Drawing.Size(160, 500);
        }
    }
}

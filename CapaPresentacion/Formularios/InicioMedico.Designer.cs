namespace CapaPresentacion.Formularios
{
    partial class InicioMedico
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel layoutMain;
        private Panel panelHeader;
        private Panel panelTurnos;
        private Panel panelPacientes;

        private Label lblNombreMedico;
        private Label lblEspecialidad;
        private Label lblEspecialidadValor;
        private Label lblMatricula;
        private Label lblMatriculaValor;
        private Label lblServidor;
        private Label lblServidorValor;
        private Label lblVersionSistema;
        private Label lblFechaHoy;

        private DataGridView dgvTurnos;
        private DataGridView dgvPacientes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Inicio Médico";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(1080, 700);
            this.Font = new System.Drawing.Font("Consolas", 10F);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeeee");

            // ===== LAYOUT PRINCIPAL =====
            layoutMain = new TableLayoutPanel();
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.RowCount = 3;
            layoutMain.Padding = new Padding(25, 20, 25, 20);
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 45));

            // ===== PANEL SUPERIOR =====
            panelHeader = new Panel();
            panelHeader.Dock = DockStyle.Fill;
            panelHeader.BackColor = Color.White;
            panelHeader.Padding = new Padding(25);
            panelHeader.BorderStyle = BorderStyle.FixedSingle;

            lblNombreMedico = new Label
            {
                Text = "Dr. <nombre>",
                Font = new Font("Consolas", 13F, FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, 25)
            };

            lblServidor = new Label
            {
                Text = "Servidor:",
                AutoSize = true,
                Location = new System.Drawing.Point(430, 25)
            };

            lblServidorValor = new Label
            {
                Text = "—",
                AutoSize = true,
                Location = new System.Drawing.Point(520, 25)
            };

            lblEspecialidad = new Label
            {
                Text = "Especialidad:",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 70)
            };

            lblEspecialidadValor = new Label
            {
                Text = "—",
                AutoSize = true,
                Location = new System.Drawing.Point(140, 70)
            };

            lblMatricula = new Label
            {
                Text = "Matrícula:",
                AutoSize = true,
                Location = new System.Drawing.Point(430, 70)
            };

            lblMatriculaValor = new Label
            {
                Text = "—",
                AutoSize = true,
                Location = new System.Drawing.Point(520, 70)
            };

            lblVersionSistema = new Label
            {
                Text = "Versión:",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 110)
            };

            lblFechaHoy = new Label
            {
                Text = "—",
                AutoSize = true,
                Location = new System.Drawing.Point(430, 110)
            };

            panelHeader.Controls.AddRange(new Control[]
            {
                lblNombreMedico, lblServidor, lblServidorValor,
                lblEspecialidad, lblEspecialidadValor,
                lblMatricula, lblMatriculaValor,
                lblVersionSistema, lblFechaHoy
            });

            // ===== PANEL TURNOS =====
            panelTurnos = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            dgvTurnos = new DataGridView { Dock = DockStyle.Fill };
            panelTurnos.Controls.Add(dgvTurnos);

            // ===== PANEL PACIENTES =====
            panelPacientes = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            dgvPacientes = new DataGridView { Dock = DockStyle.Fill };
            panelPacientes.Controls.Add(dgvPacientes);

            layoutMain.Controls.Add(panelHeader, 0, 0);
            layoutMain.Controls.Add(panelTurnos, 0, 1);
            layoutMain.Controls.Add(panelPacientes, 0, 2);

            this.Controls.Add(layoutMain);
        }
    }
}

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace CapaPresentacion.Formularios
{
    partial class InicioMedico
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        private GroupBox grpDatos;
        private TableLayoutPanel grid;
        private Label lblBienvenida;
        private Label lblUsuario;          // <- valor dinámico
        private Label lblRol;
        private Label lblEspecialidad;     // <- valor dinámico
        private Label lblMatricula;        // <- valor dinámico

        private GroupBox grpExtras;
        private Label lblFraseMotivacional;
        private Label lblVersion;
        private Label lblEstadoServidor;

        private GroupBox grpGrafico;
        private Chart chartTurnos;

        private GroupBox grpPacientesRecientes;
        private DataGridView dgvPacientesRecientes;

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            headerPanel = new Panel();
            picHeader = new PictureBox();
            lblHeader = new Label();

            grpDatos = new GroupBox();
            grid = new TableLayoutPanel();
            lblBienvenida = new Label();
            lblUsuario = new Label();
            lblRol = new Label();
            lblEspecialidad = new Label();
            lblMatricula = new Label();

            grpExtras = new GroupBox();
            lblFraseMotivacional = new Label();
            lblVersion = new Label();
            lblEstadoServidor = new Label();

            grpGrafico = new GroupBox();
            chartTurnos = new Chart();

            grpPacientesRecientes = new GroupBox();
            dgvPacientesRecientes = new DataGridView();

            // ===== Form =====
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(1000, 680);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InicioMedico";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio Médico";

            // ===== Header =====
            headerPanel.BackColor = Color.FromArgb(41, 57, 71);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 52;
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);

            picHeader.Image = Properties.Resources.dashboardIcon; // asegúrate del recurso
            picHeader.Location = new Point(14, 10);
            picHeader.Size = new Size(32, 32);
            picHeader.SizeMode = PictureBoxSizeMode.Zoom;

            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(56, 12);
            lblHeader.Text = "Panel principal médico";

            // ===== grpDatos =====
            grpDatos.Text = "Datos del profesional";
            grpDatos.BackColor = Color.White;
            grpDatos.Dock = DockStyle.Top;
            grpDatos.Height = 145;
            grpDatos.Padding = new Padding(14, 12, 14, 12);
            grpDatos.Controls.Add(grid);

            grid.Dock = DockStyle.Fill;
            grid.ColumnCount = 2;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            grid.RowCount = 5;
            for (int i = 0; i < 5; i++)
                grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));

            // etiquetas
            lblBienvenida.Text = "Bienvenido/a:";
            lblBienvenida.Anchor = AnchorStyles.Left;
            lblUsuario.Text = "<usuario>";
            lblUsuario.Anchor = AnchorStyles.Left;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            lblRol.Text = "Rol: Médico";
            lblRol.Anchor = AnchorStyles.Left;

            lblEspecialidad.Text = "Especialidad: -";
            lblEspecialidad.Anchor = AnchorStyles.Left;

            lblMatricula.Text = "Matrícula: -";
            lblMatricula.Anchor = AnchorStyles.Left;

            // agregar a grid
            grid.Controls.Add(lblBienvenida, 0, 0);
            grid.Controls.Add(lblUsuario, 1, 0);
            grid.Controls.Add(lblRol, 0, 1);
            grid.Controls.Add(lblEspecialidad, 0, 2);
            grid.Controls.Add(lblMatricula, 0, 3);

            // ===== grpExtras =====
            grpExtras.Text = "Extras";
            grpExtras.BackColor = Color.White;
            grpExtras.Dock = DockStyle.Top;
            grpExtras.Height = 86;
            grpExtras.Padding = new Padding(14, 12, 14, 12);

            lblFraseMotivacional.AutoSize = true;
            lblFraseMotivacional.Location = new Point(14, 26);
            lblFraseMotivacional.Text = "\"La medicina es el arte de la incertidumbre y la ciencia de la probabilidad.\"";

            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(14, 52);
            lblVersion.Text = "Versión: 1.0.0";

            lblEstadoServidor.AutoSize = true;
            lblEstadoServidor.Location = new Point(180, 52);
            lblEstadoServidor.Text = "Servidor: OK";

            grpExtras.Controls.AddRange(new Control[] { lblFraseMotivacional, lblVersion, lblEstadoServidor });

            // ===== grpGrafico =====
            grpGrafico.Text = "Turnos por día";
            grpGrafico.BackColor = Color.White;
            grpGrafico.Dock = DockStyle.Top;
            grpGrafico.Height = 230;
            grpGrafico.Padding = new Padding(14, 12, 14, 12);
            grpGrafico.Controls.Add(chartTurnos);

            chartTurnos.Dock = DockStyle.Fill;
            chartTurnos.Palette = ChartColorPalette.Bright;
            var ca = new ChartArea("MainArea");
            ca.BackColor = Color.Transparent;
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            chartTurnos.ChartAreas.Add(ca);
            chartTurnos.Legends.Clear();
            var s = new Series("Turnos")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "MainArea",
                IsValueShownAsLabel = true
            };
            chartTurnos.Series.Add(s);
            chartTurnos.Titles.Clear();

            // ===== grpPacientesRecientes =====
            grpPacientesRecientes.Text = "Pacientes atendidos recientemente";
            grpPacientesRecientes.BackColor = Color.White;
            grpPacientesRecientes.Dock = DockStyle.Fill;
            grpPacientesRecientes.Padding = new Padding(14, 12, 14, 12);
            grpPacientesRecientes.Controls.Add(dgvPacientesRecientes);

            dgvPacientesRecientes.Dock = DockStyle.Fill;
            dgvPacientesRecientes.BackgroundColor = Color.White;
            dgvPacientesRecientes.AllowUserToAddRows = false;
            dgvPacientesRecientes.AllowUserToDeleteRows = false;
            dgvPacientesRecientes.AllowUserToResizeRows = false;
            dgvPacientesRecientes.ReadOnly = true;
            dgvPacientesRecientes.MultiSelect = false;
            dgvPacientesRecientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientesRecientes.RowHeadersVisible = false;
            dgvPacientesRecientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPacientesRecientes.EnableHeadersVisualStyles = false;
            dgvPacientesRecientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 57, 71);
            dgvPacientesRecientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPacientesRecientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvPacientesRecientes.GridColor = Color.Gainsboro;

            // ===== Compose =====
            Controls.Add(grpPacientesRecientes);
            Controls.Add(grpGrafico);
            Controls.Add(grpExtras);
            Controls.Add(grpDatos);
            Controls.Add(headerPanel);

            ResumeLayout(false);
        }
        #endregion
    }
}

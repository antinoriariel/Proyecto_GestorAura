using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace CapaPresentacion.Formularios
{
    partial class InicioSecre
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        private GroupBox grpDatos;
        private TableLayoutPanel grid;
        private Label lblBienvenida;
        private Label lblUsuario;
        private Label lblRol;

        private GroupBox grpExtras;
        private Label lblFraseMotivacional;
        private Label lblVersion;
        private Label lblEstadoServidor;

        private GroupBox grpGrafico;
        private Chart chartAgenda;

        private GroupBox grpTurnos;
        private DataGridView dgvTurnos;

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

            grpExtras = new GroupBox();
            lblFraseMotivacional = new Label();
            lblVersion = new Label();
            lblEstadoServidor = new Label();

            grpGrafico = new GroupBox();
            chartAgenda = new Chart();

            grpTurnos = new GroupBox();
            dgvTurnos = new DataGridView();

            // ===== Form =====
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(1000, 680);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InicioSecre";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio Secretaria";

            // ===== Header =====
            headerPanel.BackColor = Color.FromArgb(41, 57, 71);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 52;
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);

            picHeader.Image = Properties.Resources.dashboardIcon; // ⚠️ crea un recurso apropiado
            picHeader.Location = new Point(14, 10);
            picHeader.Size = new Size(32, 32);
            picHeader.SizeMode = PictureBoxSizeMode.Zoom;

            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(56, 12);
            lblHeader.Text = "Panel principal secretario/a";

            // ===== grpDatos =====
            grpDatos.Text = "Datos de la secretaria";
            grpDatos.BackColor = Color.White;
            grpDatos.Dock = DockStyle.Top;
            grpDatos.Height = 100;
            grpDatos.Padding = new Padding(14, 12, 14, 12);
            grpDatos.Controls.Add(grid);

            grid.Dock = DockStyle.Fill;
            grid.ColumnCount = 2;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            grid.RowCount = 3;
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));

            lblBienvenida.Text = "Bienvenida:";
            lblBienvenida.Anchor = AnchorStyles.Left;
            lblUsuario.Text = "<usuario>";
            lblUsuario.Anchor = AnchorStyles.Left;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            lblRol.Text = "Rol: Secretaria";
            lblRol.Anchor = AnchorStyles.Left;

            grid.Controls.Add(lblBienvenida, 0, 0);
            grid.Controls.Add(lblUsuario, 1, 0);
            grid.Controls.Add(lblRol, 0, 1);

            // ===== grpExtras =====
            grpExtras.Text = "Extras";
            grpExtras.BackColor = Color.White;
            grpExtras.Dock = DockStyle.Top;
            grpExtras.Height = 80;
            grpExtras.Padding = new Padding(14, 12, 14, 12);

            lblFraseMotivacional.AutoSize = true;
            lblFraseMotivacional.Location = new Point(14, 24);
            lblFraseMotivacional.Text = "\"La organización es la clave del éxito en la gestión hospitalaria.\"";

            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(14, 50);
            lblVersion.Text = "Versión: 1.0.0";

            lblEstadoServidor.AutoSize = true;
            lblEstadoServidor.Location = new Point(180, 50);
            lblEstadoServidor.Text = "Servidor: OK";

            grpExtras.Controls.AddRange(new Control[] { lblFraseMotivacional, lblVersion, lblEstadoServidor });

            // ===== grpGrafico =====
            grpGrafico.Text = "Agenda del día";
            grpGrafico.BackColor = Color.White;
            grpGrafico.Dock = DockStyle.Top;
            grpGrafico.Height = 200;
            grpGrafico.Padding = new Padding(14, 12, 14, 12);
            grpGrafico.Controls.Add(chartAgenda);

            chartAgenda.Dock = DockStyle.Fill;
            var ca = new ChartArea("MainArea");
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            chartAgenda.ChartAreas.Add(ca);
            chartAgenda.Legends.Clear();
            var s = new Series("Turnos")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "MainArea",
                IsValueShownAsLabel = true
            };
            chartAgenda.Series.Add(s);

            // ===== grpTurnos =====
            grpTurnos.Text = "Turnos próximos";
            grpTurnos.BackColor = Color.White;
            grpTurnos.Dock = DockStyle.Fill;
            grpTurnos.Padding = new Padding(14, 12, 14, 12);
            grpTurnos.Controls.Add(dgvTurnos);

            dgvTurnos.Dock = DockStyle.Fill;
            dgvTurnos.BackgroundColor = Color.White;
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.ReadOnly = true;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.RowHeadersVisible = false;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.EnableHeadersVisualStyles = false;
            dgvTurnos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 57, 71);
            dgvTurnos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTurnos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

            // ===== Compose =====
            Controls.Add(grpTurnos);
            Controls.Add(grpGrafico);
            Controls.Add(grpExtras);
            Controls.Add(grpDatos);
            Controls.Add(headerPanel);

            ResumeLayout(false);
        }
        #endregion
    }
}

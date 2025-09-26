namespace CapaPresentacion.Formularios
{
    partial class InicioAdmin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.TableLayoutPanel grid;

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUltimoAcceso;

        private System.Windows.Forms.GroupBox grpExtras;
        private System.Windows.Forms.Label lblFraseMotivacional;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblEstadoServidor;

        private System.Windows.Forms.GroupBox grpGrafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPacientes;

        private System.Windows.Forms.GroupBox grpUsuariosPrevios;
        private System.Windows.Forms.DataGridView dgvUsuariosPrevios;

        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button btnCerrar;

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            picHeader = new PictureBox();
            lblHeader = new Label();
            grpDatos = new GroupBox();
            grid = new TableLayoutPanel();

            lblBienvenida = new Label();
            lblUsuario = new Label();
            lblRol = new Label();
            lblEmail = new Label();
            lblUltimoAcceso = new Label();

            grpExtras = new GroupBox();
            lblFraseMotivacional = new Label();
            lblVersion = new Label();
            lblEstadoServidor = new Label();

            grpGrafico = new GroupBox();
            chartPacientes = new System.Windows.Forms.DataVisualization.Charting.Chart();

            grpUsuariosPrevios = new GroupBox();
            dgvUsuariosPrevios = new DataGridView();

            footerPanel = new Panel();
            btnCerrar = new Button();

            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).BeginInit();
            grpDatos.SuspendLayout();
            grid.SuspendLayout();
            grpExtras.SuspendLayout();
            grpGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartPacientes).BeginInit();
            grpUsuariosPrevios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuariosPrevios).BeginInit();
            footerPanel.SuspendLayout();
            SuspendLayout();

            // headerPanel
            headerPanel.BackColor = Color.FromArgb(41, 57, 71);
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(21, 12);
            headerPanel.Size = new Size(676, 48);

            // picHeader
            picHeader.Image = Properties.Resources.dashboardIcon;
            picHeader.Location = new Point(14, 9);
            picHeader.Size = new Size(35, 30);
            picHeader.SizeMode = PictureBoxSizeMode.Zoom;

            // lblHeader
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(56, 14);
            lblHeader.Text = "Panel Administrador";

            // grpDatos
            grpDatos.BackColor = Color.White;
            grpDatos.Controls.Add(grid);
            grpDatos.Dock = DockStyle.Top;
            grpDatos.Padding = new Padding(14, 12, 14, 12);
            grpDatos.AutoSize = true;
            grpDatos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpDatos.Text = "Información de inicio";

            // grid
            grid.AutoSize = true;
            grid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grid.Margin = new Padding(0);
            grid.Dock = DockStyle.Top;
            grid.ColumnCount = 2;
            grid.ColumnStyles.Clear();
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            grid.RowCount = 5;
            grid.RowStyles.Clear();
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            grid.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // lblBienvenida
            lblBienvenida.Dock = DockStyle.Fill;
            lblBienvenida.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            lblBienvenida.Margin = new Padding(0, 0, 0, 6);
            lblBienvenida.Text = "👋 Bienvenido Administrador";
            grid.Controls.Add(lblBienvenida, 0, 0);
            grid.SetColumnSpan(lblBienvenida, 2);

            // Usuario
            grid.Controls.Add(new Label
            {
                Text = "Usuario:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            }, 0, 1);
            lblUsuario.Dock = DockStyle.Fill;
            lblUsuario.TextAlign = ContentAlignment.MiddleLeft;
            lblUsuario.AutoSize = true;
            lblUsuario.Text = "admin";
            grid.Controls.Add(lblUsuario, 1, 1);

            // Rol
            grid.Controls.Add(new Label
            {
                Text = "Rol:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            }, 0, 2);
            lblRol.Dock = DockStyle.Fill;
            lblRol.TextAlign = ContentAlignment.MiddleLeft;
            lblRol.AutoSize = true;
            lblRol.Text = "administrador";
            grid.Controls.Add(lblRol, 1, 2);

            // Email
            grid.Controls.Add(new Label
            {
                Text = "Email:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            }, 0, 3);
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            lblEmail.AutoSize = true;
            lblEmail.Text = "admin@gestoraura.com";
            grid.Controls.Add(lblEmail, 1, 3);

            // Último acceso
            grid.Controls.Add(new Label
            {
                Text = "Último acceso:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            }, 0, 4);
            lblUltimoAcceso.Dock = DockStyle.Fill;
            lblUltimoAcceso.TextAlign = ContentAlignment.MiddleLeft;
            lblUltimoAcceso.AutoSize = true;
            lblUltimoAcceso.Text = "26/09/2025 08:00 hs";
            grid.Controls.Add(lblUltimoAcceso, 1, 4);

            // grpExtras
            grpExtras.BackColor = Color.White;
            grpExtras.Controls.Add(lblFraseMotivacional);
            grpExtras.Controls.Add(lblVersion);
            grpExtras.Controls.Add(lblEstadoServidor);
            grpExtras.Dock = DockStyle.Top;
            grpExtras.Padding = new Padding(14, 12, 14, 12);
            grpExtras.Size = new Size(676, 100);
            grpExtras.Text = "Información extra";

            lblFraseMotivacional.AutoSize = true;
            lblFraseMotivacional.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblFraseMotivacional.ForeColor = Color.DarkSlateGray;
            lblFraseMotivacional.Location = new Point(20, 30);
            lblFraseMotivacional.Text = "✨ \"La salud es la mayor riqueza\"";

            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVersion.Location = new Point(20, 65);
            lblVersion.Text = "GestorAura v1.0";

            lblEstadoServidor.AutoSize = true;
            lblEstadoServidor.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblEstadoServidor.ForeColor = Color.Green;
            lblEstadoServidor.Anchor = AnchorStyles.Right;
            lblEstadoServidor.Location = new Point(500, 65);
            lblEstadoServidor.Text = "🟢 Servidor en línea";

            // grpGrafico
            grpGrafico.BackColor = Color.White;
            grpGrafico.Controls.Add(chartPacientes);
            grpGrafico.Dock = DockStyle.Top;
            grpGrafico.Padding = new Padding(14, 12, 14, 12);
            grpGrafico.Size = new Size(676, 220);
            grpGrafico.Text = "Pacientes nuevos en el último mes";

            chartPacientes.Dock = DockStyle.Fill;
            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea");
            chartPacientes.ChartAreas.Add(chartArea);
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Pacientes")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
            };
            series.Points.AddXY("Semana 1", 12);
            series.Points.AddXY("Semana 2", 18);
            series.Points.AddXY("Semana 3", 9);
            series.Points.AddXY("Semana 4", 15);
            chartPacientes.Series.Add(series);

            // grpUsuariosPrevios
            grpUsuariosPrevios.BackColor = Color.White;
            grpUsuariosPrevios.Controls.Add(dgvUsuariosPrevios);
            grpUsuariosPrevios.Dock = DockStyle.Fill;
            grpUsuariosPrevios.Padding = new Padding(14, 12, 14, 12);
            grpUsuariosPrevios.Text = "Usuarios conectados recientemente";

            dgvUsuariosPrevios.AllowUserToAddRows = false;
            dgvUsuariosPrevios.AllowUserToDeleteRows = false;
            dgvUsuariosPrevios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuariosPrevios.BackgroundColor = Color.White;
            dgvUsuariosPrevios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuariosPrevios.Dock = DockStyle.Fill;
            dgvUsuariosPrevios.ReadOnly = true;
            dgvUsuariosPrevios.RowHeadersVisible = false;
            dgvUsuariosPrevios.Columns.Add("Usuario", "Usuario");
            dgvUsuariosPrevios.Columns.Add("Rol", "Rol");
            dgvUsuariosPrevios.Columns.Add("Email", "Email");
            dgvUsuariosPrevios.Columns.Add("UltimoAcceso", "Último acceso");
            dgvUsuariosPrevios.Rows.Add("admin", "administrador", "admin@gestoraura.com", "26/09/2025 08:00");
            dgvUsuariosPrevios.Rows.Add("maria", "secretaria", "maria@gestoraura.com", "25/09/2025 16:22");
            dgvUsuariosPrevios.Rows.Add("juan", "medico", "juan@gestoraura.com", "25/09/2025 10:15");
            dgvUsuariosPrevios.Rows.Add("sofia", "medico", "sofia@gestoraura.com", "24/09/2025 19:47");

            // footerPanel
            footerPanel.BackColor = Color.Transparent;
            footerPanel.Controls.Add(btnCerrar);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Size = new Size(676, 48);

            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.AutoSize = true;
            btnCerrar.Text = "Recargar estado";
            btnCerrar.Location = new Point(560, 10);

            // InicioAdmin
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(718, 700);
            ControlBox = false;
            Controls.Add(footerPanel);
            Controls.Add(grpUsuariosPrevios);
            Controls.Add(grpGrafico);
            Controls.Add(grpExtras);
            Controls.Add(grpDatos);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InicioAdmin";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Inicio del Administrador";

            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).EndInit();
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grid.ResumeLayout(false);
            grid.PerformLayout();
            grpExtras.ResumeLayout(false);
            grpExtras.PerformLayout();
            grpGrafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartPacientes).EndInit();
            grpUsuariosPrevios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuariosPrevios).EndInit();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}

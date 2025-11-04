using System.Windows.Forms;
using System.Drawing;
using System.Linq;

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
        private Label lblRolValor;
        private Label lblEmail;
        private Label lblEmailValor;

        private GroupBox grpExtras;
        private Label lblFraseMotivacional;
        private Label lblVersion;
        private Label lblEstadoServidor;

        private GroupBox grpGrafico;
        private ComboBox cmbMedicos;
        private Label lblMedico;
        private TableLayoutPanel tblCalendario;

        private GroupBox grpTurnos;
        private DataGridView dgvTurnos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
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
            lblRolValor = new Label();
            lblEmail = new Label();
            lblEmailValor = new Label();

            grpExtras = new GroupBox();
            lblFraseMotivacional = new Label();
            lblVersion = new Label();
            lblEstadoServidor = new Label();

            grpGrafico = new GroupBox();
            cmbMedicos = new ComboBox();
            lblMedico = new Label();
            tblCalendario = new TableLayoutPanel();

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

            picHeader.Image = Properties.Resources.dashboardIcon;
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
            grpDatos.Height = 120;
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
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRol.Text = "Rol:";
            lblRolValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Text = "Email:";
            lblEmailValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            grid.Controls.Add(lblBienvenida, 0, 0);
            grid.Controls.Add(lblUsuario, 1, 0);
            grid.Controls.Add(lblRol, 0, 1);
            grid.Controls.Add(lblRolValor, 1, 1);
            grid.Controls.Add(lblEmail, 0, 2);
            grid.Controls.Add(lblEmailValor, 1, 2);

            // ===== grpExtras =====
            grpExtras.Text = "Extras";
            grpExtras.BackColor = Color.White;
            grpExtras.Dock = DockStyle.Top;
            grpExtras.Height = 80;
            grpExtras.Padding = new Padding(14, 12, 14, 12);
            grpExtras.Controls.AddRange(new Control[] { lblFraseMotivacional, lblVersion, lblEstadoServidor });

            lblFraseMotivacional.AutoSize = true;
            lblFraseMotivacional.Location = new Point(14, 24);
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(14, 50);
            lblEstadoServidor.AutoSize = true;
            lblEstadoServidor.Location = new Point(180, 50);

            // ===== grpGrafico =====
            grpGrafico.Text = "Agenda del día";
            grpGrafico.BackColor = Color.White;
            grpGrafico.Dock = DockStyle.Top;
            grpGrafico.Height = 350;
            grpGrafico.Padding = new Padding(14, 12, 14, 12);

            // --- Label + ComboBox ---
            lblMedico.Text = "Médico:";
            lblMedico.AutoSize = true;
            lblMedico.Location = new Point(16, 30);

            cmbMedicos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedicos.Location = new Point(80, 26);
            cmbMedicos.Width = 200;

            grpGrafico.Controls.Add(lblMedico);
            grpGrafico.Controls.Add(cmbMedicos);

            // --- Calendario ---
            tblCalendario.Dock = DockStyle.Bottom;
            tblCalendario.Height = 270;
            tblCalendario.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tblCalendario.ColumnCount = 6;
            tblCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            for (int i = 1; i <= 5; i++)
                tblCalendario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

            tblCalendario.RowCount = 10;
            tblCalendario.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            for (int i = 1; i < 10; i++)
                tblCalendario.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1F));

            DateTime lunes = System.DateTime.Today.AddDays(-(int)System.DateTime.Today.DayOfWeek + 1);
            string[] dias = { "Hora" };
            for (int i = 0; i < 5; i++)
                dias = dias.Append($"{lunes.AddDays(i):dddd dd}").ToArray();

            for (int c = 0; c < dias.Length; c++)
            {
                var lbl = new Label()
                {
                    Text = dias[c],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                    BackColor = Color.FromArgb(240, 243, 245)
                };
                tblCalendario.Controls.Add(lbl, c, 0);
            }

            string[] horas = { "08:00", "09:00", "10:00", "11:00", "12:00", "14:00", "15:00", "16:00", "17:00" };
            for (int i = 0; i < horas.Length; i++)
            {
                var lblHora = new Label()
                {
                    Text = horas[i],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(250, 250, 250)
                };
                tblCalendario.Controls.Add(lblHora, 0, i + 1);

                for (int c = 1; c <= 5; c++)
                {
                    var lblSlot = new Label()
                    {
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Margin = new Padding(0),
                        Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                        Tag = "slot" // marcar como celda clickeable
                    };

                    bool ocupado = (c == 2 && i == 1) || (c == 4 && i == 3) || (c == 5 && i == 6);
                    lblSlot.Text = ocupado ? "Ocupado" : "Libre";
                    lblSlot.BackColor = ocupado ? Color.FromArgb(255, 224, 224) : Color.FromArgb(224, 255, 224);

                    tblCalendario.Controls.Add(lblSlot, c, i + 1);
                }
            }

            grpGrafico.Controls.Add(tblCalendario);

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

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormSolicitudes : Form
    {
        // Header
        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        // Tabs
        private TabControl tabs;
        private DataGridView dgvRecibidas;
        private DataGridView dgvEnviadas;

        // Nueva solicitud
        private GroupBox grpNueva;
        private ComboBox cboPaciente;
        private ComboBox cboTipo;
        private ComboBox cboPrioridad;
        private TextBox txtDetalle;
        private Button btnEnviar;
        private Button btnLimpiar;

        public FormSolicitudes()
        {
            Text = "Solicitudes";
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            BackColor = Color.WhiteSmoke;
            DoubleBuffered = true;
            Padding = new Padding(10);

            BuildHeader("Solicitudes médicas", SystemIcons.Question.ToBitmap());
            BuildTabs();
            BuildNueva();

            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3
            };
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 40));

            main.Controls.Add(headerPanel, 0, 0);
            main.Controls.Add(tabs, 0, 1);
            main.Controls.Add(grpNueva, 0, 2);

            Controls.Add(main);

            Load += (s, e) => CargarMock();
        }

        private void BuildHeader(string titulo, Image icono)
        {
            headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(40, 56, 74),
                Padding = new Padding(12, 8, 12, 8)
            };
            picHeader = new PictureBox
            {
                Image = icono,
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 36,
                Height = 36,
                Dock = DockStyle.Left
            };
            lblHeader = new Label
            {
                Text = titulo,
                ForeColor = Color.White,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Controls.Add(picHeader);
        }

        private void BuildTabs()
        {
            tabs = new TabControl { Dock = DockStyle.Fill };

            dgvRecibidas = BuildGridSolicitudes();
            dgvEnviadas = BuildGridSolicitudes();

            var tab1 = new TabPage("Recibidas") { Padding = new Padding(6) };
            var tab2 = new TabPage("Enviadas") { Padding = new Padding(6) };
            tab1.Controls.Add(dgvRecibidas);
            tab2.Controls.Add(dgvEnviadas);

            tabs.TabPages.AddRange(new[] { tab1, tab2 });
        }

        private DataGridView BuildGridSolicitudes()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White
            };
            dgv.Columns.Add("Fecha", "Fecha");
            dgv.Columns.Add("Paciente", "Paciente");
            dgv.Columns.Add("Tipo", "Tipo");
            dgv.Columns.Add("Prioridad", "Prioridad");
            dgv.Columns.Add("Detalle", "Detalle");
            dgv.Columns.Add("Estado", "Estado");

            // Doble clic para ver detalle
            dgv.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var row = ((DataGridView)s).Rows[e.RowIndex];
                    MessageBox.Show(
                        $"Detalle:\n{row.Cells["Detalle"].Value}",
                        "Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            return dgv;
        }

        private void BuildNueva()
        {
            grpNueva = new GroupBox
            {
                Text = "Nueva solicitud",
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            var grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 44));

            var lblPaciente = new Label { Text = "Paciente", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            cboPaciente = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblTipo = new Label { Text = "Tipo", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            cboTipo = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTipo.Items.AddRange(new object[] { "Estudio", "Interconsulta", "Medicamento", "Otro" });

            var lblPrioridad = new Label { Text = "Prioridad", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            cboPrioridad = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cboPrioridad.Items.AddRange(new object[] { "Baja", "Media", "Alta", "Crítica" });

            var lblDetalle = new Label { Text = "Detalle", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            txtDetalle = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Vertical };

            var acciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft
            };
            btnEnviar = new Button { Text = "Enviar", Width = 120, Height = 32, Margin = new Padding(6) };
            btnLimpiar = new Button { Text = "Limpiar", Width = 120, Height = 32, Margin = new Padding(6) };
            acciones.Controls.AddRange(new Control[] { btnEnviar, btnLimpiar });

            btnEnviar.Click += (s, e) => EnviarSolicitud();
            btnLimpiar.Click += (s, e) => LimpiarSolicitud();

            grid.Controls.Add(lblPaciente, 0, 0);
            grid.Controls.Add(cboPaciente, 1, 0);
            grid.Controls.Add(lblTipo, 2, 0);
            grid.Controls.Add(cboTipo, 3, 0);
            grid.Controls.Add(lblPrioridad, 0, 1);
            grid.Controls.Add(cboPrioridad, 1, 1);
            grid.Controls.Add(lblDetalle, 0, 2);
            grid.SetColumnSpan(lblDetalle, 1);
            grid.Controls.Add(txtDetalle, 1, 2);
            grid.SetColumnSpan(txtDetalle, 3);
            grid.Controls.Add(acciones, 0, 3);
            grid.SetColumnSpan(acciones, 4);

            grpNueva.Controls.Add(grid);
        }

        private void CargarMock()
        {
            cboPaciente.Items.AddRange(new object[] { "García, Laura", "Suárez, Martín", "Ramírez, Nicolás" });
            cboPaciente.SelectedIndex = 0;
            cboTipo.SelectedIndex = 0;
            cboPrioridad.SelectedIndex = 1;

            dgvRecibidas.Rows.Add(DateTime.Today.ToShortDateString(), "García, Laura", "Interconsulta", "Alta", "Cardiología por dolor torácico", "Pendiente");
            dgvEnviadas.Rows.Add(DateTime.Today.AddDays(-1).ToShortDateString(), "Suárez, Martín", "Estudio", "Media", "RX de Tórax PA/LAT", "Aprobada");
        }

        private void EnviarSolicitud()
        {
            if (cboPaciente.SelectedIndex < 0 || cboTipo.SelectedIndex < 0 || cboPrioridad.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                MessageBox.Show("Completá todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvEnviadas.Rows.Add(DateTime.Now.ToShortDateString(), cboPaciente.Text, cboTipo.Text, cboPrioridad.Text, txtDetalle.Text, "Pendiente");
            MessageBox.Show("Solicitud enviada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarSolicitud();
        }

        private void LimpiarSolicitud()
        {
            cboPaciente.SelectedIndex = 0;
            cboTipo.SelectedIndex = 0;
            cboPrioridad.SelectedIndex = 1;
            txtDetalle.Clear();
            txtDetalle.Focus();
        }
    }
}

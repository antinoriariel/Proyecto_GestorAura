using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormResultados : Form
    {
        // Header
        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        // Filtros
        private TableLayoutPanel filtrosGrid;
        private ComboBox cboPaciente;
        private ComboBox cboTipo;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnBuscar;
        private Button btnLimpiar;

        // Grilla
        private DataGridView dgvResultados;

        // Acciones
        private FlowLayoutPanel accionesPanel;
        private Button btnVer;
        private Button btnDescargar;
        private Button btnImprimir;

        public FormResultados()
        {
            Text = "Resultados";
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            BackColor = Color.WhiteSmoke;
            DoubleBuffered = true;
            Padding = new Padding(10);

            BuildHeader("Resultados de estudios", SystemIcons.Information.ToBitmap());
            BuildFiltros();
            BuildGrid();
            BuildAcciones();

            // Layout vertical principal
            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
            };
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));   // header
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 90));   // filtros
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100));   // grid
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));   // acciones

            main.Controls.Add(headerPanel, 0, 0);
            main.Controls.Add(filtrosGrid, 0, 1);
            main.Controls.Add(dgvResultados, 0, 2);
            main.Controls.Add(accionesPanel, 0, 3);

            Controls.Add(main);

            Load += (s, e) => CargarMock(); // placeholder
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

        private void BuildFiltros()
        {
            filtrosGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 8,
                RowCount = 2,
                Padding = new Padding(0, 8, 0, 8)
            };
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100)); // lbl
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));   // control
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));

            var lblPaciente = new Label { Text = "Paciente", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            cboPaciente = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            var lblTipo = new Label { Text = "Tipo", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            cboTipo = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cboTipo.Items.AddRange(new object[] { "Todos", "Laboratorio", "Imagen", "Cardiología", "Otros" });
            cboTipo.SelectedIndex = 0;

            var lblDesde = new Label { Text = "Desde", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            dtpDesde = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short };

            var lblHasta = new Label { Text = "Hasta", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            dtpHasta = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short };

            btnBuscar = new Button { Text = "Buscar", Dock = DockStyle.Fill };
            btnLimpiar = new Button { Text = "Limpiar", Dock = DockStyle.Fill };

            btnBuscar.Click += (s, e) => Filtrar();
            btnLimpiar.Click += (s, e) =>
            {
                cboPaciente.SelectedIndex = -1;
                cboTipo.SelectedIndex = 0;
                dtpDesde.Value = DateTime.Today.AddMonths(-1);
                dtpHasta.Value = DateTime.Today;
                Filtrar();
            };

            filtrosGrid.Controls.Add(lblPaciente, 0, 0);
            filtrosGrid.Controls.Add(cboPaciente, 1, 0);
            filtrosGrid.Controls.Add(lblTipo, 2, 0);
            filtrosGrid.Controls.Add(cboTipo, 3, 0);
            filtrosGrid.Controls.Add(lblDesde, 4, 0);
            filtrosGrid.Controls.Add(dtpDesde, 5, 0);
            filtrosGrid.Controls.Add(lblHasta, 6, 0);
            filtrosGrid.Controls.Add(dtpHasta, 7, 0);

            filtrosGrid.Controls.Add(new Label(), 0, 1);
            filtrosGrid.Controls.Add(new Label(), 1, 1);
            filtrosGrid.Controls.Add(new Label(), 2, 1);
            filtrosGrid.Controls.Add(new Label(), 3, 1);
            filtrosGrid.Controls.Add(new Label(), 4, 1);
            filtrosGrid.Controls.Add(new Label(), 5, 1);
            filtrosGrid.Controls.Add(btnBuscar, 6, 1);
            filtrosGrid.Controls.Add(btnLimpiar, 7, 1);
        }

        private void BuildGrid()
        {
            dgvResultados = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White
            };

            dgvResultados.Columns.Add("Fecha", "Fecha");
            dgvResultados.Columns.Add("Paciente", "Paciente");
            dgvResultados.Columns.Add("Tipo", "Tipo");
            dgvResultados.Columns.Add("Estudio", "Estudio");
            dgvResultados.Columns.Add("Estado", "Estado");
        }

        private void BuildAcciones()
        {
            accionesPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 8, 0, 8)
            };

            btnVer = new Button { Text = "Ver", Width = 120, Height = 36, Margin = new Padding(8) };
            btnDescargar = new Button { Text = "Descargar PDF", Width = 160, Height = 36, Margin = new Padding(8) };
            btnImprimir = new Button { Text = "Imprimir", Width = 120, Height = 36, Margin = new Padding(8) };

            btnVer.Click += (s, e) => AccionFila("Ver");
            btnDescargar.Click += (s, e) => AccionFila("Descargar PDF");
            btnImprimir.Click += (s, e) => AccionFila("Imprimir");

            accionesPanel.Controls.AddRange(new Control[] { btnVer, btnDescargar, btnImprimir });
        }

        // ===== Mock / Lógica base =====
        private void CargarMock()
        {
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;

            cboPaciente.Items.AddRange(new object[] {
                "García, Laura", "Suárez, Martín", "Ramírez, Nicolás", "Vega, Manuel"
            });

            dgvResultados.Rows.Clear();
            dgvResultados.Rows.Add(DateTime.Today.AddDays(-2).ToShortDateString(), "García, Laura", "Laboratorio", "Perfil lipídico", "Disponible");
            dgvResultados.Rows.Add(DateTime.Today.AddDays(-1).ToShortDateString(), "Suárez, Martín", "Imagen", "RX Tórax", "Pendiente");
            dgvResultados.Rows.Add(DateTime.Today.ToShortDateString(), "Vega, Manuel", "Cardiología", "ECG", "Disponible");
        }

        private void Filtrar()
        {
            // Aquí vas a aplicar tu query real. Placeholder informativo:
            MessageBox.Show("Aplicando filtros...\n" +
                            $"Paciente: {cboPaciente.Text}\nTipo: {cboTipo.Text}\n" +
                            $"Desde: {dtpDesde.Value:d}  Hasta: {dtpHasta.Value:d}",
                            "Filtros", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AccionFila(string accion)
        {
            if (dgvResultados.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un resultado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var paciente = dgvResultados.CurrentRow.Cells["Paciente"].Value?.ToString();
            var estudio = dgvResultados.CurrentRow.Cells["Estudio"].Value?.ToString();
            MessageBox.Show($"{accion}: {estudio} de {paciente}", "Acción",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

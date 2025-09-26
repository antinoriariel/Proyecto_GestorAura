using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public class FormAgenda : Form
    {
        private Panel headerPanel; private PictureBox picHeader; private Label lblHeader;
        private TableLayoutPanel filtrosGrid;
        private DateTimePicker dtpFecha;
        private ComboBox cboEstado;
        private TextBox txtBuscar;
        private CheckBox chkSoloPendientes;
        private Button btnHoy, btnLimpiar, btnActualizar;
        private DataGridView dgvTurnos;

        public FormAgenda()
        {
            Text = "Agenda";
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            BackColor = Color.WhiteSmoke;
            DoubleBuffered = true;
            Padding = new Padding(10);

            BuildHeader("Agenda del médico", SystemIcons.Information.ToBitmap());
            BuildFiltros();
            BuildGrid();

            var main = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3 };
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 90));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            main.Controls.Add(headerPanel, 0, 0);
            main.Controls.Add(filtrosGrid, 0, 1);
            main.Controls.Add(dgvTurnos, 0, 2);
            Controls.Add(main);

            Load += (s, e) => CargarMock();
        }

        private void BuildHeader(string titulo, Image icono)
        {
            headerPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(40, 56, 74), Padding = new Padding(12, 8, 12, 8) };
            picHeader = new PictureBox { Image = icono, SizeMode = PictureBoxSizeMode.Zoom, Width = 36, Height = 36, Dock = DockStyle.Left };
            lblHeader = new Label { Text = titulo, ForeColor = Color.White, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            headerPanel.Controls.Add(lblHeader); headerPanel.Controls.Add(picHeader);
        }

        private void BuildFiltros()
        {
            filtrosGrid = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 10, RowCount = 2, Padding = new Padding(0, 8, 0, 8) };
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));  // Fecha
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210));
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));  // Estado
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210));
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));  // Buscar
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160)); // Hoy
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160)); // Limpiar
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160)); // Actualizar
            filtrosGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180)); // chk

            var lblFecha = new Label { Text = "Fecha", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            dtpFecha = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Long };

            var lblEstado = new Label { Text = "Estado", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            cboEstado = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cboEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "En curso", "Completado", "Cancelado" });
            cboEstado.SelectedIndex = 0;

            var lblBuscar = new Label { Text = "Buscar", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            txtBuscar = new TextBox { Dock = DockStyle.Fill };

            btnHoy = new Button { Text = "Hoy", Dock = DockStyle.Fill, Height = 32 };
            btnLimpiar = new Button { Text = "Limpiar", Dock = DockStyle.Fill, Height = 32 };
            btnActualizar = new Button { Text = "Actualizar", Dock = DockStyle.Fill, Height = 32 };
            chkSoloPendientes = new CheckBox { Text = "Solo pendientes", Dock = DockStyle.Fill };

            btnHoy.Click += (s, e) => { dtpFecha.Value = DateTime.Today; AplicarFiltros(); };
            btnLimpiar.Click += (s, e) =>
            {
                dtpFecha.Value = DateTime.Today;
                cboEstado.SelectedIndex = 0;
                txtBuscar.Clear();
                chkSoloPendientes.Checked = false;
                AplicarFiltros();
            };
            btnActualizar.Click += (s, e) => AplicarFiltros();

            filtrosGrid.Controls.Add(lblFecha, 0, 0);
            filtrosGrid.Controls.Add(dtpFecha, 1, 0);
            filtrosGrid.Controls.Add(lblEstado, 2, 0);
            filtrosGrid.Controls.Add(cboEstado, 3, 0);
            filtrosGrid.Controls.Add(lblBuscar, 4, 0);
            filtrosGrid.Controls.Add(txtBuscar, 5, 0);
            filtrosGrid.Controls.Add(btnHoy, 6, 0);
            filtrosGrid.Controls.Add(btnLimpiar, 7, 0);
            filtrosGrid.Controls.Add(btnActualizar, 8, 0);
            filtrosGrid.Controls.Add(chkSoloPendientes, 9, 0);
        }

        private void BuildGrid()
        {
            dgvTurnos = new DataGridView
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

            dgvTurnos.Columns.Add("TurnoId", "TurnoId");
            dgvTurnos.Columns.Add("FechaHora", "FechaHora");
            dgvTurnos.Columns.Add("Fecha", "Fecha");
            dgvTurnos.Columns.Add("Hora", "Hora");
            dgvTurnos.Columns.Add("Paciente", "Paciente");
            dgvTurnos.Columns.Add("Motivo", "Motivo");
            dgvTurnos.Columns.Add("Estado", "Estado");

            dgvTurnos.CellFormatting += (s, e) =>
            {
                if (dgvTurnos.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
                {
                    var row = dgvTurnos.Rows[e.RowIndex];
                    var estado = e.Value.ToString();
                    row.DefaultCellStyle.BackColor = estado switch
                    {
                        "Pendiente" => Color.FromArgb(255, 246, 200),
                        "En curso" => Color.FromArgb(220, 240, 255),
                        "Completado" => Color.FromArgb(210, 245, 210),
                        "Cancelado" => Color.FromArgb(255, 220, 220),
                        _ => row.DefaultCellStyle.BackColor
                    };
                }
            };
        }

        private void CargarMock()
        {
            dgvTurnos.Rows.Clear();
            dgvTurnos.Rows.Add(Guid.NewGuid(), "26/9/2025 09:00", "26/09/2025", "09:00", "Ana Gómez", "Control de presión", "Pendiente");
            dgvTurnos.Rows.Add(Guid.NewGuid(), "26/9/2025 09:30", "26/09/2025", "09:30", "Bruno Martínez", "Dolor abdominal", "Pendiente");
            dgvTurnos.Rows.Add(Guid.NewGuid(), "26/9/2025 10:00", "26/09/2025", "10:00", "Carla López", "Resultado de estudio", "En curso");
            dgvTurnos.Rows.Add(Guid.NewGuid(), "26/9/2025 11:00", "26/09/2025", "11:00", "Diego Pérez", "Consulta general", "Completado");
            dgvTurnos.Rows.Add(Guid.NewGuid(), "26/9/2025 12:30", "26/09/2025", "12:30", "Facundo Ruiz", "Gripe y fiebre", "Cancelado");
        }

        private void AplicarFiltros()
        {
            // Acá iría tu consulta/refresh real. Placeholder:
            MessageBox.Show("Actualizando agenda con filtros aplicados.",
                "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

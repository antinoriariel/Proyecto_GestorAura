using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public class FormNotas : Form
    {
        private Panel headerPanel; private PictureBox picHeader; private Label lblHeader;
        private SplitContainer split;
        private DataGridView dgvNotas;
        private TextBox txtTitulo, txtContenido, txtBuscar;
        private Button btnNuevo, btnGuardar, btnEliminar, btnBuscar;

        public FormNotas()
        {
            Text = "Notas";
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            BackColor = Color.WhiteSmoke;
            DoubleBuffered = true;
            Padding = new Padding(10);

            BuildHeader("Notas", SystemIcons.Warning.ToBitmap());
            BuildBody();

            var main = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            main.Controls.Add(headerPanel, 0, 0);
            main.Controls.Add(split, 0, 1);
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

        private void BuildBody()
        {
            split = new SplitContainer { Dock = DockStyle.Fill, SplitterDistance = 420, FixedPanel = FixedPanel.Panel1 };

            // Lista + búsqueda
            var left = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 2, Padding = new Padding(6) };
            left.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            left.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            left.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            left.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            txtBuscar = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "Buscar título..." };
            btnBuscar = new Button { Text = "Buscar", Dock = DockStyle.Fill };
            btnNuevo = new Button { Text = "Nuevo", Dock = DockStyle.Fill };
            btnBuscar.Click += (s, e) => Buscar();
            btnNuevo.Click += (s, e) => Nuevo();

            dgvNotas = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            dgvNotas.Columns.Add("Id", "Id");
            dgvNotas.Columns.Add("Fecha", "Fecha");
            dgvNotas.Columns.Add("Titulo", "Título");
            dgvNotas.Columns.Add("Resumen", "Resumen");
            dgvNotas.Columns["Id"].Visible = false;
            dgvNotas.CellClick += (s, e) => CargarDetalle();

            left.Controls.Add(txtBuscar, 0, 0);
            left.Controls.Add(btnBuscar, 1, 0);
            left.Controls.Add(btnNuevo, 2, 0);
            left.Controls.Add(dgvNotas, 0, 1);
            left.SetColumnSpan(dgvNotas, 3);

            split.Panel1.Controls.Add(left);

            // Detalle
            var right = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 5, Padding = new Padding(6) };
            right.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            right.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            right.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 8));
            right.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            right.Controls.Add(new Label { Text = "Título", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, 0);
            txtTitulo = new TextBox { Dock = DockStyle.Fill };
            right.Controls.Add(txtTitulo, 1, 0);

            right.Controls.Add(new Label { Text = "Contenido", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, 1);
            txtContenido = new TextBox { Dock = DockStyle.Fill, Multiline = true, ScrollBars = ScrollBars.Vertical };
            right.Controls.Add(txtContenido, 1, 1);
            right.SetRowSpan(txtContenido, 2);

            var acciones = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
            btnGuardar = new Button { Text = "Guardar", Width = 120, Height = 32, Margin = new Padding(6) };
            btnEliminar = new Button { Text = "Eliminar", Width = 120, Height = 32, Margin = new Padding(6) };
            acciones.Controls.AddRange(new Control[] { btnGuardar, btnEliminar });

            btnGuardar.Click += (s, e) => Guardar();
            btnEliminar.Click += (s, e) => Eliminar();

            right.Controls.Add(new Label(), 0, 3);
            right.Controls.Add(acciones, 0, 4);
            right.SetColumnSpan(acciones, 2);

            split.Panel2.Controls.Add(right);
        }

        private void CargarMock()
        {
            dgvNotas.Rows.Clear();
            dgvNotas.Rows.Add(Guid.NewGuid(), DateTime.Today.ToShortDateString(), "Llamar a laboratorio", "Confirmar entrega de RX 10:00");
            dgvNotas.Rows.Add(Guid.NewGuid(), DateTime.Today.ToShortDateString(), "Recordar turno", "Paciente García, lunes 9hs");
            dgvNotas.Rows.Add(Guid.NewGuid(), DateTime.Today.AddDays(-1).ToShortDateString(), "Entrega informes", "Carpeta Dr. López");
            if (dgvNotas.Rows.Count > 0) dgvNotas.Rows[0].Selected = true;
            CargarDetalle();
        }

        private void Buscar()
        {
            // Placeholder. En datos reales: filtrar por txtBuscar.Text
            MessageBox.Show($"Buscar: {txtBuscar.Text}", "Notas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Nuevo()
        {
            txtTitulo.Clear();
            txtContenido.Clear();
            txtTitulo.Focus();
        }

        private void CargarDetalle()
        {
            if (dgvNotas.CurrentRow == null) return;
            txtTitulo.Text = dgvNotas.CurrentRow.Cells["Titulo"].Value?.ToString();
            txtContenido.Text = dgvNotas.CurrentRow.Cells["Resumen"].Value?.ToString();
        }

        private void Guardar()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Ingresá un título.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvNotas.CurrentRow == null)
                dgvNotas.Rows.Add(Guid.NewGuid(), DateTime.Now.ToShortDateString(), txtTitulo.Text, txtContenido.Text);
            else
            {
                dgvNotas.CurrentRow.Cells["Titulo"].Value = txtTitulo.Text;
                dgvNotas.CurrentRow.Cells["Resumen"].Value = txtContenido.Text;
            }
            MessageBox.Show("Nota guardada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Eliminar()
        {
            if (dgvNotas.CurrentRow == null) return;
            dgvNotas.Rows.RemoveAt(dgvNotas.CurrentRow.Index);
        }
    }
}

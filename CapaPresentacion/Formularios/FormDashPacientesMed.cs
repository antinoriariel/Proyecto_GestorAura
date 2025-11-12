using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormDashPacientesMed : Form
    {
        private readonly PacienteNegocio _pacienteNegocio = new();
        private DataTable _tablaPacientes = new();
        private readonly int _idUsuarioActual; // ← id del médico o usuario logueado

        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        private GroupBox grpPacientes;
        private FlowLayoutPanel panelTop;
        private TextBox txtBuscar;
        private Label lblTotal;
        private Button btnVerDetalles;
        private DataGridView dgvPacientes;

        // Constructor con ID del usuario actual
        public FormDashPacientesMed(int idUsuarioActual = 0)
        {
            _idUsuarioActual = idUsuarioActual;
            InitializeComponent();
            Load += (s, e) => CargarPacientes();
        }

        private void CargarPacientes()
        {
            try
            {
                var lista = _pacienteNegocio.ObtenerPacientes(true);

                _tablaPacientes = new DataTable();
                _tablaPacientes.Columns.Add("id_paciente", typeof(int));
                _tablaPacientes.Columns.Add("dni", typeof(string));
                _tablaPacientes.Columns.Add("paciente", typeof(string));
                _tablaPacientes.Columns.Add("sexo", typeof(string));
                _tablaPacientes.Columns.Add("telefono", typeof(string));
                _tablaPacientes.Columns.Add("email", typeof(string));

                foreach (var p in lista)
                {
                    _tablaPacientes.Rows.Add(
                        p.IdPaciente,
                        p.Dni,
                        $"{p.Apellido}, {p.Nombre}",
                        p.Sexo == "M" ? "👨 Masculino" : "👩 Femenino",
                        string.IsNullOrWhiteSpace(p.Telefono) ? "—" : $"📞 {p.Telefono}",
                        string.IsNullOrWhiteSpace(p.Email) ? "—" : p.Email
                    );
                }

                dgvPacientes.DataSource = _tablaPacientes;
                ActualizarContador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarPacientes()
        {
            if (_tablaPacientes == null || _tablaPacientes.Rows.Count == 0)
                return;

            string buscar = txtBuscar.Text.Trim().Replace("'", "''");
            string filtro = string.IsNullOrEmpty(buscar)
                ? ""
                : $"(paciente LIKE '%{buscar}%' OR dni LIKE '%{buscar}%')";

            try
            {
                _tablaPacientes.DefaultView.RowFilter = filtro;
                ActualizarContador();
            }
            catch { }
        }

        private void ActualizarContador()
        {
            int total = _tablaPacientes?.DefaultView.Count ?? 0;
            lblTotal.Text = total == 1 ? "1 paciente" : $"{total} pacientes";
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e) => FiltrarPacientes();

        private void BtnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente para ver sus detalles.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRowView row = (DataRowView)dgvPacientes.SelectedRows[0].DataBoundItem;
            int idPaciente = Convert.ToInt32(row["id_paciente"]);

            string info = $"🧾 Datos del paciente:\n\n" +
                          $"DNI: {row["dni"]}\n" +
                          $"Nombre: {row["paciente"]}\n" +
                          $"Sexo: {row["sexo"]}\n" +
                          $"Teléfono: {row["telefono"]}\n" +
                          $"Correo: {row["email"]}";

            // 🔹 Ahora pasa idPaciente e idUsuarioActual al popup
            using var popup = new FormPopupPaciente(info, idPaciente, _idUsuarioActual);
            popup.ShowDialog();
        }

        // ====================================================
        // DISEÑO (idéntico al anterior)
        // ====================================================
        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(1080, 700);
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Pacientes";
            Padding = new Padding(21, 12, 21, 12);

            headerPanel = new Panel
            {
                BackColor = Color.FromArgb(41, 57, 71),
                Dock = DockStyle.Top,
                Height = 48
            };
            picHeader = new PictureBox
            {
                Image = Properties.Resources.pacienteIcon,
                Location = new Point(14, 9),
                Size = new Size(35, 30),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            lblHeader = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(56, 12),
                Text = "Panel de Pacientes"
            };
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);

            grpPacientes = new GroupBox
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(14, 12, 14, 12),
                Text = "Listado de Pacientes",
                Font = new Font("Segoe UI", 10.5F)
            };

            panelTop = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false,
                Padding = new Padding(4, 0, 4, 8)
            };

            txtBuscar = new TextBox
            {
                PlaceholderText = "Buscar por nombre o DNI...",
                Font = new Font("Segoe UI", 10.5F),
                BorderStyle = BorderStyle.FixedSingle,
                Width = 280,
                Margin = new Padding(0, 4, 8, 4)
            };
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            lblTotal = new Label
            {
                Text = "0 pacientes",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#0088cc"),
                AutoSize = true,
                Margin = new Padding(8, 9, 8, 4)
            };

            btnVerDetalles = new Button
            {
                Text = "Ver Detalles",
                Height = 36,
                Width = 140,
                BackColor = ColorTranslator.FromHtml("#0088cc"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                Margin = new Padding(24, 4, 0, 4),
                Cursor = Cursors.Hand
            };
            btnVerDetalles.FlatAppearance.BorderSize = 0;
            btnVerDetalles.Click += BtnVerDetalles_Click;

            panelTop.Controls.Add(txtBuscar);
            panelTop.Controls.Add(lblTotal);
            panelTop.Controls.Add(btnVerDetalles);

            dgvPacientes = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = ColorTranslator.FromHtml("#dddddd"),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowTemplate = { Height = 44 },
                EnableHeadersVisualStyles = false
            };

            dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f0f0f0");
            dgvPacientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#333333");
            dgvPacientes.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvPacientes.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#e3f2fd");
            dgvPacientes.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#0088cc");
            dgvPacientes.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#f9f9f9");

            grpPacientes.Controls.Add(dgvPacientes);
            grpPacientes.Controls.Add(panelTop);

            Controls.Add(grpPacientes);
            Controls.Add(headerPanel);
            ResumeLayout(false);
        }
    }
}

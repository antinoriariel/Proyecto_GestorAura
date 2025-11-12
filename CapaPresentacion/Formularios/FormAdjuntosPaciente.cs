using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio; // HistoriaClinicaNegocio y ArchivoPacienteNegocio

namespace CapaPresentacion.Formularios
{
    public partial class FormAdjuntosPaciente : Form
    {
        // ===== Header =====
        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        // ===== Selección =====
        private TableLayoutPanel infoGrid;
        private Label lblPaciente;
        private TextBox txtPaciente;
        private Label lblDescripcion;
        private TextBox txtDescripcion;

        // ===== Grilla =====
        private DataGridView dgvAdjuntos;

        // ===== Acciones =====
        private FlowLayoutPanel accionesPanel;
        private Button btnAgregar;
        private Button btnAbrir;
        private Button btnEliminar;
        private Button btnAbrirCarpeta;

        // ===== Contexto / lógica =====
        private readonly int _idUsuarioActual;
        private int _idPacienteSeleccionado = 0;

        private readonly HistoriaClinicaNegocio _hcNegocio = new();
        private readonly ArchivoPacienteNegocio _archivoNegocio = new();
        private AutoCompleteStringCollection _autoPacientes = new();

        private List<(int Id, string NombreCompleto)> _pacientes = new();

        // ===============================================================
        // CONSTRUCTOR PRINCIPAL (solo usuario)
        // ===============================================================
        public FormAdjuntosPaciente(int idUsuarioActual)
        {
            _idUsuarioActual = idUsuarioActual;
            InicializarFormulario();

            Load += (s, e) => ConfigurarAutocompletadoPacientes();
        }

        // ===============================================================
        // SOBRECARGA: usuario + paciente inicial
        // ===============================================================
        public FormAdjuntosPaciente(int idUsuarioActual, int idPacienteInicial)
        {
            _idUsuarioActual = idUsuarioActual;
            _idPacienteSeleccionado = idPacienteInicial;
            InicializarFormulario();

            Load += (s, e) =>
            {
                ConfigurarAutocompletadoPacientes();

                // Buscar el nombre del paciente en la lista y fijarlo
                var paciente = _pacientes.FirstOrDefault(p => p.Id == _idPacienteSeleccionado);
                if (paciente.Id != 0)
                {
                    txtPaciente.Text = paciente.NombreCompleto;
                    txtPaciente.Enabled = false; // Evitar modificarlo
                    CargarAdjuntos();
                }
                else
                {
                    MessageBox.Show("No se encontró el paciente indicado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
        }

        // ===============================================================
        // ESTRUCTURA VISUAL Y CONFIGURACIÓN
        // ===============================================================
        private void InicializarFormulario()
        {
            Text = "Archivos Adjuntos de Pacientes";
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            BackColor = Color.WhiteSmoke;
            DoubleBuffered = true;
            Padding = new Padding(10);
            KeyPreview = true;

            BuildHeader("Archivos adjuntos de pacientes", SystemIcons.Information.ToBitmap());
            BuildSeleccion();
            BuildGrid();
            BuildAcciones();

            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4
            };
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 90));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));

            main.Controls.Add(headerPanel, 0, 0);
            main.Controls.Add(infoGrid, 0, 1);
            main.Controls.Add(dgvAdjuntos, 0, 2);
            main.Controls.Add(accionesPanel, 0, 3);

            Controls.Add(main);
            KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) Close(); };
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

        private void BuildSeleccion()
        {
            infoGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 2,
                Padding = new Padding(0, 8, 0, 8)
            };

            infoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
            infoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            infoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            infoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            lblPaciente = new Label
            {
                Text = "Paciente",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            txtPaciente = new TextBox
            {
                Dock = DockStyle.Fill
            };
            txtPaciente.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                    e.Handled = true;
            };
            txtPaciente.TextChanged += (s, e) =>
            {
                _idPacienteSeleccionado = ResolverIdPacientePorNombre(txtPaciente.Text.Trim());
                CargarAdjuntos();
            };

            lblDescripcion = new Label
            {
                Text = "Descripción",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            txtDescripcion = new TextBox
            {
                Dock = DockStyle.Fill,
                PlaceholderText = "Descripción opcional del archivo a subir..."
            };

            infoGrid.Controls.Add(lblPaciente, 0, 0);
            infoGrid.Controls.Add(txtPaciente, 1, 0);
            infoGrid.Controls.Add(lblDescripcion, 2, 0);
            infoGrid.Controls.Add(txtDescripcion, 3, 0);
        }

        private void BuildGrid()
        {
            dgvAdjuntos = new DataGridView
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

            dgvAdjuntos.Columns.Add("id_archivo", "ID");
            dgvAdjuntos.Columns.Add("fecha_subida", "Fecha");
            dgvAdjuntos.Columns.Add("nombre_original", "Nombre original");
            dgvAdjuntos.Columns.Add("tipo_archivo", "Tipo");
            dgvAdjuntos.Columns.Add("tamaño_kb", "Tamaño (KB)");
            dgvAdjuntos.Columns.Add("descripcion", "Descripción");
            dgvAdjuntos.Columns.Add("ruta_archivo", "Ruta");
            dgvAdjuntos.Columns["ruta_archivo"].Visible = false;
            dgvAdjuntos.Columns["id_archivo"].Width = 80;
        }

        private void BuildAcciones()
        {
            accionesPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 8, 0, 8)
            };

            btnAgregar = new Button { Text = "Agregar", Width = 130, Height = 36, Margin = new Padding(8) };
            btnAbrir = new Button { Text = "Abrir", Width = 120, Height = 36, Margin = new Padding(8) };
            btnEliminar = new Button { Text = "Eliminar", Width = 120, Height = 36, Margin = new Padding(8) };
            btnAbrirCarpeta = new Button { Text = "Abrir carpeta", Width = 140, Height = 36, Margin = new Padding(8) };

            btnAgregar.Click += BtnAgregar_Click;
            btnAbrir.Click += BtnAbrir_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnAbrirCarpeta.Click += BtnAbrirCarpeta_Click;

            accionesPanel.Controls.AddRange(new Control[] { btnAgregar, btnAbrir, btnEliminar, btnAbrirCarpeta });
        }

        // ===============================================================
        // AUTOCOMPLETADO
        // ===============================================================
        private void ConfigurarAutocompletadoPacientes()
        {
            try
            {
                _autoPacientes = new AutoCompleteStringCollection();
                _pacientes = new List<(int Id, string NombreCompleto)>();

                var pacientes = _hcNegocio.ObtenerPacientes();
                foreach (var p in pacientes)
                {
                    _autoPacientes.Add(p.NombreCompleto);
                    _pacientes.Add((p.Id, p.NombreCompleto));
                }

                txtPaciente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtPaciente.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPaciente.AutoCompleteCustomSource = _autoPacientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando pacientes:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ResolverIdPacientePorNombre(string nombreCompleto)
        {
            if (string.IsNullOrWhiteSpace(nombreCompleto)) return 0;
            var item = _pacientes.FirstOrDefault(p =>
                string.Equals(p.NombreCompleto, nombreCompleto, StringComparison.OrdinalIgnoreCase));
            return item.Id;
        }

        // ===============================================================
        // LÓGICA DE ADJUNTOS
        // ===============================================================
        private void CargarAdjuntos()
        {
            try
            {
                if (_idPacienteSeleccionado == 0)
                {
                    dgvAdjuntos.Rows.Clear();
                    return;
                }

                DataTable dt = _archivoNegocio.ObtenerPorPaciente(_idPacienteSeleccionado);
                dgvAdjuntos.Rows.Clear();

                foreach (DataRow r in dt.Rows)
                {
                    dgvAdjuntos.Rows.Add(
                        r["id_archivo"],
                        Convert.ToDateTime(r["fecha_subida"]).ToString("yyyy-MM-dd HH:mm"),
                        r["nombre_original"],
                        r["tipo_archivo"],
                        r["tamaño_kb"],
                        r["descripcion"],
                        r["ruta_archivo"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar adjuntos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===============================================================
        // ACCIONES
        // ===============================================================
        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (_idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná un paciente válido antes de subir un archivo.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPaciente.Focus();
                return;
            }

            using var ofd = new OpenFileDialog
            {
                Title = "Seleccionar archivo",
                Filter = "Todos|*.*|PDF|*.pdf|Imágenes|*.jpg;*.jpeg;*.png;*.bmp|Documentos|*.docx;*.xlsx;*.pptx",
                Multiselect = false
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _archivoNegocio.SubirArchivo(
                        idPaciente: _idPacienteSeleccionado,
                        idUsuarioSubidor: _idUsuarioActual,
                        rutaOrigen: ofd.FileName,
                        descripcion: string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim()
                    );

                    txtDescripcion.Clear();
                    CargarAdjuntos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al subir archivo:\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAbrir_Click(object? sender, EventArgs e)
        {
            if (dgvAdjuntos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un adjunto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string? ruta = dgvAdjuntos.CurrentRow.Cells["ruta_archivo"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
            {
                MessageBox.Show("El archivo no se encuentra en la ruta registrada.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo { FileName = ruta, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el archivo.\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvAdjuntos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un adjunto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idArchivo = Convert.ToInt32(dgvAdjuntos.CurrentRow.Cells["id_archivo"].Value);

            if (MessageBox.Show("¿Eliminar lógicamente el adjunto seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool ok = _archivoNegocio.EliminarLogico(idArchivo);
                    if (ok) CargarAdjuntos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar.\n{ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAbrirCarpeta_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_idPacienteSeleccionado == 0)
                {
                    MessageBox.Show("Seleccioná un paciente primero.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dgvAdjuntos.Rows.Count > 0)
                {
                    string? ruta = dgvAdjuntos.Rows[0].Cells["ruta_archivo"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(ruta))
                    {
                        string dir = Path.GetDirectoryName(ruta)!;
                        if (Directory.Exists(dir))
                        {
                            Process.Start("explorer.exe", dir);
                            return;
                        }
                    }
                }

                MessageBox.Show("No se pudo determinar la carpeta porque no hay adjuntos aún.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir la carpeta.\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

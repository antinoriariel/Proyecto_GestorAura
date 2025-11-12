using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormAdjuntosPaciente : Form
    {
        // ===== Header =====
        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        // ===== Selección =====
        private Panel panelSeleccion;
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
        // CONSTRUCTORES
        // ===============================================================
        public FormAdjuntosPaciente(int idUsuarioActual)
        {
            _idUsuarioActual = idUsuarioActual;
            InicializarFormulario();
            Load += (s, e) => ConfigurarAutocompletadoPacientes();
        }

        public FormAdjuntosPaciente(int idUsuarioActual, int idPacienteInicial)
        {
            _idUsuarioActual = idUsuarioActual;
            _idPacienteSeleccionado = idPacienteInicial;
            InicializarFormulario();

            Load += (s, e) =>
            {
                ConfigurarAutocompletadoPacientes();
                var paciente = _pacientes.FirstOrDefault(p => p.Id == _idPacienteSeleccionado);
                if (paciente.Id != 0)
                {
                    txtPaciente.Text = paciente.NombreCompleto;
                    txtPaciente.Enabled = false;
                    CargarAdjuntos();
                }
                else
                {
                    MessageBox.Show("No se encontró el paciente especificado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
        }

        // ===============================================================
        // CONFIGURACIÓN VISUAL
        // ===============================================================
        private void InicializarFormulario()
        {
            Text = "Archivos Adjuntos de Pacientes";
            BackColor = Color.WhiteSmoke;
            DoubleBuffered = true;
            Padding = new Padding(12);
            KeyPreview = true;

            BuildHeader();
            BuildSeleccion();
            BuildGrid();
            BuildAcciones();

            var main = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(0)
            };

            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 65));
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            main.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));

            main.Controls.Add(headerPanel, 0, 0);
            main.Controls.Add(panelSeleccion, 0, 1);
            main.Controls.Add(dgvAdjuntos, 0, 2);
            main.Controls.Add(accionesPanel, 0, 3);

            Controls.Add(main);
            KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) Close(); };
        }

        private void BuildHeader()
        {
            headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(41, 57, 71),
                Padding = new Padding(15, 12, 15, 12)
            };

            picHeader = new PictureBox
            {
                Image = Properties.Resources.hcIcon,
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 40,
                Height = 40,
                Dock = DockStyle.Left
            };

            lblHeader = new Label
            {
                Text = "Archivos adjuntos de pacientes",
                ForeColor = Color.White,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Consolas", 15F, FontStyle.Bold),
                Padding = new Padding(15, 0, 0, 0)
            };

            headerPanel.Controls.Add(lblHeader);
            headerPanel.Controls.Add(picHeader);
        }

        private void BuildSeleccion()
        {
            panelSeleccion = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(20, 8, 20, 8)
            };

            lblPaciente = new Label
            {
                Text = "Paciente:",
                Font = new Font("Consolas", 10F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(0, 5)
            };

            txtPaciente = new TextBox
            {
                Font = new Font("Consolas", 10F),
                Width = 350,
                Location = new Point(100, 2),
                BorderStyle = BorderStyle.FixedSingle
            };

            txtPaciente.Leave += TxtPaciente_Leave;
            txtPaciente.KeyDown += TxtPaciente_KeyDown;

            lblDescripcion = new Label
            {
                Text = "Descripción:",
                Font = new Font("Consolas", 10F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(470, 5)
            };

            txtDescripcion = new TextBox
            {
                Font = new Font("Consolas", 10F),
                Width = 450,
                Location = new Point(580, 2),
                BorderStyle = BorderStyle.FixedSingle,
                PlaceholderText = "Descripción opcional del archivo..."
            };

            panelSeleccion.Controls.AddRange(new Control[] {
                lblPaciente, txtPaciente, lblDescripcion, txtDescripcion
            });
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
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ColumnHeadersHeight = 35,
                RowTemplate = { Height = 28 },
                Font = new Font("Consolas", 9F),
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(52, 73, 94),
                    ForeColor = Color.White,
                    Font = new Font("Consolas", 10F, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Padding = new Padding(5, 0, 0, 0)
                },
                EnableHeadersVisualStyles = false,
                AllowUserToResizeRows = false
            };

            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id_archivo",
                HeaderText = "ID",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fecha_subida",
                HeaderText = "Fecha",
                Width = 150
            });

            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_original",
                HeaderText = "Nombre original",
                Width = 300
            });

            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "tipo_archivo",
                HeaderText = "Tipo",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "tamaño_kb",
                HeaderText = "Tamaño (KB)",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "descripcion",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 200
            });

            dgvAdjuntos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ruta_archivo",
                HeaderText = "Ruta",
                Visible = false
            });

            // Alternar colores de filas
            dgvAdjuntos.RowsDefaultCellStyle.BackColor = Color.White;
            dgvAdjuntos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
        }

        private void BuildAcciones()
        {
            accionesPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(5, 10, 5, 10),
                BackColor = Color.FromArgb(245, 245, 245)
            };

            var estiloBoton = new Font("Consolas", 10F, FontStyle.Bold);

            btnAgregar = new Button
            {
                Text = "➕ Agregar",
                Width = 130,
                Height = 38,
                Margin = new Padding(6),
                Font = estiloBoton,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAgregar.FlatAppearance.BorderSize = 0;

            btnAbrir = new Button
            {
                Text = "📂 Abrir",
                Width = 120,
                Height = 38,
                Margin = new Padding(6),
                Font = estiloBoton,
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAbrir.FlatAppearance.BorderSize = 0;

            btnEliminar = new Button
            {
                Text = "🗑 Eliminar",
                Width = 130,
                Height = 38,
                Margin = new Padding(6),
                Font = estiloBoton,
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnEliminar.FlatAppearance.BorderSize = 0;

            btnAbrirCarpeta = new Button
            {
                Text = "📁 Carpeta",
                Width = 130,
                Height = 38,
                Margin = new Padding(6),
                Font = estiloBoton,
                BackColor = Color.FromArgb(155, 89, 182),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAbrirCarpeta.FlatAppearance.BorderSize = 0;

            btnAgregar.Click += BtnAgregar_Click;
            btnAbrir.Click += BtnAbrir_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnAbrirCarpeta.Click += BtnAbrirCarpeta_Click;

            accionesPanel.Controls.AddRange(new Control[] {
                btnAgregar, btnAbrir, btnEliminar, btnAbrirCarpeta
            });
        }

        // ===============================================================
        // EVENTOS DE SELECCIÓN
        // ===============================================================
        private void TxtPaciente_Leave(object? sender, EventArgs e)
        {
            ProcesarSeleccionPaciente();
        }

        private void TxtPaciente_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcesarSeleccionPaciente();
            }
        }

        private void ProcesarSeleccionPaciente()
        {
            int idAnterior = _idPacienteSeleccionado;
            _idPacienteSeleccionado = ResolverIdPacientePorNombre(txtPaciente.Text.Trim());

            if (_idPacienteSeleccionado != idAnterior)
            {
                if (_idPacienteSeleccionado > 0)
                {
                    CargarAdjuntos();
                }
                else
                {
                    dgvAdjuntos.Rows.Clear();
                    lblHeader.Text = "Archivos adjuntos de pacientes";
                    if (!string.IsNullOrWhiteSpace(txtPaciente.Text))
                    {
                        MessageBox.Show("El paciente ingresado no es válido.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
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
        // CARGA DE DATOS
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
                        Convert.ToDateTime(r["fecha_subida"]).ToString("dd/MM/yyyy HH:mm"),
                        r["nombre_original"],
                        r["tipo_archivo"],
                        $"{r["tamaño_kb"]:N0}",
                        r["descripcion"],
                        r["ruta_archivo"]
                    );
                }

                lblHeader.Text = dgvAdjuntos.Rows.Count == 0
                    ? "Archivos adjuntos de pacientes - Sin archivos"
                    : $"Archivos adjuntos de pacientes - {dgvAdjuntos.Rows.Count} archivo(s)";
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
                    MessageBox.Show("Archivo agregado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string nombreArchivo = dgvAdjuntos.CurrentRow.Cells["nombre_original"].Value?.ToString() ?? "";

            if (MessageBox.Show($"¿Eliminar el adjunto \"{nombreArchivo}\"?\n\nEsta acción es lógica, el archivo físico permanecerá en disco.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool ok = _archivoNegocio.EliminarLogico(idArchivo);
                    if (ok)
                    {
                        CargarAdjuntos();
                        MessageBox.Show("Adjunto eliminado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
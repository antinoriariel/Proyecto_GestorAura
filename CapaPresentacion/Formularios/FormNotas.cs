using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormNotas : Form
    {
        private readonly NotaNegocio notaNegocio = new NotaNegocio();
        private readonly int idSecretaria;
        private int? notaSeleccionadaId;

        // Controles
        private TableLayoutPanel tlpRoot;
        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;
        private SplitContainer split;
        private DataGridView dgvNotas;
        private TextBox txtBuscar, txtTitulo, txtContenido;
        private Button btnBuscar, btnNuevo, btnGuardar, btnEliminar;
        private Label lblTituloCaption, lblContenidoCaption;
        private TableLayoutPanel leftTlp, rightTlp;
        private FlowLayoutPanel pnlAcciones;

        public FormNotas(int idSecretaria)
        {
            this.idSecretaria = idSecretaria;
            InitializeComponent();

            Load += FormNotas_Load;
        }

        private void FormNotas_Load(object sender, EventArgs e)
        {
            CargarNotas();

            // Ajustar el split en el próximo ciclo de eventos
            BeginInvoke(new Action(() => AjustarSplitSeguro()));
        }

        // ===============================
        //   INTERFAZ GRÁFICA
        // ===============================
        private void InitializeComponent()
        {
            // Configuración del formulario
            Text = "Notas de la secretaria";
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            BackColor = Color.WhiteSmoke;
            Padding = new Padding(8);
            DoubleBuffered = true;
            MinimumSize = new Size(900, 600);
            ClientSize = new Size(1100, 680);
            StartPosition = FormStartPosition.CenterScreen;

            // ===== ROOT LAYOUT =====
            tlpRoot = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent
            };
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // ===== HEADER PANEL =====
            headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(40, 56, 74),
                Padding = new Padding(14, 10, 14, 10)
            };

            picHeader = new PictureBox
            {
                Dock = DockStyle.Left,
                Width = 40,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Cargar el ícono desde Properties.Resources
            try
            {
                picHeader.Image = Properties.Resources.calendarTodayIcon;
            }
            catch
            {
                // Si no se encuentra, crear un ícono simple
                try
                {
                    Bitmap icon = new Bitmap(40, 40);
                    using (Graphics g = Graphics.FromImage(icon))
                    {
                        g.Clear(Color.FromArgb(40, 56, 74));
                        g.FillEllipse(Brushes.White, 8, 8, 24, 24);
                        g.DrawString("N", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.DarkSlateGray, 12, 8);
                    }
                    picHeader.Image = icon;
                }
                catch { }
            }

            lblHeader = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = "Notas de la secretaria",
                TextAlign = ContentAlignment.MiddleLeft
            };

            headerPanel.Controls.Add(lblHeader);
            headerPanel.Controls.Add(picHeader);

            // ===== SPLIT CONTAINER =====
            split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterWidth = 6,
                FixedPanel = FixedPanel.None,
                IsSplitterFixed = false
            };

            // Establecer los mínimos DESPUÉS de agregarlo al contenedor
            // para evitar conflictos durante la inicialización

            // ===== PANEL IZQUIERDO (Lista de notas) =====
            leftTlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(6),
                ColumnCount = 3,
                RowCount = 2
            };
            leftTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            leftTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            leftTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F)); // Aumentado para los botones
            leftTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            txtBuscar = new TextBox
            {
                Dock = DockStyle.Fill,
                PlaceholderText = "Buscar título...",
                Font = new Font("Consolas", 11F),
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };
            txtBuscar.Height = 36; // Mismo alto que los botones

            btnBuscar = new Button
            {
                Text = "Buscar",
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Height = 36
            };
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.Click += btnBuscar_Click;

            btnNuevo = new Button
            {
                Text = "Nuevo",
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Height = 36
            };
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.Click += btnNuevo_Click;

            dgvNotas = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                GridColor = Color.Gainsboro,
                Font = new Font("Consolas", 10F)
            };
            dgvNotas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvNotas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNotas.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 10F, FontStyle.Bold);
            dgvNotas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvNotas.CellClick += dgvNotas_CellClick;

            leftTlp.Controls.Add(txtBuscar, 0, 0);
            leftTlp.Controls.Add(btnBuscar, 1, 0);
            leftTlp.Controls.Add(btnNuevo, 2, 0);
            leftTlp.Controls.Add(dgvNotas, 0, 1);
            leftTlp.SetColumnSpan(dgvNotas, 3);

            // ===== PANEL DERECHO (Detalle de nota) =====
            rightTlp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(6),
                ColumnCount = 2,
                RowCount = 5
            };
            rightTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            rightTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            rightTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            rightTlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rightTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            rightTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));

            lblTituloCaption = new Label
            {
                Text = "Título:",
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 11F, FontStyle.Bold)
            };

            txtTitulo = new TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 11F)
            };

            lblContenidoCaption = new Label
            {
                Text = "Contenido:",
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 11F, FontStyle.Bold)
            };

            txtContenido = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 10F)
            };

            pnlAcciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false
            };

            btnGuardar = new Button
            {
                Text = "Guardar",
                AutoSize = true,
                Height = 36,
                Padding = new Padding(20, 0, 20, 0),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(8, 6, 0, 6)
            };
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += btnGuardar_Click;

            btnEliminar = new Button
            {
                Text = "Eliminar",
                AutoSize = true,
                Height = 36,
                Padding = new Padding(20, 0, 20, 0),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(8, 6, 0, 6)
            };
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Click += btnEliminar_Click;

            pnlAcciones.Controls.Add(btnGuardar);
            pnlAcciones.Controls.Add(btnEliminar);

            rightTlp.Controls.Add(lblTituloCaption, 0, 0);
            rightTlp.Controls.Add(txtTitulo, 1, 0);
            rightTlp.Controls.Add(lblContenidoCaption, 0, 1);
            rightTlp.Controls.Add(txtContenido, 1, 1);
            rightTlp.SetRowSpan(txtContenido, 2);
            rightTlp.Controls.Add(pnlAcciones, 0, 4);
            rightTlp.SetColumnSpan(pnlAcciones, 2);

            // ===== ENSAMBLAR TODO =====
            split.Panel1.Controls.Add(leftTlp);
            split.Panel2.Controls.Add(rightTlp);

            tlpRoot.Controls.Add(headerPanel, 0, 0);
            tlpRoot.Controls.Add(split, 0, 1);

            Controls.Add(tlpRoot);

            // Configurar los tamaños mínimos DESPUÉS de que todo esté agregado
            split.Panel1MinSize = 300;
            split.Panel2MinSize = 250;
        }

        // Ajusta SplitContainer dinámicamente evitando errores
        private void AjustarSplitSeguro()
        {
            if (split == null || !split.IsHandleCreated || split.Width <= 0)
                return;

            try
            {
                int ancho = split.Width;
                int min1 = split.Panel1MinSize;
                int min2 = split.Panel2MinSize;
                int splitterWidth = split.SplitterWidth;

                // Verificar que hay espacio suficiente
                if (ancho <= (min1 + min2 + splitterWidth))
                    return;

                // Calcular 60% para el panel izquierdo
                int distanciaDeseada = (int)(ancho * 0.60);

                // Límites válidos
                int minValido = min1;
                int maxValido = ancho - min2 - splitterWidth;

                // Ajustar dentro de los límites
                int distanciaFinal = Math.Max(minValido, Math.Min(distanciaDeseada, maxValido));

                // Solo aplicar si está dentro del rango permitido
                if (distanciaFinal >= minValido && distanciaFinal <= maxValido)
                {
                    split.SplitterDistance = distanciaFinal;
                }
            }
            catch (InvalidOperationException)
            {
                // Ignorar errores de SplitterDistance
            }
            catch (Exception)
            {
                // Ignorar otros errores de ajuste
            }
        }

        // ===============================
        //   LÓGICA DE NEGOCIO
        // ===============================
        private void CargarNotas()
        {
            try
            {
                DataTable notas = notaNegocio.ObtenerNotasPorSecretaria(idSecretaria);
                dgvNotas.DataSource = notas;

                // Ocultar columnas de ID
                if (dgvNotas.Columns.Contains("id_nota"))
                    dgvNotas.Columns["id_nota"].Visible = false;
                if (dgvNotas.Columns.Contains("id_secretaria"))
                    dgvNotas.Columns["id_secretaria"].Visible = false;
                if (dgvNotas.Columns.Contains("id"))
                    dgvNotas.Columns["id"].Visible = false;

                // Ajustar nombres de columnas
                if (dgvNotas.Columns.Contains("titulo"))
                    dgvNotas.Columns["titulo"].HeaderText = "Título";
                if (dgvNotas.Columns.Contains("cuerpo"))
                    dgvNotas.Columns["cuerpo"].HeaderText = "Contenido";
                if (dgvNotas.Columns.Contains("fecha_creacion"))
                {
                    dgvNotas.Columns["fecha_creacion"].HeaderText = "Fecha";
                    dgvNotas.Columns["fecha_creacion"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las notas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string termino = txtBuscar.Text.Trim();
                if (string.IsNullOrEmpty(termino))
                {
                    CargarNotas();
                }
                else
                {
                    dgvNotas.DataSource = notaNegocio.BuscarNotas(idSecretaria, termino);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la búsqueda: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            notaSeleccionadaId = null;
            txtTitulo.Clear();
            txtContenido.Clear();
            txtTitulo.Focus();
        }

        private void dgvNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var fila = dgvNotas.Rows[e.RowIndex];

                // Intentar obtener el ID de la nota
                notaSeleccionadaId = null;
                if (dgvNotas.Columns.Contains("id_nota"))
                {
                    var val = fila.Cells["id_nota"].Value;
                    notaSeleccionadaId = val != null && val != DBNull.Value ? Convert.ToInt32(val) : null;
                }
                else if (dgvNotas.Columns.Contains("id"))
                {
                    var val = fila.Cells["id"].Value;
                    notaSeleccionadaId = val != null && val != DBNull.Value ? Convert.ToInt32(val) : null;
                }

                // Obtener el título
                txtTitulo.Text = "";
                if (dgvNotas.Columns.Contains("titulo"))
                {
                    var val = fila.Cells["titulo"].Value;
                    txtTitulo.Text = val != null && val != DBNull.Value ? val.ToString() : "";
                }
                else if (dgvNotas.Columns.Contains("Título"))
                {
                    var val = fila.Cells["Título"].Value;
                    txtTitulo.Text = val != null && val != DBNull.Value ? val.ToString() : "";
                }

                // Obtener el contenido
                txtContenido.Text = "";
                if (dgvNotas.Columns.Contains("cuerpo"))
                {
                    var val = fila.Cells["cuerpo"].Value;
                    txtContenido.Text = val != null && val != DBNull.Value ? val.ToString() : "";
                }
                else if (dgvNotas.Columns.Contains("contenido"))
                {
                    var val = fila.Cells["contenido"].Value;
                    txtContenido.Text = val != null && val != DBNull.Value ? val.ToString() : "";
                }
                else if (dgvNotas.Columns.Contains("Contenido"))
                {
                    var val = fila.Cells["Contenido"].Value;
                    txtContenido.Text = val != null && val != DBNull.Value ? val.ToString() : "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la nota: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Debe ingresar un título.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }

            try
            {
                if (notaSeleccionadaId == null)
                {
                    notaNegocio.InsertarNota(idSecretaria, txtTitulo.Text.Trim(), txtContenido.Text.Trim());
                    MessageBox.Show("Nota creada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    notaNegocio.ActualizarNota((int)notaSeleccionadaId, txtTitulo.Text.Trim(), txtContenido.Text.Trim());
                    MessageBox.Show("Nota actualizada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarNotas();
                btnNuevo_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (notaSeleccionadaId == null)
            {
                MessageBox.Show("Seleccione una nota para eliminar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar esta nota?\n\nEsta acción no se puede deshacer.",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    notaNegocio.EliminarNota((int)notaSeleccionadaId);
                    MessageBox.Show("Nota eliminada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarNotas();
                    btnNuevo_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
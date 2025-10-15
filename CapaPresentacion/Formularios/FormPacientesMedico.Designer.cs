using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormPacientesMedico
    {
        private System.ComponentModel.IContainer components = null;

        private Panel header;
        private PictureBox picHeader;
        private Label lblHeader;
        private Label lblSubtitulo;

        private GroupBox grpFiltros;
        private TextBox txtBuscar;
        private ComboBox cboFiltro;
        private ComboBox cboEstado;
        private Button btnLimpiar;
        private Label lblTotal;

        private DataGridView dgvPacientes;

        private GroupBox grpDetalle;
        private Label lblNom;
        private Label lblDni;
        private Label lblEdadSexo;
        private Label lblOS;
        private Label lblInternacion;
        private Label lblUltEvo;
        private Label lblRiesgo;
        private Panel pnlEstado;
        private Panel pnlRiesgo;

        private FlowLayoutPanel pnlAcciones;
        private Button btnVerHC;
        private Button btnNuevaEvolucion;
        private Button btnIndicaciones;
        private Button btnSolicitarEstudios;
        private Button btnVerResultados;
        private Button btnInterconsulta;
        private Button btnImprimir;

        private Panel footer;
        private Button btnActualizar;
        private Button btnCerrar;

        private ComboBox cboDummy; // para evitar tab stop en último control

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ===== Ventana =====
            this.Text = "Pacientes - Médico";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Font = new Font("Segoe UI", 10F);
            this.BackColor = Color.WhiteSmoke;
            this.MinimumSize = new Size(1100, 680);
            this.Load += FormPacientesMedico_Load;

            // ===== Header =====
            header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 72,
                BackColor = ColorTranslator.FromHtml("#2F3C44")
            };
            picHeader = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.CenterImage,
                Image = SystemIcons.Information.ToBitmap(),
                Width = 56,
                Height = 56,
                Left = 16,
                Top = 8
            };
            lblHeader = new Label
            {
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold),
                Left = 88,
                Top = 10,
                Text = "Pacientes"
            };
            lblSubtitulo = new Label
            {
                AutoSize = true,
                ForeColor = Color.Gainsboro,
                Font = new Font("Segoe UI", 10F),
                Left = 92,
                Top = 46,
                Text = "Asignados a: —"
            };
            header.Controls.AddRange(new Control[] { picHeader, lblHeader, lblSubtitulo });
            this.Controls.Add(header);

            // ===== Filtros =====
            grpFiltros = new GroupBox
            {
                Text = "Búsqueda",
                Dock = DockStyle.Top,
                Height = 84,
                Padding = new Padding(12, 10, 12, 10)
            };

            txtBuscar = new TextBox { PlaceholderText = "Buscar…", Width = 260, Left = 12, Top = 32 };
            cboFiltro = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Left = 284, Top = 31, Width = 140 };
            cboFiltro.Items.AddRange(new object[] { "Nombre", "DNI", "Historia" });

            cboEstado = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Left = 438, Top = 31, Width = 150 };
            cboEstado.Items.AddRange(new object[] { "Todos", "Internados", "Ambulatorios" });

            btnLimpiar = new Button { Text = "Limpiar", Left = 598, Top = 30, Width = 96 };
            btnLimpiar.Click += btnLimpiar_Click;

            lblTotal = new Label { AutoSize = true, Left = 712, Top = 35, Text = "Total: 0" };

            grpFiltros.Controls.AddRange(new Control[] { txtBuscar, cboFiltro, cboEstado, btnLimpiar, lblTotal });
            this.Controls.Add(grpFiltros);

            // ===== Grilla =====
            dgvPacientes = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DNI",
                HeaderText = "DNI",
                FillWeight = 90
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                FillWeight = 160
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Edad",
                HeaderText = "Edad",
                FillWeight = 60
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Sexo",
                HeaderText = "Sexo",
                FillWeight = 60
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ObraSocial",
                HeaderText = "Obra Social",
                FillWeight = 100
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EstadoTxt",
                HeaderText = "Estado",
                FillWeight = 150
            });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Riesgo",
                HeaderText = "Riesgo",
                FillWeight = 80
            });
            this.Controls.Add(dgvPacientes);

            // ===== Panel detalle (derecha) =====
            grpDetalle = new GroupBox
            {
                Dock = DockStyle.Right,
                Width = 360,
                Text = "Detalle del paciente",
                Padding = new Padding(12)
            };
            // Etiquetas
            int y = 28;
            lblNom = NuevaEtiquetaValor("Nombre:", "—", 14, ref y);
            lblDni = NuevaEtiquetaValor("DNI:", "—", 0, ref y);
            lblEdadSexo = NuevaEtiquetaValor("Edad / Sexo:", "—", 0, ref y);
            lblOS = NuevaEtiquetaValor("Obra social:", "—", 0, ref y);
            lblInternacion = NuevaEtiquetaValor("Atención:", "—", 0, ref y);
            lblUltEvo = NuevaEtiquetaValor("Últ. evolución:", "—", 0, ref y);
            lblRiesgo = NuevaEtiquetaValor("Riesgo:", "—", 0, ref y);

            // Badges
            pnlEstado = new Panel { Left = 16, Top = y + 10, Width = 150, Height = 10, BackColor = SystemColors.ControlDark };
            pnlRiesgo = new Panel { Left = 180, Top = y + 10, Width = 150, Height = 10, BackColor = SystemColors.ControlDark };
            grpDetalle.Controls.Add(pnlEstado);
            grpDetalle.Controls.Add(pnlRiesgo);

            // Acciones
            pnlAcciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 190,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(8),
                WrapContents = true
            };
            btnVerHC = BotonAccion("Ver HC", btnVerHC_Click);
            btnNuevaEvolucion = BotonAccion("Nueva evolución", btnNuevaEvolucion_Click);
            btnIndicaciones = BotonAccion("Indicaciones", btnIndicaciones_Click);
            btnSolicitarEstudios = BotonAccion("Solicitar estudios", btnSolicitarEstudios_Click);
            btnVerResultados = BotonAccion("Ver resultados", btnVerResultados_Click);
            btnInterconsulta = BotonAccion("Interconsulta", btnInterconsulta_Click);
            btnImprimir = BotonAccion("Imprimir resumen", btnImprimir_Click);

            pnlAcciones.Controls.AddRange(new Control[]
            {
                btnVerHC, btnNuevaEvolucion, btnIndicaciones, btnSolicitarEstudios, btnVerResultados, btnInterconsulta, btnImprimir
            });

            grpDetalle.Controls.Add(pnlAcciones);
            this.Controls.Add(grpDetalle);

            // ===== Footer =====
            footer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 56,
                BackColor = Color.White
            };
            btnActualizar = new Button { Text = "Actualizar", Left = this.ClientSize.Width - 220, Top = 12, Width = 96, Anchor = AnchorStyles.Right | AnchorStyles.Top };
            btnActualizar.Click += btnActualizar_Click;
            btnCerrar = new Button { Text = "Cerrar", Left = this.ClientSize.Width - 112, Top = 12, Width = 96, Anchor = AnchorStyles.Right | AnchorStyles.Top };
            btnCerrar.Click += btnCerrar_Click;
            footer.Controls.AddRange(new Control[] { btnActualizar, btnCerrar });
            this.Controls.Add(footer);

            // Dummy para tab-stop
            cboDummy = new ComboBox { Visible = false };
            this.Controls.Add(cboDummy);
        }

        // Helpers UI
        private Label NuevaEtiquetaValor(string titulo, string valor, int extraTop, ref int y)
        {
            var lblT = new Label
            {
                Left = 16,
                Top = y,
                AutoSize = true,
                Text = titulo,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold)
            };
            var lblV = new Label
            {
                Left = 140,
                Top = y,
                AutoSize = true,
                Text = valor
            };
            grpDetalle.Controls.Add(lblT);
            grpDetalle.Controls.Add(lblV);
            y += 26 + extraTop;
            return lblV;
        }

        private Button BotonAccion(string texto, System.EventHandler onClick)
        {
            var b = new Button
            {
                Text = texto,
                Width = 156,
                Height = 38,
                Margin = new Padding(6),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            b.FlatAppearance.BorderColor = Color.LightGray;
            b.Click += onClick;
            return b;
        }
    }
}

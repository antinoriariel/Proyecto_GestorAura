using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormPacientesSecretaria
    {
        private IContainer components = null;

        // Header
        private Panel panelEncabezado;
        private PictureBox iconoEncabezado;
        private Label lblTitulo;

        // Ficha
        private GroupBox gbEdicion;
        private TableLayoutPanel tlpFicha;
        private Label lblDni, lblNombre, lblApellido, lblSexo, lblNacimiento, lblTelefono, lblEmail, lblGrupo, lblAlergias;
        private TextBox txtDni, txtNombre, txtApellido, txtTelefono, txtEmail;
        private ComboBox cboSexo, cboGrupo;
        private DateTimePicker dtpNacimiento;
        private RichTextBox txtAlergias;
        private CheckBox chkActivo;

        // Acciones
        private GroupBox gbAcciones;
        private FlowLayoutPanel flpAcciones;
        private Button btnNuevo, btnGuardar, btnActualizar, btnEliminar, btnLimpiar;

        // Buscar
        private GroupBox gbBusqueda;
        private TableLayoutPanel tlpBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar, btnQuitarFiltro;
        private CheckBox chkSoloActivos;

        // Grilla
        private DataGridView dgvPacientes;
        private ContextMenuStrip ctxGrid;
        private ToolStripMenuItem ctxVerFicha, ctxDarDeBaja, ctxReactivar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new Container();

            // ===== Form =====
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(1100, 750);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPacientesSecretaria";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Pacientes";
            Font = new Font("Segoe UI", 9F);

            // ===== Panel Encabezado =====
            panelEncabezado = new Panel
            {
                BackColor = Color.FromArgb(41, 57, 71),
                Dock = DockStyle.Top,
                Height = 60,
                Margin = new Padding(0, 0, 0, 16)
            };

            iconoEncabezado = new PictureBox
            {
                Image = Properties.Resources.hospitalBedIcon,
                Location = new Point(16, 14),
                Size = new Size(32, 32),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            lblTitulo = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(60, 16),
                Text = "Gestión de Pacientes"
            };

            panelEncabezado.Controls.Add(iconoEncabezado);
            panelEncabezado.Controls.Add(lblTitulo);

            // ===== Grupo Ficha =====
            gbEdicion = new GroupBox
            {
                Text = "Ficha del paciente",
                BackColor = Color.White,
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(14, 12, 14, 12),
                Margin = new Padding(0, 16, 0, 12),
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 57, 71)
            };

            // ** TLP de ficha **
            tlpFicha = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 6,
                RowCount = 4,
                Padding = new Padding(0),
            };
            // Columnas: Label | Control | Label | Control | Label | Control
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            gbEdicion.Controls.Add(tlpFicha);

            // Helpers
            Label L(string t) => new Label
            {
                Text = t,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Margin = new Padding(0, 6, 12, 8),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(60, 60, 60)
            };
            TextBox T() => new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 12, 12),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(250, 250, 250)
            };

            // ===== Fila 1: DNI | Fecha Nac | Email =====
            lblDni = L("DNI *");
            txtDni = T();
            lblNacimiento = L("Fecha nac. *");
            dtpNacimiento = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                MaxDate = DateTime.Today,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 12, 12),
                Font = new Font("Segoe UI", 9F)
            };
            lblEmail = L("Email");
            txtEmail = T();

            tlpFicha.Controls.Add(lblDni, 0, 0);
            tlpFicha.Controls.Add(txtDni, 1, 0);
            tlpFicha.Controls.Add(lblNacimiento, 2, 0);
            tlpFicha.Controls.Add(dtpNacimiento, 3, 0);
            tlpFicha.Controls.Add(lblEmail, 4, 0);
            tlpFicha.Controls.Add(txtEmail, 5, 0);

            // ===== Fila 2: Nombre | Sexo | Teléfono =====
            lblNombre = L("Nombre *");
            txtNombre = T();
            lblSexo = L("Sexo (H/M) *");
            cboSexo = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                IntegralHeight = false,
                Margin = new Padding(0, 0, 12, 12),
                Font = new Font("Segoe UI", 9F),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(250, 250, 250)
            };
            lblTelefono = L("Teléfono");
            txtTelefono = T();

            tlpFicha.Controls.Add(lblNombre, 0, 1);
            tlpFicha.Controls.Add(txtNombre, 1, 1);
            tlpFicha.Controls.Add(lblSexo, 2, 1);
            tlpFicha.Controls.Add(cboSexo, 3, 1);
            tlpFicha.Controls.Add(lblTelefono, 4, 1);
            tlpFicha.Controls.Add(txtTelefono, 5, 1);

            // ===== Fila 3: Apellido | Grupo sanguíneo | Alergias =====
            lblApellido = L("Apellido *");
            txtApellido = T();
            lblGrupo = L("Grupo sanguíneo");
            cboGrupo = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                IntegralHeight = false,
                Margin = new Padding(0, 0, 12, 12),
                Font = new Font("Segoe UI", 9F),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(250, 250, 250)
            };
            lblAlergias = L("Alergias");
            txtAlergias = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 12),
                Height = 60,
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(250, 250, 250)
            };

            tlpFicha.Controls.Add(lblApellido, 0, 2);
            tlpFicha.Controls.Add(txtApellido, 1, 2);
            tlpFicha.Controls.Add(lblGrupo, 2, 2);
            tlpFicha.Controls.Add(cboGrupo, 3, 2);
            tlpFicha.Controls.Add(lblAlergias, 4, 2);
            tlpFicha.Controls.Add(txtAlergias, 5, 2);

            // ===== Fila 4: Activo =====
            var flpActivo = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Margin = new Padding(0, 4, 0, 0),
                AutoSize = true
            };

            chkActivo = new CheckBox
            {
                Text = "Paciente activo",
                AutoSize = true,
                Checked = true,
                Margin = new Padding(0, 0, 0, 0),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(60, 60, 60)
            };

            flpActivo.Controls.Add(chkActivo);
            tlpFicha.Controls.Add(flpActivo, 0, 3);
            tlpFicha.SetColumnSpan(flpActivo, 6);

            // ===== Grupo Acciones =====
            gbAcciones = new GroupBox
            {
                Text = "Acciones",
                BackColor = Color.White,
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(14, 12, 14, 12),
                Margin = new Padding(0, 0, 0, 12),
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 57, 71)
            };

            flpAcciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true
            };
            gbAcciones.Controls.Add(flpAcciones);

            btnNuevo = Btn("Nuevo");
            btnGuardar = BtnPrimary("Guardar");
            btnActualizar = Btn("Actualizar");
            btnEliminar = BtnDanger("Dar de baja");
            btnLimpiar = Btn("Limpiar");

            flpAcciones.Controls.AddRange(new Control[]
            {
                btnNuevo, btnGuardar, btnActualizar, btnEliminar, btnLimpiar
            });

            // ===== Grupo Buscar =====
            gbBusqueda = new GroupBox
            {
                Text = "Buscar paciente",
                BackColor = Color.White,
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(14, 12, 14, 12),
                Margin = new Padding(0, 0, 0, 12),
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 57, 71)
            };

            tlpBuscar = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                ColumnCount = 5,
                RowCount = 1
            };
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            gbBusqueda.Controls.Add(tlpBuscar);

            txtBuscar = new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(250, 250, 250)
            };
            var spacer = new Panel { Dock = DockStyle.Fill, Width = 12 };
            btnBuscar = BtnPrimary("Buscar");
            btnQuitarFiltro = Btn("Quitar filtro");
            chkSoloActivos = new CheckBox
            {
                Text = "Solo activos",
                AutoSize = true,
                Checked = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(12, 0, 0, 0),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(60, 60, 60)
            };

            tlpBuscar.Controls.Add(txtBuscar, 0, 0);
            tlpBuscar.Controls.Add(spacer, 1, 0);
            tlpBuscar.Controls.Add(btnBuscar, 2, 0);
            tlpBuscar.Controls.Add(btnQuitarFiltro, 3, 0);
            tlpBuscar.Controls.Add(chkSoloActivos, 4, 0);

            // ===== Grilla =====
            dgvPacientes = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoGenerateColumns = false,
                BorderStyle = BorderStyle.None,
                BackgroundColor = Color.White,
                Margin = new Padding(0),
                Font = new Font("Segoe UI", 9F),
                GridColor = Color.FromArgb(230, 230, 230)
            };

            // Context menu
            ctxGrid = new ContextMenuStrip(components);
            ctxVerFicha = new ToolStripMenuItem("Ver/Editar ficha");
            ctxDarDeBaja = new ToolStripMenuItem("Dar de baja");
            ctxReactivar = new ToolStripMenuItem("Reactivar");
            ctxGrid.Items.AddRange(new ToolStripItem[] { ctxVerFicha, ctxDarDeBaja, ctxReactivar });
            dgvPacientes.ContextMenuStrip = ctxGrid;

            // ===== Ensamblado final =====
            Controls.Add(dgvPacientes);
            Controls.Add(gbBusqueda);
            Controls.Add(gbAcciones);
            Controls.Add(gbEdicion);
            Controls.Add(panelEncabezado);
        }
        #endregion

        // ===== Botones (estilo Apple) =====
        private static Button Btn(string texto)
        {
            var b = new Button
            {
                Text = texto,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(60, 60, 60),
                Margin = new Padding(0, 0, 8, 0),
                Height = 34,
                AutoSize = true,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9F),
                Padding = new Padding(16, 0, 16, 0)
            };
            b.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            return b;
        }

        private static Button BtnPrimary(string texto)
        {
            var b = new Button
            {
                Text = texto,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 122, 255),
                ForeColor = Color.White,
                Margin = new Padding(0, 0, 8, 0),
                Height = 34,
                AutoSize = true,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Padding = new Padding(16, 0, 16, 0)
            };
            b.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 255);
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 108, 230);
            return b;
        }

        private static Button BtnDanger(string texto)
        {
            var b = new Button
            {
                Text = texto,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(255, 59, 48),
                ForeColor = Color.White,
                Margin = new Padding(0, 0, 8, 0),
                Height = 34,
                AutoSize = true,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9F),
                Padding = new Padding(16, 0, 16, 0)
            };
            b.FlatAppearance.BorderColor = Color.FromArgb(255, 59, 48);
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 50, 40);
            return b;
        }
    }
}
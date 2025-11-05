using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormPacientesSecretaria
    {
        private IContainer components = null;

        // Root
        private TableLayoutPanel root;

        // Título
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
            Font = new Font("Segoe UI", 9F);
            Text = "Pacientes - Secretaría";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            MinimumSize = new Size(1100, 750);

            // ===== Root layout =====
            root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ColumnCount = 1,
                RowCount = 5,
                Padding = new Padding(12),
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // Título
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // Ficha
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // Acciones
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));          // Buscar
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));     // Grilla
            Controls.Add(root);

            // ===== Título =====
            lblTitulo = new Label
            {
                Text = "Gestión de Pacientes",
                Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(4, 0, 0, 10)
            };
            root.Controls.Add(lblTitulo, 0, 0);

            // ===== Grupo Ficha =====
            gbEdicion = new GroupBox
            {
                Text = "Ficha del paciente",
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(10),
                Margin = new Padding(0, 0, 0, 10)
            };
            root.Controls.Add(gbEdicion, 0, 1);

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
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            gbEdicion.Controls.Add(tlpFicha);

            // Helpers
            Label L(string t) => new Label
            {
                Text = t,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Margin = new Padding(0, 0, 8, 4)
            };
            TextBox T() => new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 8, 8)
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
                Margin = new Padding(0, 0, 8, 8)
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
                Margin = new Padding(0, 0, 8, 8)
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
                Margin = new Padding(0, 0, 8, 8)
            };
            lblAlergias = L("Alergias");
            txtAlergias = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 8),
                Height = 60
            };

            tlpFicha.Controls.Add(lblApellido, 0, 2);
            tlpFicha.Controls.Add(txtApellido, 1, 2);
            tlpFicha.Controls.Add(lblGrupo, 2, 2);
            tlpFicha.Controls.Add(cboGrupo, 3, 2);
            tlpFicha.Controls.Add(lblAlergias, 4, 2);
            tlpFicha.Controls.Add(txtAlergias, 5, 2);

            // ===== Fila 4: Activo (alineado a la derecha, sin placeholders) =====
            var flpActivo = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                Margin = new Padding(0, 0, 0, 0),
                AutoSize = true
            };

            chkActivo = new CheckBox
            {
                Text = "Activo (baja lógica)",
                AutoSize = true,
                Checked = true,
                Margin = new Padding(0, 2, 0, 0)
            };

            flpActivo.Controls.Add(chkActivo);
            tlpFicha.Controls.Add(flpActivo, 0, 3);
            tlpFicha.SetColumnSpan(flpActivo, 6);

            // ===== Grupo Acciones =====
            gbAcciones = new GroupBox
            {
                Text = "Acciones",
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(10),
                Margin = new Padding(0, 0, 0, 10)
            };
            root.Controls.Add(gbAcciones, 0, 2);

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
                Text = "Buscar",
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(10),
                Margin = new Padding(0, 0, 0, 10)
            };
            root.Controls.Add(gbBusqueda, 0, 3);

            tlpBuscar = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                ColumnCount = 5,
                RowCount = 1
            };
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));  // textbox
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16F));  // spacer
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));       // btn buscar
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));       // btn quitar
            tlpBuscar.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));       // chk activos
            gbBusqueda.Controls.Add(tlpBuscar);

            txtBuscar = new TextBox { Dock = DockStyle.Fill, Margin = new Padding(0) };
            var spacer = new Panel { Dock = DockStyle.Fill, Width = 16 };
            btnBuscar = BtnPrimary("Buscar");
            btnQuitarFiltro = Btn("Quitar filtro");
            chkSoloActivos = new CheckBox { Text = "Solo activos", AutoSize = true, Checked = true, Anchor = AnchorStyles.Left };

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
                Margin = new Padding(0)
            };
            root.Controls.Add(dgvPacientes, 0, 4);

            // Context menu
            ctxGrid = new ContextMenuStrip(components);
            ctxVerFicha = new ToolStripMenuItem("Ver/Editar ficha");
            ctxDarDeBaja = new ToolStripMenuItem("Dar de baja");
            ctxReactivar = new ToolStripMenuItem("Reactivar");
            ctxGrid.Items.AddRange(new ToolStripItem[] { ctxVerFicha, ctxDarDeBaja, ctxReactivar });
            dgvPacientes.ContextMenuStrip = ctxGrid;
        }
        #endregion

        // ===== Botones (estilo) =====
        private static Button Btn(string texto)
        {
            var b = new Button
            {
                Text = texto,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Black,
                Margin = new Padding(0, 0, 8, 0),
                Height = 30,
                AutoSize = true
            };
            b.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            return b;
        }
        private static Button BtnPrimary(string texto)
        {
            var b = Btn(texto);
            b.BackColor = ColorTranslator.FromHtml("#0088cc");
            b.ForeColor = Color.White;
            b.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#007ab3");
            return b;
        }
        private static Button BtnDanger(string texto)
        {
            var b = Btn(texto);
            b.BackColor = Color.FromArgb(203, 68, 53);
            b.ForeColor = Color.White;
            b.FlatAppearance.BorderColor = Color.FromArgb(180, 60, 47);
            return b;
        }
    }
}
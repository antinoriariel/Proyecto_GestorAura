using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormPacientesSecretaria
    {
        private IContainer components = null;

        // Título
        private Label lblTitulo;

        // Ficha
        private GroupBox gbEdicion;
        private Label lblDni, lblFecNac, lblEmail, lblNombre, lblSexo, lblDomicilio, lblApellido, lblTelefono, lblContacto, lblObra, lblAfiliado, lblNotas, lblLeyenda;
        private TextBox txtDni, txtEmail, txtNombre, txtDomicilio, txtApellido, txtTelefono, txtContactoEmergencia, txtNroAfiliado;
        private DateTimePicker dtpFechaNac;
        private ComboBox cboSexo, cboObraSocial;
        private RichTextBox txtNotas;
        private CheckBox chkActivo;

        // Acciones
        private GroupBox gbAcciones;
        private Button btnNuevo, btnGuardar, btnActualizar, btnEliminar, btnLimpiar, btnAdjuntar, btnExportar;
        private ToolTip toolTip1;

        // Buscar
        private GroupBox gbBusqueda;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnQuitarFiltro;
        private CheckBox chkSoloActivos;

        // Grilla
        private DataGridView dgvPacientes;
        private ContextMenuStrip ctxGrid;
        private ToolStripMenuItem ctxVerFicha, ctxDarDeBaja, ctxReactivar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
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
            MinimumSize = new Size(1200, 750);

            // ===== Título =====
            lblTitulo = new Label
            {
                Text = "Pacientes (Secretaría)",
                Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(16, 12)
            };
            Controls.Add(lblTitulo);

            // ===== Grupo FICHA =====
            gbEdicion = new GroupBox
            {
                Text = "Ficha del paciente",
                Location = new Point(12, 46),
                Size = new Size(1160, 340),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            Controls.Add(gbEdicion);

            // Columnas pensadas para que todo se vea cómodo
            int x1 = 16;    // Columna 1
            int x2 = 400;   // Columna 2
            int x3 = 760;   // Columna 3 (ancha)
            int w1 = 360;   // ancho col1
            int w2 = 220;   // ancho col2
            int w3 = gbEdicion.Width - x3 - 24; // dinámico
            int y = 28;     // fila
            int rowGap = 40;

            // Recalcular w3 cuando se redimensiona
            gbEdicion.Resize += (_, __) =>
            {
                int dyn = gbEdicion.Width - x3 - 24;
                if (txtEmail != null) txtEmail.Width = dyn;
                if (txtDomicilio != null) txtDomicilio.Width = dyn;
                if (txtContactoEmergencia != null) txtContactoEmergencia.Width = dyn;
                if (txtNotas != null) txtNotas.Width = dyn - 170;
            };

            // ===== Fila 1: DNI / Fecha Nac. / Email
            lblDni = new Label { Text = "DNI *", Location = new Point(x1, y) };
            txtDni = new TextBox { Location = new Point(x1, y + 18), Size = new Size(w1, 28) };
            gbEdicion.Controls.AddRange(new Control[] { lblDni, txtDni });

            lblFecNac = new Label { Text = "Fecha nac. *", Location = new Point(x2, y) };
            dtpFechaNac = new DateTimePicker { Format = DateTimePickerFormat.Short, MaxDate = DateTime.Today, Location = new Point(x2, y + 18), Size = new Size(w2, 28) };
            gbEdicion.Controls.AddRange(new Control[] { lblFecNac, dtpFechaNac });

            lblEmail = new Label { Text = "Email", Location = new Point(x3, y) };
            txtEmail = new TextBox { Location = new Point(x3, y + 18), Size = new Size(w3, 28), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            gbEdicion.Controls.AddRange(new Control[] { lblEmail, txtEmail });

            // ===== Fila 2: Nombre / Sexo / Domicilio
            y += rowGap;
            lblNombre = new Label { Text = "Nombre *", Location = new Point(x1, y) };
            txtNombre = new TextBox { Location = new Point(x1, y + 18), Size = new Size(w1, 28) };
            gbEdicion.Controls.AddRange(new Control[] { lblNombre, txtNombre });

            lblSexo = new Label { Text = "Sexo *", Location = new Point(x2, y) };
            cboSexo = new ComboBox { Location = new Point(x2, y + 18), Size = new Size(w2, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            gbEdicion.Controls.AddRange(new Control[] { lblSexo, cboSexo });

            lblDomicilio = new Label { Text = "Domicilio", Location = new Point(x3, y) };
            txtDomicilio = new TextBox { Location = new Point(x3, y + 18), Size = new Size(w3, 28), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            gbEdicion.Controls.AddRange(new Control[] { lblDomicilio, txtDomicilio });

            // ===== Fila 3: Apellido / Teléfono / Contacto emergencia
            y += rowGap;
            lblApellido = new Label { Text = "Apellido *", Location = new Point(x1, y) };
            txtApellido = new TextBox { Location = new Point(x1, y + 18), Size = new Size(w1, 28) };
            gbEdicion.Controls.AddRange(new Control[] { lblApellido, txtApellido });

            lblTelefono = new Label { Text = "Teléfono", Location = new Point(x2, y) };
            txtTelefono = new TextBox { Location = new Point(x2, y + 18), Size = new Size(w2, 28) };
            gbEdicion.Controls.AddRange(new Control[] { lblTelefono, txtTelefono });

            lblContacto = new Label { Text = "Contacto de emergencia", Location = new Point(x3, y) };
            txtContactoEmergencia = new TextBox { Location = new Point(x3, y + 18), Size = new Size(w3, 28), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            gbEdicion.Controls.AddRange(new Control[] { lblContacto, txtContactoEmergencia });

            // ===== Fila 4: Obra social / N° Afiliado / Notas + Activo
            y += rowGap;
            lblObra = new Label { Text = "Obra social", Location = new Point(x1, y) };
            cboObraSocial = new ComboBox { Location = new Point(x1, y + 18), Size = new Size(w1, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            gbEdicion.Controls.AddRange(new Control[] { lblObra, cboObraSocial });

            lblAfiliado = new Label { Text = "N° Afiliado", Location = new Point(x2, y) };
            txtNroAfiliado = new TextBox { Location = new Point(x2, y + 18), Size = new Size(w2, 28) };
            gbEdicion.Controls.AddRange(new Control[] { lblAfiliado, txtNroAfiliado });

            lblNotas = new Label { Text = "Notas", Location = new Point(x3, y) };
            txtNotas = new RichTextBox { Location = new Point(x3, y + 18), Size = new Size(w3 - 170, 76), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right, BorderStyle = BorderStyle.FixedSingle };
            gbEdicion.Controls.AddRange(new Control[] { lblNotas, txtNotas });

            chkActivo = new CheckBox { Text = "Activo (baja lógica)", Location = new Point(x3 + w3 - 150, y + 30), AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right, Checked = true };
            gbEdicion.Controls.Add(chkActivo);

            // Leyenda de obligatorios
            lblLeyenda = new Label
            {
                Text = "Campos marcados con * son obligatorios",
                ForeColor = Color.DimGray,
                AutoSize = true,
                Location = new Point(16, gbEdicion.Height - 22),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            gbEdicion.Controls.Add(lblLeyenda);

            // ===== Grupo ACCIONES (botones grandes) =====
            gbAcciones = new GroupBox
            {
                Text = "Acciones",
                Location = new Point(12, 392),
                Size = new Size(1160, 72),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            Controls.Add(gbAcciones);

            btnNuevo = MakeButton("Nuevo");
            btnGuardar = MakePrimaryButton("Guardar");
            btnActualizar = MakeButton("Actualizar");
            btnEliminar = MakeDangerButton("Dar de baja");
            btnLimpiar = MakeButton("Limpiar");
            btnAdjuntar = MakeButton("Adjuntar doc.");
            btnExportar = MakeButton("Exportar Excel");

            // Distribución en línea con margen
            int bx = 16, by = 28, bw = 120, bh = 32, sep = 10;
            Place(btnNuevo, bx, by, bw, bh);
            Place(btnGuardar, bx += bw + sep, by, bw, bh);
            Place(btnActualizar, bx += bw + sep, by, bw, bh);
            Place(btnEliminar, bx += bw + sep, by, bw, bh);
            Place(btnLimpiar, bx += bw + sep, by, 100, bh);
            Place(btnAdjuntar, bx += 100 + sep, by, 120, bh);
            Place(btnExportar, bx += 120 + sep, by, 120, bh);

            gbAcciones.Controls.AddRange(new Control[] { btnNuevo, btnGuardar, btnActualizar, btnEliminar, btnLimpiar, btnAdjuntar, btnExportar });

            toolTip1 = new ToolTip(components);
            toolTip1.SetToolTip(btnNuevo, "Limpiar la ficha para cargar un paciente nuevo");
            toolTip1.SetToolTip(btnGuardar, "Registrar un nuevo paciente");
            toolTip1.SetToolTip(btnActualizar, "Guardar cambios del paciente seleccionado");
            toolTip1.SetToolTip(btnEliminar, "Dar de baja lógica al paciente");
            toolTip1.SetToolTip(btnLimpiar, "Borrar los campos del formulario");
            toolTip1.SetToolTip(btnAdjuntar, "Adjuntar documentación del paciente");
            toolTip1.SetToolTip(btnExportar, "Exportar listado a Excel");

            // ===== Grupo BUSCAR =====
            gbBusqueda = new GroupBox
            {
                Text = "Buscar",
                Location = new Point(12, 472),
                Size = new Size(1160, 64),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            Controls.Add(gbBusqueda);

            lblBuscar = new Label { Text = "Buscar", Location = new Point(16, 28) };
            txtBuscar = new TextBox { Location = new Point(70, 24), Size = new Size(780, 26), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            btnBuscar = MakePrimaryButton("Buscar");
            btnBuscar.Location = new Point(860, 23);
            btnBuscar.Size = new Size(90, 28);
            btnQuitarFiltro = MakeButton("Quitar filtro");
            btnQuitarFiltro.Location = new Point(956, 23);
            btnQuitarFiltro.Size = new Size(100, 28);
            chkSoloActivos = new CheckBox { Text = "Solo activos", Location = new Point(1066, 27), AutoSize = true, Checked = true, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            gbBusqueda.Controls.AddRange(new Control[] { lblBuscar, txtBuscar, btnBuscar, btnQuitarFiltro, chkSoloActivos });

            // ===== Grilla =====
            dgvPacientes = new DataGridView
            {
                Location = new Point(12, 544),
                Size = new Size(1160, 165),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToResizeRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoGenerateColumns = false,
                BorderStyle = BorderStyle.None,
                BackgroundColor = Color.White
            };
            Controls.Add(dgvPacientes);

            // Menú contextual
            ctxGrid = new ContextMenuStrip(components);
            ctxVerFicha = new ToolStripMenuItem("Ver/Editar ficha");
            ctxDarDeBaja = new ToolStripMenuItem("Dar de baja");
            ctxReactivar = new ToolStripMenuItem("Reactivar");
            ctxGrid.Items.AddRange(new ToolStripItem[] { ctxVerFicha, ctxDarDeBaja, ctxReactivar });
            dgvPacientes.ContextMenuStrip = ctxGrid;
        }
        #endregion

        // ===== Helpers de estilo y colocación =====
        private static Button MakeButton(string text) =>
            new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.Black
            };

        private static Button MakePrimaryButton(string text)
        {
            var b = MakeButton(text);
            b.BackColor = Color.FromArgb(0, 136, 122);
            b.ForeColor = Color.White;
            b.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 108);
            return b;
        }

        private static Button MakeDangerButton(string text)
        {
            var b = MakeButton(text);
            b.BackColor = Color.FromArgb(203, 68, 53);
            b.ForeColor = Color.White;
            b.FlatAppearance.BorderColor = Color.FromArgb(180, 60, 47);
            return b;
        }

        private static void Place(Control c, int x, int y, int w, int h)
        {
            c.Location = new Point(x, y);
            c.Size = new Size(w, h);
            c.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        }
    }
}
    
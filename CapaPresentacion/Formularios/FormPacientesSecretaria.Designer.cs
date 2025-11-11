namespace CapaPresentacion.Formularios
{
    partial class FormPacientesSecretaria
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.PictureBox iconoEncabezado;
        private System.Windows.Forms.Label lblTitulo;

        // Edición (datos + acciones + búsqueda unificada debajo de acciones)
        private System.Windows.Forms.GroupBox gbEdicion;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.Label lblDni, lblNombre, lblApellido, lblNacimiento, lblEmail, lblTelefono, lblSexo, lblGrupo, lblAlergias, lblAcciones;
        private System.Windows.Forms.TextBox txtDni, txtNombre, txtApellido, txtEmail, txtTelefono;
        private System.Windows.Forms.DateTimePicker dtpNacimiento;
        private System.Windows.Forms.ComboBox cboSexo, cboGrupo;
        private System.Windows.Forms.RichTextBox txtAlergias;
        private System.Windows.Forms.CheckBox chkActivo;

        // Acciones centradas
        private System.Windows.Forms.TableLayoutPanel tlpAcciones;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnNuevo, btnGuardar, btnActualizar, btnEliminar, btnLimpiar;

        // Barra de búsqueda (fija debajo de Acciones)
        private System.Windows.Forms.Panel panelBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar, btnQuitarFiltro;
        private System.Windows.Forms.CheckBox chkSoloActivos;

        // Espaciador inferior
        private System.Windows.Forms.Panel pnlSpacer;

        // Grilla y menú contextual
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxVerFicha, ctxDarDeBaja, ctxReactivar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Header
            this.panelEncabezado = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 50, BackColor = System.Drawing.Color.FromArgb(20, 80, 120) };
            this.iconoEncabezado = new System.Windows.Forms.PictureBox { Size = new System.Drawing.Size(28, 28), Location = new System.Drawing.Point(12, 11), SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom };
            this.lblTitulo = new System.Windows.Forms.Label
            {
                Text = "Gestión de Pacientes",
                ForeColor = System.Drawing.Color.White,
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(50, 13)
            };
            this.panelEncabezado.Controls.Add(this.iconoEncabezado);
            this.panelEncabezado.Controls.Add(this.lblTitulo);

            // ===== FICHA =====
            this.gbEdicion = new System.Windows.Forms.GroupBox
            {
                Text = "Ficha del paciente",
                Dock = System.Windows.Forms.DockStyle.Top,
                Height = 510, // más alto: acciones + búsqueda + respiro
                Padding = new System.Windows.Forms.Padding(10)
            };

            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 14,
                AutoSize = true
            };
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.lblDni = new System.Windows.Forms.Label { Text = "DNI *", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };
            this.txtDni = new System.Windows.Forms.TextBox { Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right, MaxLength = 8 };

            this.lblNombre = new System.Windows.Forms.Label { Text = "Nombre *", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };
            this.txtNombre = new System.Windows.Forms.TextBox { Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right };

            this.lblApellido = new System.Windows.Forms.Label { Text = "Apellido *", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };
            this.txtApellido = new System.Windows.Forms.TextBox { Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right };

            this.lblNacimiento = new System.Windows.Forms.Label { Text = "Fecha de nacimiento *", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };
            this.dtpNacimiento = new System.Windows.Forms.DateTimePicker { Format = System.Windows.Forms.DateTimePickerFormat.Short, Anchor = System.Windows.Forms.AnchorStyles.Left };

            this.lblEmail = new System.Windows.Forms.Label { Text = "Email", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };
            this.txtEmail = new System.Windows.Forms.TextBox { Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right };

            this.lblTelefono = new System.Windows.Forms.Label { Text = "Teléfono", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };
            this.txtTelefono = new System.Windows.Forms.TextBox { Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right };

            this.lblSexo = new System.Windows.Forms.Label { Text = "Sexo (H/M) *", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };
            this.cboSexo = new System.Windows.Forms.ComboBox { DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Anchor = System.Windows.Forms.AnchorStyles.Left };

            this.lblGrupo = new System.Windows.Forms.Label { Text = "Grupo sanguíneo", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };
            this.cboGrupo = new System.Windows.Forms.ComboBox { DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Anchor = System.Windows.Forms.AnchorStyles.Left };

            this.lblAlergias = new System.Windows.Forms.Label { Text = "Alergias", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };
            this.txtAlergias = new System.Windows.Forms.RichTextBox { Height = 60, Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right };

            this.chkActivo = new System.Windows.Forms.CheckBox { Text = "Paciente", Checked = true, Anchor = System.Windows.Forms.AnchorStyles.Left };

            // ---- Acciones centradas ----
            this.lblAcciones = new System.Windows.Forms.Label { Text = "Acciones", Anchor = System.Windows.Forms.AnchorStyles.Left, AutoSize = true };

            this.tlpAcciones = new System.Windows.Forms.TableLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Margin = new System.Windows.Forms.Padding(0)
            };
            this.tlpAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel
            {
                FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                Anchor = System.Windows.Forms.AnchorStyles.None,
                Margin = new System.Windows.Forms.Padding(0)
            };

            this.btnNuevo = new System.Windows.Forms.Button { Text = "Nuevo", Width = 90 };
            this.btnGuardar = new System.Windows.Forms.Button { Text = "Guardar", Width = 90, BackColor = System.Drawing.Color.FromArgb(0, 136, 204), ForeColor = System.Drawing.Color.White, FlatStyle = System.Windows.Forms.FlatStyle.Flat };
            this.btnActualizar = new System.Windows.Forms.Button { Text = "Actualizar", Width = 90 };
            this.btnEliminar = new System.Windows.Forms.Button { Text = "Dar de baja", Width = 90, BackColor = System.Drawing.Color.FromArgb(220, 53, 69), ForeColor = System.Drawing.Color.White, FlatStyle = System.Windows.Forms.FlatStyle.Flat };
            this.btnLimpiar = new System.Windows.Forms.Button { Text = "Limpiar", Width = 90 };
            this.flpAcciones.Controls.AddRange(new System.Windows.Forms.Control[] { this.btnNuevo, this.btnGuardar, this.btnActualizar, this.btnEliminar, this.btnLimpiar });

            this.tlpAcciones.Controls.Add(this.flpAcciones, 1, 0);

            // ---- Barra de búsqueda fija (debajo de Acciones) ----
            this.panelBuscar = new System.Windows.Forms.Panel { Height = 40, Dock = System.Windows.Forms.DockStyle.Fill, Visible = true, Padding = new System.Windows.Forms.Padding(0) };
            this.txtBuscar = new System.Windows.Forms.TextBox { Width = 520 };
            this.btnBuscar = new System.Windows.Forms.Button { Text = "Buscar", Width = 80 };
            this.btnQuitarFiltro = new System.Windows.Forms.Button { Text = "Quitar filtro", Width = 100 };
            this.chkSoloActivos = new System.Windows.Forms.CheckBox { Text = "Solo activos", Checked = true, AutoSize = true, Margin = new System.Windows.Forms.Padding(12, 8, 0, 0) };

            var flBuscarInline = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight,
                WrapContents = false
            };
            flBuscarInline.Controls.AddRange(new System.Windows.Forms.Control[] { this.txtBuscar, this.btnBuscar, this.btnQuitarFiltro, this.chkSoloActivos });
            this.panelBuscar.Controls.Add(flBuscarInline);

            // Espaciador inferior para que no choque con la grilla
            this.pnlSpacer = new System.Windows.Forms.Panel { Height = 8, Dock = System.Windows.Forms.DockStyle.Fill };

            // ---- Filas del tlpDatos ----
            int r = 0;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F)); this.tlpDatos.Controls.Add(this.lblDni, 0, r); this.tlpDatos.Controls.Add(this.txtDni, 1, r); r++;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F)); this.tlpDatos.Controls.Add(this.lblNombre, 0, r); this.tlpDatos.Controls.Add(this.txtNombre, 1, r); r++;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F)); this.tlpDatos.Controls.Add(this.lblApellido, 0, r); this.tlpDatos.Controls.Add(this.txtApellido, 1, r); r++;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F)); this.tlpDatos.Controls.Add(this.lblNacimiento, 0, r); this.tlpDatos.Controls.Add(this.dtpNacimiento, 1, r); r++;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F)); this.tlpDatos.Controls.Add(this.lblEmail, 0, r); this.tlpDatos.Controls.Add(this.txtEmail, 1, r); r++;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F)); this.tlpDatos.Controls.Add(this.lblTelefono, 0, r); this.tlpDatos.Controls.Add(this.txtTelefono, 1, r); r++;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F)); this.tlpDatos.Controls.Add(this.lblSexo, 0, r); this.tlpDatos.Controls.Add(this.cboSexo, 1, r); r++;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F)); this.tlpDatos.Controls.Add(this.lblGrupo, 0, r); this.tlpDatos.Controls.Add(this.cboGrupo, 1, r); r++;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F)); this.tlpDatos.Controls.Add(this.lblAlergias, 0, r); this.tlpDatos.Controls.Add(this.txtAlergias, 1, r); r++;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F)); this.tlpDatos.Controls.Add(this.chkActivo, 1, r); r++;

            // Etiqueta Acciones
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpDatos.Controls.Add(this.lblAcciones, 0, r);
            this.tlpDatos.SetColumnSpan(this.lblAcciones, 2);
            r++;

            // Acciones centradas
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpDatos.Controls.Add(this.tlpAcciones, 0, r);
            this.tlpDatos.SetColumnSpan(this.tlpAcciones, 2);
            r++;

            // Barra de búsqueda fija (debajo de Acciones)
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpDatos.Controls.Add(this.panelBuscar, 0, r);
            this.tlpDatos.SetColumnSpan(this.panelBuscar, 2);
            r++;

            // Espaciador
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlpDatos.Controls.Add(this.pnlSpacer, 0, r);
            this.tlpDatos.SetColumnSpan(this.pnlSpacer, 2);
            r++;

            this.gbEdicion.Controls.Add(this.tlpDatos);

            // ===== GRILLA =====
            this.dgvPacientes = new System.Windows.Forms.DataGridView
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect,
                ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components)
            };

            this.ctxMenu = this.dgvPacientes.ContextMenuStrip;
            this.ctxVerFicha = new System.Windows.Forms.ToolStripMenuItem("Ver ficha");
            this.ctxDarDeBaja = new System.Windows.Forms.ToolStripMenuItem("Dar de baja");
            this.ctxReactivar = new System.Windows.Forms.ToolStripMenuItem("Reactivar");
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ctxVerFicha, this.ctxDarDeBaja, this.ctxReactivar });

            // Form
            this.Text = "Medic - Gestión hospitalaria";
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1220, 720);

            // Orden de apilado: header -> ficha (con acciones + búsqueda) -> grilla
            this.Controls.Add(this.dgvPacientes);
            this.Controls.Add(this.gbEdicion);
            this.Controls.Add(this.panelEncabezado);
        }
    }
}

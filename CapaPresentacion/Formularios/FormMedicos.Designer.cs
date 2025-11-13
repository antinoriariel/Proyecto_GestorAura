using System.ComponentModel;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormMedicos
    {
        private IContainer components = null;
        private Panel panelHeader;
        private Label lblTitulo;

        private FlowLayoutPanel panelBotones; // arriba del listado
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnInactivar;

        private GroupBox gbListado;
        private DataGridView dgvMedicos;

        private GroupBox gbFicha;
        private TableLayoutPanel tlpFicha;

        private Label lblUsername; private TextBox txtUsername;
        private Label lblEmail; private TextBox txtEmail;
        private Label lblTelefono; private TextBox txtTelefono;
        private Label lblNombre; private TextBox txtNombre;
        private Label lblApellido; private TextBox txtApellido;
        private Label lblDni; private TextBox txtDni;
        private Label lblNacimiento; private DateTimePicker dtpNacimiento;
        private Label lblEspecialidad; private TextBox txtEspecialidad;
        private Label lblMatProv; private TextBox txtMatProv;
        private Label lblMatNac; private TextBox txtMatNac;
        private CheckBox chkActivo;

        private FlowLayoutPanel panelFichaBotones;
        private Button btnNuevoFicha;
        private Button btnGuardarFicha;
        private Button btnCancelarFicha;

        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new Container();
            this.panelHeader = new Panel();
            this.lblTitulo = new Label();

            this.panelBotones = new FlowLayoutPanel();
            this.btnAgregar = new Button();
            this.btnModificar = new Button();
            this.btnEliminar = new Button();
            this.btnInactivar = new Button();

            this.gbListado = new GroupBox();
            this.dgvMedicos = new DataGridView();

            this.gbFicha = new GroupBox();
            this.tlpFicha = new TableLayoutPanel();

            this.lblUsername = new Label(); this.txtUsername = new TextBox();
            this.lblEmail = new Label(); this.txtEmail = new TextBox();
            this.lblTelefono = new Label(); this.txtTelefono = new TextBox();
            this.lblNombre = new Label(); this.txtNombre = new TextBox();
            this.lblApellido = new Label(); this.txtApellido = new TextBox();
            this.lblDni = new Label(); this.txtDni = new TextBox();
            this.lblNacimiento = new Label(); this.dtpNacimiento = new DateTimePicker();
            this.lblEspecialidad = new Label(); this.txtEspecialidad = new TextBox();
            this.lblMatProv = new Label(); this.txtMatProv = new TextBox();
            this.lblMatNac = new Label(); this.txtMatNac = new TextBox();
            this.chkActivo = new CheckBox();

            this.panelFichaBotones = new FlowLayoutPanel();
            this.btnNuevoFicha = new Button();
            this.btnGuardarFicha = new Button();
            this.btnCancelarFicha = new Button();

            this.statusStrip = new StatusStrip();
            this.lblTotal = new ToolStripStatusLabel();

            // Form
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Text = "Gestión de Médicos";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 720);
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.gbFicha);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip);

            // Header
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 55;
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(33, 42, 62);
            this.panelHeader.Padding = new Padding(16, 10, 16, 10);
            this.panelHeader.Controls.Add(this.lblTitulo);

            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Text = "Gestión de Médicos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // Botones (arriba del listado)
            this.panelBotones.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.panelBotones.FlowDirection = FlowDirection.LeftToRight;
            this.panelBotones.Location = new System.Drawing.Point(16, 60);
            this.panelBotones.Size = new System.Drawing.Size(640, 44);
            this.panelBotones.WrapContents = false;
            this.panelBotones.Controls.Add(this.btnAgregar);
            this.panelBotones.Controls.Add(this.btnModificar);
            this.panelBotones.Controls.Add(this.btnEliminar);
            this.panelBotones.Controls.Add(this.btnInactivar);

            this.btnAgregar.Text = "➕ Nuevo";
            this.btnAgregar.Width = 120; this.btnAgregar.Height = 36;
            this.btnModificar.Text = "✏️ Editar";
            this.btnModificar.Width = 120; this.btnModificar.Height = 36;
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.Width = 120; this.btnEliminar.Height = 36;
            this.btnInactivar.Text = "🚫 Inactivar";
            this.btnInactivar.Width = 120; this.btnInactivar.Height = 36;

            // Listado
            this.gbListado.Text = "Listado de médicos";
            this.gbListado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.gbListado.Location = new System.Drawing.Point(16, 110);
            this.gbListado.Size = new System.Drawing.Size(1068, 330);
            this.gbListado.Padding = new Padding(10);
            this.gbListado.Controls.Add(this.dgvMedicos);

            this.dgvMedicos.Dock = DockStyle.Fill;
            this.dgvMedicos.AllowUserToAddRows = false;
            this.dgvMedicos.AllowUserToDeleteRows = false;
            this.dgvMedicos.AllowUserToOrderColumns = true;
            this.dgvMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicos.BorderStyle = BorderStyle.None;
            this.dgvMedicos.MultiSelect = false;
            this.dgvMedicos.ReadOnly = true;
            this.dgvMedicos.RowHeadersVisible = false;
            this.dgvMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvMedicos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Ficha
            this.gbFicha.Text = "Ficha del médico";
            this.gbFicha.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.gbFicha.Location = new System.Drawing.Point(16, 448);
            this.gbFicha.Size = new System.Drawing.Size(1068, 230);
            this.gbFicha.Padding = new Padding(10);
            this.gbFicha.Controls.Add(this.tlpFicha);
            this.gbFicha.Controls.Add(this.panelFichaBotones);

            // TableLayout (3 filas x 6 columnas)
            this.tlpFicha.Dock = DockStyle.Top;
            this.tlpFicha.ColumnCount = 6;
            this.tlpFicha.RowCount = 3;
            this.tlpFicha.AutoSize = true;
            this.tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14f));
            this.tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19f));
            this.tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14f));
            this.tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19f));
            this.tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14f));
            this.tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));

            // Fila 1
            this.lblUsername.Text = "Usuario"; this.lblUsername.AutoSize = true;
            this.tlpFicha.Controls.Add(this.lblUsername, 0, 0);
            this.tlpFicha.Controls.Add(this.txtUsername, 1, 0);

            this.lblEmail.Text = "Email"; this.lblEmail.AutoSize = true;
            this.tlpFicha.Controls.Add(this.lblEmail, 2, 0);
            this.tlpFicha.Controls.Add(this.txtEmail, 3, 0);

            this.lblTelefono.Text = "Teléfono"; this.lblTelefono.AutoSize = true;
            this.tlpFicha.Controls.Add(this.lblTelefono, 4, 0);
            this.tlpFicha.Controls.Add(this.txtTelefono, 5, 0);

            // Fila 2
            this.lblNombre.Text = "Nombre"; this.lblNombre.AutoSize = true;
            this.tlpFicha.Controls.Add(this.lblNombre, 0, 1);
            this.tlpFicha.Controls.Add(this.txtNombre, 1, 1);

            this.lblApellido.Text = "Apellido"; this.lblApellido.AutoSize = true;
            this.tlpFicha.Controls.Add(this.lblApellido, 2, 1);
            this.tlpFicha.Controls.Add(this.txtApellido, 3, 1);

            this.lblDni.Text = "DNI"; this.lblDni.AutoSize = true;
            this.tlpFicha.Controls.Add(this.lblDni, 4, 1);
            this.tlpFicha.Controls.Add(this.txtDni, 5, 1);

            // Fila 3
            this.lblNacimiento.Text = "F. Nacimiento"; this.lblNacimiento.AutoSize = true;
            this.tlpFicha.Controls.Add(this.lblNacimiento, 0, 2);
            this.dtpNacimiento.Format = DateTimePickerFormat.Short;
            this.tlpFicha.Controls.Add(this.dtpNacimiento, 1, 2);

            this.lblEspecialidad.Text = "Especialidad"; this.lblEspecialidad.AutoSize = true;
            this.tlpFicha.Controls.Add(this.lblEspecialidad, 2, 2);
            this.tlpFicha.Controls.Add(this.txtEspecialidad, 3, 2);

            this.lblMatProv.Text = "Matrícula Prov."; this.lblMatProv.AutoSize = true;
            this.tlpFicha.Controls.Add(this.lblMatProv, 4, 2);
            this.tlpFicha.Controls.Add(this.txtMatProv, 5, 2);

            // Fila 4 (debajo del layout)
            this.lblMatNac.Text = "Matrícula Nac."; this.lblMatNac.AutoSize = true;
            this.lblMatNac.Location = new System.Drawing.Point(20, 150);
            this.txtMatNac.Location = new System.Drawing.Point(120, 146);
            this.txtMatNac.Width = 200;
            this.chkActivo.Text = "Activo"; this.chkActivo.Checked = true;
            this.chkActivo.Location = new System.Drawing.Point(350, 148);

            this.gbFicha.Controls.Add(this.lblMatNac);
            this.gbFicha.Controls.Add(this.txtMatNac);
            this.gbFicha.Controls.Add(this.chkActivo);

            // Estirar inputs
            foreach (Control c in new Control[] { txtUsername, txtEmail, txtTelefono, txtNombre, txtApellido, txtDni, txtEspecialidad, txtMatProv })
                if (c is TextBox t) t.Dock = DockStyle.Fill;

            // Botones de ficha
            this.panelFichaBotones.Dock = DockStyle.Bottom;
            this.panelFichaBotones.Height = 48;
            this.panelFichaBotones.FlowDirection = FlowDirection.RightToLeft;
            this.panelFichaBotones.Controls.Add(this.btnCancelarFicha);
            this.panelFichaBotones.Controls.Add(this.btnGuardarFicha);
            this.panelFichaBotones.Controls.Add(this.btnNuevoFicha);

            this.btnNuevoFicha.Text = "➕ Nuevo"; this.btnNuevoFicha.Width = 120; this.btnNuevoFicha.Height = 36;
            this.btnGuardarFicha.Text = "💾 Guardar"; this.btnGuardarFicha.Width = 120; this.btnGuardarFicha.Height = 36;
            this.btnCancelarFicha.Text = "✖ Cancelar"; this.btnCancelarFicha.Width = 120; this.btnCancelarFicha.Height = 36;

            // Status
            this.statusStrip.Dock = DockStyle.Bottom;
            this.statusStrip.Items.Add(this.lblTotal);
            this.lblTotal.Text = "Total: 0";
        }
        #endregion
    }
}

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormMedicos
    {
        private IContainer components = null;

        private Panel panelHeader;
        private Label lblTitulo;

        private FlowLayoutPanel panelBotones;
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

        private Label lblPass; private TextBox txtPass;
        private Label lblPass2; private TextBox txtPass2;

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

            this.lblPass = new Label(); this.txtPass = new TextBox();
            this.lblPass2 = new Label(); this.txtPass2 = new TextBox();

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
            this.MinimumSize = new Size(1000, 720);
            this.ClientSize = new Size(1100, 750);
            this.Controls.Add(this.gbFicha);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip);

            // Header
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 55;
            this.panelHeader.BackColor = Color.FromArgb(33, 42, 62);
            this.panelHeader.Padding = new Padding(16, 10, 16, 10);
            this.panelHeader.Controls.Add(this.lblTitulo);

            this.lblTitulo.Dock = DockStyle.Fill;
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Font = new Font("Consolas", 18F, FontStyle.Bold);
            this.lblTitulo.Text = "Gestión de Médicos";
            this.lblTitulo.TextAlign = ContentAlignment.MiddleLeft;

            // Botones (arriba del listado)
            this.panelBotones.Location = new Point(16, 60);
            this.panelBotones.Size = new Size(700, 44);
            this.panelBotones.FlowDirection = FlowDirection.LeftToRight;
            this.panelBotones.WrapContents = false;

            ConfigurarBotonCabecera(this.btnAgregar, "➕ Nuevo");
            ConfigurarBotonCabecera(this.btnModificar, "✏ Editar");
            ConfigurarBotonCabecera(this.btnEliminar, "🗑 Eliminar");
            ConfigurarBotonCabecera(this.btnInactivar, "🚫 Inactivar");

            this.panelBotones.Controls.Add(this.btnAgregar);
            this.panelBotones.Controls.Add(this.btnModificar);
            this.panelBotones.Controls.Add(this.btnEliminar);
            this.panelBotones.Controls.Add(this.btnInactivar);

            // Listado
            this.gbListado.Text = "Listado de médicos";
            this.gbListado.Location = new Point(16, 110);
            this.gbListado.Size = new Size(1068, 330);
            this.gbListado.Padding = new Padding(10);
            this.gbListado.Controls.Add(this.dgvMedicos);

            this.dgvMedicos.Dock = DockStyle.Fill;
            this.dgvMedicos.AllowUserToAddRows = false;
            this.dgvMedicos.AllowUserToDeleteRows = false;
            this.dgvMedicos.AllowUserToOrderColumns = true;
            this.dgvMedicos.BackgroundColor = Color.White;
            this.dgvMedicos.BorderStyle = BorderStyle.None;
            this.dgvMedicos.MultiSelect = false;
            this.dgvMedicos.ReadOnly = true;
            this.dgvMedicos.RowHeadersVisible = false;
            this.dgvMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ficha
            this.gbFicha.Text = "Ficha del médico";
            this.gbFicha.Location = new Point(16, 448);
            this.gbFicha.Size = new Size(1068, 260);
            this.gbFicha.Padding = new Padding(10);
            this.gbFicha.Controls.Add(this.tlpFicha);
            this.gbFicha.Controls.Add(this.panelFichaBotones);

            // TableLayout
            this.tlpFicha.Dock = DockStyle.Top;
            this.tlpFicha.ColumnCount = 6;
            this.tlpFicha.RowCount = 5;
            this.tlpFicha.AutoSize = true;

            for (int i = 0; i < 6; i++)
                this.tlpFicha.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6F));

            // ---- Fila 0 ----
            lblUsername.Text = "Usuario:"; lblUsername.AutoSize = true;
            lblEmail.Text = "Email:"; lblEmail.AutoSize = true;
            lblTelefono.Text = "Teléfono:"; lblTelefono.AutoSize = true;

            this.tlpFicha.Controls.Add(lblUsername, 0, 0);
            this.tlpFicha.Controls.Add(txtUsername, 1, 0);
            this.tlpFicha.Controls.Add(lblEmail, 2, 0);
            this.tlpFicha.Controls.Add(txtEmail, 3, 0);
            this.tlpFicha.Controls.Add(lblTelefono, 4, 0);
            this.tlpFicha.Controls.Add(txtTelefono, 5, 0);

            // ---- Fila 1 ----
            lblNombre.Text = "Nombre:"; lblNombre.AutoSize = true;
            lblApellido.Text = "Apellido:"; lblApellido.AutoSize = true;
            lblDni.Text = "DNI:"; lblDni.AutoSize = true;

            this.tlpFicha.Controls.Add(lblNombre, 0, 1);
            this.tlpFicha.Controls.Add(txtNombre, 1, 1);
            this.tlpFicha.Controls.Add(lblApellido, 2, 1);
            this.tlpFicha.Controls.Add(txtApellido, 3, 1);
            this.tlpFicha.Controls.Add(lblDni, 4, 1);
            this.tlpFicha.Controls.Add(txtDni, 5, 1);

            // ---- Fila 2 ----
            lblNacimiento.Text = "F. Nac."; lblNacimiento.AutoSize = true;
            lblEspecialidad.Text = "Especialidad:"; lblEspecialidad.AutoSize = true;
            lblMatProv.Text = "Matrícula Prov."; lblMatProv.AutoSize = true;

            this.dtpNacimiento.Format = DateTimePickerFormat.Short;

            this.tlpFicha.Controls.Add(lblNacimiento, 0, 2);
            this.tlpFicha.Controls.Add(dtpNacimiento, 1, 2);
            this.tlpFicha.Controls.Add(lblEspecialidad, 2, 2);
            this.tlpFicha.Controls.Add(txtEspecialidad, 3, 2);
            this.tlpFicha.Controls.Add(lblMatProv, 4, 2);
            this.tlpFicha.Controls.Add(txtMatProv, 5, 2);

            // ---- Fila 3 ----
            lblMatNac.Text = "Matrícula Nac."; lblMatNac.AutoSize = true;
            chkActivo.Text = "Activo"; chkActivo.AutoSize = true;

            this.tlpFicha.Controls.Add(lblMatNac, 0, 3);
            this.tlpFicha.Controls.Add(txtMatNac, 1, 3);
            this.tlpFicha.Controls.Add(chkActivo, 2, 3);

            // ---- Fila 4 (Contraseñas) ----
            lblPass.Text = "Contraseña:"; lblPass.AutoSize = true;
            txtPass.PasswordChar = '●';

            lblPass2.Text = "Repetir:"; lblPass2.AutoSize = true;
            txtPass2.PasswordChar = '●';

            this.tlpFicha.Controls.Add(lblPass, 0, 4);
            this.tlpFicha.Controls.Add(txtPass, 1, 4);
            this.tlpFicha.Controls.Add(lblPass2, 2, 4);
            this.tlpFicha.Controls.Add(txtPass2, 3, 4);

            // Botones de ficha
            this.panelFichaBotones.Dock = DockStyle.Bottom;
            this.panelFichaBotones.Height = 48;
            this.panelFichaBotones.FlowDirection = FlowDirection.RightToLeft;

            ConfigurarBotonFicha(btnNuevoFicha, "➕ Nuevo");
            ConfigurarBotonFicha(btnGuardarFicha, "💾 Guardar");
            ConfigurarBotonFicha(btnCancelarFicha, "✖ Cancelar");

            this.panelFichaBotones.Controls.Add(btnCancelarFicha);
            this.panelFichaBotones.Controls.Add(btnGuardarFicha);
            this.panelFichaBotones.Controls.Add(btnNuevoFicha);

            // Estilo inputs (Dock Fill para que ocupen bien la celda)
            foreach (Control c in new Control[]
            {
                txtUsername, txtEmail, txtTelefono,
                txtNombre, txtApellido, txtDni,
                txtEspecialidad, txtMatProv, txtMatNac,
                txtPass, txtPass2
            })
            {
                if (c is TextBox t)
                {
                    t.Dock = DockStyle.Fill;
                }
            }

            // StatusStrip
            this.statusStrip.Dock = DockStyle.Bottom;
            this.statusStrip.Items.Add(this.lblTotal);
            this.lblTotal.Text = "Total: 0";
        }

        private void ConfigurarBotonCabecera(Button b, string texto)
        {
            b.Text = texto;
            b.Width = 140;
            b.Height = 36;
            b.Font = new Font("Consolas", 11F, FontStyle.Bold);
            b.Margin = new Padding(4, 4, 4, 4);
        }

        private void ConfigurarBotonFicha(Button b, string texto)
        {
            b.Text = texto;
            b.Width = 120;
            b.Height = 36;
            b.Font = new Font("Consolas", 11F, FontStyle.Bold);
            b.Margin = new Padding(4, 4, 4, 4);
        }

        #endregion
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormAgregarPaciente
    {
        private System.ComponentModel.IContainer components = null;

        private Panel header;
        private PictureBox picHeader;
        private Label lblHeader;

        private GroupBox grpDatos;
        private TableLayoutPanel grid;

        private Label lblNombre; private TextBox txtNombre;
        private Label lblApellido; private TextBox txtApellido;
        private Label lblDni; private TextBox txtDni;
        private Label lblSexo; private ComboBox cboSexo;
        private Label lblNacimiento; private DateTimePicker dtpNacimiento;
        private Label lblTelefono; private TextBox txtTelefono;
        private Label lblEmail; private TextBox txtEmail;
        private Label lblDireccion; private TextBox txtDireccion;
        private Label lblProvincia; private ComboBox cboProvincia;
        private Label lblLocalidad; private ComboBox cboLocalidad;
        private Label lblGrupo; private ComboBox cboGrupo;
        private Label lblAlergias; private TextBox txtAlergias;

        private Panel footer;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Form
            this.SuspendLayout();
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.BackColor = ColorTranslator.FromHtml("#D7DADB");
            this.ClientSize = new Size(980, 640);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Agregar paciente";

            // Header
            header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = ColorTranslator.FromHtml("#2D3E46")
            };
            picHeader = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(18, 15),
                SizeMode = PictureBoxSizeMode.Zoom,
                // Reemplazá por un recurso existente de tu proyecto
                // Image = Properties.Resources.user_add_40px
            };
            lblHeader = new Label
            {
                AutoSize = false,
                Text = "Alta de paciente",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(70, 18),
                Size = new Size(400, 35)
            };
            header.Controls.Add(picHeader);
            header.Controls.Add(lblHeader);
            this.Controls.Add(header);

            // GroupBox
            grpDatos = new GroupBox
            {
                Text = "Datos del paciente",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = ColorTranslator.FromHtml("#2D3E46"),
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Height = 470,
                Padding = new Padding(15)
            };

            // Grid
            grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 7,
                BackColor = Color.White
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            for (int i = 0; i < 7; i++)
                grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));

            // Controles
            lblNombre = Etiqueta("Nombre:");
            txtNombre = Caja();

            lblApellido = Etiqueta("Apellido:");
            txtApellido = Caja();

            lblDni = Etiqueta("DNI:");
            txtDni = Caja();
            txtDni.MaxLength = 9;

            lblSexo = Etiqueta("Sexo:");
            cboSexo = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            lblNacimiento = Etiqueta("F. nacimiento:");
            dtpNacimiento = new DateTimePicker
            {
                Dock = DockStyle.Fill,
                Format = DateTimePickerFormat.Short
            };

            lblTelefono = Etiqueta("Teléfono:");
            txtTelefono = Caja();

            lblEmail = Etiqueta("Email:");
            txtEmail = Caja();

            lblDireccion = Etiqueta("Dirección:");
            txtDireccion = Caja();

            lblProvincia = Etiqueta("Provincia:");
            cboProvincia = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cboProvincia.SelectedIndexChanged += cboProvincia_SelectedIndexChanged;

            lblLocalidad = Etiqueta("Localidad:");
            cboLocalidad = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            lblGrupo = Etiqueta("Grupo sanguíneo:");
            cboGrupo = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };

            lblAlergias = Etiqueta("Alergias:");
            txtAlergias = new TextBox { Dock = DockStyle.Fill, Multiline = true, Height = 80, ScrollBars = ScrollBars.Vertical };

            // Agregar al grid
            int r = 0;
            grid.Controls.Add(lblNombre, 0, r); grid.Controls.Add(txtNombre, 1, r);
            grid.Controls.Add(lblApellido, 2, r); grid.Controls.Add(txtApellido, 3, r); r++;

            grid.Controls.Add(lblDni, 0, r); grid.Controls.Add(txtDni, 1, r);
            grid.Controls.Add(lblSexo, 2, r); grid.Controls.Add(cboSexo, 3, r); r++;

            grid.Controls.Add(lblNacimiento, 0, r); grid.Controls.Add(dtpNacimiento, 1, r);
            grid.Controls.Add(lblTelefono, 2, r); grid.Controls.Add(txtTelefono, 3, r); r++;

            grid.Controls.Add(lblEmail, 0, r); grid.Controls.Add(txtEmail, 1, r);
            grid.Controls.Add(lblDireccion, 2, r); grid.Controls.Add(txtDireccion, 3, r); r++;

            grid.Controls.Add(lblProvincia, 0, r); grid.Controls.Add(cboProvincia, 1, r);
            grid.Controls.Add(lblLocalidad, 2, r); grid.Controls.Add(cboLocalidad, 3, r); r++;

            grid.Controls.Add(lblGrupo, 0, r); grid.Controls.Add(cboGrupo, 1, r); r++;

            grid.Controls.Add(lblAlergias, 0, r);
            grid.SetColumnSpan(txtAlergias, 3);
            grid.Controls.Add(txtAlergias, 1, r);

            grpDatos.Controls.Add(grid);
            this.Controls.Add(grpDatos);
            grpDatos.BringToFront();

            // Footer
            footer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10)
            };

            btnGuardar = BotonPrimario("Guardar");
            btnGuardar.Click += btnGuardar_Click;

            btnLimpiar = BotonSecundario("Limpiar");
            btnLimpiar.Click += btnLimpiar_Click;

            btnCancelar = BotonPeligro("Cancelar");
            btnCancelar.Click += btnCancelar_Click;

            int w = 120, h = 40, sep = 12;
            btnCancelar.Size = btnLimpiar.Size = btnGuardar.Size = new Size(w, h);

            footer.Resize += (s, e) =>
            {
                btnCancelar.Location = new Point(footer.Width - w - 15, 15);
                btnLimpiar.Location = new Point(footer.Width - (w * 2 + sep) - 15, 15);
                btnGuardar.Location = new Point(footer.Width - (w * 3 + sep * 2) - 15, 15);
            };
            // Forzar ubicación inicial
            footer.Width = this.ClientSize.Width;
            footer.PerformLayout();

            footer.Controls.AddRange(new Control[] { btnGuardar, btnLimpiar, btnCancelar });
            this.Controls.Add(footer);

            this.ResumeLayout(false);
        }

        // Helpers visuales
        private static Label Etiqueta(string texto) => new Label
        {
            Text = texto,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        };
        private static TextBox Caja() => new TextBox { Dock = DockStyle.Fill };

        private static Button BotonPrimario(string texto) => new Button
        {
            Text = texto,
            FlatStyle = FlatStyle.Flat,
            BackColor = ColorTranslator.FromHtml("#25C4C2"),
            ForeColor = Color.Black,
            FlatAppearance = { BorderSize = 0 },
            Cursor = Cursors.Hand
        };
        private static Button BotonSecundario(string texto) => new Button
        {
            Text = texto,
            FlatStyle = FlatStyle.Flat,
            BackColor = ColorTranslator.FromHtml("#AEECEF"),
            ForeColor = Color.Black,
            FlatAppearance = { BorderSize = 0 },
            Cursor = Cursors.Hand
        };
        private static Button BotonPeligro(string texto) => new Button
        {
            Text = texto,
            FlatStyle = FlatStyle.Flat,
            BackColor = ColorTranslator.FromHtml("#F07B72"),
            ForeColor = Color.White,
            FlatAppearance = { BorderSize = 0 },
            Cursor = Cursors.Hand
        };
    }
}

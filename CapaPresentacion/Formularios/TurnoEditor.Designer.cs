namespace CapaPresentacion.Formularios
{
    partial class TurnoEditor
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblPaciente, lblMedico, lblFecha, lblHora, lblMotivo, lblObs, lblEstado;
        private ComboBox cmbPacientes, cmbMedicos, cmbEstado;
        private DateTimePicker dtpFecha, dtpHora;
        private TextBox txtMotivo, txtObs;
        private Button btnGuardar, btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblPaciente = new Label();
            lblMedico = new Label();
            lblFecha = new Label();
            lblHora = new Label();
            lblMotivo = new Label();
            lblObs = new Label();
            lblEstado = new Label();

            cmbPacientes = new ComboBox();
            cmbMedicos = new ComboBox();
            cmbEstado = new ComboBox();

            dtpFecha = new DateTimePicker();
            dtpHora = new DateTimePicker();

            txtMotivo = new TextBox();
            txtObs = new TextBox();

            btnGuardar = new Button();
            btnCancelar = new Button();

            SuspendLayout();

            // === Formulario ===
            Text = "Gestión de Turno";
            Size = new Size(520, 520);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;

            int y = 30, sep = 40, xLbl = 30, xCtrl = 150;

            lblPaciente.Text = "Paciente:";
            lblPaciente.Location = new Point(xLbl, y);
            cmbPacientes.Location = new Point(xCtrl, y - 3);
            cmbPacientes.Width = 300;
            y += sep;

            lblMedico.Text = "Médico:";
            lblMedico.Location = new Point(xLbl, y);
            cmbMedicos.Location = new Point(xCtrl, y - 3);
            cmbMedicos.Width = 300;
            y += sep;

            lblFecha.Text = "Fecha:";
            lblFecha.Location = new Point(xLbl, y);
            dtpFecha.Location = new Point(xCtrl, y - 3);
            y += sep;

            lblHora.Text = "Hora:";
            lblHora.Location = new Point(xLbl, y);
            dtpHora.Location = new Point(xCtrl, y - 3);
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.ShowUpDown = true;
            y += sep;

            lblMotivo.Text = "Motivo:";
            lblMotivo.Location = new Point(xLbl, y);
            txtMotivo.Location = new Point(xCtrl, y - 3);
            txtMotivo.Width = 300;
            y += sep;

            lblObs.Text = "Observaciones:";
            lblObs.Location = new Point(xLbl, y);
            txtObs.Location = new Point(xCtrl, y - 3);
            txtObs.Width = 300;
            txtObs.Height = 70;
            txtObs.Multiline = true;
            y += 90;

            lblEstado.Text = "Estado:";
            lblEstado.Location = new Point(xLbl, y);
            cmbEstado.Location = new Point(xCtrl, y - 3);
            cmbEstado.Width = 180;
            y += sep + 10;

            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(150, y);
            btnGuardar.BackColor = Color.FromArgb(0, 136, 204);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Click += BtnGuardar_Click;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(260, y);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Click += BtnCancelar_Click;

            Controls.AddRange(new Control[]
            {
                lblPaciente, cmbPacientes,
                lblMedico, cmbMedicos,
                lblFecha, dtpFecha,
                lblHora, dtpHora,
                lblMotivo, txtMotivo,
                lblObs, txtObs,
                lblEstado, cmbEstado,
                btnGuardar, btnCancelar
            });

            Load += TurnoEditor_Load;
            ResumeLayout(false);
        }
    }
}

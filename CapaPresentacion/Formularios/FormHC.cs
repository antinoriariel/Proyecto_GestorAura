using System;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormHC : Form
    {
        private readonly ErrorProvider _ep;
        private readonly HistoriaClinicaNegocio _hcNegocio = new();
        private AutoCompleteStringCollection _autoPacientes = new();

        public int IdUsuarioActual { get; set; }

        public FormHC()
        {
            InitializeComponent();
            _ep = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            AsignarErrorIconos();

            Load += FormHC_Load;

            txtPaciente.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                    e.Handled = true;
            };

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => Close();
            KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) Close(); };
        }

        // ✅ Constructor adicional para recibir directamente el ID del usuario
        public FormHC(int idUsuarioActual) : this()
        {
            IdUsuarioActual = idUsuarioActual;
        }

        // Constructor adicional con idUsuarioActual e idPaciente
        public FormHC(int idUsuarioActual, int idPaciente) : this(idUsuarioActual)
        {
            // 🔹 Cargar automáticamente el paciente en el campo de texto
            try
            {
                var pacienteNeg = new PacienteNegocio();
                var dt = pacienteNeg.ObtenerPacientePorId(idPaciente); // método simple que devuelva el nombre completo
                if (dt != null && dt.Rows.Count > 0)
                {
                    string nombreCompleto = $"{dt.Rows[0]["nombre"]} {dt.Rows[0]["apellido"]}";
                    txtPaciente.Text = nombreCompleto;
                    txtPaciente.Enabled = false; // evitar edición
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando paciente:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormHC_Load(object? sender, EventArgs e)
        {
            ConfigurarAutocompletadoPacientes();
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            if (cboTipoConsulta.Items.Count > 0) cboTipoConsulta.SelectedIndex = 0;
        }

        private void ConfigurarAutocompletadoPacientes()
        {
            try
            {
                _autoPacientes = new AutoCompleteStringCollection();
                var pacientes = _hcNegocio.ObtenerPacientes();
                foreach (var p in pacientes)
                    _autoPacientes.Add(p.NombreCompleto);

                txtPaciente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtPaciente.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtPaciente.AutoCompleteCustomSource = _autoPacientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando pacientes:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarErrorIconos()
        {
            void Set(Control c)
            {
                _ep.SetIconAlignment(c, ErrorIconAlignment.MiddleRight);
                _ep.SetIconPadding(c, 8);
            }
            Set(txtPaciente); Set(cboEstado); Set(txtMotivo); Set(dtpFechaHora);
            Set(txtImpresionDiag); Set(txtDiagnostico); Set(txtIndicaciones);
            Set(txtAntecedentes); Set(txtObservaciones); Set(cboTipoConsulta);
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            _ep.Clear();
            bool ok = true;

            string pac = txtPaciente.Text.Trim();
            string estado = Convert.ToString(cboEstado.SelectedValue) ?? "abierta";
            string tipo = Convert.ToString(cboTipoConsulta.SelectedValue) ?? "consulta";

            string motivo = txtMotivo.Text.Trim();
            DateTime fechaHora = dtpFechaHora.Value;
            string imp = txtImpresionDiag.Text.Trim();
            string diag = txtDiagnostico.Text.Trim();
            string ind = txtIndicaciones.Text.Trim();
            string ant = txtAntecedentes.Text.Trim();
            string obs = txtObservaciones.Text.Trim();

            if (string.IsNullOrWhiteSpace(pac) || pac.Length < 3)
            {
                _ep.SetError(txtPaciente, "Ingrese un paciente válido.");
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(diag))
            {
                _ep.SetError(txtDiagnostico, "El diagnóstico es obligatorio.");
                ok = false;
            }
            if (!ok) return;

            try
            {
                if (IdUsuarioActual <= 0)
                {
                    MessageBox.Show("Error: no se recibió el ID del usuario actual.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool exito = _hcNegocio.RegistrarHistoriaClinica(
                    pac, estado, motivo, fechaHora, imp, diag, ind, ant, obs, tipo, IdUsuarioActual);

                if (exito)
                {
                    MessageBox.Show("Historia clínica registrada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la historia clínica.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la historia clínica:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

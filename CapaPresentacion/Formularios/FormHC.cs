using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormHC : Form
    {
        private readonly ErrorProvider _ep;
        private readonly HistoriaClinicaNegocio _hcNegocio = new();

        public int IdUsuarioActual { get; set; } // <- Se setea desde el Dashboard o formulario anterior

        public FormHC()
        {
            InitializeComponent();
            _ep = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            AsignarErrorIconos();

            txtPaciente.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                    e.Handled = true;
            };

            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            if (cboTipoConsulta.Items.Count > 0) cboTipoConsulta.SelectedIndex = 0;

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => this.Close();
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };
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
            string estado = cboEstado.Text;
            string motivo = txtMotivo.Text.Trim();
            DateTime fechaHora = dtpFechaHora.Value;
            string imp = txtImpresionDiag.Text.Trim();
            string diag = txtDiagnostico.Text.Trim();
            string ind = txtIndicaciones.Text.Trim();
            string ant = txtAntecedentes.Text.Trim();
            string obs = txtObservaciones.Text.Trim();
            string tipo = cboTipoConsulta.Text;

            // Validaciones simples de presentación
            if (string.IsNullOrWhiteSpace(pac) || pac.Length < 3)
            {
                _ep.SetError(txtPaciente, "Ingrese un nombre de paciente válido.");
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
                bool exito = _hcNegocio.RegistrarHistoriaClinica(
                    pac, estado, motivo, fechaHora, imp, diag, ind, ant, obs, tipo, IdUsuarioActual);

                if (exito)
                {
                    MessageBox.Show("Historia clínica registrada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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

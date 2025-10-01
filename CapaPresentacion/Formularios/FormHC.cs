using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormHC : Form
    {
        private readonly ErrorProvider _ep;

        public FormHC()
        {
            InitializeComponent();

            // ErrorProvider
            _ep = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };

            // Asignar íconos a todos los controles
            AsignarErrorIconos();

            // Solo letras y espacios en Paciente
            txtPaciente.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                    e.Handled = true;
            };

            // Valores por defecto
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            if (cboTipoConsulta.Items.Count > 0) cboTipoConsulta.SelectedIndex = 0;

            // Botones
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            // ESC cierra
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) this.Close();
            };
        }

        private void AsignarErrorIconos()
        {
            void Set(Control c)
            {
                _ep.SetIconAlignment(c, ErrorIconAlignment.MiddleRight);
                _ep.SetIconPadding(c, 8);
            }

            Set(txtPaciente);
            Set(cboEstado);
            Set(txtMotivo);
            Set(dtpFechaHora);
            Set(txtImpresionDiag);
            Set(txtDiagnostico);
            Set(txtIndicaciones);
            Set(txtAntecedentes);
            Set(txtObservaciones);
            Set(cboTipoConsulta);
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            _ep.Clear();
            bool ok = true;

            // Paciente
            string pac = txtPaciente.Text.Trim();
            if (string.IsNullOrWhiteSpace(pac) || pac.Length < 3 || !Regex.IsMatch(pac, @"^[A-Za-z ]+$"))
            {
                _ep.SetError(txtPaciente, "Paciente obligatorio (mín. 3 letras, solo texto).");
                ok = false;
            }

            // Estado
            if (cboEstado.SelectedIndex < 0)
            {
                _ep.SetError(cboEstado, "Seleccione un estado.");
                ok = false;
            }

            // Motivo
            string motivo = txtMotivo.Text.Trim();
            if (motivo.Length < 5 || motivo.Length > 200)
            {
                _ep.SetError(txtMotivo, "Motivo obligatorio (5–200 caracteres).");
                ok = false;
            }

            // Fecha y hora
            if (dtpFechaHora.Value > DateTime.Now)
            {
                _ep.SetError(dtpFechaHora, "La fecha/hora no puede ser futura.");
                ok = false;
            }

            // Impresión diagnóstica (opcional, máx. 400)
            if (!string.IsNullOrWhiteSpace(txtImpresionDiag.Text) && txtImpresionDiag.Text.Trim().Length > 400)
            {
                _ep.SetError(txtImpresionDiag, "Máximo 400 caracteres.");
                ok = false;
            }

            // Diagnóstico (obligatorio, 5–400)
            if (string.IsNullOrWhiteSpace(txtDiagnostico.Text) ||
                txtDiagnostico.Text.Trim().Length < 5 ||
                txtDiagnostico.Text.Trim().Length > 400)
            {
                _ep.SetError(txtDiagnostico, "Diagnóstico obligatorio (5–400 caracteres).");
                ok = false;
            }

            // Indicaciones (obligatorio, 5–2000)
            if (string.IsNullOrWhiteSpace(txtIndicaciones.Text) ||
                txtIndicaciones.Text.Trim().Length < 5 ||
                txtIndicaciones.Text.Trim().Length > 2000)
            {
                _ep.SetError(txtIndicaciones, "Indicaciones obligatorias (5–2000 caracteres).");
                ok = false;
            }

            // Antecedentes (opcional, ?2000)
            if (!string.IsNullOrWhiteSpace(txtAntecedentes.Text) && txtAntecedentes.Text.Trim().Length > 2000)
            {
                _ep.SetError(txtAntecedentes, "Máximo 2000 caracteres.");
                ok = false;
            }

            // Observaciones (opcional, ?2000)
            if (!string.IsNullOrWhiteSpace(txtObservaciones.Text) && txtObservaciones.Text.Trim().Length > 2000)
            {
                _ep.SetError(txtObservaciones, "Máximo 2000 caracteres.");
                ok = false;
            }

            // Tipo consulta
            if (cboTipoConsulta.SelectedIndex < 0)
            {
                _ep.SetError(cboTipoConsulta, "Seleccione el tipo de consulta.");
                ok = false;
            }

            // Resultado
            if (!ok) return;

            MessageBox.Show("? Historia clínica guardada con éxito (demo hardcodeado).",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}

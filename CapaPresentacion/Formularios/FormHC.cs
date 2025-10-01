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

            // ErrorProvider visible y sin recortes
            _ep = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            _ep.SetIconAlignment(txtPaciente, ErrorIconAlignment.MiddleRight);
            _ep.SetIconPadding(txtPaciente, 8);
            _ep.SetIconAlignment(txtMotivo, ErrorIconAlignment.MiddleRight);
            _ep.SetIconPadding(txtMotivo, 8);
            _ep.SetIconAlignment(cboEstado, ErrorIconAlignment.MiddleRight);
            _ep.SetIconPadding(cboEstado, 8);
            _ep.SetIconAlignment(cboTipoConsulta, ErrorIconAlignment.MiddleRight);
            _ep.SetIconPadding(cboTipoConsulta, 8);

            // Valores por defecto
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            if (cboTipoConsulta.Items.Count > 0) cboTipoConsulta.SelectedIndex = 0;

            // Solo letras y espacios en Paciente
            txtPaciente.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                    e.Handled = true;
            };

            // Botones
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            // ESC cierra
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) this.Close();
            };
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            _ep.Clear();
            bool ok = true;

            // Paciente: m�nimo 3 letras, solo a-z A-Z y espacios
            string pac = txtPaciente.Text.Trim();
            if (string.IsNullOrWhiteSpace(pac) || pac.Length < 3 || !Regex.IsMatch(pac, @"^[A-Za-z ]+$"))
            {
                _ep.SetError(txtPaciente, "Ingrese un nombre v�lido (solo letras y espacios, m�n. 3).");
                ok = false;
            }

            // Motivo: m�nimo 5 caracteres
            if (string.IsNullOrWhiteSpace(txtMotivo.Text) || txtMotivo.Text.Trim().Length < 5)
            {
                _ep.SetError(txtMotivo, "Motivo obligatorio (m�n. 5 caracteres).");
                ok = false;
            }

            if (cboEstado.SelectedIndex < 0)
            {
                _ep.SetError(cboEstado, "Seleccione un estado.");
                ok = false;
            }

            if (cboTipoConsulta.SelectedIndex < 0)
            {
                _ep.SetError(cboTipoConsulta, "Seleccione el tipo de consulta.");
                ok = false;
            }

            if (!ok) return;

            MessageBox.Show("? Historia cl�nica guardada (demo hardcodeado).",
                "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}

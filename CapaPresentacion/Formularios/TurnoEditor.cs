using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class TurnoEditor : Form
    {
        private readonly TurnoNegocio _turnoNegocio = new TurnoNegocio();
        private readonly bool _modoEdicion;
        private readonly int _idTurnoEditar;

        public TurnoEditor()
        {
            InitializeComponent();
        }

        public TurnoEditor(int idTurno) : this()
        {
            _modoEdicion = true;
            _idTurnoEditar = idTurno;
            Text = "Editar Turno";
        }

        private void TurnoEditor_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            cmbEstado.Items.AddRange(new[] { "programado", "confirmado", "atendido", "cancelado" });
            cmbEstado.SelectedIndex = 0;
        }

        // === CARGA DE COMBOS CON AUTOCOMPLETADO ===
        private void CargarCombos()
        {
            try
            {
                DataTable pacientes = _turnoNegocio.ObtenerPacientes();
                ConfigurarAutoCompletar(cmbPacientes, pacientes, "nombreCompleto", "id_paciente");

                DataTable medicos = _turnoNegocio.ObtenerMedicos();
                ConfigurarAutoCompletar(cmbMedicos, medicos, "nombreCompleto", "id_medico");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar listas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarAutoCompletar(ComboBox combo, DataTable datos, string display, string value)
        {
            combo.DataSource = datos;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        // === GUARDAR TURNOS ===
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                DateTime fecha = dtpFecha.Value.Date;
                TimeSpan hora = dtpHora.Value.TimeOfDay;
                int idPaciente = (int)cmbPacientes.SelectedValue;
                int idMedico = (int)cmbMedicos.SelectedValue;
                string motivo = txtMotivo.Text.Trim();
                string observaciones = txtObs.Text.Trim();
                string estado = cmbEstado.SelectedItem.ToString();

                bool ok;
                if (_modoEdicion)
                {
                    ok = _turnoNegocio.ActualizarTurno(_idTurnoEditar, fecha, hora, idMedico, estado, motivo, observaciones);
                }
                else
                {
                    ok = _turnoNegocio.CrearTurno(fecha, hora, idPaciente, idMedico, 1, motivo, observaciones);
                }

                if (ok)
                {
                    MessageBox.Show("✅ Turno guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("⚠️ No se pudo guardar el turno.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === VALIDACIÓN DE CAMPOS OBLIGATORIOS ===
        private bool ValidarCampos()
        {
            if (cmbPacientes.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un paciente válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPacientes.Focus();
                return false;
            }
            if (cmbMedicos.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un médico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMedicos.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Debe ingresar el motivo del turno.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivo.Focus();
                return false;
            }
            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e) => Close();
    }
}

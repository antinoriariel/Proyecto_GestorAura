using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormHC : Form
    {
        public FormHC()
        {
            InitializeComponent();
        }

        private void FormHC_Load(object sender, EventArgs e)
        {
            // TODO: cargar combos desde tu capa de datos
            // cboPaciente.DataSource = servicioPacientes.Listar();
            // cboPaciente.DisplayMember = "NombreCompleto";
            // cboPaciente.ValueMember = "Id";
            //
            // cboEstado.DataSource = new[] { "Abierta", "Cerrada", "Derivada" };
        }

        private void OnGuardarHC()
        {
            if (cboPaciente.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccioná un paciente.");
                cboPaciente.DroppedDown = true;
                return;
            }
            if (cboEstado.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccioná un estado de historia clínica.");
                cboEstado.DroppedDown = true;
                return;
            }

            // Ejemplo de armado de entidad (ajustá a tu modelo)
            var hc = new
            {
                PacienteId = cboPaciente.SelectedValue,
                Estado = cboEstado.SelectedItem?.ToString(),
                FechaHora = dtpFechaHora.Value,
                Motivo = txtMotivoConsulta.Text.Trim(),
                ImpresionDiagnostica = txtImpresionDiag.Text.Trim(),
                Diagnostico = txtDiagnostico.Text.Trim(),
                Indicaciones = txtIndicaciones.Text.Trim(),
                Antecedentes = txtAntecedentes.Text.Trim(),
                Evolucion = txtEvolucion.Text.Trim(),
                ImpresionGeneral = txtImpresionGral.Text.Trim(),
                Examenes = txtExamenes.Text.Trim(),
                TipoConsulta = txtTipoConsulta.Text.Trim()
            };

            // TODO: persistir en tu servicio/repositorio
            // servicioHC.Guardar(hc);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

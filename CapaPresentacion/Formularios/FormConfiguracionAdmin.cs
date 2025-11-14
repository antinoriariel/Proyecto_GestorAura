using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormConfiguracionAdmin : Form
    {
        public FormConfiguracionAdmin()
        {
            InitializeComponent();
            CargarConfiguraciones();
        }

        private void CargarConfiguraciones()
        {
            // TODO: Cargar valores reales desde tu capa de configuración / BD.
            // Por ahora dejo valores de ejemplo.

            txtNombreSistema.Text = "GestorAura";
            txtVersion.Text = "v1.0";
            txtMensajeBienvenida.Text = "Bienvenido al sistema de gestión hospitalaria.";

            nudDiasVencimiento.Value = 90;
            nudIntentosFallidos.Value = 3;
            chkRequerirMayusculas.Checked = true;
            chkRequerirNumeros.Checked = true;
            chkForzarCambioPrimerInicio.Checked = false;

            txtRutaBackup.Text = @"C:\Backups_GestorAura";
            chkComprimirBackup.Checked = true;
            chkIncluirLog.Checked = false;

            chkTemaOscuro.Checked = false;
            chkConfirmarSalida.Checked = true;
            chkMostrarTooltips.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // TODO: Guardar valores en tu config / BD.
            // Acá solo muestro mensaje de ejemplo.

            MessageBox.Show("Configuraciones guardadas correctamente.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(
                "¿Seguro que deseas restablecer las configuraciones a sus valores por defecto?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                CargarConfiguraciones();
            }
        }

        private void btnSeleccionarRutaBackup_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona la carpeta por defecto para los backups";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaBackup.Text = fbd.SelectedPath;
                }
            }
        }
    }
}

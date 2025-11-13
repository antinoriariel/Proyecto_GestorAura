using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormBackup : Form
    {
        private readonly BackupNegocio _backupNegocio = new();

        public FormBackup()
        {
            InitializeComponent();
        }

        private void btnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Seleccione la carpeta donde se guardará el backup";

                if (!string.IsNullOrWhiteSpace(txtRuta.Text))
                    dialog.SelectedPath = txtRuta.Text;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            string ruta = txtRuta.Text.Trim();

            if (string.IsNullOrWhiteSpace(ruta))
            {
                MessageBox.Show("Debe ingresar o seleccionar una ruta de destino.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar caracteres no permitidos
            char[] invalidChars = Path.GetInvalidPathChars()
                                     .Concat(new char[] { '*', '?', '"', '<', '>', '|' })
                                     .ToArray();

            if (ruta.IndexOfAny(invalidChars) >= 0)
            {
                MessageBox.Show("La ruta contiene caracteres no permitidos: \\ / : * ? \" < > |",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar existencia de la ruta
            if (!Directory.Exists(ruta))
            {
                MessageBox.Show("La ruta especificada no existe. Seleccione una carpeta válida.",
                    "Ruta inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnGenerarBackup.Enabled = false;
                Cursor = Cursors.WaitCursor;

                string carpetaFinal = _backupNegocio.GenerarBackupCompleto(ruta);

                MessageBox.Show(
                    $"Backup generado correctamente.\n\nCarpeta:\n{carpetaFinal}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al generar backup:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnGenerarBackup.Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }
}

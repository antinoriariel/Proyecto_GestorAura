using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormBackup : Form
    {
        public FormBackup()
        {
            InitializeComponent();
        }

        private void btnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
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

            // Simulación de creación de backup
            string fileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string fullPath = Path.Combine(ruta, fileName);

            try
            {
                File.Create(fullPath).Close();
                MessageBox.Show($"Backup generado correctamente en:\n{fullPath}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar backup: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

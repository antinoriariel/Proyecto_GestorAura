using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FormCargaUsuarios : Form
    {
        private readonly Carga carga = new Carga();

        public FormCargaUsuarios()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                carga.CargarUsuario(
                    txtUsername.Text.Trim(),
                    txtPassword.Text,
                    txtEmail.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    decimal.Parse(txtDni.Text.Trim()),
                    dtpFechaNacimiento.Value,
                    txtTelefono.Text.Trim(),
                    cmbRol.SelectedItem?.ToString() ?? "medico"
                );

                MessageBox.Show("✅ Usuario cargado con éxito",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            cmbRol.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Today;
        }
    }
}

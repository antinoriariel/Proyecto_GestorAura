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

            // Eventos de botones
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += (s, e) => this.Close();

            // Escape cierra formulario
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) this.Close();
            };
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtDni.Text) ||
                    string.IsNullOrWhiteSpace(cmbRol.Text))
                {
                    MessageBox.Show("⚠️ Todos los campos son obligatorios",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

        // 🎨 Handler para estilizar el ComboBox Rol
        private void cmbRol_DrawItem(object? sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var combo = (ComboBox)sender!;
                string text = combo.GetItemText(combo.Items[e.Index]);

                var foreColor = ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    ? SystemColors.HighlightText
                    : SystemColors.ControlText;

                TextRenderer.DrawText(
                    e.Graphics,
                    text,
                    combo.Font,
                    e.Bounds,
                    foreColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left
                );
            }
            e.DrawFocusRectangle();
        }
    }
}

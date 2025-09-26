using System;
using System.Text.RegularExpressions;
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
                // === Validaciones de frontend ===

                // Username
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Length > 30)
                {
                    MessageBox.Show("⚠️ El usuario es obligatorio y no debe superar 30 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Password
                if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("⚠️ La contraseña es obligatoria y debe tener al menos 6 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Email
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || txtEmail.Text.Length > 50 ||
                    !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("⚠️ El email es obligatorio, válido y no debe superar 50 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nombre
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text.Length > 50)
                {
                    MessageBox.Show("⚠️ El nombre es obligatorio y no debe superar 50 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Apellido
                if (string.IsNullOrWhiteSpace(txtApellido.Text) || txtApellido.Text.Length > 50)
                {
                    MessageBox.Show("⚠️ El apellido es obligatorio y no debe superar 50 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // DNI
                if (!Regex.IsMatch(txtDni.Text.Trim(), @"^\d{8}$"))
                {
                    MessageBox.Show("⚠️ El DNI debe tener exactamente 8 dígitos numéricos.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fecha de nacimiento
                if (dtpFechaNacimiento.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("⚠️ La fecha de nacimiento no puede ser futura.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Teléfono (opcional, solo si se completa)
                if (!string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    if (!Regex.IsMatch(txtTelefono.Text, @"^[0-9+()\-\s]{7,20}$"))
                    {
                        MessageBox.Show("⚠️ El teléfono solo puede contener números, +, (), - y debe tener entre 7 y 20 caracteres.",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Rol
                if (cmbRol.SelectedIndex == -1 ||
                    !(cmbRol.Text == "medico" || cmbRol.Text == "secretaria" || cmbRol.Text == "administrador"))
                {
                    MessageBox.Show("⚠️ Debe seleccionar un rol válido (medico, secretaria o administrador).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // === Si pasa todas las validaciones ===
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

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

            // Fuente uniforme (igual que FormHC)
            this.Font = new Font("Consolas", 12F, FontStyle.Bold);

            // 🔒 Evitar doble suscripción
            btnGuardar.Click -= btnGuardar_Click;
            btnGuardar.Click += btnGuardar_Click;

            // Escape cierra formulario
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) this.Close();
            };

            // 🗓️ Restringir fecha (≥18 años)
            dtpFechaNacimiento.MaxDate = DateTime.Today.AddYears(-18);

            // 🆕 Cargar roles disponibles en ComboBox
            cmbRol.Items.Clear();
            cmbRol.Items.AddRange(new string[]
            {
                "medico",
                "secretaria",
                "administrador",
                "administrativo" // 🆕 nuevo rol
            });
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                // === Validaciones de frontend ===

                // Username (min 5, max 30)
                string user = txtUsername.Text?.Trim() ?? string.Empty;
                if (user.Length < 5 || user.Length > 30)
                {
                    MessageBox.Show("⚠️ El usuario es obligatorio, mínimo 5 y máximo 30 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Password (min 6)
                string pass = txtPassword.Text ?? string.Empty;
                if (string.IsNullOrWhiteSpace(pass) || pass.Length < 6)
                {
                    MessageBox.Show("⚠️ La contraseña es obligatoria y debe tener al menos 6 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Email
                string email = txtEmail.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(email) || email.Length > 50 ||
                    !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("⚠️ El email es obligatorio, válido y no debe superar 50 caracteres.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nombre (solo letras)
                string nombre = txtNombre.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 3 || nombre.Length > 50 ||
                    !Regex.IsMatch(nombre, @"^[a-zA-ZÁÉÍÓÚÑáéíóúñ\s]+$"))
                {
                    MessageBox.Show("⚠️ El nombre es obligatorio, debe tener entre 3 y 50 caracteres y no puede contener números.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Apellido (solo letras)
                string apellido = txtApellido.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(apellido) || apellido.Length < 3 || apellido.Length > 50 ||
                    !Regex.IsMatch(apellido, @"^[a-zA-ZÁÉÍÓÚÑáéíóúñ\s]+$"))
                {
                    MessageBox.Show("⚠️ El apellido es obligatorio, debe tener entre 3 y 50 caracteres y no puede contener números.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // DNI (8 dígitos)
                string dniTxt = txtDni.Text?.Trim() ?? string.Empty;
                if (!Regex.IsMatch(dniTxt, @"^\d{8}$"))
                {
                    MessageBox.Show("⚠️ El DNI debe tener exactamente 8 dígitos numéricos.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fecha de nacimiento (≥ 18 años)
                DateTime fnac = dtpFechaNacimiento.Value.Date;
                if (fnac > DateTime.Today.AddYears(-18))
                {
                    MessageBox.Show("⚠️ El usuario debe ser mayor de 18 años.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Teléfono (opcional)
                string telefono = txtTelefono.Text?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(telefono))
                {
                    if (!Regex.IsMatch(telefono, @"^[0-9+()\-\s]{7,20}$") ||
                        !Regex.IsMatch(telefono, @"\d"))
                    {
                        MessageBox.Show("⚠️ El teléfono debe tener entre 7 y 20 caracteres, puede contener números, +, (), - y espacios; y debe incluir al menos un dígito.",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Rol (ahora incluye "administrativo")
                string rol = cmbRol.SelectedItem?.ToString() ?? string.Empty;
                if (string.IsNullOrEmpty(rol) ||
                    !(rol == "medico" || rol == "secretaria" || rol == "administrador" || rol == "administrativo"))
                {
                    MessageBox.Show("⚠️ Debe seleccionar un rol válido (medico, secretaria, administrador o administrativo).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // === Si pasa todas las validaciones ===
                carga.CargarUsuario(
                    user,
                    pass,
                    email,
                    nombre,
                    apellido,
                    decimal.Parse(dniTxt),
                    fnac,
                    telefono,
                    rol
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

            var limite18 = DateTime.Today.AddYears(-18);
            dtpFechaNacimiento.MaxDate = limite18;
            dtpFechaNacimiento.Value = limite18;
        }

        // 🎨 Estilo ComboBox
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

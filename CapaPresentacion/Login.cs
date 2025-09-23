using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        private int intentosFallidos;
        private readonly UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;  // Enter hace login
            this.CancelButton = btnClose;  // Esc hace this.Close()
            this.KeyPreview = true;        // Permite capturar teclas a nivel de formulario
            this.KeyDown += Login_KeyDown;
        }

        private void Login_KeyDown(object? sender, KeyEventArgs e)
        {
            // ESC o Ctrl+S cierran el formulario
            if (e.KeyCode == Keys.Escape || (e.Control && e.KeyCode == Keys.S))
            {
                this.Close();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsername.Text.Trim();
            string contraseña = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("El campo usuario es obligatorio.",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("La contraseña es obligatoria.",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string? rol = usuarioNegocio.Login(usuario, contraseña);

            if (rol != null)
            {
                this.Hide();
                var dashboard_form = new Dashboard(rol);
                dashboard_form.FormClosed += (s, args) => this.Close();
                dashboard_form.Show();
            }
            else
            {
                intentosFallidos++;
                MessageBox.Show("Usuario o contraseña incorrectos.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();

                if (intentosFallidos >= 3)
                {
                    MessageBox.Show("Demasiados intentos fallidos. Cerrando la aplicación.",
                        "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

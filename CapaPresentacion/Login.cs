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
            this.AcceptButton = btnLogin;
            this.CancelButton = btnClose;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsername.Text.Trim();
            string contraseña = txtPassword.Text;

            ErrorProvider1.SetError(txtUsername, "");
            ErrorProvider1.SetError(txtPassword, "");

            if (string.IsNullOrWhiteSpace(usuario))
            {
                ErrorProvider1.SetError(txtUsername, "El campo usuario es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                ErrorProvider1.SetError(txtPassword, "La contraseña es obligatoria.");
                return;
            }

            string? rol = usuarioNegocio.Login(usuario, contraseña);

            if (rol != null)
            {
                this.Hide();
                var dashboard_form = new Dashboard(/*rol*/);
                dashboard_form.FormClosed += (s, args) => this.Close();
                dashboard_form.Show();
            }
            else
            {
                intentosFallidos++;
                ErrorProvider1.SetError(txtPassword, "Usuario o contraseña incorrectos.");
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
    }
}

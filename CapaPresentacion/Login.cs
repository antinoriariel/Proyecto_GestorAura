using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration; // Para ConfigurationManager de la base de datos
using System.Data.SqlClient; // Para SqlConnection, SqlCommand, SqlDataReader

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        private int intentosFallidos; //Para contabilizar los intentos de login

        // Constructor
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Quitar borde predeterminado

            this.AcceptButton = btnLogin; // <- Ejecuta el botón al presionar Enter
            this.KeyPreview = true; // <-- Necesario para capturar las teclas
            this.KeyDown += LoginForm_KeyDown; // <-- Manejo de teclas
        }

        // Usar System.Drawing.Drawing2D para bordes redondeados
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int radio = 10;
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(this.Width - radio, 0, radio, radio, 270, 90);
                path.AddArc(this.Width - radio, this.Height - radio, radio, radio, 0, 90);
                path.AddArc(0, this.Height - radio, radio, radio, 90, 90);
                path.CloseAllFigures();
                this.Region = new Region(path);
            }
        }

        private void btnClose_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsername.Text.Trim(); //elimina los espacios vacios en el texto ingresado al campo usuario
            string contraseña = txtPassword.Text;

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, completa el campo de usuario", "Campo usuario requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Clear();
                txtPassword.Clear();
                return;
            }

            if (string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, completa el campo de contraseña", "Campo contraseña requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Clear();
                txtPassword.Clear();
                return;
            }

            // Validación de credenciales
            if (usuario == "admin" || usuario == "medico" || usuario == "secre" && contraseña == "1234")
            {
                // Ocultar el login
                this.Hide();

                // Crear e iniciar el formulario MDI
                var mdi = new MdiDahsboard(usuario);   // <-- usa el nombre exacto de tu clase MDI
                mdi.FormClosed += (s, args) => this.Close(); // al cerrar MDI, cerrar login también
                mdi.Show();
            }
            else
            {
                intentosFallidos++;

                if (intentosFallidos >= 3)
                {
                    MessageBox.Show("Demasiados intentos fallidos. Cerrando la aplicación.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close(); // o Application.Exit() si quieres cerrar toda la app
                    return;
                }

                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        //Usamos este metodo para cerrar el login form con ctrl + s
        private void LoginForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Close();
                //Application.Exit(); // <- opcional si querés cerrar toda la app
            }
        }
    }
}

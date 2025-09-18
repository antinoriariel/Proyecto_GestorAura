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
            string usuario = txtUsername.Text.Trim();
            string contraseña = txtPassword.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, completa todos los campos", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 👇 Usa el mismo nombre definido en App.config
            string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT rol FROM users WHERE username = @user AND password = @pass AND activo = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", usuario);
                        cmd.Parameters.AddWithValue("@pass", contraseña);

                        object rol = cmd.ExecuteScalar(); // Devuelve el rol o null si no existe

                        if (rol != null)
                        {
                            // Ocultar el login
                            this.Hide();

                            // Abrir el dashboard
                            var mdi = new MdiDahsboard(usuario);
                            mdi.FormClosed += (s, args) => this.Close();
                            mdi.Show();
                        }
                        else
                        {
                            intentosFallidos++;
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            if (intentosFallidos >= 3)
                            {
                                MessageBox.Show("Demasiados intentos fallidos. Cerrando la aplicación.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

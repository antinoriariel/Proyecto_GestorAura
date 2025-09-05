using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class LoginForm : Form
    {
        private int intentosFallidos = 0; //Para contabilizar los intentos de login

        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load; // <- aquí se conecta el evento
            this.AcceptButton = btnLogin; // <- Ejecuta el botón al presionar Enter

            this.KeyPreview = true; // <-- Necesario para capturar las teclas
            this.KeyDown += LoginForm_KeyDown; // <-- Manejo de teclas

            //esta parte hay que eliminarla en produccion
            /*var mdi = new MdiDahsboard();   // <-- usa el nombre exacto de tu clase MDI
            mdi.FormClosed += (s, args) => this.Close(); // al cerrar MDI, cerrar login también
            mdi.Show();*/
        }

        //Usamos este metodo para cerrar el login form con ctrl + s
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Close();
                //Application.Exit(); // <- opcional si querés cerrar toda la app
            }
        }

        //Renderizador para rounded en las esquinas de la imagen de medic
        private void SetRoundedPictureBox(PictureBox pb, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // esquina superior izquierda
            path.AddArc(pb.Width - radius, 0, radius, radius, 270, 90); // superior derecha
            path.AddArc(pb.Width - radius, pb.Height - radius, radius, radius, 0, 90); // inferior derecha
            path.AddArc(0, pb.Height - radius, radius, radius, 90, 90); // inferior izquierda
            path.CloseAllFigures();
            pb.Region = new Region(path);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetRoundedPictureBox(imgMedic, 10); // 20 = radio de las esquinas, ajusta a gusto
        }

        private void BtnLogin_Click(object sender, EventArgs e)
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
            if (usuario == "admin" && contraseña == "1234")
            {
                // Ocultar el login
                this.Hide();

                // Crear e iniciar el formulario MDI
                var mdi = new MdiDahsboard();   // <-- usa el nombre exacto de tu clase MDI
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

        private void imgMedic_Click(object sender, EventArgs e)
        {

        }
    }
}
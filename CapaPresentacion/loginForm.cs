using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load; // <- aquí se conecta el evento
            this.AcceptButton = btnLogin; // <- Ejecuta el botón al presionar Enter
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
                return;
            }

            if (string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, completa el campo de contraseña", "Campo contraseña requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de credenciales
            if (usuario == "admin" && contraseña == "1234")
            {
                MessageBox.Show("Inicio de sesión exitoso", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí podrías abrir otro formulario, ocultar este, etc.
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }
    }
}
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
            this.Load += LoginForm_Load; // <- aqu� se conecta el evento
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
            string usuario = txtUsername.Text.Trim();
            string contrase�a = txtPassword.Text;

            // Validaci�n de campos vac�os
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrase�a))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validaci�n de credenciales
            if (usuario == "admin" && contrase�a == "1234")
            {
                MessageBox.Show("Inicio de sesi�n exitoso", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aqu� podr�as abrir otro formulario, ocultar este, etc.
            }
            else
            {
                MessageBox.Show("Usuario o contrase�a incorrectos.", "Error de autenticaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
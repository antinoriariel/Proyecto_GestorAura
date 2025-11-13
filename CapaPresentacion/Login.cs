using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            this.KeyPreview = true;
            this.KeyDown += Login_KeyDown;

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Teal;

            this.Load += (s, e) =>
            {
                AplicarEsquinasRedondeadas(12);
                AplicarEsquinasRedondeadasPictureBox(pictureBox1, 12);
            };

            this.Resize += (s, e) =>
            {
                AplicarEsquinasRedondeadas(12);
                AplicarEsquinasRedondeadasPictureBox(pictureBox1, 12);
            };
        }

        private void AplicarEsquinasRedondeadas(int radio)
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radio, radio, 180, 90);
                path.AddArc(bounds.Right - radio, bounds.Y, radio, radio, 270, 90);
                path.AddArc(bounds.Right - radio, bounds.Bottom - radio, radio, radio, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radio, radio, radio, 90, 90);
                path.CloseAllFigures();
                this.Region = new Region(path);
            }
        }

        private void AplicarEsquinasRedondeadasPictureBox(PictureBox pb, int radio)
        {
            if (pb.Image == null) return;

            Rectangle bounds = new Rectangle(0, 0, pb.Width, pb.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radio, radio, 180, 90);
                path.AddArc(bounds.Right - radio, bounds.Y, radio, radio, 270, 90);
                path.AddArc(bounds.Right - radio, bounds.Bottom - radio, radio, radio, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radio, radio, radio, 90, 90);
                path.CloseAllFigures();
                pb.Region = new Region(path);
            }
        }

        private void Login_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || (e.Control && e.KeyCode == Keys.S))
            {
                this.Close();
            }
        }

        // ============================================================
        // EVENTO: BOTÓN LOGIN (CORREGIDO)
        // ============================================================
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

            UsuarioLoginResult? userData = usuarioNegocio.Login(usuario, contraseña);

            // Usuario NO existe
            if (userData == null)
            {
                intentosFallidos++;
                MessageBox.Show("Usuario o contraseña incorrectos.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Usuario inactivo
            if (!userData.Activo)
            {
                MessageBox.Show(
                    "El usuario se encuentra deshabilitado para iniciar sesión.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Contraseña incorrecta
            if (!userData.PasswordValida)
            {
                intentosFallidos++;
                MessageBox.Show("Usuario o contraseña incorrectos.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // ============================
            // LOGIN CORRECTO
            // ============================
            this.Hide();

            var dashboard_form = new Dashboard(userData.Rol, userData.NombreCompleto, usuario);

            dashboard_form.FormClosed += (s, args) =>
            {
                if (!this.IsDisposed)
                {
                    this.Show();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            };

            dashboard_form.Show();
        }

        // ============================================================
        // EVENTO: BOTÓN CERRAR
        // ============================================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

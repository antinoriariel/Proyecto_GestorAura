using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            this.Load += loginForm_Load; // <- aquí se conecta el evento
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void loginForm_Load(object sender, EventArgs e)
        {
            SetRoundedPictureBox(imgMedic, 10); // 20 = radio de las esquinas, ajusta a gusto
        }
    }
}
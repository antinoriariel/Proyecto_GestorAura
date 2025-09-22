using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Dashboard : Form
    {
        private int childFormNumber = 0;

        public Dashboard()
        {
            InitializeComponent();
            InicializarPanelLateral(); // <- agregamos los botones en runtime
        }

        private void InicializarPanelLateral()
        {
            // Botón Usuarios
            Button btnUsuarios = new Button();
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.Size = new System.Drawing.Size(140, 40);
            btnUsuarios.Location = new System.Drawing.Point(10, 20);
            btnUsuarios.Click += (s, e) =>
            {
                FormCargaUsuarios form = new FormCargaUsuarios();
                form.MdiParent = this;
                form.Show();
            };
            panel1.Controls.Add(btnUsuarios);

            // Botón Pacientes
            Button btnPacientes = new Button();
            btnPacientes.Text = "Pacientes";
            btnPacientes.Size = new System.Drawing.Size(140, 40);
            btnPacientes.Location = new System.Drawing.Point(10, 70);
            btnPacientes.Click += (s, e) =>
            {
                MessageBox.Show("Formulario de Pacientes (pendiente de implementación).");
                // Cuando crees FormPacientes:
                // var form = new FormPacientes();
                // form.MdiParent = this;
                // form.Show();
            };
            panel1.Controls.Add(btnPacientes);

            // Botón Turnos
            Button btnTurnos = new Button();
            btnTurnos.Text = "Turnos";
            btnTurnos.Size = new System.Drawing.Size(140, 40);
            btnTurnos.Location = new System.Drawing.Point(10, 120);
            btnTurnos.Click += (s, e) =>
            {
                MessageBox.Show("Formulario de Turnos (pendiente de implementación).");
                // var form = new FormTurnos();
                // form.MdiParent = this;
                // form.Show();
            };
            panel1.Controls.Add(btnTurnos);

            // Botón Salir
            Button btnSalir = new Button();
            btnSalir.Text = "Salir";
            btnSalir.Size = new System.Drawing.Size(140, 40);
            btnSalir.Location = new System.Drawing.Point(10, 400);
            btnSalir.Click += (s, e) => this.Close();
            panel1.Controls.Add(btnSalir);
        }

        // Métodos que ya tenías
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string mensaje = "Gestor de Historias Clínicas - MedicSys\n\n" +
                 "Versión: 1.0\n" +
                 "Desarrolladores:\n" +
                 "- Antinori, Ariel\n" +
                 "- Alegre, Leonel\n" +
                 "\n© 2025 Medic - Todos los derechos reservados";

            MessageBox.Show(mensaje, "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void webDelProyectoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/antinoriariel/Proyecto_GestorAura",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
        }
    }
}

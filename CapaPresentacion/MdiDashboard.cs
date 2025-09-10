using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class MdiDahsboard : Form
    {
        private int childFormNumber = 0;

        public MdiDahsboard(string userName)
        {
            InitializeComponent();
            // Cargar el menú según el rol del usuario
            if (userName == "admin")
            {
                CargarMenu("Administrador");
            }
            else if (userName == "medico")
            {
                CargarMenu("Medico");
            }
            else if (userName == "secre")
            {
                CargarMenu("Secretaria");
            }
        }

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

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MdiDahsboard_Load(object sender, EventArgs e)
        {

        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/antinoriariel/Proyecto_GestorAura",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "Gestor de Historias Clínicas - MedicSys\n\n" +
                 "Versión: 1.0\n" +
                 "Desarrolladores:\n" +
                 "- Antinori, Ariel\n" +
                 "- Alegre, Leonel\n" +
                 "\n© 2025 Medic - Todos los derechos reservados";

            MessageBox.Show(mensaje, "Acerca de", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CargarMenu(string rolUsuario)
        {
            panel1.Controls.Clear(); // Limpia por si ya tenía botones

            FlowLayoutPanel menu = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                WrapContents = false
            };

            // Opciones del Administrador
            if (rolUsuario == "Administrador")
            {
                menu.Controls.Add(CrearBoton("Gestión de usuarios", cBtnUsuarios_Click));
                menu.Controls.Add(CrearBoton("Permisos y roles", BtnPermisos_Click));
                menu.Controls.Add(CrearBoton("Reportes estadísticos", BtnReportes_Click));
                menu.Controls.Add(CrearBoton("Configuración del sistema", BtnConfig_Click));
                menu.Controls.Add(CrearBoton("Auditoría de accesos", BtnAuditoria_Click));
            }

            // Opciones del Médico
            if (rolUsuario == "Medico")
            {
                menu.Controls.Add(CrearBoton("Agenda de turnos", BtnAgenda_Click));
                menu.Controls.Add(CrearBoton("Historia clínica", BtnHistoria_Click));
                menu.Controls.Add(CrearBoton("Recetas y órdenes", BtnRecetas_Click));
                menu.Controls.Add(CrearBoton("Estudios y resultados", BtnEstudios_Click));
                menu.Controls.Add(CrearBoton("Evoluciones", BtnEvoluciones_Click));
            }

            // Opciones de la Secretaria
            if (rolUsuario == "Secretaria")
            {
                menu.Controls.Add(CrearBoton("Gestión de turnos", BtnTurnos_Click));
                menu.Controls.Add(CrearBoton("Registro de pacientes", BtnPacientes_Click));
                menu.Controls.Add(CrearBoton("Búsqueda de pacientes", BtnBusqueda_Click));
                menu.Controls.Add(CrearBoton("Impresión de comprobantes", BtnImpresion_Click));
                menu.Controls.Add(CrearBoton("Notificaciones", BtnNotificaciones_Click));
            }

            panel1.Controls.Add(menu);
        }

        // Método auxiliar para crear botones con estilo
        private Button CrearBoton(string texto, EventHandler eventoClick)
        {
            Button btn = new Button
            {
                Text = texto,
                Width = panel1.Width - 10,
                Height = 40,
                Margin = new Padding(5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightSteelBlue
            };
            btn.Click += eventoClick;
            return btn;
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gestión de usuarios");
        }

        private void BtnPermisos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Permisos y roles");
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reportes estadísticos");
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Configuración del sistema");
        }

        private void BtnAuditoria_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Auditoría de accesos");
        }

        private void BtnAgenda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agenda de turnos");
        }

        private void BtnHistoria_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Historia clínica");
        }

        private void BtnRecetas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recetas y órdenes");
        }

        private void BtnEstudios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Estudios y resultados");
        }

        private void BtnEvoluciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Evoluciones médicas");
        }

        private void BtnTurnos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gestión de turnos");
        }

        private void BtnPacientes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registro de pacientes");
        }

        private void BtnBusqueda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Búsqueda de pacientes");
        }

        private void BtnImpresion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Impresión de comprobantes");
        }

        private void BtnNotificaciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notificaciones a pacientes");
        }

        private void cBtnUsuarios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gestión de usuarios");
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has hecho clic en el botón de ejemplo.");
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has hecho clic en el botón de opciones");
        }
    }
}

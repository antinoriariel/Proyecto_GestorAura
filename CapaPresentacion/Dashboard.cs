using System;
using System.Windows.Forms;
using CapaPresentacion.Controles;
using CapaPresentacion.Formularios;

namespace CapaPresentacion
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            // MDI
            this.IsMdiContainer = true;

            // Cargar menú lateral
            var menuLateral = new MenuLateral
            {
                Dock = DockStyle.Fill
            };

            menuLateral.BtnPacientesClick += (s, e) =>
            {
                FormPacientes form = new FormPacientes();
                form.MdiParent = this;
                form.FormBorderStyle = FormBorderStyle.None;
                form.ControlBox = false;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Text = "";
                form.Dock = DockStyle.Fill;
                form.Show();
            };

            menuLateral.BtnTurnosClick += (s, e) =>
            {
                FormTurnos form = new FormTurnos();
                form.MdiParent = this;
                form.FormBorderStyle = FormBorderStyle.None;
                form.ControlBox = false;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Text = "";
                form.Dock = DockStyle.Fill;
                form.Show();
            };

            menuLateral.BtnHistoriasClick += (s, e) =>
            {
                FormHC form = new FormHC();
                form.MdiParent = this;
                form.FormBorderStyle = FormBorderStyle.None;
                form.ControlBox = false;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Text = "";
                form.Dock = DockStyle.Fill;
                form.Show();
            };

            menuLateral.BtnCerrarSesionClick += (s, e) =>
            {
                Application.Exit();
            };

            panelMenu.Controls.Add(menuLateral);
        }
    }
}

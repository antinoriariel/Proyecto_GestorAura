using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormMedicos : Form
    {
        public FormMedicos()
        {
            InitializeComponent();

            // Eventos de botones
            btnAgregar.Click += (s, e) => MessageBox.Show("➕ Agregar médico");
            btnModificar.Click += (s, e) => MessageBox.Show("✏️ Modificar médico seleccionado");
            btnEliminar.Click += (s, e) => MessageBox.Show("🗑️ Eliminar médico seleccionado");
            btnInactivar.Click += (s, e) => MessageBox.Show("🚫 Inactivar médico seleccionado");

            // Escape cierra formulario
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) this.Close();
            };
        }
    }
}

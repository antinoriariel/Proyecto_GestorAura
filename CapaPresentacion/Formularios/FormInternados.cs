using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormInternados : Form
    {
        private readonly PacienteNegocio _pacienteNegocio = new();

        public FormInternados()
        {
            InitializeComponent();
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            try
            {
                // Traemos todos los pacientes (activos e inactivos)
                var lista = _pacienteNegocio.ObtenerPacientes();

                // Ordenamos por Apellido, Nombre
                var ordenada = lista
                    .OrderBy(p => p.Apellido)
                    .ThenBy(p => p.Nombre)
                    .ToList();

                dgvPacientes.DataSource = null;
                dgvPacientes.DataSource = ordenada;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar los pacientes:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarPacientes();
        }

        // Ajustamos algunas columnas cuando termina el binding
        private void dgvPacientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvPacientes.Columns.Contains("IdPaciente"))
                dgvPacientes.Columns["IdPaciente"].Visible = false;

            if (dgvPacientes.Columns.Contains("FechaAlta"))
                dgvPacientes.Columns["FechaAlta"].HeaderText = "Fecha alta";

            if (dgvPacientes.Columns.Contains("FechaNac"))
                dgvPacientes.Columns["FechaNac"].HeaderText = "F. Nacimiento";

            // Hacemos que la columna de alergias ocupe el espacio restante
            if (dgvPacientes.Columns.Contains("Alergias"))
                dgvPacientes.Columns["Alergias"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}

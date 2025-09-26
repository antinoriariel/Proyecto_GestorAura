using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormInternados : Form
    {
        public FormInternados()
        {
            InitializeComponent();
            ConfigurarGrilla();
            CargarDatosDummy();
        }

        private void ConfigurarGrilla()
        {
            dgvCamas.Columns.Clear();

            dgvCamas.Columns.Add("NroCama", "N° Cama");
            dgvCamas.Columns.Add("Paciente", "Paciente");
            dgvCamas.Columns.Add("Estado", "Estado");
            dgvCamas.Columns.Add("Ingreso", "Fecha Ingreso");
            dgvCamas.Columns.Add("Area", "Área");

            dgvCamas.Columns["NroCama"].Width = 80;
            dgvCamas.Columns["Estado"].Width = 100;
            dgvCamas.Columns["Ingreso"].Width = 150;
        }

        private void CargarDatosDummy()
        {
            dgvCamas.Rows.Clear();

            dgvCamas.Rows.Add("101", "Juan Pérez", "Ocupada", DateTime.Today.AddDays(-2).ToShortDateString(), "Clínica Médica");
            dgvCamas.Rows.Add("102", "Libre", "Disponible", "-", "Clínica Médica");
            dgvCamas.Rows.Add("201", "María Gómez", "Ocupada", DateTime.Today.AddDays(-5).ToShortDateString(), "Cirugía");
            dgvCamas.Rows.Add("202", "Libre", "Disponible", "-", "Cirugía");
            dgvCamas.Rows.Add("301", "Pedro Ruiz", "Ocupada", DateTime.Today.AddDays(-1).ToShortDateString(), "UTI");
        }
    }
}

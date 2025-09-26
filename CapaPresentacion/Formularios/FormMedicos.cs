using System;
using System.Data;
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

            // 🔹 Cargar listado de médicos al iniciar
            CargarMedicos();
        }

        private void CargarMedicos()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Apellido");
            tabla.Columns.Add("Especialidad");
            tabla.Columns.Add("Matrícula");

            // Hardcodeamos varios médicos
            tabla.Rows.Add("Carlos", "Pérez", "Cardiología", "MP12345");
            tabla.Rows.Add("Ana", "Gómez", "Clínica Médica", "MP54321");
            tabla.Rows.Add("Juan", "Martínez", "Pediatría", "MP67890");
            tabla.Rows.Add("María", "Fernández", "Dermatología", "MP98765");
            tabla.Rows.Add("Lucía", "Rodríguez", "Neurología", "MP11223");
            tabla.Rows.Add("Pedro", "López", "Traumatología", "MP33445");
            tabla.Rows.Add("Sofía", "Sánchez", "Oftalmología", "MP55667");
            tabla.Rows.Add("Diego", "Ramírez", "Gastroenterología", "MP77889");
            tabla.Rows.Add("Valeria", "Morales", "Endocrinología", "MP99112");
            tabla.Rows.Add("Javier", "Torres", "Nefrología", "MP22334");
            tabla.Rows.Add("Paula", "Cabrera", "Ginecología", "MP44556");
            tabla.Rows.Add("Andrés", "Domínguez", "Oncología", "MP66778");
            tabla.Rows.Add("Camila", "Rivas", "Otorrinolaringología", "MP88990");
            tabla.Rows.Add("Martín", "Silva", "Reumatología", "MP10112");
            tabla.Rows.Add("Florencia", "Vega", "Psiquiatría", "MP13141");

            // Asignamos al DataGridView
            dgvMedicos.DataSource = tabla;
        }
    }
}

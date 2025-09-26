using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion.Formularios
{
    public partial class InicioMedico : Form
    {
        public InicioMedico()
        {
            InitializeComponent();
            Load += InicioMedico_Load;
        }

        private void InicioMedico_Load(object? sender, EventArgs e)
        {
            // ===== Datos hardcodeados (demo) =====
            lblUsuario.Text = "Dr. Juan Pérez";
            lblEspecialidad.Text = "Especialidad: Clínica Médica";
            lblMatricula.Text = "Matrícula: Prov. 12.345 | Nac. 67.890";
            lblEstadoServidor.Text = "Servidor: OK";

            // ===== Gráfico: turnos por día (demo) =====
            var serie = chartTurnos.Series["Turnos"];
            serie.Points.Clear();

            var dias = new[] { "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb" };
            var valores = new[] { 12, 15, 10, 18, 14, 6 };
            for (int i = 0; i < dias.Length; i++)
                serie.Points.AddXY(dias[i], valores[i]);

            chartTurnos.Titles.Add("Turnos de la semana");
            chartTurnos.Titles[0].Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // ===== Tabla: pacientes recientes (demo) =====
            dgvPacientesRecientes.Columns.Clear();
            dgvPacientesRecientes.DataSource = CrearTablaPacientesDemo();

            // Ajustes finos de estilo
            dgvPacientesRecientes.Columns["Paciente"].FillWeight = 200;
            dgvPacientesRecientes.Columns["DNI"].FillWeight = 80;
            dgvPacientesRecientes.Columns["Motivo"].FillWeight = 160;
            dgvPacientesRecientes.Columns["FechaHora"].FillWeight = 120;
            dgvPacientesRecientes.Columns["Estado"].FillWeight = 90;
        }

        private static DataTable CrearTablaPacientesDemo()
        {
            var dt = new DataTable();
            dt.Columns.Add("Paciente");
            dt.Columns.Add("DNI");
            dt.Columns.Add("Motivo");
            dt.Columns.Add("FechaHora");
            dt.Columns.Add("Estado");

            dt.Rows.Add("García, Laura", "28.456.789", "Control posoperatorio", "26/09 08:30", "Finalizado");
            dt.Rows.Add("Suárez, Martín", "32.112.334", "HTA descompensada", "26/09 09:00", "En curso");
            dt.Rows.Add("López, Daniela", "41.556.120", "Resultados de laboratorio", "26/09 09:30", "Pendiente");
            dt.Rows.Add("Ríos, Agustín", "27.889.004", "Dolor torácico", "26/09 10:15", "Finalizado");
            dt.Rows.Add("Ruiz, Camila", "45.112.778", "Control clínico", "26/09 11:00", "Pendiente");
            dt.Rows.Add("Fernández, Pablo", "33.987.654", "Chequeo general", "26/09 11:30", "Finalizado");
            dt.Rows.Add("Martínez, Sofía", "29.443.221", "Consulta por cefalea", "26/09 12:00", "En curso");
            dt.Rows.Add("Ramírez, Nicolás", "40.221.876", "Control de glucemia", "26/09 12:30", "Pendiente");
            dt.Rows.Add("Torres, Julieta", "36.778.990", "Examen prequirúrgico", "26/09 13:00", "Finalizado");
            dt.Rows.Add("Vega, Manuel", "31.456.112", "Control de presión arterial", "26/09 13:30", "Pendiente");
            dt.Rows.Add("Sosa, Valentina", "44.569.001", "Chequeo pediátrico", "26/09 14:00", "En curso");
            dt.Rows.Add("Domínguez, Javier", "27.003.456", "Revisión de estudios", "26/09 14:30", "Finalizado");
            dt.Rows.Add("Alonso, Micaela", "35.671.223", "Consulta ginecológica", "26/09 15:00", "Pendiente");
            dt.Rows.Add("Moreno, Esteban", "42.998.110", "Control postvacuna", "26/09 15:30", "Finalizado");
            dt.Rows.Add("Pereyra, Lucía", "39.114.578", "Consulta por dolor lumbar", "26/09 16:00", "En curso");


            return dt;
        }
    }
}

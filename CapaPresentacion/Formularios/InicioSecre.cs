using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class InicioSecre : Form
    {
        private readonly UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        public string NombreUsuario { get; set; } = string.Empty;
        public string RolUsuario { get; set; } = "Secretaria";

        public InicioSecre()
        {
            InitializeComponent();
            Load += InicioSecre_Load;
        }

        private void InicioSecre_Load(object? sender, EventArgs e)
        {
            // === Datos desde la BD ===
            try
            {
                DataTable dt = usuarioNegocio.ObtenerDatosSecretaria(NombreUsuario);
                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];
                    lblUsuario.Text = $"{r["nombre"]} {r["apellido"]}";
                    lblRolValor.Text = r["rol"].ToString();
                    lblEmailValor.Text = r["email"].ToString();
                }
                else
                {
                    lblUsuario.Text = "<usuario no encontrado>";
                    lblRolValor.Text = RolUsuario;
                    lblEmailValor.Text = "—";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos del usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // === Información general ===
            lblVersion.Text = "GestorAura v1.0";
            lblEstadoServidor.Text = "🟢 Servidor activo";
            lblFraseMotivacional.Text =
                $"📅 Hoy es {DateTime.Now:dddd, dd MMMM yyyy} - \"La organización es la clave del éxito\"";

            // === Gráfico de ejemplo ===
            var serie = chartAgenda.Series["Turnos"];
            serie.Points.Clear();
            var horas = new[] { "08:00", "09:00", "10:00", "11:00", "12:00", "14:00", "15:00", "16:00" };
            var valores = new[] { 2, 3, 1, 3, 1, 2, 1, 1 };
            for (int i = 0; i < horas.Length; i++)
                serie.Points.AddXY(horas[i], valores[i]);

            chartAgenda.Titles.Clear();
            chartAgenda.Titles.Add("Distribución de turnos del día");
            chartAgenda.Titles[0].Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // === Tabla de turnos demo ===
            dgvTurnos.DataSource = CrearTablaTurnosDemo();
        }

        private static DataTable CrearTablaTurnosDemo()
        {
            var dt = new DataTable();
            dt.Columns.Add("Paciente");
            dt.Columns.Add("Médico");
            dt.Columns.Add("Hora");
            dt.Columns.Add("Motivo");
            dt.Columns.Add("Estado");

            dt.Rows.Add("García, Laura", "Dr. Pérez", "08:30", "Control", "Pendiente");
            dt.Rows.Add("Suárez, Martín", "Dra. Gómez", "09:00", "HTA", "Pendiente");
            dt.Rows.Add("López, Daniela", "Dr. Pérez", "09:30", "Laboratorio", "Pendiente");
            dt.Rows.Add("Ríos, Agustín", "Dr. Fernández", "10:15", "Dolor torácico", "Pendiente");
            dt.Rows.Add("Ruiz, Camila", "Dra. Gómez", "11:00", "Control clínico", "En curso");
            dt.Rows.Add("Fernández, Pablo", "Dr. Pérez", "11:30", "Chequeo", "En curso");
            dt.Rows.Add("Martínez, Sofía", "Dr. Fernández", "12:00", "Cefalea", "Pendiente");
            dt.Rows.Add("Ramírez, Nicolás", "Dr. Pérez", "14:00", "Glucemia", "Pendiente");
            dt.Rows.Add("Torres, Julieta", "Dra. Gómez", "15:00", "Prequirúrgico", "Pendiente");
            dt.Rows.Add("Vega, Manuel", "Dr. Fernández", "16:00", "Presión arterial", "Pendiente");

            return dt;
        }
    }
}

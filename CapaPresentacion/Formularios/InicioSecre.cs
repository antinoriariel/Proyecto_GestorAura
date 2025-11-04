using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
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
                $"📅 Hoy es {DateTime.Now:dddd, dd MMMM yyyy}  -  \"La organización es la clave del éxito\"";

            // === ComboBox médicos ===
            cmbMedicos.Items.AddRange(new string[] { "Dr. Pérez", "Dra. Gómez", "Dr. Fernández" });
            cmbMedicos.SelectedIndex = 0;

            // === Celdas interactivas ===
            foreach (Control c in tblCalendario.Controls)
            {
                if (c is Label lbl && lbl.Tag?.ToString() == "slot")
                {
                    lbl.Cursor = Cursors.Hand;
                    lbl.Click += LblSlot_Click;
                }
            }

            // === Tabla de turnos demo ===
            dgvTurnos.DataSource = CrearTablaTurnosDemo();
        }

        private void LblSlot_Click(object? sender, EventArgs e)
        {
            if (sender is not Label lbl) return;

            if (lbl.Text == "Ocupado")
            {
                var result = MessageBox.Show(
                    "Seleccione una acción para este turno:\n\n- Cambiar estado a Libre\n- Asignar a otro paciente",
                    "Turno ocupado",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button3);

                if (result == DialogResult.Yes)
                {
                    lbl.Text = "Libre";
                    lbl.BackColor = Color.FromArgb(224, 255, 224);
                }
                else if (result == DialogResult.No)
                {
                    string nuevo = Microsoft.VisualBasic.Interaction.InputBox(
                        "Ingrese el nombre del nuevo paciente:", "Reasignar turno", "Apellido, Nombre");
                    if (!string.IsNullOrWhiteSpace(nuevo))
                    {
                        lbl.Text = $"Asignado a\n{nuevo}";
                        lbl.BackColor = Color.FromArgb(255, 240, 200);
                    }
                }
            }
            else if (lbl.Text == "Libre")
            {
                var result = MessageBox.Show("¿Desea asignar este horario a un nuevo paciente?",
                    "Turno libre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string nuevo = Microsoft.VisualBasic.Interaction.InputBox(
                        "Ingrese el nombre del paciente:", "Nuevo turno", "Apellido, Nombre");
                    if (!string.IsNullOrWhiteSpace(nuevo))
                    {
                        lbl.Text = $"Asignado a\n{nuevo}";
                        lbl.BackColor = Color.FromArgb(255, 240, 200);
                    }
                }
            }
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

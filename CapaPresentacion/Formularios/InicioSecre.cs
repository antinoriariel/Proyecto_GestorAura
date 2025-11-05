using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class InicioSecre : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();
        private TurnosPanel _turnosPanel; // 👈 nuevo componente embebido

        public string NombreUsuario { get; set; } = string.Empty;
        public string RolUsuario { get; set; } = "Secretaria";

        public InicioSecre()
        {
            InitializeComponent();
            Load += OnFormLoad;
        }

        private void OnFormLoad(object? sender, EventArgs e)
        {
            CargarDatosSecretaria();
            MostrarInformacionGeneral();
            InicializarPanelTurnos(); // 👈 integrar TurnosPanel
        }

        private void CargarDatosSecretaria()
        {
            try
            {
                DataTable datos = _usuarioNegocio.ObtenerDatosSecretaria(NombreUsuario);
                if (datos.Rows.Count > 0)
                {
                    var fila = datos.Rows[0];
                    lblNombreSecretaria.Text = $"{fila["nombre"]} {fila["apellido"]}";
                    lblRolSecretaria.Text = fila["rol"].ToString();
                    lblEmailSecretaria.Text = fila["email"].ToString();
                }
                else
                {
                    lblNombreSecretaria.Text = "<usuario no encontrado>";
                    lblRolSecretaria.Text = RolUsuario;
                    lblEmailSecretaria.Text = "—";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos de la secretaria: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarInformacionGeneral()
        {
            lblVersionSistema.Text = "GestorAura v1.0";
            lblEstadoServidor.Text = "🟢 Servidor activo";
            lblFraseMotivacional.Text =
                $"📅 Hoy es {DateTime.Now:dddd, dd MMMM yyyy}  -  \"La organización es la clave del éxito\"";
        }

        /// <summary>
        /// Inicializa y agrega el panel de turnos en la parte inferior.
        /// </summary>
        private void InicializarPanelTurnos()
        {
            _turnosPanel = new TurnosPanel
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None
            };

            Panel contenedorTurnos = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(14, 10, 14, 10)
            };

            Label lblTituloTurnos = new Label
            {
                Text = "📅 Agenda de Turnos",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 57, 71),
                Padding = new Padding(0, 0, 0, 10),
                AutoSize = false,
                Height = 32
            };

            contenedorTurnos.Controls.Add(_turnosPanel);
            contenedorTurnos.Controls.Add(lblTituloTurnos);

            Controls.Add(contenedorTurnos);
            Controls.SetChildIndex(contenedorTurnos, 0); // lo coloca debajo del resto
            _turnosPanel.Show();
        }
    }
}

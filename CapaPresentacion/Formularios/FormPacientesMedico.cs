using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormPacientesMedico : Form
    {
        private readonly int _idMedico;
        private readonly string _nombreMedico;

        // Fuente de datos: en tu proyecto real vendrá de la CapaNegocio / CapaDatos
        private BindingList<PacienteVM> _pacientes = new BindingList<PacienteVM>();
        private readonly Color _ok = ColorTranslator.FromHtml("#93E29D");     // verde suave (ocupación libre style)
        private readonly Color _warn = ColorTranslator.FromHtml("#FFD18A");   // amarillo
        private readonly Color _bad = ColorTranslator.FromHtml("#EE8E8B");    // rojo suave (ocupado/alerta)

        public FormPacientesMedico()
        {
            InitializeComponent();
            //_idMedico = idMedico;
            //_nombreMedico = nombreMedico;

            lblHeader.Text = "Pacientes";
            lblSubtitulo.Text = $"Asignados a: {_nombreMedico}";

            dgvPacientes.AutoGenerateColumns = false;
            dgvPacientes.DataSource = _pacientes;

            cboFiltro.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            // Eventos
            txtBuscar.TextChanged += (_, __) => AplicarFiltros();
            cboFiltro.SelectedIndexChanged += (_, __) => AplicarFiltros();
            cboEstado.SelectedIndexChanged += (_, __) => AplicarFiltros();
            dgvPacientes.SelectionChanged += (_, __) => PintarDetalleActual();
            dgvPacientes.CellDoubleClick += (_, __) => btnVerHC.PerformClick();
        }

        private void FormPacientesMedico_Load(object sender, EventArgs e)
        {
            CargarPacientes();
        }

        private void CargarPacientes()
        {
            // TODO: Reemplazar por llamada real: PacienteNegocio.ListarPorMedico(_idMedico)
            var demo = new List<PacienteVM>
            {
                new PacienteVM{ PacienteId=1, DNI="30123456", Nombre="Juan Pérez", Edad=54, Sexo="M",
                    ObraSocial="OSDE", Internado=true, Cama="101", Riesgo="Alto", UltimaEvolucion=DateTime.Today.AddDays(-1) },

                new PacienteVM{ PacienteId=2, DNI="27888999", Nombre="Ana Torres", Edad=37, Sexo="F",
                    ObraSocial="PAMI", Internado=true, Cama="401", Riesgo="Medio", UltimaEvolucion=DateTime.Today.AddDays(-3) },

                new PacienteVM{ PacienteId=3, DNI="35666111", Nombre="Laura Rivas", Edad=62, Sexo="F",
                    ObraSocial="IOMA", Internado=true, Cama="602", Riesgo="Alto", UltimaEvolucion=DateTime.Today },

                new PacienteVM{ PacienteId=4, DNI="28976543", Nombre="Pedro Ruiz", Edad=45, Sexo="M",
                    ObraSocial="Swiss", Internado=false, Cama=null, Riesgo="Bajo", UltimaEvolucion=DateTime.Today.AddDays(-10) },

                new PacienteVM{ PacienteId=5, DNI="27888912", Nombre="María Gómez", Edad=51, Sexo="F",
                    ObraSocial="OSDE", Internado=true, Cama="201", Riesgo="Medio", UltimaEvolucion=DateTime.Today.AddDays(-2) },
            };

            _pacientes = new BindingList<PacienteVM>(demo.OrderBy(p => p.Nombre).ToList());
            dgvPacientes.DataSource = _pacientes;
            lblTotal.Text = $"Total: {_pacientes.Count}";
            if (_pacientes.Count > 0) dgvPacientes.Rows[0].Selected = true;
            PintarDetalleActual();
        }

        private void AplicarFiltros()
        {
            string q = (txtBuscar.Text ?? "").Trim().ToLowerInvariant();
            string campo = cboFiltro.SelectedItem?.ToString() ?? "Nombre";
            string estado = cboEstado.SelectedItem?.ToString() ?? "Todos";

            IEnumerable<PacienteVM> query = _pacientes;

            // Filtro texto
            if (!string.IsNullOrEmpty(q))
            {
                query = campo switch
                {
                    "DNI" => query.Where(p => p.DNI.ToLower().Contains(q)),
                    "Historia" => query.Where(p => p.PacienteId.ToString().Contains(q)),
                    _ => query.Where(p => p.Nombre.ToLower().Contains(q)),
                };
            }

            // Filtro estado
            query = estado switch
            {
                "Internados" => query.Where(p => p.Internado),
                "Ambulatorios" => query.Where(p => !p.Internado),
                _ => query
            };

            dgvPacientes.DataSource = new BindingList<PacienteVM>(query.ToList());
            lblTotal.Text = $"Total: {((BindingList<PacienteVM>)dgvPacientes.DataSource).Count}";
        }

        private PacienteVM? PacienteSeleccionado()
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is PacienteVM p) return p;
            return null;
        }

        private void PintarDetalleActual()
        {
            var p = PacienteSeleccionado();
            if (p == null)
            {
                LimpiarDetalle();
                return;
            }

            lblNom.Text = p.Nombre;
            lblDni.Text = p.DNI;
            lblEdadSexo.Text = $"{p.Edad} años · {p.Sexo}";
            lblOS.Text = p.ObraSocial;
            lblInternacion.Text = p.Internado ? $"Internado · Cama {p.Cama}" : "Ambulatorio";
            lblUltEvo.Text = p.UltimaEvolucion.ToString("dd/MM/yyyy");
            lblRiesgo.Text = p.Riesgo;

            // Badges de color
            pnlEstado.BackColor = p.Internado ? _bad : _ok;
            pnlRiesgo.BackColor = p.Riesgo switch
            {
                "Alto" => _bad,
                "Medio" => _warn,
                _ => _ok
            };

            // Habilitar acciones según contexto
            btnNuevaEvolucion.Enabled = true;
            btnIndicaciones.Enabled = true;
            btnSolicitarEstudios.Enabled = true;
            btnVerResultados.Enabled = true;
            btnInterconsulta.Enabled = true;
            btnImprimir.Enabled = true;
        }

        private void LimpiarDetalle()
        {
            lblNom.Text = "—";
            lblDni.Text = "—";
            lblEdadSexo.Text = "—";
            lblOS.Text = "—";
            lblInternacion.Text = "—";
            lblUltEvo.Text = "—";
            lblRiesgo.Text = "—";
            pnlEstado.BackColor = SystemColors.Control;
            pnlRiesgo.BackColor = SystemColors.Control;
            btnNuevaEvolucion.Enabled = false;
            btnIndicaciones.Enabled = false;
            btnSolicitarEstudios.Enabled = false;
            btnVerResultados.Enabled = false;
            btnInterconsulta.Enabled = false;
            btnImprimir.Enabled = false;
        }

        // ===== Acciones =====
        private void btnVerHC_Click(object sender, EventArgs e)
        {
            var p = PacienteSeleccionado(); if (p == null) return;
            // TODO: abrir FormHC con el paciente seleccionado (solo lectura cabecera, edición de evoluciones según permisos)
            // new FormHC(p.PacienteId, modo: "Medico").ShowDialog(this);
            MessageBox.Show($"Abrir Historia Clínica de {p.Nombre} (ID:{p.PacienteId})", "HC", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNuevaEvolucion_Click(object sender, EventArgs e)
        {
            var p = PacienteSeleccionado(); if (p == null) return;
            // TODO: FormEvolucionNueva(p.PacienteId, _idMedico).ShowDialog();
            MessageBox.Show($"Registrar evolución para {p.Nombre}", "Evolución", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnIndicaciones_Click(object sender, EventArgs e)
        {
            var p = PacienteSeleccionado(); if (p == null) return;
            // TODO: FormIndicaciones(p.PacienteId).ShowDialog();
            MessageBox.Show($"Indicar medicación/indicaciones para {p.Nombre}", "Indicaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSolicitarEstudios_Click(object sender, EventArgs e)
        {
            var p = PacienteSeleccionado(); if (p == null) return;
            // TODO: FormSolicitudEstudios(p.PacienteId).ShowDialog();
            MessageBox.Show($"Solicitar estudios para {p.Nombre}", "Estudios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVerResultados_Click(object sender, EventArgs e)
        {
            var p = PacienteSeleccionado(); if (p == null) return;
            // TODO: FormResultados(p.PacienteId).ShowDialog();
            MessageBox.Show($"Ver resultados de {p.Nombre}", "Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInterconsulta_Click(object sender, EventArgs e)
        {
            var p = PacienteSeleccionado(); if (p == null) return;
            // TODO: FormInterconsultaNueva(p.PacienteId, _idMedico).ShowDialog();
            MessageBox.Show($"Iniciar interconsulta para {p.Nombre}", "Interconsulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var p = PacienteSeleccionado(); if (p == null) return;
            // TODO: Generar PDF/impresión de resumen clínico
            MessageBox.Show($"Imprimir/Exportar resumen de {p.Nombre}", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CargarPacientes();
        private void btnLimpiar_Click(object sender, EventArgs e) { txtBuscar.Clear(); cboEstado.SelectedIndex = 0; cboFiltro.SelectedIndex = 0; }
        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }

    // ViewModel simple para la grilla (en tu solución real vendrá del DTO de la capa de negocio)
    public class PacienteVM
    {
        public int PacienteId { get; set; }
        public string DNI { get; set; } = "";
        public string Nombre { get; set; } = "";
        public int Edad { get; set; }
        public string Sexo { get; set; } = "";
        public string ObraSocial { get; set; } = "";
        public bool Internado { get; set; }
        public string? Cama { get; set; }
        public string Riesgo { get; set; } = "Bajo"; // Bajo/Medio/Alto
        public DateTime UltimaEvolucion { get; set; }

        // Para mostrar en grilla
        public string EstadoTxt => Internado ? $"Internado (Cama {Cama})" : "Ambulatorio";
    }
}

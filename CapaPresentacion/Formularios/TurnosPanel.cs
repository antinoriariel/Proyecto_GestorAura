using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class TurnosPanel : Form
    {
        private readonly TurnoNegocio _turnoNegocio = new TurnoNegocio();
        private DataTable _tablaTurnos = new();

        public TurnosPanel()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object? sender, EventArgs e)
        {
            CargarTurnos();
        }

        private void CargarTurnos()
        {
            try
            {
                _tablaTurnos = _turnoNegocio.ObtenerTurnos();
                dgvTurnos.DataSource = _tablaTurnos;
                ConfigurarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los turnos: " + ex.Message);
            }
        }

        private void ConfigurarGrilla()
        {
            dgvTurnos.Columns["id_turno"].HeaderText = "ID";
            dgvTurnos.Columns["fecha_turno"].HeaderText = "Fecha";
            dgvTurnos.Columns["hora_turno"].HeaderText = "Hora";
            dgvTurnos.Columns["paciente"].HeaderText = "Paciente";
            dgvTurnos.Columns["medico"].HeaderText = "Médico";
            dgvTurnos.Columns["estado"].HeaderText = "Estado";
            dgvTurnos.Columns["motivo"].HeaderText = "Motivo";
        }

        // === Botones CRUD ===
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new TurnoEditor(); // formulario de alta
            if (frm.ShowDialog() == DialogResult.OK)
                CargarTurnos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["id_turno"].Value);
            var frm = new TurnoEditor(id);
            if (frm.ShowDialog() == DialogResult.OK)
                CargarTurnos();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["id_turno"].Value);
            if (MessageBox.Show("¿Eliminar el turno seleccionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_turnoNegocio.EliminarTurno(id))
                {
                    MessageBox.Show("Turno eliminado correctamente.");
                    CargarTurnos();
                }
            }
        }
    }
}

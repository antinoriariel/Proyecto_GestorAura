using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormDashHC : Form
    {
        private readonly HistoriaClinicaNegocio _hcNegocio = new();
        private readonly PacienteNegocio _pacNegocio = new();

        private DataTable _tablaHistorias = new();
        private readonly int _idUsuarioActual;

        public FormDashHC(int idUsuarioActual)
        {
            InitializeComponent();
            _idUsuarioActual = idUsuarioActual;
        }

        private void FormDashHC_Load(object sender, EventArgs e)
        {
            BackColor = ColorTranslator.FromHtml("#eeeeee");
            ConfigurarControles();
            CargarPacientesCombo();
            CargarHistorias();
        }

        // ===============================================================
        // CONFIGURACIÓN DE GRILLA
        // ===============================================================
        private void ConfigurarControles()
        {
            dgvHistorias.EnableHeadersVisualStyles = false;
            dgvHistorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorias.ReadOnly = true;
            dgvHistorias.MultiSelect = false;
            dgvHistorias.RowHeadersVisible = false;

            dgvHistorias.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0088cc");
            dgvHistorias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorias.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#d0ebff");
            dgvHistorias.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        // ===============================================================
        // CARGA DE PACIENTES Y DATOS
        // ===============================================================
        private void CargarPacientesCombo()
        {
            var dt = _pacNegocio.ObtenerListaSimple();
            cboPaciente.DataSource = dt;
            cboPaciente.DisplayMember = "apellido";
            cboPaciente.ValueMember = "id_paciente";
            cboPaciente.SelectedIndex = -1;
        }

        private void CargarHistorias()
        {
            int? idPaciente = cboPaciente.SelectedIndex >= 0 ? (int?)cboPaciente.SelectedValue : null;
            DateTime? desde = chkFiltrarFecha.Checked ? dtpDesde.Value.Date : null;
            DateTime? hasta = chkFiltrarFecha.Checked ? dtpHasta.Value.Date : null;

            _tablaHistorias = _hcNegocio.ObtenerHistoriasDetalladas(idPaciente, desde, hasta);
            dgvHistorias.DataSource = _tablaHistorias;
        }

        // ===============================================================
        // BOTONES
        // ===============================================================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvHistorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una historia clínica para editar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔹 Obtener el id_paciente directamente de la fila seleccionada
            DataRowView drv = dgvHistorias.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null)
            {
                MessageBox.Show("No se pudo obtener el paciente asociado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idPaciente = Convert.ToInt32(drv["id_paciente"]);
            int idUsuarioActual = _idUsuarioActual;

            using (FormEditarHC form = new(idUsuarioActual, idPaciente))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }

            CargarHistorias();
        }




        private void btnAdjuntos_Click(object sender, EventArgs e)
        {
            if (dgvHistorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una historia clínica para ver los archivos adjuntos.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Obtener el DataRow subyacente, incluso si la columna está oculta
            DataRowView drv = dgvHistorias.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null)
            {
                MessageBox.Show("No se pudo obtener la información del paciente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idPaciente = Convert.ToInt32(drv["id_paciente"]);

            // Abrir el formulario de adjuntos pasando usuario + paciente
            using (FormAdjuntosPaciente form = new(_idUsuarioActual, idPaciente))
            {
                form.ShowDialog();
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dgvHistorias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una historia clínica para exportar.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idHistoria = Convert.ToInt32(dgvHistorias.CurrentRow.Cells["id_historia"].Value);
            string nombrePaciente = dgvHistorias.CurrentRow.Cells["paciente"].Value.ToString();

            SaveFileDialog sfd = new()
            {
                Filter = "Archivo PDF|*.pdf",
                FileName = $"Historia_{nombrePaciente}_{DateTime.Now:yyyyMMdd}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _hcNegocio.ExportarHistoriaClinicaPDF(idHistoria, sfd.FileName);
                MessageBox.Show("PDF exportado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo(sfd.FileName)
                {
                    UseShellExecute = true
                });
            }
        }
    }
}

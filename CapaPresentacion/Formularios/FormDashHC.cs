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

        public FormDashHC()
        {
            InitializeComponent();
        }

        private void FormDashHC_Load(object sender, EventArgs e)
        {
            BackColor = ColorTranslator.FromHtml("#eeeeee");
            ConfigurarControles();
            CargarPacientesCombo();
            CargarHistorias();
        }

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarHistorias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvHistorias.CurrentRow == null) return;

            int idHistoria = Convert.ToInt32(dgvHistorias.CurrentRow.Cells["id_historia"].Value);
            //FormHC form = new(idHistoria);
            //form.ShowDialog();
            CargarHistorias();
        }

        private void btnAdjuntos_Click(object sender, EventArgs e)
        {
            if (dgvHistorias.CurrentRow == null) return;

            int idPaciente = Convert.ToInt32(dgvHistorias.CurrentRow.Cells["id_paciente"].Value);
            FormAdjuntosPaciente form = new(idPaciente);
            form.ShowDialog();
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dgvHistorias.CurrentRow == null) return;

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
                Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
        }
    }
}

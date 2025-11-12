using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormEditarHC : Form
    {
        private readonly HistoriaClinicaNegocio _hcNegocio = new();
        private readonly PacienteNegocio _pacNegocio = new();
        private readonly ErrorProvider _ep = new();

        private int _idUsuarioActual;
        private int _idPaciente;
        private int _idHistoriaSeleccionada;

        private DataGridView dgvHistorias;
        private TextBox txtMotivo, txtImpresion, txtDiagnostico, txtIndicaciones, txtAntecedentes, txtObservaciones;
        private ComboBox cboEstado, cboTipoConsulta;
        private DateTimePicker dtpFechaHora;
        private Button btnGuardar, btnCancelar;
        private Label lblPaciente;

        public FormEditarHC(int idUsuarioActual, int idPaciente)
        {
            _idUsuarioActual = idUsuarioActual;
            _idPaciente = idPaciente;

            InitializeComponent();
            ConfigurarFormulario();
            CargarHistoriasPaciente();
        }

        private void ConfigurarFormulario()
        {
            Text = "Editar Historia Clínica";
            Font = new Font("Consolas", 10);
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1080, 720);
            BackColor = ColorTranslator.FromHtml("#eeeeee");

            _ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // === Etiqueta paciente ===
            lblPaciente = new Label
            {
                Text = ObtenerNombrePaciente(),
                Font = new Font("Consolas", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 15)
            };
            Controls.Add(lblPaciente);

            // === Grilla de historias ===
            dgvHistorias = new DataGridView
            {
                Location = new Point(20, 50),
                Size = new Size(1020, 200),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White
            };
            dgvHistorias.SelectionChanged += DgvHistorias_SelectionChanged;
            Controls.Add(dgvHistorias);

            int y = 270;

            // === Campos ===
            txtMotivo = CrearTextBox("Motivo", 20, ref y);
            dtpFechaHora = new DateTimePicker { Location = new Point(20, y), Width = 250, Font = new Font("Consolas", 10) };
            Controls.Add(dtpFechaHora);
            y += 40;

            txtImpresion = CrearTextBox("Impresión diagnóstica", 20, ref y);
            txtDiagnostico = CrearTextBox("Diagnóstico", 20, ref y);
            txtIndicaciones = CrearTextBox("Indicaciones", 20, ref y);
            txtAntecedentes = CrearTextBox("Antecedentes", 20, ref y);
            txtObservaciones = CrearTextBox("Observaciones", 20, ref y);

            // === ComboBoxes ===
            cboEstado = new ComboBox
            {
                Location = new Point(600, 270),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Consolas", 10)
            };
            cboEstado.Items.AddRange(new[] { "abierta", "cerrada", "archivada" });
            cboEstado.SelectedIndex = 0;
            Controls.Add(cboEstado);

            cboTipoConsulta = new ComboBox
            {
                Location = new Point(820, 270),
                Width = 220,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Consolas", 10)
            };
            cboTipoConsulta.Items.AddRange(new[] { "consulta", "control", "urgencia" });
            cboTipoConsulta.SelectedIndex = 0;
            Controls.Add(cboTipoConsulta);

            // === Botones ===
            btnGuardar = new Button
            {
                Text = "💾 Guardar Cambios",
                Font = new Font("Consolas", 10, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#0088cc"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(700, 640),
                Size = new Size(160, 35)
            };
            btnGuardar.Click += BtnGuardar_Click;
            Controls.Add(btnGuardar);

            btnCancelar = new Button
            {
                Text = "Cancelar",
                Font = new Font("Consolas", 10),
                BackColor = ColorTranslator.FromHtml("#666666"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(870, 640),
                Size = new Size(120, 35)
            };
            btnCancelar.Click += (s, e) => Close();
            Controls.Add(btnCancelar);
        }

        private TextBox CrearTextBox(string placeholder, int x, ref int y)
        {
            Label lbl = new Label
            {
                Text = placeholder,
                Location = new Point(x, y),
                Font = new Font("Consolas", 10, FontStyle.Bold),
                AutoSize = true
            };
            Controls.Add(lbl);
            y += 20;

            TextBox txt = new TextBox
            {
                Location = new Point(x, y),
                Width = 500,
                Font = new Font("Consolas", 10)
            };
            Controls.Add(txt);
            y += 40;
            return txt;
        }

        private string ObtenerNombrePaciente()
        {
            try
            {
                var dt = _pacNegocio.ObtenerPacientePorId(_idPaciente);
                if (dt != null && dt.Rows.Count > 0)
                    return $"Paciente: {dt.Rows[0]["nombre"]} {dt.Rows[0]["apellido"]}";
            }
            catch { }
            return "Paciente desconocido";
        }

        private void CargarHistoriasPaciente()
        {
            try
            {
                var historias = _hcNegocio.ObtenerHistoriasPorPaciente(_idPaciente);
                dgvHistorias.DataSource = historias;
                /*if (historias != null && historias.Rows.Count > 0)
                {
                    dgvHistorias.Columns["id_historia"].Visible = false;
                    dgvHistorias.Columns["diagnostico"].Width = 300;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando historias:\n" + ex.Message);
            }
        }

        private void DgvHistorias_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvHistorias.SelectedRows.Count == 0) return;

            DataGridViewRow row = dgvHistorias.SelectedRows[0];

            _idHistoriaSeleccionada = Convert.ToInt32(row.Cells["id_historia"].Value);

            txtMotivo.Text = Convert.ToString(row.Cells["mdc"].Value);
            txtImpresion.Text = Convert.ToString(row.Cells["impresion_diagnostica"].Value);
            txtDiagnostico.Text = Convert.ToString(row.Cells["diagnostico"].Value);
            txtIndicaciones.Text = Convert.ToString(row.Cells["indicaciones"].Value);
            txtAntecedentes.Text = Convert.ToString(row.Cells["antecedentes_patologicos"].Value);
            txtObservaciones.Text = Convert.ToString(row.Cells["evolucion"].Value);

            cboEstado.Text = Convert.ToString(row.Cells["estado"].Value);
            cboTipoConsulta.Text = Convert.ToString(row.Cells["tipo_consulta"].Value);

            if (DateTime.TryParse(Convert.ToString(row.Cells["fecha_hora"].Value), out DateTime fecha))
                dtpFechaHora.Value = fecha;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (_idHistoriaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una historia clínica para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool ok = _hcNegocio.ActualizarHistoriaClinica(
                    _idHistoriaSeleccionada,
                    cboEstado.Text,
                    txtMotivo.Text,
                    dtpFechaHora.Value,
                    txtImpresion.Text,
                    txtDiagnostico.Text,
                    txtIndicaciones.Text,
                    txtAntecedentes.Text,
                    txtObservaciones.Text,
                    cboTipoConsulta.Text,
                    _idUsuarioActual
                );

                if (ok)
                {
                    MessageBox.Show("Historia clínica actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarHistoriasPaciente();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la historia clínica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

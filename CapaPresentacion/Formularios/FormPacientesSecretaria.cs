using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormPacientesSecretaria : Form
    {
        private readonly PacienteNegocio pacienteNegocio = new();
        private BindingList<Paciente> pacientes = new();
        private readonly BindingSource bsPacientes = new();

        public FormPacientesSecretaria()
        {
            InitializeComponent();
            AplicarEstilo();
            ConfigurarGrilla();
            CargarCombos();

            btnBuscar.Click += (_, __) => AplicarFiltro();
            btnQuitarFiltro.Click += (_, __) => { txtBuscar.Clear(); AplicarFiltro(); };
            chkSoloActivos.CheckedChanged += (_, __) => CargarPacientes(chkSoloActivos.Checked);

            btnNuevo.Click += (_, __) => LimpiarFormulario(true);
            btnGuardar.Click += (_, __) => Guardar();
            btnActualizar.Click += (_, __) => Actualizar();
            btnEliminar.Click += (_, __) => DarDeBaja();
            btnLimpiar.Click += (_, __) => LimpiarFormulario();

            dgvPacientes.CellDoubleClick += (_, __) => CargarDesdeSeleccion();
            ctxVerFicha.Click += (_, __) => CargarDesdeSeleccion();
            ctxDarDeBaja.Click += (_, __) => DarDeBaja();
            ctxReactivar.Click += (_, __) => Reactivar();

            Load += (_, __) => CargarPacientes(true);
        }

        private void AplicarEstilo()
        {
            var accent = ColorTranslator.FromHtml("#0088cc");
            dgvPacientes.EnableHeadersVisualStyles = false;
            dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPacientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvPacientes.RowHeadersVisible = false;
            dgvPacientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
            dgvPacientes.DefaultCellStyle.SelectionBackColor = accent;
            dgvPacientes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPacientes.GridColor = Color.FromArgb(230, 230, 230);
        }

        private void ConfigurarGrilla()
        {
            dgvPacientes.AutoGenerateColumns = false;
            dgvPacientes.Columns.Clear();
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "DNI", DataPropertyName = nameof(Paciente.Dni), FillWeight = 90 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = nameof(Paciente.Nombre), FillWeight = 120 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Apellido", DataPropertyName = nameof(Paciente.Apellido), FillWeight = 120 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sexo", DataPropertyName = nameof(Paciente.Sexo), FillWeight = 50 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha Nac.", DataPropertyName = nameof(Paciente.FechaNac), FillWeight = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teléfono", DataPropertyName = nameof(Paciente.Telefono), FillWeight = 110 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = nameof(Paciente.Email), FillWeight = 150 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Grupo Sanguíneo", DataPropertyName = nameof(Paciente.GrupoSanguineo), FillWeight = 80 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Alergias", DataPropertyName = nameof(Paciente.Alergias), FillWeight = 200 });
        }

        private void CargarCombos()
        {
            cboSexo.Items.AddRange(new[] { "H", "M" });
            cboSexo.SelectedIndex = 0;
            cboGrupo.Items.AddRange(new[] { "—", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });
            cboGrupo.SelectedIndex = 0;
        }

        private void CargarPacientes(bool soloActivos)
        {
            var lista = pacienteNegocio.ObtenerPacientes(soloActivos);
            pacientes = new BindingList<Paciente>(lista);
            bsPacientes.DataSource = pacientes;
            dgvPacientes.DataSource = bsPacientes;
        }

        private void Guardar()
        {
            try
            {
                var p = CapturarFormulario();
                pacienteNegocio.RegistrarPaciente(p);
                MessageBox.Show("Paciente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPacientes(chkSoloActivos.Checked);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Actualizar()
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not Paciente sel) return;
            try
            {
                var p = CapturarFormulario();
                p.IdPaciente = sel.IdPaciente;
                pacienteNegocio.ActualizarPaciente(p);
                MessageBox.Show("Datos actualizados correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPacientes(chkSoloActivos.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DarDeBaja()
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not Paciente sel) return;
            if (!sel.Activo)
            {
                MessageBox.Show("El paciente ya está dado de baja.");
                return;
            }
            if (MessageBox.Show($"¿Dar de baja a {sel.Apellido}, {sel.Nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pacienteNegocio.DarDeBaja(sel.IdPaciente);
                CargarPacientes(chkSoloActivos.Checked);
            }
        }

        private void Reactivar()
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not Paciente sel) return;
            pacienteNegocio.Reactivar(sel.IdPaciente);
            CargarPacientes(chkSoloActivos.Checked);
        }

        private void AplicarFiltro()
        {
            string q = txtBuscar.Text.Trim().ToLowerInvariant();
            var filtrados = pacientes.Where(p =>
                (p.Dni ?? "").ToLower().Contains(q) ||
                (p.Nombre ?? "").ToLower().Contains(q) ||
                (p.Apellido ?? "").ToLower().Contains(q)).ToList();
            bsPacientes.DataSource = new BindingList<Paciente>(filtrados);
        }

        private void CargarDesdeSeleccion()
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not Paciente p) return;
            txtDni.Text = p.Dni;
            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;
            cboSexo.SelectedItem = p.Sexo;
            dtpNacimiento.Value = p.FechaNac;
            txtTelefono.Text = p.Telefono;
            txtEmail.Text = p.Email;
            cboGrupo.SelectedItem = p.GrupoSanguineo;
            txtAlergias.Text = p.Alergias;
            chkActivo.Checked = p.Activo;
        }

        private void LimpiarFormulario(bool nuevo = false)
        {
            foreach (Control c in gbEdicion.Controls.OfType<TextBox>()) c.Text = string.Empty;
            txtAlergias.Clear();
            cboSexo.SelectedIndex = 0;
            cboGrupo.SelectedIndex = 0;
            chkActivo.Checked = true;
            dtpNacimiento.Value = new DateTime(1990, 1, 1);
            if (nuevo) txtDni.Focus();
        }

        private Paciente CapturarFormulario() => new()
        {
            Dni = txtDni.Text.Trim(),
            Nombre = txtNombre.Text.Trim(),
            Apellido = txtApellido.Text.Trim(),
            Sexo = cboSexo.Text,
            FechaNac = dtpNacimiento.Value.Date,
            Telefono = txtTelefono.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            GrupoSanguineo = cboGrupo.Text,
            Alergias = txtAlergias.Text.Trim(),
            Activo = chkActivo.Checked
        };
    }
}

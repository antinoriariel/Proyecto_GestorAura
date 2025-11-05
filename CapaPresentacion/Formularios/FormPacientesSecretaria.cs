using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormPacientesSecretaria : Form
    {
        // ---- Estado en memoria (simulación sin BD) ----
        private readonly BindingList<PacienteVm> _pacientes = new BindingList<PacienteVm>();
        private readonly BindingSource _bsPacientes = new BindingSource();

        public FormPacientesSecretaria()
        {
            InitializeComponent();

            // Estilo visual y grilla
            ApplyTheme();
            ConfigureGridSizing();

            // Combos base
            CargarCombos();

            // Eventos (todo desde el .cs para mantener limpio el Designer)
            btnBuscar.Click += (_, __) => AplicarFiltro();
            btnQuitarFiltro.Click += (_, __) => { txtBuscar.Clear(); AplicarFiltro(); };
            chkSoloActivos.CheckedChanged += (_, __) => AplicarFiltro();

            btnNuevo.Click += (_, __) => LimpiarFormulario(true);
            btnGuardar.Click += (_, __) => Guardar();
            btnActualizar.Click += (_, __) => Actualizar();
            btnEliminar.Click += (_, __) => BajaLogica();
            btnLimpiar.Click += (_, __) => LimpiarFormulario();
            btnAdjuntar.Click += (_, __) => MessageBox.Show("Stub: aquí adjuntarías documentos del paciente.", "Adjuntar");
            btnExportar.Click += (_, __) => MessageBox.Show("Stub: exportar a Excel (pendiente de capa de datos).", "Exportar");

            dgvPacientes.CellDoubleClick += (_, __) => CargarDesdeFilaActual();
            dgvPacientes.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.Handled = true; CargarDesdeFilaActual(); } };

            ctxVerFicha.Click += (_, __) => CargarDesdeFilaActual();
            ctxDarDeBaja.Click += (_, __) => BajaLogica();
            ctxReactivar.Click += (_, __) => Reactivar();

            // Data binding
            _bsPacientes.DataSource = _pacientes;
            dgvPacientes.DataSource = _bsPacientes;

            // Datos demo
            _pacientes.Add(new PacienteVm
            {
                PacienteId = Guid.NewGuid(),
                Dni = "30111222",
                Nombre = "Ana",
                Apellido = "Gómez",
                FechaNac = new DateTime(1992, 3, 14),
                Sexo = "Femenino",
                Telefono = "3794567890",
                Email = "ana.gomez@mail.com",
                Domicilio = "San Martín 123",
                ObraSocial = "IOSCOR",
                NroAfiliado = "A-123456",
                ContactoEmergencia = "María 3794441122",
                Notas = "Control de presión",
                Activo = true,
                FechaAlta = DateTime.Today
            });

            LimpiarFormulario();
            AplicarFiltro();
        }

        // =========================================================
        // Apariencia
        // =========================================================
        private void ApplyTheme()
        {
            // Teal consistente con tu app
            var teal = Color.FromArgb(0, 136, 122);

            // DataGridView look & feel
            dgvPacientes.EnableHeadersVisualStyles = false;
            dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPacientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvPacientes.RowHeadersVisible = false;
            dgvPacientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
            dgvPacientes.DefaultCellStyle.SelectionBackColor = teal;
            dgvPacientes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPacientes.GridColor = Color.FromArgb(230, 230, 230);
        }

        private void ConfigureGridSizing()
        {
            // Armado de columnas (coherente con el VM)
            dgvPacientes.AutoGenerateColumns = false;
            dgvPacientes.Columns.Clear();

            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "DNI", DataPropertyName = nameof(PacienteVm.Dni), FillWeight = 90 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = nameof(PacienteVm.Nombre), FillWeight = 120 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Apellido", DataPropertyName = nameof(PacienteVm.Apellido), FillWeight = 120 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha Nac.", DataPropertyName = nameof(PacienteVm.FechaNac), FillWeight = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sexo", DataPropertyName = nameof(PacienteVm.Sexo), FillWeight = 70 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teléfono", DataPropertyName = nameof(PacienteVm.Telefono), FillWeight = 110 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = nameof(PacienteVm.Email), FillWeight = 160 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Obra social", DataPropertyName = nameof(PacienteVm.ObraSocial), FillWeight = 110 });
            dgvPacientes.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Activo", DataPropertyName = nameof(PacienteVm.Activo), FillWeight = 60 });
            dgvPacientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Notas", DataPropertyName = nameof(PacienteVm.Notas), FillWeight = 200 });
        }

        private void CargarCombos()
        {
            cboSexo.Items.Clear();
            cboSexo.Items.AddRange(new[] { "Femenino", "Masculino", "Otro/Pref. no decir" });
            if (cboSexo.Items.Count > 0) cboSexo.SelectedIndex = 0;

            cboObraSocial.Items.Clear();
            cboObraSocial.Items.AddRange(new[] { "—", "IOSCOR", "PAMI", "OSDE", "Swiss Medical", "IOMA", "Galeno" });
            cboObraSocial.SelectedIndex = 0;
        }

        // =========================================================
        // Acciones CRUD
        // =========================================================
        private void Guardar()
        {
            var (ok, msj) = Validar();
            if (!ok) { MessageBox.Show(msj, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (_pacientes.Any(p => p.Dni == txtDni.Text.Trim()))
            {
                MessageBox.Show("Ya existe un paciente con ese DNI.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var vm = CapturarFormulario();
            vm.PacienteId = Guid.NewGuid();
            vm.FechaAlta = DateTime.Now;

            _pacientes.Add(vm);
            AplicarFiltro();
            SeleccionarEnGrilla(vm.PacienteId);

            MessageBox.Show("Paciente registrado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Actualizar()
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not PacienteVm sel)
            { MessageBox.Show("Seleccioná un paciente de la lista.", "Atención"); return; }

            var (ok, msj) = Validar(permitirDniExistente: sel.Dni);
            if (!ok) { MessageBox.Show(msj, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            sel.Dni = txtDni.Text.Trim();
            sel.Nombre = txtNombre.Text.Trim();
            sel.Apellido = txtApellido.Text.Trim();
            sel.FechaNac = dtpFechaNac.Value.Date;
            sel.Sexo = cboSexo.Text;
            sel.Telefono = txtTelefono.Text.Trim();
            sel.Email = txtEmail.Text.Trim();
            sel.Domicilio = txtDomicilio.Text.Trim();
            sel.ObraSocial = cboObraSocial.Text;
            sel.NroAfiliado = txtNroAfiliado.Text.Trim();
            sel.ContactoEmergencia = txtContactoEmergencia.Text.Trim();
            sel.Notas = txtNotas.Text;
            sel.Activo = chkActivo.Checked;

            _bsPacientes.ResetBindings(false);
            MessageBox.Show("Datos actualizados.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BajaLogica()
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not PacienteVm sel)
            { MessageBox.Show("Seleccioná un paciente.", "Atención"); return; }

            if (!sel.Activo)
            { MessageBox.Show("El paciente ya está dado de baja.", "Info"); return; }

            if (MessageBox.Show($"Dar de baja a {sel.Apellido}, {sel.Nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sel.Activo = false;
                _bsPacientes.ResetBindings(false);
                AplicarFiltro();
            }
        }

        private void Reactivar()
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not PacienteVm sel) return;
            sel.Activo = true;
            _bsPacientes.ResetBindings(false);
            AplicarFiltro();
        }

        // =========================================================
        // Helpers
        // =========================================================
        private void AplicarFiltro()
        {
            var q = txtBuscar.Text.Trim().ToLowerInvariant();
            var src = _pacientes.AsEnumerable();

            if (chkSoloActivos.Checked)
                src = src.Where(p => p.Activo);

            if (!string.IsNullOrEmpty(q))
                src = src.Where(p =>
                    (p.Dni ?? "").ToLower().Contains(q) ||
                    (p.Apellido ?? "").ToLower().Contains(q) ||
                    (p.Nombre ?? "").ToLower().Contains(q));

            _bsPacientes.DataSource = new BindingList<PacienteVm>(src.ToList());
            dgvPacientes.DataSource = _bsPacientes;
        }

        private void CargarDesdeFilaActual()
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not PacienteVm vm) return;

            txtDni.Text = vm.Dni;
            txtNombre.Text = vm.Nombre;
            txtApellido.Text = vm.Apellido;
            dtpFechaNac.Value = vm.FechaNac == default ? DateTime.Today : vm.FechaNac;
            cboSexo.SelectedItem = cboSexo.Items.Cast<object>().FirstOrDefault(i => i.ToString() == vm.Sexo) ?? (cboSexo.Items.Count > 0 ? cboSexo.Items[0] : null);
            txtTelefono.Text = vm.Telefono;
            txtEmail.Text = vm.Email;
            txtDomicilio.Text = vm.Domicilio;
            cboObraSocial.SelectedItem = cboObraSocial.Items.Cast<object>().FirstOrDefault(i => i.ToString() == vm.ObraSocial) ?? (cboObraSocial.Items.Count > 0 ? cboObraSocial.Items[0] : null);
            txtNroAfiliado.Text = vm.NroAfiliado;
            txtContactoEmergencia.Text = vm.ContactoEmergencia;
            txtNotas.Text = vm.Notas;
            chkActivo.Checked = vm.Activo;
        }

        private void LimpiarFormulario(bool prepararAlta = false)
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            dtpFechaNac.Value = new DateTime(1990, 1, 1);
            if (cboSexo.Items.Count > 0) cboSexo.SelectedIndex = 0;
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDomicilio.Clear();
            if (cboObraSocial.Items.Count > 0) cboObraSocial.SelectedIndex = 0;
            txtNroAfiliado.Clear();
            txtContactoEmergencia.Clear();
            txtNotas.Clear();
            chkActivo.Checked = true;

            if (prepararAlta) txtDni.Focus();
        }

        private PacienteVm CapturarFormulario()
        {
            return new PacienteVm
            {
                Dni = txtDni.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                FechaNac = dtpFechaNac.Value.Date,
                Sexo = cboSexo.Text,
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Domicilio = txtDomicilio.Text.Trim(),
                ObraSocial = cboObraSocial.Text,
                NroAfiliado = txtNroAfiliado.Text.Trim(),
                ContactoEmergencia = txtContactoEmergencia.Text.Trim(),
                Notas = txtNotas.Text,
                Activo = chkActivo.Checked
            };
        }

        private (bool ok, string msj) Validar(string permitirDniExistente = null)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text)) return (false, "El DNI es obligatorio.");
            if (!Regex.IsMatch(txtDni.Text.Trim(), @"^\d{7,9}$")) return (false, "DNI inválido (solo números, 7 a 9 dígitos).");
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) return (false, "El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) return (false, "El apellido es obligatorio.");
            if (dtpFechaNac.Value.Date >= DateTime.Today) return (false, "La fecha de nacimiento no puede ser futura.");
            if (cboSexo.SelectedIndex < 0) return (false, "Seleccioná el sexo.");
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return (false, "Email inválido.");

            var dni = txtDni.Text.Trim();
            if (permitirDniExistente == null && _pacientes.Any(p => p.Dni == dni))
                return (false, "DNI ya existente.");
            if (permitirDniExistente != null && _pacientes.Any(p => p.Dni == dni && p.Dni != permitirDniExistente))
                return (false, "Otro paciente ya usa ese DNI.");

            return (true, "");
        }

        private void SeleccionarEnGrilla(Guid id)
        {
            foreach (DataGridViewRow row in dgvPacientes.Rows)
            {
                if (row.DataBoundItem is PacienteVm p && p.PacienteId == id)
                {
                    row.Selected = true;
                    dgvPacientes.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        // =========================================================
        // ViewModel simple (sin entidades ni BD)
        // =========================================================
        private class PacienteVm
        {
            public Guid PacienteId { get; set; }
            public string Dni { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime FechaNac { get; set; }
            public string Sexo { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }
            public string Domicilio { get; set; }
            public string ObraSocial { get; set; }
            public string NroAfiliado { get; set; }
            public string ContactoEmergencia { get; set; }
            public string Notas { get; set; }
            public bool Activo { get; set; }
            public DateTime FechaAlta { get; set; }
        }
    }
}

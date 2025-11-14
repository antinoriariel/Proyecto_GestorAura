using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormMedicos : Form
    {
        private readonly MedicoNegocio _neg = new MedicoNegocio();

        private enum ModoEdicion { Ninguno, Nuevo, Editar }
        private ModoEdicion _modo = ModoEdicion.Ninguno;

        private int? _idUsuarioSel = null;
        private int? _idMedicoSel = null;

        public FormMedicos()
        {
            InitializeComponent();

            // Regla general: Consolas
            this.Font = new Font("Consolas", 11F, FontStyle.Regular);

            KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) Close();
            };

            PrepararGrid();
            HookEventos();
            HabilitarFicha(false);
            CargarMedicos();
        }

        // ============================================================
        // EVENTOS
        // ============================================================
        private void HookEventos()
        {
            // Botones superiores
            btnAgregar.Click += (s, e) => Nuevo();
            btnModificar.Click += (s, e) => Editar();
            btnEliminar.Click += (s, e) => Eliminar();
            btnInactivar.Click += (s, e) => Inactivar();

            // Botones ficha
            btnNuevoFicha.Click += (s, e) => Nuevo();
            btnGuardarFicha.Click += (s, e) => Guardar();
            btnCancelarFicha.Click += (s, e) => Cancelar();

            // Grid
            dgvMedicos.SelectionChanged += (s, e) => SincronizarSeleccion();
            dgvMedicos.CellDoubleClick += (s, e) => Editar();
        }

        private void PrepararGrid()
        {
            dgvMedicos.AutoGenerateColumns = false;
            dgvMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicos.MultiSelect = false;
            dgvMedicos.ReadOnly = true;
            dgvMedicos.AllowUserToAddRows = false;
            dgvMedicos.AllowUserToDeleteRows = false;
            dgvMedicos.RowHeadersVisible = false;

            dgvMedicos.Columns.Clear();

            dgvMedicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25
            });
            dgvMedicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 25
            });
            dgvMedicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Especialidad",
                HeaderText = "Especialidad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 35
            });
            dgvMedicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MatriculaProvincial",
                HeaderText = "Matrícula Prov.",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 15
            });

            dgvMedicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id_usuario",
                Name = "id_usuario",
                Visible = false
            });
            dgvMedicos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id_medico",
                Name = "id_medico",
                Visible = false
            });
        }

        private void CargarMedicos()
        {
            try
            {
                var tabla = _neg.Listar();
                dgvMedicos.DataSource = tabla;
                lblTotal.Text = $"Total: {tabla.Rows.Count}";
                SincronizarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando médicos:\n{ex.Message}", "BD",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SincronizarSeleccion()
        {
            if (dgvMedicos.CurrentRow?.DataBoundItem is not DataRowView drv)
            {
                _idUsuarioSel = _idMedicoSel = null;
                return;
            }

            var row = drv.Row;
            _idUsuarioSel = row.Field<int?>("id_usuario");
            _idMedicoSel = row.Field<int?>("id_medico");

            if (_modo == ModoEdicion.Ninguno)
                CargarFilaEnFicha(row);
        }

        private void CargarFilaEnFicha(DataRow row)
        {
            txtUsername.Text = row["username"]?.ToString() ?? "";
            txtEmail.Text = row["email"]?.ToString() ?? "";
            txtNombre.Text = row["Nombre"]?.ToString() ?? "";
            txtApellido.Text = row["Apellido"]?.ToString() ?? "";
            txtTelefono.Text = row["telefono"]?.ToString() ?? "";

            txtDni.Text = row["dni"] is DBNull
                ? ""
                : Convert.ToDecimal(row["dni"]).ToString("0");

            dtpNacimiento.Value = row.Field<DateTime?>("f_nacimiento")
                                  ?? DateTime.Today.AddYears(-25);

            txtEspecialidad.Text = row["Especialidad"]?.ToString() ?? "";
            txtMatProv.Text = row["MatriculaProvincial"]?.ToString() ?? "";
            txtMatNac.Text = row["MatriculaNacional"]?.ToString() ?? "";
            chkActivo.Checked = row.Field<bool?>("activo") ?? true;

            // Nunca mostramos contraseña
            txtPass.Clear();
            txtPass2.Clear();
        }

        private void LimpiarFicha()
        {
            txtUsername.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtDni.Clear();

            txtEspecialidad.Clear();
            txtMatProv.Clear();
            txtMatNac.Clear();

            txtPass.Clear();
            txtPass2.Clear();

            dtpNacimiento.Value = DateTime.Today.AddYears(-25);
            chkActivo.Checked = true;
        }

        private void HabilitarFicha(bool habilitar)
        {
            foreach (Control c in gbFicha.Controls)
            {
                if (c == panelFichaBotones) continue;
                c.Enabled = habilitar;
            }

            btnGuardarFicha.Enabled = habilitar;
            btnCancelarFicha.Enabled = habilitar;

            btnAgregar.Enabled = !habilitar;
            btnModificar.Enabled = !habilitar && dgvMedicos.CurrentRow != null;
            btnEliminar.Enabled = !habilitar && dgvMedicos.CurrentRow != null;
            btnInactivar.Enabled = !habilitar && dgvMedicos.CurrentRow != null;
        }

        // ============================================================
        // ACCIONES
        // ============================================================
        private void Nuevo()
        {
            _modo = ModoEdicion.Nuevo;
            _idUsuarioSel = _idMedicoSel = null;
            LimpiarFicha();
            HabilitarFicha(true);
            txtUsername.Focus();
        }

        private void Editar()
        {
            if (_idUsuarioSel == null || _idMedicoSel == null)
            {
                MessageBox.Show("Seleccioná un médico.", "Editar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _modo = ModoEdicion.Editar;
            HabilitarFicha(true);
            txtUsername.Focus();
        }

        private void Cancelar()
        {
            _modo = ModoEdicion.Ninguno;
            HabilitarFicha(false);
            SincronizarSeleccion();
        }

        private bool ValidarCampos(out long dni)
        {
            dni = 0;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Usuario requerido.");
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email inválido.");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Nombre requerido.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Apellido requerido.");
                txtApellido.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtDni.Text.Trim(), @"^\d{7,8}$"))
            {
                MessageBox.Show("DNI inválido (7-8 dígitos).");
                txtDni.Focus();
                return false;
            }

            dni = long.Parse(txtDni.Text.Trim());

            if (string.IsNullOrWhiteSpace(txtEspecialidad.Text))
            {
                MessageBox.Show("Especialidad requerida.");
                txtEspecialidad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatProv.Text) &&
                string.IsNullOrWhiteSpace(txtMatNac.Text))
            {
                MessageBox.Show("Ingresá al menos una matrícula.");
                txtMatProv.Focus();
                return false;
            }

            // Validar contraseña solo cuando se crea
            if (_modo == ModoEdicion.Nuevo)
            {
                if (string.IsNullOrWhiteSpace(txtPass.Text) || txtPass.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
                    txtPass.Focus();
                    return false;
                }

                if (txtPass.Text != txtPass2.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                    txtPass2.Focus();
                    return false;
                }
            }

            return true;
        }

        private void Guardar()
        {
            if (!ValidarCampos(out var dni)) return;

            try
            {
                if (_modo == ModoEdicion.Nuevo)
                {
                    var dto = new MedicoCrearDto(
                        txtUsername.Text.Trim(),
                        txtPass.Text.Trim(),               // 🔐 contraseña
                        txtEmail.Text.Trim(),
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        dni,
                        dtpNacimiento.Value.Date,
                        string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                        chkActivo.Checked,
                        txtEspecialidad.Text.Trim(),
                        txtMatProv.Text.Trim(),
                        string.IsNullOrWhiteSpace(txtMatNac.Text) ? null : txtMatNac.Text.Trim()
                    );

                    _neg.Crear(dto);
                }
                else if (_modo == ModoEdicion.Editar &&
         _idUsuarioSel.HasValue && _idMedicoSel.HasValue)
                {
                    var dto = new MedicoActualizarDto(
                        _idUsuarioSel.Value,
                        _idMedicoSel.Value,
                        txtUsername.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtNombre.Text.Trim(),
                        txtApellido.Text.Trim(),
                        dni,
                        dtpNacimiento.Value.Date,
                        string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                        chkActivo.Checked,
                        txtEspecialidad.Text.Trim(),
                        txtMatProv.Text.Trim(),
                        string.IsNullOrWhiteSpace(txtMatNac.Text) ? null : txtMatNac.Text.Trim(),
                        string.IsNullOrWhiteSpace(txtPass.Text) ? null : txtPass.Text.Trim()
                    );

                    _neg.Actualizar(dto);
                }


                _modo = ModoEdicion.Ninguno;
                HabilitarFicha(false);
                CargarMedicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo guardar:\n{ex.Message}", "Guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminar()
        {
            if (_idUsuarioSel == null)
            {
                MessageBox.Show("Seleccioná un médico.", "Eliminar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Eliminar definitivamente el médico seleccionado?",
                    "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _neg.Eliminar(_idUsuarioSel.Value);
                    CargarMedicos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar:\n{ex.Message}", "Eliminar",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Inactivar()
        {
            if (_idUsuarioSel == null)
            {
                MessageBox.Show("Seleccioná un médico.", "Inactivar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bool nuevoEstado = !chkActivo.Checked;
                _neg.SetActivo(_idUsuarioSel.Value, nuevoEstado);
                CargarMedicos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cambiar el estado:\n{ex.Message}", "Inactivar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

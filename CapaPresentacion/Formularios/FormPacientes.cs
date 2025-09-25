using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Infra;

namespace CapaPresentacion.Formularios
{
    public partial class FormPacientes : Form
    {
        int? _idPaciente = null; // null => alta, valor => edición

        public FormPacientes()
        {
            InitializeComponent();
            this.Load += FormPacientes_Load;
            btnGuardar.Click += BtnGuardar_Click;
            btnNuevo.Click += (_, __) => Limpiar();
            btnCancelar.Click += (_, __) => this.Close();
        }

        void FormPacientes_Load(object sender, EventArgs e)
        {
            cboSexo.Items.AddRange(new[] { "M", "F", "X" });
            cboGrupo.Items.AddRange(new[] { "0-", "0+", "A-", "A+", "B-", "B+", "AB-", "AB+" });
            CargarLocalidades();
        }

        void CargarLocalidades()
        {
            var dt = Db.Q(@"SELECT id_localidad, nombre FROM localidades ORDER BY nombre;");
            cboLocalidad.DataSource = dt;
            cboLocalidad.DisplayMember = "nombre";
            cboLocalidad.ValueMember = "id_localidad";
        }

        void Limpiar()
        {
            _idPaciente = null;
            foreach (Control c in this.Controls)
                if (c is TextBox tb) tb.Clear();
            cboSexo.SelectedIndex = -1;
            cboGrupo.SelectedIndex = -1;
            if (cboLocalidad.Items.Count > 0) cboLocalidad.SelectedIndex = 0;
            dtpNacimiento.Value = DateTime.Today.AddYears(-20);
        }

        bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { Msg("Falta nombre"); return false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { Msg("Falta apellido"); return false; }
            if (!long.TryParse(txtDni.Text, out _)) { Msg("DNI inválido"); return false; }
            if (cboSexo.SelectedIndex < 0) { Msg("Seleccioná sexo"); return false; }
            if (cboLocalidad.SelectedValue == null) { Msg("Seleccioná localidad"); return false; }
            if (dtpNacimiento.Value > DateTime.Today) { Msg("Fecha de nacimiento inválida"); return false; }
            return true;
        }

        void Msg(string s) => MessageBox.Show(s, "Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            var ps = new[]
            {
                new SqlParameter("@nombre", txtNombre.Text.Trim()),
                new SqlParameter("@apellido", txtApellido.Text.Trim()),
                new SqlParameter("@dni", txtDni.Text.Trim()),
                new SqlParameter("@sexo", cboSexo.Text),
                new SqlParameter("@f_nac", dtpNacimiento.Value.Date),
                new SqlParameter("@telefono", (object)txtTelefono.Text.Trim() ?? DBNull.Value),
                new SqlParameter("@email", (object)txtEmail.Text.Trim() ?? DBNull.Value),
                new SqlParameter("@direccion", (object)txtDireccion.Text.Trim() ?? DBNull.Value),
                new SqlParameter("@id_localidad", cboLocalidad.SelectedValue),
                new SqlParameter("@grupo", (object)cboGrupo.Text ?? DBNull.Value),
                new SqlParameter("@alergias", (object)txtAlergias.Text.Trim() ?? DBNull.Value)
            };

            if (_idPaciente == null)
            {
                var sql = @"
INSERT INTO pacientes
(nombre, apellido, dni, sexo, f_nacimiento, telefono, email, direccion, id_localidad, grupo_sanguineo, alergias, created_at)
OUTPUT INSERTED.id_paciente
VALUES (@nombre,@apellido,@dni,@sexo,@f_nac,@telefono,@email,@direccion,@id_localidad,@grupo,@alergias, SYSUTCDATETIME());";
                var nuevoId = (int)Db.Escalar(sql, ps);
                _idPaciente = nuevoId;
                MessageBox.Show($"Paciente creado (ID: {nuevoId})", "OK");
            }
            else
            {
                var sql = @"
UPDATE pacientes SET
  nombre=@nombre, apellido=@apellido, dni=@dni, sexo=@sexo, f_nacimiento=@f_nac,
  telefono=@telefono, email=@email, direccion=@direccion, id_localidad=@id_localidad,
  grupo_sanguineo=@grupo, alergias=@alergias, modified_at=SYSUTCDATETIME()
WHERE id_paciente=@id;";
                var list = new System.Collections.Generic.List<SqlParameter>(ps) { new("@id", _idPaciente) };
                Db.Exec(sql, list.ToArray());
                MessageBox.Show("Paciente actualizado", "OK");
            }
        }

        // Llama a esto cuando abras el form en modo edición
        public void CargarPaciente(int id)
        {
            var dt = Db.Q("SELECT * FROM pacientes WHERE id_paciente=@id", new SqlParameter("@id", id));
            if (dt.Rows.Count == 0) { Msg("No existe el paciente"); return; }

            _idPaciente = id;
            var r = dt.Rows[0];
            txtNombre.Text = r["nombre"].ToString();
            txtApellido.Text = r["apellido"].ToString();
            txtDni.Text = r["dni"].ToString();
            cboSexo.Text = r["sexo"].ToString();
            dtpNacimiento.Value = Convert.ToDateTime(r["f_nacimiento"]);
            txtTelefono.Text = r["telefono"]?.ToString();
            txtEmail.Text = r["email"]?.ToString();
            txtDireccion.Text = r["direccion"]?.ToString();
            cboLocalidad.SelectedValue = (int)r["id_localidad"];
            cboGrupo.Text = r["grupo_sanguineo"]?.ToString();
            txtAlergias.Text = r["alergias"]?.ToString();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
    }
}

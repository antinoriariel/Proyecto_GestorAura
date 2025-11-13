using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormAgregarPaciente : Form
    {
        // Datos de ejemplo en memoria para la cascada Provincia → Localidad
        private readonly List<Provincia> _provincias = new()
        {
            new Provincia { Id = 1, Nombre = "Buenos Aires", Localidades = new() {
                new Localidad{ Id=101, Nombre="La Plata"},
                new Localidad{ Id=102, Nombre="Mar del Plata"},
                new Localidad{ Id=103, Nombre="Bahía Blanca"},
            }},
            new Provincia { Id = 2, Nombre = "Chaco", Localidades = new() {
                new Localidad{ Id=201, Nombre="Resistencia"},
                new Localidad{ Id=202, Nombre="Barranqueras"},
                new Localidad{ Id=203, Nombre="Fontana"},
            }},
            new Provincia { Id = 3, Nombre = "Corrientes", Localidades = new() {
                new Localidad{ Id=301, Nombre="Corrientes"},
                new Localidad{ Id=302, Nombre="Goya"},
                new Localidad{ Id=303, Nombre="Curuzú Cuatiá"},
            }},
        };

        public FormAgregarPaciente()
        {
            InitializeComponent();
            CargarCombosEstaticos();
        }

        private void CargarCombosEstaticos()
        {
            // Sexo
            cboSexo.Items.Clear();
            cboSexo.Items.AddRange(new object[] { "F", "M", "X" });

            // Grupo sanguíneo
            cboGrupo.Items.Clear();
            cboGrupo.Items.AddRange(new object[] { "0-", "0+", "A-", "A+", "B-", "B+", "AB-", "AB+" });

            // Provincias (en memoria)
            cboProvincia.DataSource = _provincias;
            cboProvincia.DisplayMember = "Nombre";
            cboProvincia.ValueMember = "Id";
            cboProvincia.SelectedIndex = -1;

            // Localidades vacío hasta elegir provincia
            cboLocalidad.DataSource = null;

            dtpNacimiento.MaxDate = DateTime.Today;
            dtpNacimiento.Value = DateTime.Today.AddYears(-18);
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex < 0) { cboLocalidad.DataSource = null; return; }
            var prov = (Provincia)cboProvincia.SelectedItem;
            cboLocalidad.DataSource = prov.Localidades;
            cboLocalidad.DisplayMember = "Nombre";
            cboLocalidad.ValueMember = "Id";
            cboLocalidad.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control c in grid.Controls)
                if (c is TextBox tb) tb.Clear();

            cboSexo.SelectedIndex = -1;
            cboProvincia.SelectedIndex = -1;
            cboLocalidad.DataSource = null;
            cboGrupo.SelectedIndex = -1;
            dtpNacimiento.Value = DateTime.Today.AddYears(-18);
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones mínimas para demo visual (sin DB)
            if (!ValidarUI(out string msg))
            {
                MessageBox.Show(msg, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Vista previa: aquí guardaríamos el paciente en la base de datos.",
                            "Demo estática", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidarUI(out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { mensaje = "Nombre es requerido."; return false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { mensaje = "Apellido es requerido."; return false; }
            if (string.IsNullOrWhiteSpace(txtDni.Text)) { mensaje = "DNI es requerido."; return false; }
            if (!Regex.IsMatch(txtDni.Text.Trim(), @"^\d{7,9}$")) { mensaje = "DNI inválido (solo números 7-9 dígitos)."; return false; }
            if (cboSexo.SelectedIndex < 0) { mensaje = "Seleccione sexo."; return false; }
            if (cboProvincia.SelectedIndex < 0) { mensaje = "Seleccione provincia."; return false; }
            if (cboLocalidad.SelectedIndex < 0) { mensaje = "Seleccione localidad."; return false; }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { mensaje = "Email inválido."; return false; }
            if (dtpNacimiento.Value.Date > DateTime.Today) { mensaje = "Fecha de nacimiento no puede ser futura."; return false; }

            mensaje = "";
            return true;
        }

        // Tipos locales solo para la demo estática
        private class Provincia
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public List<Localidad> Localidades { get; set; } = new();
            public override string ToString() => Nombre;
        }
        private class Localidad
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public override string ToString() => Nombre;
        }
    }
}

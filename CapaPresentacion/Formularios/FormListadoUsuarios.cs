using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class FormListadoUsuarios : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new();

        public FormListadoUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();      // carga inicial
            FormatearGrilla();     // deja linda la grilla
        }

        // ============================================================
        // CARGAR USUARIOS
        // ============================================================
        private void CargarUsuarios(string filtro = "")
        {
            try
            {
                DataTable dt = _usuarioNegocio.ListarUsuarios(filtro);
                dgvUsuarios.DataSource = dt;

                lblTotal.Text = $"Total de usuarios: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el listado de usuarios:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ============================================================
        // FORMATEAR GRILLA
        // ============================================================
        private void FormatearGrilla()
        {
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.EnableHeadersVisualStyles = false;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvUsuarios.ColumnHeadersHeight = 32;

            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(207, 216, 220);
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvUsuarios.Columns.Contains("id_usuario"))
                dgvUsuarios.Columns["id_usuario"].HeaderText = "ID";

            if (dgvUsuarios.Columns.Contains("username"))
                dgvUsuarios.Columns["username"].HeaderText = "Usuario";

            if (dgvUsuarios.Columns.Contains("nombre"))
                dgvUsuarios.Columns["nombre"].HeaderText = "Nombre";

            if (dgvUsuarios.Columns.Contains("apellido"))
                dgvUsuarios.Columns["apellido"].HeaderText = "Apellido";

            if (dgvUsuarios.Columns.Contains("email"))
                dgvUsuarios.Columns["email"].HeaderText = "Email";

            if (dgvUsuarios.Columns.Contains("rol"))
                dgvUsuarios.Columns["rol"].HeaderText = "Rol";

            if (dgvUsuarios.Columns.Contains("dni"))
                dgvUsuarios.Columns["dni"].HeaderText = "DNI";

            if (dgvUsuarios.Columns.Contains("f_nacimiento"))
            {
                dgvUsuarios.Columns["f_nacimiento"].HeaderText = "F. Nac.";
                dgvUsuarios.Columns["f_nacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvUsuarios.Columns.Contains("telefono"))
                dgvUsuarios.Columns["telefono"].HeaderText = "Teléfono";

            if (dgvUsuarios.Columns.Contains("activo"))
            {
                dgvUsuarios.Columns["activo"].HeaderText = "Activo";
                dgvUsuarios.Columns["activo"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // ============================================================
        // EVENTOS
        // ============================================================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            CargarUsuarios(filtro);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            CargarUsuarios();
        }
    }
}

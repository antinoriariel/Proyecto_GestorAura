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
        // OBTENER USUARIO SELECCIONADO (ID, username, activo)
        // ============================================================
        private bool TryObtenerUsuarioSeleccionado(out int idUsuario, out string username, out bool activo)
        {
            idUsuario = 0;
            username = string.Empty;
            activo = false;

            if (dgvUsuarios.CurrentRow == null)
                return false;

            // Verificamos que exista la columna en la grilla
            if (!dgvUsuarios.Columns.Contains("id_usuario"))
                return false;

            DataGridViewRow fila = dgvUsuarios.CurrentRow;

            object idValue = fila.Cells["id_usuario"].Value;
            if (idValue == null || idValue == DBNull.Value)
                return false;

            idUsuario = Convert.ToInt32(idValue);

            if (dgvUsuarios.Columns.Contains("username"))
                username = fila.Cells["username"].Value?.ToString() ?? string.Empty;

            if (dgvUsuarios.Columns.Contains("activo"))
            {
                object activoValue = fila.Cells["activo"].Value;
                if (activoValue != null && activoValue != DBNull.Value)
                    activo = Convert.ToBoolean(activoValue);
            }

            return true;
        }

        // ============================================================
        // EVENTOS BÁSICOS
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

        // ------------------------------------------------------------
        // INACTIVAR USUARIO
        // ------------------------------------------------------------
        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (!TryObtenerUsuarioSeleccionado(out int idUsuario, out string username, out bool activo))
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!activo)
            {
                MessageBox.Show("El usuario ya se encuentra inactivo.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"¿Está seguro que desea inactivar al usuario '{username}'?",
                "Confirmar inactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr != DialogResult.Yes)
                return;

            try
            {
                _usuarioNegocio.CambiarEstadoUsuario(idUsuario, false);
                CargarUsuarios(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inactivar el usuario:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------
        // ACTIVAR USUARIO
        // ------------------------------------------------------------
        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (!TryObtenerUsuarioSeleccionado(out int idUsuario, out string username, out bool activo))
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (activo)
            {
                MessageBox.Show("El usuario ya se encuentra activo.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"¿Está seguro que desea volver a activar al usuario '{username}'?",
                "Confirmar activación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr != DialogResult.Yes)
                return;

            try
            {
                _usuarioNegocio.CambiarEstadoUsuario(idUsuario, true);
                CargarUsuarios(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al activar el usuario:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------
        // ELIMINAR USUARIO
        // ------------------------------------------------------------
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!TryObtenerUsuarioSeleccionado(out int idUsuario, out string username, out bool _))
            {
                MessageBox.Show("Debe seleccionar un usuario de la lista.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"¿Está seguro que desea eliminar definitivamente al usuario '{username}'?\n\n" +
                "Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr != DialogResult.Yes)
                return;

            try
            {
                _usuarioNegocio.EliminarUsuario(idUsuario);
                CargarUsuarios(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el usuario:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

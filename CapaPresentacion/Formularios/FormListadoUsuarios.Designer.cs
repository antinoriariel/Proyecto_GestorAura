using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormListadoUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnRefrescar;
        private Button btnInactivar;
        private Button btnActivar;
        private Button btnEliminar;
        private GroupBox grpListado;
        private DataGridView dgvUsuarios;
        private Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitulo = new Label();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnRefrescar = new Button();
            btnInactivar = new Button();
            btnActivar = new Button();
            btnEliminar = new Button();
            grpListado = new GroupBox();
            dgvUsuarios = new DataGridView();
            lblTotal = new Label();

            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            grpListado.SuspendLayout();
            SuspendLayout();

            // FormListadoUsuarios
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 240, 245);
            ClientSize = new Size(1000, 550);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListadoUsuarios";
            Text = "Listado de usuarios";
            Padding = new Padding(20);

            // lblTitulo
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 45;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Text = "Listado de usuarios del sistema";

            // lblBuscar
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblBuscar.Location = new Point(40, 70);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(207, 15);
            lblBuscar.Text = "Buscar (usuario, nombre, email, rol):";

            // txtBuscar
            txtBuscar.Location = new Point(43, 90);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(350, 23);

            // btnBuscar
            btnBuscar.Location = new Point(405, 88);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 26);
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;

            // btnRefrescar
            btnRefrescar.Location = new Point(495, 88);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(80, 26);
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;

            // btnInactivar
            btnInactivar.Location = new Point(585, 88);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(90, 26);
            btnInactivar.Text = "Inactivar";
            btnInactivar.FlatStyle = FlatStyle.Flat;
            btnInactivar.FlatAppearance.BorderSize = 0;
            btnInactivar.BackColor = Color.FromArgb(255, 193, 7);   // amarillo
            btnInactivar.ForeColor = Color.White;
            btnInactivar.UseVisualStyleBackColor = false;
            btnInactivar.Click += btnInactivar_Click;

            // btnActivar
            btnActivar.Location = new Point(685, 88);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(90, 26);
            btnActivar.Text = "Activar";
            btnActivar.FlatStyle = FlatStyle.Flat;
            btnActivar.FlatAppearance.BorderSize = 0;
            btnActivar.BackColor = Color.FromArgb(76, 175, 80);    // verde
            btnActivar.ForeColor = Color.White;
            btnActivar.UseVisualStyleBackColor = false;
            btnActivar.Click += btnActivar_Click;

            // btnEliminar
            btnEliminar.Location = new Point(785, 88);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 26);
            btnEliminar.Text = "Eliminar";
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.BackColor = Color.FromArgb(244, 67, 54);   // rojo
            btnEliminar.ForeColor = Color.White;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            // grpListado
            grpListado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpListado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            grpListado.Text = " Usuarios registrados ";
            grpListado.Location = new Point(35, 125);
            grpListado.Name = "grpListado";
            grpListado.Size = new Size(ClientSize.Width - 70, ClientSize.Height - 170);
            grpListado.BackColor = Color.White;
            grpListado.Padding = new Padding(10);

            // dgvUsuarios
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.Name = "dgvUsuarios";

            // lblTotal
            lblTotal.Dock = DockStyle.Bottom;
            lblTotal.Height = 24;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.FromArgb(90, 98, 104);
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            lblTotal.Padding = new Padding(0, 0, 10, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Total de usuarios: 0";

            grpListado.Controls.Add(dgvUsuarios);
            grpListado.Controls.Add(lblTotal);

            // Ajustar tamaño del groupbox al cambiar el tamaño del form
            Resize += (s, e) =>
            {
                grpListado.Size = new Size(ClientSize.Width - 70, ClientSize.Height - 170);
            };

            Controls.Add(grpListado);
            Controls.Add(btnEliminar);
            Controls.Add(btnActivar);
            Controls.Add(btnInactivar);
            Controls.Add(btnRefrescar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(lblTitulo);

            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            grpListado.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

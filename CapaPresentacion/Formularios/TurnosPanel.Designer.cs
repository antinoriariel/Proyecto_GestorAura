namespace CapaPresentacion.Formularios
{
    partial class TurnosPanel
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvTurnos;
        private Panel panelBotones;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnRefrescar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvTurnos = new DataGridView();
            panelBotones = new Panel();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnRefrescar = new Button();

            SuspendLayout();

            // === DataGridView ===
            dgvTurnos.Dock = DockStyle.Fill;
            dgvTurnos.ReadOnly = true;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.BackgroundColor = Color.White;
            dgvTurnos.BorderStyle = BorderStyle.FixedSingle;
            dgvTurnos.MultiSelect = false;

            // === Panel de botones ===
            panelBotones.Dock = DockStyle.Top;
            panelBotones.Height = 44;
            panelBotones.Padding = new Padding(10, 6, 10, 6);
            panelBotones.BackColor = Color.FromArgb(246, 247, 249);

            // === Botones CRUD ===
            int btnWidth = 100, btnHeight = 30, spacing = 8;
            int left = 10;

            Button[] botones = { btnAgregar, btnEditar, btnEliminar, btnRefrescar };
            string[] textos = { "Agregar", "Editar", "Eliminar", "Refrescar" };
            EventHandler[] eventos =
            {
                BtnAgregar_Click,
                BtnEditar_Click,
                BtnEliminar_Click,
                (s, e) => CargarTurnos()
            };

            for (int i = 0; i < botones.Length; i++)
            {
                var b = botones[i];
                b.Text = textos[i];
                b.Size = new Size(btnWidth, btnHeight);
                b.Location = new Point(left, 6);
                b.FlatStyle = FlatStyle.Flat;
                b.BackColor = Color.FromArgb(0, 136, 204);
                b.ForeColor = Color.White;
                b.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                b.Cursor = Cursors.Hand;
                b.Click += eventos[i];
                b.FlatAppearance.BorderSize = 0;
                panelBotones.Controls.Add(b);
                left += btnWidth + spacing;
            }

            // === Formulario / Panel contenedor ===
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Controls.Add(dgvTurnos);
            Controls.Add(panelBotones);
            Dock = DockStyle.Fill;
            ResumeLayout(false);
        }
    }
}

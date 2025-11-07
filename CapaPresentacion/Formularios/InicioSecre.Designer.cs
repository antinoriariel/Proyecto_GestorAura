using System.Windows.Forms;
using System.Drawing;

namespace CapaPresentacion.Formularios
{
    partial class InicioSecre
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelEncabezado;
        private PictureBox iconoEncabezado;
        private Label lblTitulo;

        private GroupBox grupoDatosSecretaria;
        private TableLayoutPanel tablaDatos;
        private Label lblEtiquetaBienvenida;
        private Label lblNombreSecretaria;
        private Label lblEtiquetaRol;
        private Label lblRolSecretaria;
        private Label lblEtiquetaEmail;
        private Label lblEmailSecretaria;

        private GroupBox grupoExtras;
        private Label lblFraseMotivacional;
        private Label lblVersionSistema;
        private Label lblEstadoServidor;

        private GroupBox grupoAgenda;
        private ComboBox cmbMedicos;
        private Label lblMedico;
        private DataGridView dgvTurnos;

        // 🔹 Nuevos controles para filtros debajo del grupoExtras
        private Panel panelFiltros;
        private TextBox txtBuscar;
        private Button btnHoy;
        private Button btnActualizar;
        private Button btnLimpiar;
        private DateTimePicker dtpFecha;
        private Label lblBuscar;
        private Label lblFecha;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelEncabezado = new Panel();
            iconoEncabezado = new PictureBox();
            lblTitulo = new Label();

            grupoDatosSecretaria = new GroupBox();
            tablaDatos = new TableLayoutPanel();
            lblEtiquetaBienvenida = new Label();
            lblNombreSecretaria = new Label();
            lblEtiquetaRol = new Label();
            lblRolSecretaria = new Label();
            lblEtiquetaEmail = new Label();
            lblEmailSecretaria = new Label();

            grupoExtras = new GroupBox();
            lblFraseMotivacional = new Label();
            lblVersionSistema = new Label();
            lblEstadoServidor = new Label();

            grupoAgenda = new GroupBox();
            cmbMedicos = new ComboBox();
            lblMedico = new Label();
            dgvTurnos = new DataGridView();

            panelFiltros = new Panel();
            txtBuscar = new TextBox();
            btnHoy = new Button();
            btnActualizar = new Button();
            btnLimpiar = new Button();
            dtpFecha = new DateTimePicker();
            lblBuscar = new Label();
            lblFecha = new Label();

            SuspendLayout();

            // === FORM ===
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(1000, 650);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InicioSecre";
            Padding = new Padding(20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio - Secretaría";

            // === HEADER ===
            panelEncabezado.BackColor = Color.FromArgb(41, 57, 71);
            panelEncabezado.Dock = DockStyle.Top;
            panelEncabezado.Height = 52;
            panelEncabezado.Controls.Add(iconoEncabezado);
            panelEncabezado.Controls.Add(lblTitulo);

            iconoEncabezado.Image = Properties.Resources.dashboardIcon;
            iconoEncabezado.Location = new Point(14, 10);
            iconoEncabezado.Size = new Size(32, 32);
            iconoEncabezado.SizeMode = PictureBoxSizeMode.Zoom;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(56, 12);
            lblTitulo.Text = "Panel de Inicio - Secretaría";

            // === DATOS SECRETARIA ===
            grupoDatosSecretaria.Text = "Datos personales";
            grupoDatosSecretaria.BackColor = Color.White;
            grupoDatosSecretaria.Dock = DockStyle.Top;
            grupoDatosSecretaria.Height = 120;
            grupoDatosSecretaria.Padding = new Padding(14, 12, 14, 12);
            grupoDatosSecretaria.Controls.Add(tablaDatos);

            tablaDatos.Dock = DockStyle.Fill;
            tablaDatos.ColumnCount = 2;
            tablaDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tablaDatos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablaDatos.RowCount = 3;
            tablaDatos.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tablaDatos.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tablaDatos.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));

            lblEtiquetaBienvenida.Text = "Bienvenida:";
            lblNombreSecretaria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEtiquetaRol.Text = "Rol:";
            lblRolSecretaria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEtiquetaEmail.Text = "Email:";
            lblEmailSecretaria.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            tablaDatos.Controls.Add(lblEtiquetaBienvenida, 0, 0);
            tablaDatos.Controls.Add(lblNombreSecretaria, 1, 0);
            tablaDatos.Controls.Add(lblEtiquetaRol, 0, 1);
            tablaDatos.Controls.Add(lblRolSecretaria, 1, 1);
            tablaDatos.Controls.Add(lblEtiquetaEmail, 0, 2);
            tablaDatos.Controls.Add(lblEmailSecretaria, 1, 2);

            // === EXTRAS ===
            grupoExtras.Text = "Información general";
            grupoExtras.BackColor = Color.White;
            grupoExtras.Dock = DockStyle.Top;
            grupoExtras.Height = 80;
            grupoExtras.Padding = new Padding(14, 12, 14, 12);
            grupoExtras.Controls.AddRange(new Control[] { lblFraseMotivacional, lblVersionSistema, lblEstadoServidor });

            lblFraseMotivacional.AutoSize = true;
            lblFraseMotivacional.Location = new Point(14, 24);
            lblVersionSistema.AutoSize = true;
            lblVersionSistema.Location = new Point(14, 50);
            lblEstadoServidor.AutoSize = true;
            lblEstadoServidor.Location = new Point(180, 50);

            // === PANEL DE FILTROS ===
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Height = 55;
            panelFiltros.Padding = new Padding(14, 8, 14, 8);
            panelFiltros.BackColor = Color.FromArgb(246, 247, 249);

            lblMedico.Text = "Médico:";
            lblMedico.Location = new Point(20, 18);
            lblMedico.AutoSize = true;

            cmbMedicos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedicos.Location = new Point(80, 14);
            cmbMedicos.Width = 220;

            lblFecha.Text = "Fecha:";
            lblFecha.Location = new Point(320, 18);
            lblFecha.AutoSize = true;

            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(375, 14);
            dtpFecha.Width = 110;

            lblBuscar.Text = "Buscar:";
            lblBuscar.Location = new Point(505, 18);
            lblBuscar.AutoSize = true;

            txtBuscar.Location = new Point(565, 14);
            txtBuscar.Width = 160;

            btnHoy.Text = "Hoy";
            btnHoy.BackColor = Color.FromArgb(0, 136, 204);
            btnHoy.ForeColor = Color.White;
            btnHoy.FlatStyle = FlatStyle.Flat;
            btnHoy.Location = new Point(740, 12);
            btnHoy.Size = new Size(60, 28);

            btnActualizar.Text = "Actualizar";
            btnActualizar.BackColor = Color.FromArgb(0, 136, 204);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Location = new Point(810, 12);
            btnActualizar.Size = new Size(90, 28);

            btnLimpiar.Text = "Limpiar";
            btnLimpiar.BackColor = Color.LightGray;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Location = new Point(910, 12);
            btnLimpiar.Size = new Size(75, 28);

            panelFiltros.Controls.AddRange(new Control[]
            {
                lblMedico, cmbMedicos,
                lblFecha, dtpFecha,
                lblBuscar, txtBuscar,
                btnHoy, btnActualizar, btnLimpiar
            });

            // === AGENDA DEL DÍA ===
            grupoAgenda.Text = "Agenda del día";
            grupoAgenda.BackColor = Color.White;
            grupoAgenda.Dock = DockStyle.Fill;
            grupoAgenda.Padding = new Padding(14, 12, 14, 12);
            grupoAgenda.Controls.Add(dgvTurnos);

            dgvTurnos.Dock = DockStyle.Fill;
            dgvTurnos.ReadOnly = true;
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.BackgroundColor = Color.White;
            dgvTurnos.BorderStyle = BorderStyle.FixedSingle;

            // === ENSAMBLE ===
            Controls.Add(grupoAgenda);
            Controls.Add(panelFiltros);
            Controls.Add(grupoExtras);
            Controls.Add(grupoDatosSecretaria);
            Controls.Add(panelEncabezado);

            ResumeLayout(false);
        }
    }
}

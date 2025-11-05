using System.Windows.Forms;
using System.Drawing;

namespace CapaPresentacion.Formularios
{
    partial class InicioSecre
    {
        private System.ComponentModel.IContainer components = null;

        // === Header ===
        private Panel panelEncabezado;
        private PictureBox iconoEncabezado;
        private Label lblTitulo;

        // === Datos personales ===
        private GroupBox grupoDatosSecretaria;
        private TableLayoutPanel tablaDatos;
        private Label lblEtiquetaBienvenida;
        private Label lblNombreSecretaria;
        private Label lblEtiquetaRol;
        private Label lblRolSecretaria;
        private Label lblEtiquetaEmail;
        private Label lblEmailSecretaria;

        // === Sección extra ===
        private GroupBox grupoExtras;
        private Label lblFraseMotivacional;
        private Label lblVersionSistema;
        private Label lblEstadoServidor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
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

            // === Formulario ===
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(1000, 300);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InicioSecre";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel Secretaria";

            // === Panel Encabezado ===
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
            lblTitulo.Text = "Panel principal secretario/a";

            // === Grupo: Datos de la secretaria ===
            grupoDatosSecretaria.Text = "Datos de la secretaria";
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

            // === Grupo: Extras ===
            grupoExtras.Text = "Extras";
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

            // === Ensamblado final ===
            Controls.Add(grupoExtras);
            Controls.Add(grupoDatosSecretaria);
            Controls.Add(panelEncabezado);

            ResumeLayout(false);
        }
        #endregion
    }
}

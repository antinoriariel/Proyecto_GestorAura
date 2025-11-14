using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormConfiguracionAdmin
    {
        private System.ComponentModel.IContainer components = null;

        // Controles
        private Panel panelHeader;
        private Label lblTitulo;

        private Panel panelContenido;
        private TableLayoutPanel tlpPrincipal;

        private GroupBox gbSistema;
        private Label lblNombreSistema;
        private TextBox txtNombreSistema;
        private Label lblVersion;
        private TextBox txtVersion;
        private Label lblMensajeBienvenida;
        private TextBox txtMensajeBienvenida;

        private GroupBox gbSeguridad;
        private Label lblDiasVencimiento;
        private NumericUpDown nudDiasVencimiento;
        private Label lblIntentosFallidos;
        private NumericUpDown nudIntentosFallidos;
        private CheckBox chkRequerirMayusculas;
        private CheckBox chkRequerirNumeros;
        private CheckBox chkForzarCambioPrimerInicio;

        private GroupBox gbBackup;
        private Label lblRutaBackup;
        private TextBox txtRutaBackup;
        private Button btnSeleccionarRutaBackup;
        private CheckBox chkComprimirBackup;
        private CheckBox chkIncluirLog;

        private GroupBox gbInterfaz;
        private CheckBox chkTemaOscuro;
        private CheckBox chkConfirmarSalida;
        private CheckBox chkMostrarTooltips;

        private Panel panelAcciones;
        private Button btnGuardar;
        private Button btnCancelar;
        private Button btnRestablecer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Form
            this.SuspendLayout();
            this.Text = "Configuración del sistema";
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.BackColor = Color.FromArgb(235, 240, 245);
            this.ClientSize = new Size(1100, 650);
            this.FormBorderStyle = FormBorderStyle.None; // si usás MDI embebido
            this.Padding = new Padding(10);

            // panelHeader
            panelHeader = new Panel();
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 60;
            panelHeader.BackColor = Color.FromArgb(44, 62, 80);

            lblTitulo = new Label();
            lblTitulo.Text = "Configuración del sistema";
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 18);

            panelHeader.Controls.Add(lblTitulo);

            // panelContenido
            panelContenido = new Panel();
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.BackColor = Color.FromArgb(235, 240, 245);
            panelContenido.Padding = new Padding(10);

            // tlpPrincipal
            tlpPrincipal = new TableLayoutPanel();
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.ColumnCount = 2;
            tlpPrincipal.RowCount = 2;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpPrincipal.Padding = new Padding(5);
            tlpPrincipal.BackColor = Color.Transparent;

            // === GroupBox Sistema ===
            gbSistema = new GroupBox();
            gbSistema.Text = "Datos del sistema";
            gbSistema.Dock = DockStyle.Fill;
            gbSistema.Padding = new Padding(10);

            lblNombreSistema = new Label();
            lblNombreSistema.Text = "Nombre del sistema:";
            lblNombreSistema.AutoSize = true;
            lblNombreSistema.Location = new Point(15, 30);

            txtNombreSistema = new TextBox();
            txtNombreSistema.Location = new Point(18, 50);
            txtNombreSistema.Width = 320;

            lblVersion = new Label();
            lblVersion.Text = "Versión:";
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(15, 85);

            txtVersion = new TextBox();
            txtVersion.Location = new Point(18, 105);
            txtVersion.Width = 150;

            lblMensajeBienvenida = new Label();
            lblMensajeBienvenida.Text = "Mensaje de bienvenida:";
            lblMensajeBienvenida.AutoSize = true;
            lblMensajeBienvenida.Location = new Point(15, 140);

            txtMensajeBienvenida = new TextBox();
            txtMensajeBienvenida.Location = new Point(18, 160);
            txtMensajeBienvenida.Multiline = true;
            txtMensajeBienvenida.Width = 360;
            txtMensajeBienvenida.Height = 80;

            gbSistema.Controls.Add(lblNombreSistema);
            gbSistema.Controls.Add(txtNombreSistema);
            gbSistema.Controls.Add(lblVersion);
            gbSistema.Controls.Add(txtVersion);
            gbSistema.Controls.Add(lblMensajeBienvenida);
            gbSistema.Controls.Add(txtMensajeBienvenida);

            // === GroupBox Seguridad ===
            gbSeguridad = new GroupBox();
            gbSeguridad.Text = "Seguridad de usuarios";
            gbSeguridad.Dock = DockStyle.Fill;
            gbSeguridad.Padding = new Padding(10);

            lblDiasVencimiento = new Label();
            lblDiasVencimiento.Text = "Días de vigencia de contraseña:";
            lblDiasVencimiento.AutoSize = true;
            lblDiasVencimiento.Location = new Point(15, 30);

            nudDiasVencimiento = new NumericUpDown();
            nudDiasVencimiento.Location = new Point(18, 50);
            nudDiasVencimiento.Minimum = 0;
            nudDiasVencimiento.Maximum = 365;
            nudDiasVencimiento.Width = 80;

            lblIntentosFallidos = new Label();
            lblIntentosFallidos.Text = "Intentos fallidos antes de bloqueo:";
            lblIntentosFallidos.AutoSize = true;
            lblIntentosFallidos.Location = new Point(15, 85);

            nudIntentosFallidos = new NumericUpDown();
            nudIntentosFallidos.Location = new Point(18, 105);
            nudIntentosFallidos.Minimum = 1;
            nudIntentosFallidos.Maximum = 10;
            nudIntentosFallidos.Width = 80;

            chkRequerirMayusculas = new CheckBox();
            chkRequerirMayusculas.Text = "Requerir mayúsculas en la contraseña";
            chkRequerirMayusculas.AutoSize = true;
            chkRequerirMayusculas.Location = new Point(18, 140);

            chkRequerirNumeros = new CheckBox();
            chkRequerirNumeros.Text = "Requerir números en la contraseña";
            chkRequerirNumeros.AutoSize = true;
            chkRequerirNumeros.Location = new Point(18, 165);

            chkForzarCambioPrimerInicio = new CheckBox();
            chkForzarCambioPrimerInicio.Text = "Forzar cambio de contraseña en primer inicio";
            chkForzarCambioPrimerInicio.AutoSize = true;
            chkForzarCambioPrimerInicio.Location = new Point(18, 190);

            gbSeguridad.Controls.Add(lblDiasVencimiento);
            gbSeguridad.Controls.Add(nudDiasVencimiento);
            gbSeguridad.Controls.Add(lblIntentosFallidos);
            gbSeguridad.Controls.Add(nudIntentosFallidos);
            gbSeguridad.Controls.Add(chkRequerirMayusculas);
            gbSeguridad.Controls.Add(chkRequerirNumeros);
            gbSeguridad.Controls.Add(chkForzarCambioPrimerInicio);

            // === GroupBox Backup ===
            gbBackup = new GroupBox();
            gbBackup.Text = "Opciones de backup";
            gbBackup.Dock = DockStyle.Fill;
            gbBackup.Padding = new Padding(10);

            lblRutaBackup = new Label();
            lblRutaBackup.Text = "Carpeta por defecto para los backups:";
            lblRutaBackup.AutoSize = true;
            lblRutaBackup.Location = new Point(15, 30);

            txtRutaBackup = new TextBox();
            txtRutaBackup.Location = new Point(18, 50);
            txtRutaBackup.Width = 320;

            btnSeleccionarRutaBackup = new Button();
            btnSeleccionarRutaBackup.Text = "Seleccionar...";
            btnSeleccionarRutaBackup.Location = new Point(345, 48);
            btnSeleccionarRutaBackup.Width = 90;
            btnSeleccionarRutaBackup.Click += new System.EventHandler(this.btnSeleccionarRutaBackup_Click);

            chkComprimirBackup = new CheckBox();
            chkComprimirBackup.Text = "Comprimir archivos de backup";
            chkComprimirBackup.AutoSize = true;
            chkComprimirBackup.Location = new Point(18, 90);

            chkIncluirLog = new CheckBox();
            chkIncluirLog.Text = "Incluir archivos de log en el backup";
            chkIncluirLog.AutoSize = true;
            chkIncluirLog.Location = new Point(18, 115);

            gbBackup.Controls.Add(lblRutaBackup);
            gbBackup.Controls.Add(txtRutaBackup);
            gbBackup.Controls.Add(btnSeleccionarRutaBackup);
            gbBackup.Controls.Add(chkComprimirBackup);
            gbBackup.Controls.Add(chkIncluirLog);

            // === GroupBox Interfaz ===
            gbInterfaz = new GroupBox();
            gbInterfaz.Text = "Interfaz y comportamiento";
            gbInterfaz.Dock = DockStyle.Fill;
            gbInterfaz.Padding = new Padding(10);

            chkTemaOscuro = new CheckBox();
            chkTemaOscuro.Text = "Usar tema oscuro (requiere reiniciar)";
            chkTemaOscuro.AutoSize = true;
            chkTemaOscuro.Location = new Point(18, 30);

            chkConfirmarSalida = new CheckBox();
            chkConfirmarSalida.Text = "Pedir confirmación al cerrar sesión / salir";
            chkConfirmarSalida.AutoSize = true;
            chkConfirmarSalida.Location = new Point(18, 55);

            chkMostrarTooltips = new CheckBox();
            chkMostrarTooltips.Text = "Mostrar ayudas emergentes (tooltips)";
            chkMostrarTooltips.AutoSize = true;
            chkMostrarTooltips.Location = new Point(18, 80);

            gbInterfaz.Controls.Add(chkTemaOscuro);
            gbInterfaz.Controls.Add(chkConfirmarSalida);
            gbInterfaz.Controls.Add(chkMostrarTooltips);

            // === Panel Acciones ===
            panelAcciones = new Panel();
            panelAcciones.Dock = DockStyle.Bottom;
            panelAcciones.Height = 60;
            panelAcciones.BackColor = Color.FromArgb(235, 240, 245);

            btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Width = 110;
            btnGuardar.Height = 32;
            btnGuardar.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnGuardar.Location = new Point(this.ClientSize.Width - 10 - 110 - 120 - 10, 15);
            btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            btnRestablecer = new Button();
            btnRestablecer.Text = "Restablecer";
            btnRestablecer.Width = 110;
            btnRestablecer.Height = 32;
            btnRestablecer.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnRestablecer.Location = new Point(this.ClientSize.Width - 10 - 110 - 10, 15);
            btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);

            btnCancelar = new Button();
            btnCancelar.Text = "Cerrar";
            btnCancelar.Width = 90;
            btnCancelar.Height = 32;
            btnCancelar.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            btnCancelar.Location = new Point(15, 15);
            btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // IMPORTANTE: ajustar posición cuando cambie el tamaño
            panelAcciones.Resize += (s, e) =>
            {
                btnRestablecer.Location = new Point(panelAcciones.Width - 10 - btnRestablecer.Width, 15);
                btnGuardar.Location = new Point(btnRestablecer.Left - 10 - btnGuardar.Width, 15);
            };

            panelAcciones.Controls.Add(btnGuardar);
            panelAcciones.Controls.Add(btnRestablecer);
            panelAcciones.Controls.Add(btnCancelar);

            // Agregar GroupBox al TableLayout
            tlpPrincipal.Controls.Add(gbSistema, 0, 0);
            tlpPrincipal.Controls.Add(gbSeguridad, 1, 0);
            tlpPrincipal.Controls.Add(gbBackup, 0, 1);
            tlpPrincipal.Controls.Add(gbInterfaz, 1, 1);

            panelContenido.Controls.Add(tlpPrincipal);

            // Agregar al form
            this.Controls.Add(panelContenido);
            this.Controls.Add(panelAcciones);
            this.Controls.Add(panelHeader);

            this.ResumeLayout(false);
        }
    }
}

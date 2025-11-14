using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormBackup
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblDescripcion;
        private GroupBox grpOpciones;
        private TextBox txtRuta;
        private Button btnSeleccionarRuta;
        private Button btnGenerarBackup;
        private Label lblRuta;
        private Label lblDetalle;

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitulo = new Label();
            lblDescripcion = new Label();
            grpOpciones = new GroupBox();
            lblDetalle = new Label();
            lblRuta = new Label();
            txtRuta = new TextBox();
            btnSeleccionarRuta = new Button();
            btnGenerarBackup = new Button();

            grpOpciones.SuspendLayout();
            SuspendLayout();

            // 
            // FormBackup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 240, 245); // mismo tono que el resto de módulos
            ClientSize = new Size(900, 500);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormBackup";
            Text = "Gestión de Backups";
            Padding = new Padding(20);

            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitulo.Height = 45;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Text = "Gestión de Backups";

            // 
            // lblDescripcion
            // 
            lblDescripcion.Dock = DockStyle.Top;
            lblDescripcion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcion.ForeColor = Color.FromArgb(90, 98, 104);
            lblDescripcion.Height = 30;
            lblDescripcion.Padding = new Padding(0, 0, 0, 5);
            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            lblDescripcion.Text = "Cree copias de seguridad completas de la base de datos del sistema.";

            // 
            // grpOpciones
            // 
            grpOpciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpOpciones.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpOpciones.ForeColor = Color.FromArgb(33, 37, 41);
            grpOpciones.Text = " Opciones de backup ";
            grpOpciones.BackColor = Color.White;
            grpOpciones.Location = new Point(60, 100);
            grpOpciones.Name = "grpOpciones";
            grpOpciones.Size = new Size(ClientSize.Width - 120, 220);
            grpOpciones.Padding = new Padding(15);
            grpOpciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // lblRuta
            // 
            lblRuta.AutoSize = true;
            lblRuta.Location = new Point(20, 40);
            lblRuta.Name = "lblRuta";
            lblRuta.Size = new Size(101, 19);
            lblRuta.Text = "Carpeta destino:";

            // 
            // txtRuta
            // 
            txtRuta.Location = new Point(23, 65);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(grpOpciones.Width - 180, 25);
            txtRuta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // btnSeleccionarRuta
            // 
            btnSeleccionarRuta.Name = "btnSeleccionarRuta";
            btnSeleccionarRuta.Text = "Seleccionar...";
            btnSeleccionarRuta.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSeleccionarRuta.Size = new Size(110, 27);
            btnSeleccionarRuta.Location = new Point(grpOpciones.Width - 135, 64);
            btnSeleccionarRuta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSeleccionarRuta.UseVisualStyleBackColor = true;
            btnSeleccionarRuta.Click += btnSeleccionarRuta_Click;

            // 
            // lblDetalle
            // 
            lblDetalle.AutoSize = false;
            lblDetalle.Location = new Point(20, 105);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(grpOpciones.Width - 40, 60);
            lblDetalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetalle.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblDetalle.ForeColor = Color.FromArgb(108, 117, 125);
            lblDetalle.Text =
                "Se generará una carpeta con la fecha y hora actual que contendrá el backup completo\n" +
                "de la base de datos. Asegúrese de seleccionar una ubicación con espacio disponible.";

            // 
            // btnGenerarBackup
            // 
            btnGenerarBackup.Name = "btnGenerarBackup";
            btnGenerarBackup.Text = "Generar backup";
            btnGenerarBackup.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerarBackup.Size = new Size(150, 32);
            btnGenerarBackup.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGenerarBackup.Location = new Point(grpOpciones.Width - 20 - btnGenerarBackup.Width, grpOpciones.Height - 20 - btnGenerarBackup.Height);
            btnGenerarBackup.UseVisualStyleBackColor = true;
            btnGenerarBackup.Click += btnGenerarBackup_Click;

            // Para que el botón e inputs se reacomoden si cambia el tamaño del form
            grpOpciones.Resize += (s, e) =>
            {
                txtRuta.Width = grpOpciones.Width - 180;
                btnSeleccionarRuta.Location = new Point(grpOpciones.Width - 135, 64);
                lblDetalle.Size = new Size(grpOpciones.Width - 40, 60);
                btnGenerarBackup.Location = new Point(
                    grpOpciones.Width - 20 - btnGenerarBackup.Width,
                    grpOpciones.Height - 20 - btnGenerarBackup.Height
                );
            };

            // 
            // Agregar controles al GroupBox y al Form
            // 
            grpOpciones.Controls.Add(lblRuta);
            grpOpciones.Controls.Add(txtRuta);
            grpOpciones.Controls.Add(btnSeleccionarRuta);
            grpOpciones.Controls.Add(lblDetalle);
            grpOpciones.Controls.Add(btnGenerarBackup);

            Controls.Add(grpOpciones);
            Controls.Add(lblDescripcion);
            Controls.Add(lblTitulo);

            grpOpciones.ResumeLayout(false);
            grpOpciones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}

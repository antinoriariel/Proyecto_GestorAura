using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormBackup
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private GroupBox grpOpciones;
        private TextBox txtRuta;
        private Button btnSeleccionarRuta;
        private Button btnGenerarBackup;
        private Label lblRuta;

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
            lblTitulo = new Label();
            grpOpciones = new GroupBox();
            lblRuta = new Label();
            txtRuta = new TextBox();
            btnSeleccionarRuta = new Button();
            btnGenerarBackup = new Button();
            grpOpciones.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(280, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(216, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Backups";
            // 
            // grpOpciones
            // 
            grpOpciones.Controls.Add(btnGenerarBackup);
            grpOpciones.Controls.Add(btnSeleccionarRuta);
            grpOpciones.Controls.Add(txtRuta);
            grpOpciones.Controls.Add(lblRuta);
            grpOpciones.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            grpOpciones.Location = new Point(40, 70);
            grpOpciones.Name = "grpOpciones";
            grpOpciones.Size = new Size(400, 140);
            grpOpciones.TabIndex = 1;
            grpOpciones.TabStop = false;
            grpOpciones.Text = "Opciones de Backup";
            // 
            // lblRuta
            // 
            lblRuta.AutoSize = true;
            lblRuta.Location = new Point(16, 30);
            lblRuta.Name = "lblRuta";
            lblRuta.Size = new Size(96, 15);
            lblRuta.TabIndex = 0;
            lblRuta.Text = "Carpeta destino:";
            // 
            // txtRuta
            // 
            txtRuta.Location = new Point(19, 50);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(260, 23);
            txtRuta.TabIndex = 1;
            // 
            // btnSeleccionarRuta
            // 
            btnSeleccionarRuta.Location = new Point(285, 49);
            btnSeleccionarRuta.Name = "btnSeleccionarRuta";
            btnSeleccionarRuta.Size = new Size(90, 25);
            btnSeleccionarRuta.TabIndex = 2;
            btnSeleccionarRuta.Text = "Seleccionar";
            btnSeleccionarRuta.UseVisualStyleBackColor = true;
            btnSeleccionarRuta.Click += btnSeleccionarRuta_Click;
            // 
            // btnGenerarBackup
            // 
            btnGenerarBackup.Anchor = AnchorStyles.Bottom;
            btnGenerarBackup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGenerarBackup.Location = new Point(133, 92);
            btnGenerarBackup.Name = "btnGenerarBackup";
            btnGenerarBackup.Size = new Size(130, 30);
            btnGenerarBackup.TabIndex = 3;
            btnGenerarBackup.Text = "Generar Backup";
            btnGenerarBackup.UseVisualStyleBackColor = true;
            btnGenerarBackup.Click += btnGenerarBackup_Click;
            // 
            // FormBackup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 300);
            Controls.Add(grpOpciones);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormBackup";
            Text = "FormBackup";
            grpOpciones.ResumeLayout(false);
            grpOpciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

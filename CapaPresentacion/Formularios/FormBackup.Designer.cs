namespace CapaPresentacion.Formularios
{
    partial class FormBackup
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnSeleccionarRuta;
        private System.Windows.Forms.Button btnGenerarBackup;
        private System.Windows.Forms.GroupBox grpOpciones;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnSeleccionarRuta = new System.Windows.Forms.Button();
            this.btnGenerarBackup = new System.Windows.Forms.Button();
            this.grpOpciones = new System.Windows.Forms.GroupBox();
            this.grpOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.Black;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Text = "Gestión de Backups";
            this.lblTitulo.Height = 50;
            // 
            // grpOpciones
            // 
            this.grpOpciones.Text = "Opciones de Backup";
            this.grpOpciones.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.grpOpciones.Location = new System.Drawing.Point(30, 70);
            this.grpOpciones.Size = new System.Drawing.Size(600, 150);
            this.grpOpciones.Controls.Add(this.txtRuta);
            this.grpOpciones.Controls.Add(this.btnSeleccionarRuta);
            this.grpOpciones.Controls.Add(this.btnGenerarBackup);
            // 
            // txtRuta
            // 
            this.txtRuta.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtRuta.Location = new System.Drawing.Point(20, 40);
            this.txtRuta.Width = 400;
            // 
            // btnSeleccionarRuta
            // 
            this.btnSeleccionarRuta.Text = "Seleccionar ruta...";
            this.btnSeleccionarRuta.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionarRuta.BackColor = Color.FromArgb(0, 150, 136);
            this.btnSeleccionarRuta.ForeColor = Color.White;
            this.btnSeleccionarRuta.Location = new System.Drawing.Point(440, 40);
            this.btnSeleccionarRuta.Size = new System.Drawing.Size(130, 30);
            this.btnSeleccionarRuta.Click += new System.EventHandler(this.btnSeleccionarRuta_Click);
            // 
            // btnGenerarBackup
            // 
            this.btnGenerarBackup.Text = "Generar Backup";
            this.btnGenerarBackup.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.btnGenerarBackup.BackColor = Color.FromArgb(0, 150, 136);
            this.btnGenerarBackup.ForeColor = Color.White;
            this.btnGenerarBackup.Location = new System.Drawing.Point(220, 90);
            this.btnGenerarBackup.Size = new System.Drawing.Size(160, 35);
            this.btnGenerarBackup.Click += new System.EventHandler(this.btnGenerarBackup_Click);
            // 
            // FormBackup
            // 
            this.ClientSize = new System.Drawing.Size(660, 250);
            this.Controls.Add(this.grpOpciones);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.White;
            this.grpOpciones.ResumeLayout(false);
            this.grpOpciones.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}

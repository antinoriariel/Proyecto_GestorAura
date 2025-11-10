namespace CapaPresentacion.Formularios
{
    partial class FormMensajes
    {
        private System.ComponentModel.IContainer components = null;

        // 🔹 Declaración de controles (solo una vez)
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.ListBox lstConversaciones;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.RichTextBox rtbHistorial;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ComboBox cmbUsuarios;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensajes";
        }
        #endregion
    }
}

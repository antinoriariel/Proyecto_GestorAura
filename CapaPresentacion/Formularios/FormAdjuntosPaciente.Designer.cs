using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormAdjuntosPaciente
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 
            // FormAdjuntosPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Tamaño inicial
            this.ClientSize = new System.Drawing.Size(1080, 700);

            // Centrado en pantalla
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Color de fondo y título
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Archivos Adjuntos de Pacientes";

            // Evita maximizar si querés mantener tamaño fijo
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.ResumeLayout(false);
        }
    }
}

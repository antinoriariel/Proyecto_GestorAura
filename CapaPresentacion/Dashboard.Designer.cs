namespace CapaPresentacion
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMenu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelMenu = new Panel();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.LightSeaGreen;
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(180, 600);
            panelMenu.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(panelMenu);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor Aura";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }
    }
}

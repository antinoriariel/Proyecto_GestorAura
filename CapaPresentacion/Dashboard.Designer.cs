namespace CapaPresentacion
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMenu;
        private Controles.NavbarSuperior navbarSuperior1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelMenu = new System.Windows.Forms.Panel();
            navbarSuperior1 = new CapaPresentacion.Controles.NavbarSuperior();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = System.Drawing.Color.FromArgb(0, 98, 113);
            panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            panelMenu.Location = new System.Drawing.Point(0, 0);
            panelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new System.Drawing.Size(180, 470);
            panelMenu.TabIndex = 0;
            // 
            // navbarSuperior1
            // 
            navbarSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            navbarSuperior1.Location = new System.Drawing.Point(180, 0);
            navbarSuperior1.Name = "navbarSuperior1";
            navbarSuperior1.Size = new System.Drawing.Size(659, 45);
            navbarSuperior1.TabIndex = 1;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ActiveBorder;
            ClientSize = new System.Drawing.Size(839, 470);
            Controls.Add(navbarSuperior1);
            Controls.Add(panelMenu);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Dashboard";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Gestor Aura";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ResumeLayout(false);
        }
    }
}

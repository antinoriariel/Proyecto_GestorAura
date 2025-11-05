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
            panelMenu = new Panel();
            navbarSuperior1 = new CapaPresentacion.Controles.NavbarSuperior();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(0, 98, 113);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 2, 3, 2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(180, 470);
            panelMenu.TabIndex = 0;
            // 
            // navbarSuperior1
            // 
            navbarSuperior1.BackColor = Color.FromArgb(55, 71, 79);
            navbarSuperior1.Dock = DockStyle.Top;
            navbarSuperior1.Location = new Point(180, 0);
            navbarSuperior1.Name = "navbarSuperior1";
            navbarSuperior1.Size = new Size(659, 45);
            navbarSuperior1.TabIndex = 1;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(839, 470);
            Controls.Add(navbarSuperior1);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor Aura";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }
    }
}

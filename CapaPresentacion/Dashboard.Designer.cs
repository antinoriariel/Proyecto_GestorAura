using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            panelSuperior = new Panel();
            userNavbar1 = new CapaPresentacion.Controles.UserNavbar();
            panelSuperior.SuspendLayout();
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
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(55, 71, 79);
            panelSuperior.Controls.Add(userNavbar1);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(180, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(659, 45);
            panelSuperior.TabIndex = 1;
            // 
            // userNavbar1
            // 
            userNavbar1.Dock = DockStyle.Fill;
            userNavbar1.Location = new Point(0, 0);
            userNavbar1.Name = "userNavbar1";
            userNavbar1.Size = new Size(659, 45);
            userNavbar1.TabIndex = 0;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(839, 470);
            Controls.Add(panelSuperior);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor Aura";
            WindowState = FormWindowState.Maximized;
            panelSuperior.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Panel panelSuperior;
        private Controles.UserNavbar userNavbar1;
    }
}

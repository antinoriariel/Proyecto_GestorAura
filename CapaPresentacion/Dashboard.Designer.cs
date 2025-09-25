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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
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
            panelSuperior.Controls.Add(button4);
            panelSuperior.Controls.Add(button3);
            panelSuperior.Controls.Add(button2);
            panelSuperior.Controls.Add(button1);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(180, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(659, 45);
            panelSuperior.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(55, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(175, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(560, 12);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(296, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
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
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button4;
    }
}

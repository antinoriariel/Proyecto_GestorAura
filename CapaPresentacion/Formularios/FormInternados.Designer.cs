namespace CapaPresentacion.Formularios
{
    partial class FormInternados
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.GroupBox grpCamas;
        private System.Windows.Forms.DataGridView dgvCamas;

        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;

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
            headerPanel = new Panel();
            picHeader = new PictureBox();
            lblHeader = new Label();
            grpCamas = new GroupBox();
            dgvCamas = new DataGridView();
            footerPanel = new Panel();
            btnActualizar = new Button();
            btnCerrar = new Button();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).BeginInit();
            grpCamas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCamas).BeginInit();
            footerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(41, 57, 71);
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(21, 12);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(760, 50);
            headerPanel.TabIndex = 0;
            // 
            // picHeader
            // 
            picHeader.Image = Properties.Resources.hospitalBedIcon; // 👈 asegúrate de agregar este recurso
            picHeader.Location = new Point(14, 9);
            picHeader.Name = "picHeader";
            picHeader.Size = new Size(35, 30);
            picHeader.SizeMode = PictureBoxSizeMode.Zoom;
            picHeader.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(56, 14);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(207, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Ocupación de camas";
            // 
            // grpCamas
            // 
            grpCamas.BackColor = Color.White;
            grpCamas.Controls.Add(dgvCamas);
            grpCamas.Dock = DockStyle.Fill;
            grpCamas.Location = new Point(21, 62);
            grpCamas.Name = "grpCamas";
            grpCamas.Padding = new Padding(14, 12, 14, 12);
            grpCamas.Size = new Size(760, 360);
            grpCamas.TabIndex = 1;
            grpCamas.TabStop = false;
            grpCamas.Text = "Listado de camas";
            // 
            // dgvCamas
            // 
            dgvCamas.AllowUserToAddRows = false;
            dgvCamas.AllowUserToDeleteRows = false;
            dgvCamas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCamas.BackgroundColor = Color.White;
            dgvCamas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCamas.Dock = DockStyle.Fill;
            dgvCamas.Location = new Point(14, 28);
            dgvCamas.MultiSelect = false;
            dgvCamas.Name = "dgvCamas";
            dgvCamas.ReadOnly = true;
            dgvCamas.RowTemplate.Height = 28;
            dgvCamas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCamas.Size = new Size(732, 320);
            dgvCamas.TabIndex = 0;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = Color.Transparent;
            footerPanel.Controls.Add(btnActualizar);
            footerPanel.Controls.Add(btnCerrar);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(21, 422);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(0, 6, 0, 0);
            footerPanel.Size = new Size(760, 48);
            footerPanel.TabIndex = 2;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.AutoSize = true;
            btnActualizar.Location = new Point(580, 10);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 27);
            btnActualizar.TabIndex = 0;
            btnActualizar.Text = "Actualizar";
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.AutoSize = true;
            btnCerrar.Location = new Point(670, 10);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 27);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            //btnCerrar.Click += (s, e) => this.Close();
            // 
            // FormInternados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(802, 482);
            ControlBox = false;
            Controls.Add(grpCamas);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInternados";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Internados";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).EndInit();
            grpCamas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCamas).EndInit();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
    }
}

namespace CapaPresentacion.Formularios
{
    partial class FormMedicos
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.GroupBox grpListado;
        private System.Windows.Forms.DataGridView dgvMedicos;

        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnInactivar;

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
            grpListado = new GroupBox();
            dgvMedicos = new DataGridView();
            footerPanel = new Panel();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnInactivar = new Button();

            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).BeginInit();
            grpListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicos).BeginInit();
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
            headerPanel.Size = new Size(676, 48);
            headerPanel.TabIndex = 0;
            // 
            // picHeader
            // 
            picHeader.Image = Properties.Resources.medicoIcon;
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
            lblHeader.Size = new Size(223, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Gestión de Médicos";
            // 
            // grpListado
            // 
            grpListado.BackColor = Color.White;
            grpListado.Controls.Add(dgvMedicos);
            grpListado.Dock = DockStyle.Fill;
            grpListado.Location = new Point(21, 60);
            grpListado.Name = "grpListado";
            grpListado.Padding = new Padding(14, 12, 14, 12);
            grpListado.Size = new Size(676, 340);
            grpListado.TabIndex = 1;
            grpListado.TabStop = false;
            grpListado.Text = "Listado de médicos";
            // 
            // dgvMedicos
            // 
            dgvMedicos.AllowUserToAddRows = false;
            dgvMedicos.AllowUserToDeleteRows = false;
            dgvMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicos.BackgroundColor = Color.White;
            dgvMedicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicos.Dock = DockStyle.Fill;
            dgvMedicos.Location = new Point(14, 28);
            dgvMedicos.MultiSelect = false;
            dgvMedicos.Name = "dgvMedicos";
            dgvMedicos.ReadOnly = true;
            dgvMedicos.RowHeadersVisible = false;
            dgvMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicos.Size = new Size(648, 300);
            dgvMedicos.TabIndex = 0;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = Color.Transparent;
            footerPanel.Controls.Add(btnAgregar);
            footerPanel.Controls.Add(btnModificar);
            footerPanel.Controls.Add(btnEliminar);
            footerPanel.Controls.Add(btnInactivar);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(21, 400);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(0, 6, 0, 0);
            footerPanel.Size = new Size(676, 60);
            footerPanel.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.AutoSize = true;
            btnAgregar.Text = "➕ Agregar";
            btnAgregar.Location = new Point(20, 15);
            // 
            // btnModificar
            // 
            btnModificar.AutoSize = true;
            btnModificar.Text = "✏️ Modificar";
            btnModificar.Location = new Point(140, 15);
            // 
            // btnEliminar
            // 
            btnEliminar.AutoSize = true;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.Location = new Point(260, 15);
            // 
            // btnInactivar
            // 
            btnInactivar.AutoSize = true;
            btnInactivar.Text = "🚫 Inactivar";
            btnInactivar.Location = new Point(380, 15);
            // 
            // FormMedicos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(718, 472);
            ControlBox = false;
            Controls.Add(grpListado);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMedicos";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Médicos";

            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).EndInit();
            grpListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedicos).EndInit();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
    }
}

namespace CapaPresentacion.Formularios
{
    partial class FormTurnos
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.TableLayoutPanel grid;

        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cboPaciente;

        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ComboBox cboMedico;

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;

        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;

        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;

        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObs;

        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

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
            grpDatos = new GroupBox();
            grid = new TableLayoutPanel();
            lblPaciente = new Label();
            cboPaciente = new ComboBox();
            lblMedico = new Label();
            cboMedico = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHora = new Label();
            dtpHora = new DateTimePicker();
            lblMotivo = new Label();
            txtMotivo = new TextBox();
            lblObs = new Label();
            txtObs = new TextBox();
            footerPanel = new Panel();
            btnGuardar = new Button();
            btnCancelar = new Button();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).BeginInit();
            grpDatos.SuspendLayout();
            grid.SuspendLayout();
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
            headerPanel.Margin = new Padding(3, 2, 3, 2);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(676, 48);
            headerPanel.TabIndex = 2;
            // 
            // picHeader
            // 
            picHeader.Image = Properties.Resources.calendarTodayIcon;
            picHeader.Location = new Point(14, 9);
            picHeader.Margin = new Padding(3, 2, 3, 2);
            picHeader.Name = "picHeader";
            picHeader.Size = new Size(35, 30);
            picHeader.SizeMode = PictureBoxSizeMode.Zoom;
            picHeader.TabIndex = 0;
            picHeader.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(56, 14);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(191, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Agenda de turnos";
            // 
            // grpDatos
            // 
            grpDatos.BackColor = Color.White;
            grpDatos.Controls.Add(grid);
            grpDatos.Dock = DockStyle.Top;
            grpDatos.Location = new Point(21, 60);
            grpDatos.Margin = new Padding(3, 2, 3, 2);
            grpDatos.Name = "grpDatos";
            grpDatos.Padding = new Padding(14, 12, 14, 12);
            grpDatos.Size = new Size(676, 281);
            grpDatos.TabIndex = 1;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del turno";
            // 
            // grid
            // 
            grid.ColumnCount = 2;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            grid.Controls.Add(lblPaciente, 0, 0);
            grid.Controls.Add(cboPaciente, 1, 0);
            grid.Controls.Add(lblMedico, 0, 1);
            grid.Controls.Add(cboMedico, 1, 1);
            grid.Controls.Add(lblFecha, 0, 2);
            grid.Controls.Add(dtpFecha, 1, 2);
            grid.Controls.Add(lblHora, 0, 3);
            grid.Controls.Add(lblMotivo, 0, 4);
            grid.Controls.Add(txtMotivo, 1, 4);
            grid.Controls.Add(lblObs, 0, 5);
            grid.Controls.Add(txtObs, 1, 5);
            grid.Controls.Add(dtpHora, 1, 3);
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(14, 28);
            grid.Margin = new Padding(3, 2, 3, 2);
            grid.Name = "grid";
            grid.RowCount = 6;
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            grid.Size = new Size(648, 241);
            grid.TabIndex = 0;
            // 
            // lblPaciente
            // 
            lblPaciente.Anchor = AnchorStyles.Left;
            lblPaciente.AutoSize = true;
            lblPaciente.Location = new Point(3, 9);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(52, 15);
            lblPaciente.TabIndex = 0;
            lblPaciente.Text = "Paciente";
            // 
            // cboPaciente
            // 
            cboPaciente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboPaciente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaciente.IntegralHeight = false;
            cboPaciente.Location = new Point(125, 5);
            cboPaciente.Margin = new Padding(3, 2, 3, 2);
            cboPaciente.MaxDropDownItems = 12;
            cboPaciente.Name = "cboPaciente";
            cboPaciente.Size = new Size(520, 23);
            cboPaciente.TabIndex = 1;
            // 
            // lblMedico
            // 
            lblMedico.Anchor = AnchorStyles.Left;
            lblMedico.AutoSize = true;
            lblMedico.Location = new Point(3, 42);
            lblMedico.Name = "lblMedico";
            lblMedico.Size = new Size(47, 15);
            lblMedico.TabIndex = 2;
            lblMedico.Text = "Médico";
            // 
            // cboMedico
            // 
            cboMedico.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboMedico.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMedico.IntegralHeight = false;
            cboMedico.Location = new Point(125, 38);
            cboMedico.Margin = new Padding(3, 2, 3, 2);
            cboMedico.Name = "cboMedico";
            cboMedico.Size = new Size(520, 23);
            cboMedico.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Left;
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(3, 75);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Anchor = AnchorStyles.Left;
            dtpFecha.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(125, 71);
            dtpFecha.Margin = new Padding(3, 2, 3, 2);
            dtpFecha.MinDate = new DateTime(2025, 9, 26, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(248, 23);
            dtpFecha.TabIndex = 5;
            // 
            // lblHora
            // 
            lblHora.Anchor = AnchorStyles.Left;
            lblHora.AutoSize = true;
            lblHora.Location = new Point(3, 108);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(33, 15);
            lblHora.TabIndex = 6;
            lblHora.Text = "Hora";
            // 
            // dtpHora
            // 
            dtpHora.Anchor = AnchorStyles.Left;
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.Location = new Point(125, 104);
            dtpHora.Margin = new Padding(3, 2, 3, 2);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(58, 23);
            dtpHora.TabIndex = 7;
            // 
            // lblMotivo
            // 
            lblMotivo.Anchor = AnchorStyles.Left;
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(3, 141);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(45, 15);
            lblMotivo.TabIndex = 8;
            lblMotivo.Text = "Motivo";
            // 
            // txtMotivo
            // 
            txtMotivo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMotivo.Location = new Point(125, 137);
            txtMotivo.Margin = new Padding(3, 2, 3, 2);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.PlaceholderText = "Ej.: control, resultado de estudio, dolor…";
            txtMotivo.Size = new Size(520, 23);
            txtMotivo.TabIndex = 9;
            // 
            // lblObs
            // 
            lblObs.Anchor = AnchorStyles.Left;
            lblObs.AutoSize = true;
            lblObs.Location = new Point(3, 195);
            lblObs.Name = "lblObs";
            lblObs.Size = new Size(84, 15);
            lblObs.TabIndex = 10;
            lblObs.Text = "Observaciones";
            // 
            // txtObs
            // 
            txtObs.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtObs.Location = new Point(125, 172);
            txtObs.Margin = new Padding(3, 2, 3, 2);
            txtObs.Multiline = true;
            txtObs.Name = "txtObs";
            txtObs.Size = new Size(520, 62);
            txtObs.TabIndex = 11;
            // 
            // footerPanel
            // 
            footerPanel.BackColor = Color.Transparent;
            footerPanel.Controls.Add(btnGuardar);
            footerPanel.Controls.Add(btnCancelar);
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Location = new Point(21, 345);
            footerPanel.Margin = new Padding(3, 2, 3, 2);
            footerPanel.Name = "footerPanel";
            footerPanel.Padding = new Padding(0, 6, 0, 0);
            footerPanel.Size = new Size(676, 48);
            footerPanel.TabIndex = 0;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.AutoSize = true;
            btnGuardar.Location = new Point(749, 9);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 27);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.AutoSize = true;
            btnCancelar.Location = new Point(749, 9);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 27);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            // 
            // FormTurnos
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            CancelButton = btnCancelar;
            ClientSize = new Size(718, 405);
            ControlBox = false;
            Controls.Add(footerPanel);
            Controls.Add(grpDatos);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTurnos";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agenda de Turnos";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).EndInit();
            grpDatos.ResumeLayout(false);
            grid.ResumeLayout(false);
            grid.PerformLayout();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);

            // ===== Eventos clave (puedes mover el código a FormTurnos.cs) =====
            // btnGuardar.Click += (s, e) => this.OnGuardar();
            // btnCancelar.Click += (s, e) => this.Close();
            // this.KeyDown += (s, e) => { if (e.KeyCode == System.Windows.Forms.Keys.Escape) this.Close(); };
        }
        #endregion
    }
}

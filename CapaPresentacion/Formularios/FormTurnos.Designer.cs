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
            components = new System.ComponentModel.Container();

            // ===== Form =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 244, 246); // gris claro suave
            this.ClientSize = new System.Drawing.Size(820, 540);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agenda de Turnos";
            this.KeyPreview = true;

            // ===== Header =====
            headerPanel = new System.Windows.Forms.Panel();
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Height = 64;
            headerPanel.BackColor = System.Drawing.Color.FromArgb(41, 57, 71); // como tu barra superior

            picHeader = new System.Windows.Forms.PictureBox();
            picHeader.Size = new System.Drawing.Size(40, 40);
            picHeader.Location = new System.Drawing.Point(16, 12);
            picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picHeader.Image = Properties.Resources.calendarTodayIcon; // reemplaza si no existe

            lblHeader = new System.Windows.Forms.Label();
            lblHeader.AutoSize = true;
            lblHeader.Location = new System.Drawing.Point(64, 18);
            lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            lblHeader.ForeColor = System.Drawing.Color.White;
            lblHeader.Text = "Agenda de turnos";

            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);

            // ===== GroupBox + Grid =====
            grpDatos = new System.Windows.Forms.GroupBox();
            grpDatos.Text = "Datos del turno";
            grpDatos.Dock = System.Windows.Forms.DockStyle.Top;
            grpDatos.Padding = new System.Windows.Forms.Padding(16);
            grpDatos.Height = 320;
            grpDatos.BackColor = System.Drawing.Color.White;

            grid = new System.Windows.Forms.TableLayoutPanel();
            grid.ColumnCount = 2;
            grid.RowCount = 6;
            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F)); // columna de labels
            grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            for (int i = 0; i < 6; i++)
                grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));

            // Paciente
            lblPaciente = new System.Windows.Forms.Label();
            lblPaciente.Text = "Paciente";
            lblPaciente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblPaciente.AutoSize = true;

            cboPaciente = new System.Windows.Forms.ComboBox();
            cboPaciente.Name = "cboPaciente";
            cboPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPaciente.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cboPaciente.IntegralHeight = false;
            cboPaciente.MaxDropDownItems = 12;

            // Médico
            lblMedico = new System.Windows.Forms.Label();
            lblMedico.Text = "Médico";
            lblMedico.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblMedico.AutoSize = true;

            cboMedico = new System.Windows.Forms.ComboBox();
            cboMedico.Name = "cboMedico";
            cboMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboMedico.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cboMedico.IntegralHeight = false;

            // Fecha
            lblFecha = new System.Windows.Forms.Label();
            lblFecha.Text = "Fecha";
            lblFecha.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblFecha.AutoSize = true;

            dtpFecha = new System.Windows.Forms.DateTimePicker();
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.Left;
            dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy";
            dtpFecha.MinDate = System.DateTime.Today;

            // Hora
            lblHora = new System.Windows.Forms.Label();
            lblHora.Text = "Hora";
            lblHora.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblHora.AutoSize = true;

            dtpHora = new System.Windows.Forms.DateTimePicker();
            dtpHora.Name = "dtpHora";
            dtpHora.Anchor = System.Windows.Forms.AnchorStyles.Left;
            dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.ShowUpDown = true; // spinner en vez de calendario

            // Motivo
            lblMotivo = new System.Windows.Forms.Label();
            lblMotivo.Text = "Motivo";
            lblMotivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblMotivo.AutoSize = true;

            txtMotivo = new System.Windows.Forms.TextBox();
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMotivo.PlaceholderText = "Ej.: control, resultado de estudio, dolor…";

            // Observaciones
            lblObs = new System.Windows.Forms.Label();
            lblObs.Text = "Observaciones";
            lblObs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblObs.AutoSize = true;

            txtObs = new System.Windows.Forms.TextBox();
            txtObs.Name = "txtObs";
            txtObs.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtObs.Multiline = true;
            txtObs.Height = 60;

            // Agregar al grid
            grid.Controls.Add(lblPaciente, 0, 0);
            grid.Controls.Add(cboPaciente, 1, 0);

            grid.Controls.Add(lblMedico, 0, 1);
            grid.Controls.Add(cboMedico, 1, 1);

            grid.Controls.Add(lblFecha, 0, 2);
            grid.Controls.Add(dtpFecha, 1, 2);

            grid.Controls.Add(lblHora, 0, 3);
            grid.Controls.Add(dtpHora, 1, 3);

            grid.Controls.Add(lblMotivo, 0, 4);
            grid.Controls.Add(txtMotivo, 1, 4);

            grid.Controls.Add(lblObs, 0, 5);
            grid.Controls.Add(txtObs, 1, 5);

            grpDatos.Controls.Add(grid);

            // ===== Footer (botonera) =====
            footerPanel = new System.Windows.Forms.Panel();
            footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            footerPanel.Height = 64;
            footerPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            footerPanel.BackColor = System.Drawing.Color.Transparent;

            btnGuardar = new System.Windows.Forms.Button();
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Text = "Guardar";
            btnGuardar.AutoSize = true;
            btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnGuardar.Size = new System.Drawing.Size(120, 36);
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Standard;

            btnCancelar = new System.Windows.Forms.Button();
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Text = "Cancelar";
            btnCancelar.AutoSize = true;
            btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnCancelar.Size = new System.Drawing.Size(120, 36);

            // Alinear a la derecha
            btnCancelar.Location = new System.Drawing.Point(this.ClientSize.Width - 120 - 24, 12);
            btnGuardar.Location = new System.Drawing.Point(this.ClientSize.Width - (120 * 2) - 32, 12);
            btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            footerPanel.Controls.Add(btnGuardar);
            footerPanel.Controls.Add(btnCancelar);

            // ===== Agregar todo al Form =====
            this.Controls.Add(footerPanel);
            this.Controls.Add(grpDatos);
            this.Controls.Add(headerPanel);

            // ===== Config global =====
            this.AcceptButton = btnGuardar;
            this.CancelButton = btnCancelar;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

            // ===== Eventos clave (puedes mover el código a FormTurnos.cs) =====
            // btnGuardar.Click += (s, e) => this.OnGuardar();
            // btnCancelar.Click += (s, e) => this.Close();
            // this.KeyDown += (s, e) => { if (e.KeyCode == System.Windows.Forms.Keys.Escape) this.Close(); };
        }
        #endregion
    }
}

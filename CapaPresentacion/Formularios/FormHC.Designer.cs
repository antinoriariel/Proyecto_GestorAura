namespace CapaPresentacion.Formularios
{
    partial class FormHC
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label lblHeader;

        // Contenido
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.TableLayoutPanel grid;

        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cboPaciente;

        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;

        private System.Windows.Forms.Label lblMotivoConsulta;
        private System.Windows.Forms.TextBox txtMotivoConsulta;

        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;

        private System.Windows.Forms.Label lblImpDiag;
        private System.Windows.Forms.TextBox txtImpresionDiag;

        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;

        private System.Windows.Forms.Label lblIndicaciones;
        private System.Windows.Forms.TextBox txtIndicaciones;

        private System.Windows.Forms.Label lblAntecedentes;
        private System.Windows.Forms.TextBox txtAntecedentes;

        private System.Windows.Forms.Label lblEvolucion;
        private System.Windows.Forms.TextBox txtEvolucion;

        private System.Windows.Forms.Label lblImpGral;
        private System.Windows.Forms.TextBox txtImpresionGral;

        private System.Windows.Forms.Label lblExamenes;
        private System.Windows.Forms.TextBox txtExamenes;

        private System.Windows.Forms.Label lblTipoConsulta;
        private System.Windows.Forms.TextBox txtTipoConsulta;

        // Footer
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button bGuardar;
        private System.Windows.Forms.Button bCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ===== Form =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 244, 246);
            this.ClientSize = new System.Drawing.Size(980, 720);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historia clínica";
            this.KeyPreview = true;

            // ===== Header =====
            headerPanel = new System.Windows.Forms.Panel();
            headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            headerPanel.Height = 64;
            headerPanel.BackColor = System.Drawing.Color.FromArgb(41, 57, 71);

            picHeader = new System.Windows.Forms.PictureBox();
            picHeader.Size = new System.Drawing.Size(40, 40);
            picHeader.Location = new System.Drawing.Point(16, 12);
            picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // Si no tenés este recurso, comentá la línea siguiente o usá otro:
            picHeader.Image = Properties.Resources.medicalNotesIcon;

            lblHeader = new System.Windows.Forms.Label();
            lblHeader.AutoSize = true;
            lblHeader.Location = new System.Drawing.Point(64, 18);
            lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            lblHeader.ForeColor = System.Drawing.Color.White;
            lblHeader.Text = "Historia clínica";

            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);

            // ===== GroupBox + Grid =====
            grpDatos = new System.Windows.Forms.GroupBox();
            grpDatos.Text = "Datos de la consulta";
            grpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            grpDatos.Padding = new System.Windows.Forms.Padding(16);
            grpDatos.BackColor = System.Drawing.Color.White;

            grid = new System.Windows.Forms.TableLayoutPanel();
            grid.ColumnCount = 2;
            grid.RowCount = 12;
            grid.Dock = System.Windows.Forms.DockStyle.Fill;
            grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F)); // labels
            grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // Alturas: compactas para cabeceras, más altas para multilínea
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // Paciente
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // Estado
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // Motivo
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // FechaHora
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Imp. Diagnóstico
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Diagnóstico
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Indicaciones
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Antecedentes
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Evolución
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Imp. Gral
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Exámenes
            grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F)); // Tipo consulta

            // Paciente
            lblPaciente = new System.Windows.Forms.Label();
            lblPaciente.Text = "Paciente";
            lblPaciente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblPaciente.AutoSize = true;

            cboPaciente = new System.Windows.Forms.ComboBox();
            cboPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPaciente.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cboPaciente.MaxDropDownItems = 12;

            // Estado
            lblEstado = new System.Windows.Forms.Label();
            lblEstado.Text = "Estado";
            lblEstado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblEstado.AutoSize = true;

            cboEstado = new System.Windows.Forms.ComboBox();
            cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEstado.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Motivo
            lblMotivoConsulta = new System.Windows.Forms.Label();
            lblMotivoConsulta.Text = "Motivo de consulta";
            lblMotivoConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblMotivoConsulta.AutoSize = true;

            txtMotivoConsulta = new System.Windows.Forms.TextBox();
            txtMotivoConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtMotivoConsulta.PlaceholderText = "Ej.: control, dolor abdominal, seguimiento…";

            // Fecha/hora
            lblFechaHora = new System.Windows.Forms.Label();
            lblFechaHora.Text = "Fecha y hora";
            lblFechaHora.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblFechaHora.AutoSize = true;

            dtpFechaHora = new System.Windows.Forms.DateTimePicker();
            dtpFechaHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpFechaHora.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy - HH:mm";
            dtpFechaHora.Anchor = System.Windows.Forms.AnchorStyles.Left;
            dtpFechaHora.ShowUpDown = true;

            // Impresión diagnóstica
            lblImpDiag = new System.Windows.Forms.Label();
            lblImpDiag.Text = "Impresión diagnóstica";
            lblImpDiag.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblImpDiag.AutoSize = true;

            txtImpresionDiag = new System.Windows.Forms.TextBox();
            txtImpresionDiag.Multiline = true;
            txtImpresionDiag.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtImpresionDiag.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Diagnóstico
            lblDiagnostico = new System.Windows.Forms.Label();
            lblDiagnostico.Text = "Diagnóstico";
            lblDiagnostico.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblDiagnostico.AutoSize = true;

            txtDiagnostico = new System.Windows.Forms.TextBox();
            txtDiagnostico.Multiline = true;
            txtDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtDiagnostico.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Indicaciones
            lblIndicaciones = new System.Windows.Forms.Label();
            lblIndicaciones.Text = "Indicaciones";
            lblIndicaciones.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblIndicaciones.AutoSize = true;

            txtIndicaciones = new System.Windows.Forms.TextBox();
            txtIndicaciones.Multiline = true;
            txtIndicaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtIndicaciones.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Antecedentes
            lblAntecedentes = new System.Windows.Forms.Label();
            lblAntecedentes.Text = "Antecedentes";
            lblAntecedentes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblAntecedentes.AutoSize = true;

            txtAntecedentes = new System.Windows.Forms.TextBox();
            txtAntecedentes.Multiline = true;
            txtAntecedentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtAntecedentes.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Evolución
            lblEvolucion = new System.Windows.Forms.Label();
            lblEvolucion.Text = "Evolución";
            lblEvolucion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblEvolucion.AutoSize = true;

            txtEvolucion = new System.Windows.Forms.TextBox();
            txtEvolucion.Multiline = true;
            txtEvolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtEvolucion.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Impresión general
            lblImpGral = new System.Windows.Forms.Label();
            lblImpGral.Text = "Impresión general";
            lblImpGral.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblImpGral.AutoSize = true;

            txtImpresionGral = new System.Windows.Forms.TextBox();
            txtImpresionGral.Multiline = true;
            txtImpresionGral.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtImpresionGral.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Exámenes
            lblExamenes = new System.Windows.Forms.Label();
            lblExamenes.Text = "Exámenes";
            lblExamenes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblExamenes.AutoSize = true;

            txtExamenes = new System.Windows.Forms.TextBox();
            txtExamenes.Multiline = true;
            txtExamenes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtExamenes.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Tipo de consulta
            lblTipoConsulta = new System.Windows.Forms.Label();
            lblTipoConsulta.Text = "Tipo de consulta";
            lblTipoConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblTipoConsulta.AutoSize = true;

            txtTipoConsulta = new System.Windows.Forms.TextBox();
            txtTipoConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Agregar controles al grid
            grid.Controls.Add(lblPaciente, 0, 0); grid.Controls.Add(cboPaciente, 1, 0);
            grid.Controls.Add(lblEstado, 0, 1); grid.Controls.Add(cboEstado, 1, 1);
            grid.Controls.Add(lblMotivoConsulta, 0, 2); grid.Controls.Add(txtMotivoConsulta, 1, 2);
            grid.Controls.Add(lblFechaHora, 0, 3); grid.Controls.Add(dtpFechaHora, 1, 3);
            grid.Controls.Add(lblImpDiag, 0, 4); grid.Controls.Add(txtImpresionDiag, 1, 4);
            grid.Controls.Add(lblDiagnostico, 0, 5); grid.Controls.Add(txtDiagnostico, 1, 5);
            grid.Controls.Add(lblIndicaciones, 0, 6); grid.Controls.Add(txtIndicaciones, 1, 6);
            grid.Controls.Add(lblAntecedentes, 0, 7); grid.Controls.Add(txtAntecedentes, 1, 7);
            grid.Controls.Add(lblEvolucion, 0, 8); grid.Controls.Add(txtEvolucion, 1, 8);
            grid.Controls.Add(lblImpGral, 0, 9); grid.Controls.Add(txtImpresionGral, 1, 9);
            grid.Controls.Add(lblExamenes, 0, 10); grid.Controls.Add(txtExamenes, 1, 10);
            grid.Controls.Add(lblTipoConsulta, 0, 11); grid.Controls.Add(txtTipoConsulta, 1, 11);

            grpDatos.Controls.Add(grid);

            // ===== Footer =====
            footerPanel = new System.Windows.Forms.Panel();
            footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            footerPanel.Height = 64;
            footerPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);

            bGuardar = new System.Windows.Forms.Button();
            bGuardar.Text = "Guardar";
            bGuardar.AutoSize = true;
            bGuardar.Size = new System.Drawing.Size(120, 36);
            bGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            bCancelar = new System.Windows.Forms.Button();
            bCancelar.Text = "Cancelar";
            bCancelar.AutoSize = true;
            bCancelar.Size = new System.Drawing.Size(120, 36);
            bCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // Posicionar a la derecha
            bCancelar.Location = new System.Drawing.Point(this.ClientSize.Width - 120 - 24, 12);
            bGuardar.Location = new System.Drawing.Point(this.ClientSize.Width - (120 * 2) - 32, 12);

            footerPanel.Controls.Add(bGuardar);
            footerPanel.Controls.Add(bCancelar);

            // ===== Agregar al form =====
            this.Controls.Add(footerPanel);
            this.Controls.Add(grpDatos);
            this.Controls.Add(headerPanel);

            // ===== Config global =====
            this.AcceptButton = bGuardar;
            this.CancelButton = bCancelar;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;

            // Eventos mínimos (podés moverlos al .cs)
            // bGuardar.Click += (s, e) => this.OnGuardarHC();
            // bCancelar.Click += (s, e) => this.Close();
            // this.KeyDown += (s, e) => { if (e.KeyCode == System.Windows.Forms.Keys.Escape) this.Close(); };

            // Si ya usabas FormHC_Load, mantenelo:
            this.Load += FormHC_Load;
        }
    }
}

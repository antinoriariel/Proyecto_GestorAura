using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormDashHC
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;
        private GroupBox grpFiltros;
        private ComboBox cboPaciente;
        private Label lblPaciente;
        private CheckBox chkFiltrarFecha;
        private DateTimePicker dtpDesde, dtpHasta;
        private Label lblDesde, lblHasta;
        private Button btnBuscar;
        private DataGridView dgvHistorias;
        private FlowLayoutPanel accionesPanel;
        private Button btnEditar, btnAdjuntos, btnExportarPDF;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            picHeader = new PictureBox();
            lblHeader = new Label();
            grpFiltros = new GroupBox();
            lblPaciente = new Label();
            cboPaciente = new ComboBox();
            chkFiltrarFecha = new CheckBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnBuscar = new Button();
            dgvHistorias = new DataGridView();
            accionesPanel = new FlowLayoutPanel();
            btnExportarPDF = new Button();
            btnAdjuntos = new Button();
            btnEditar = new Button();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).BeginInit();
            grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorias).BeginInit();
            accionesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(16, 8, 8, 8);
            headerPanel.Size = new Size(1241, 70);
            headerPanel.TabIndex = 3;
            // 
            // picHeader
            // 
            picHeader.Image = Properties.Resources.hcIcon;
            picHeader.Location = new Point(10, 10);
            picHeader.Name = "picHeader";
            picHeader.Size = new Size(48, 48);
            picHeader.SizeMode = PictureBoxSizeMode.Zoom;
            picHeader.TabIndex = 0;
            picHeader.TabStop = false;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(0, 136, 204);
            lblHeader.Location = new Point(70, 18);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(189, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Historias Clínicas";
            // 
            // grpFiltros
            // 
            grpFiltros.Controls.Add(lblPaciente);
            grpFiltros.Controls.Add(cboPaciente);
            grpFiltros.Controls.Add(chkFiltrarFecha);
            grpFiltros.Controls.Add(lblDesde);
            grpFiltros.Controls.Add(dtpDesde);
            grpFiltros.Controls.Add(lblHasta);
            grpFiltros.Controls.Add(dtpHasta);
            grpFiltros.Controls.Add(btnBuscar);
            grpFiltros.Dock = DockStyle.Top;
            grpFiltros.Location = new Point(0, 70);
            grpFiltros.Name = "grpFiltros";
            grpFiltros.Padding = new Padding(10);
            grpFiltros.Size = new Size(1241, 90);
            grpFiltros.TabIndex = 2;
            grpFiltros.TabStop = false;
            grpFiltros.Text = "Filtros";
            // 
            // lblPaciente
            // 
            lblPaciente.AutoSize = true;
            lblPaciente.Location = new Point(15, 25);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(55, 15);
            lblPaciente.TabIndex = 0;
            lblPaciente.Text = "Paciente:";
            // 
            // cboPaciente
            // 
            cboPaciente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaciente.Location = new Point(85, 22);
            cboPaciente.Name = "cboPaciente";
            cboPaciente.Size = new Size(200, 23);
            cboPaciente.TabIndex = 1;
            // 
            // chkFiltrarFecha
            // 
            chkFiltrarFecha.AutoSize = true;
            chkFiltrarFecha.Location = new Point(310, 24);
            chkFiltrarFecha.Name = "chkFiltrarFecha";
            chkFiltrarFecha.Size = new Size(109, 19);
            chkFiltrarFecha.TabIndex = 2;
            chkFiltrarFecha.Text = "Filtrar por fecha";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(440, 25);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(42, 15);
            lblDesde.TabIndex = 3;
            lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(490, 22);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(130, 23);
            dtpDesde.TabIndex = 4;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(640, 25);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(40, 15);
            lblHasta.TabIndex = 5;
            lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(690, 22);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(130, 23);
            dtpHasta.TabIndex = 6;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(0, 136, 204);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(850, 22);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 23);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvHistorias
            // 
            dgvHistorias.BackgroundColor = Color.White;
            dgvHistorias.Dock = DockStyle.Fill;
            dgvHistorias.Location = new Point(0, 160);
            dgvHistorias.Name = "dgvHistorias";
            dgvHistorias.Size = new Size(1241, 233);
            dgvHistorias.TabIndex = 0;
            // 
            // accionesPanel
            // 
            accionesPanel.BackColor = Color.WhiteSmoke;
            accionesPanel.Controls.Add(btnExportarPDF);
            accionesPanel.Controls.Add(btnAdjuntos);
            accionesPanel.Controls.Add(btnEditar);
            accionesPanel.Dock = DockStyle.Bottom;
            accionesPanel.FlowDirection = FlowDirection.RightToLeft;
            accionesPanel.Location = new Point(0, 393);
            accionesPanel.Name = "accionesPanel";
            accionesPanel.Padding = new Padding(10);
            accionesPanel.Size = new Size(1241, 55);
            accionesPanel.TabIndex = 1;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.BackColor = Color.FromArgb(0, 136, 204);
            btnExportarPDF.FlatStyle = FlatStyle.Flat;
            btnExportarPDF.ForeColor = Color.White;
            btnExportarPDF.Location = new Point(1098, 13);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(120, 23);
            btnExportarPDF.TabIndex = 0;
            btnExportarPDF.Text = "Exportar PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // btnAdjuntos
            // 
            btnAdjuntos.BackColor = Color.FromArgb(102, 102, 102);
            btnAdjuntos.FlatStyle = FlatStyle.Flat;
            btnAdjuntos.ForeColor = Color.White;
            btnAdjuntos.Location = new Point(992, 13);
            btnAdjuntos.Name = "btnAdjuntos";
            btnAdjuntos.Size = new Size(100, 23);
            btnAdjuntos.TabIndex = 1;
            btnAdjuntos.Text = "Adjuntos";
            btnAdjuntos.UseVisualStyleBackColor = false;
            btnAdjuntos.Click += btnAdjuntos_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(151, 151, 151);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(886, 13);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 23);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // FormDashHC
            // 
            ClientSize = new Size(1241, 448);
            Controls.Add(dgvHistorias);
            Controls.Add(accionesPanel);
            Controls.Add(grpFiltros);
            Controls.Add(headerPanel);
            Name = "FormDashHC";
            Text = "Panel de Historias Clínicas";
            WindowState = FormWindowState.Maximized;
            Load += FormDashHC_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).EndInit();
            grpFiltros.ResumeLayout(false);
            grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorias).EndInit();
            accionesPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

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

        private GroupBox grpDatos;
        private ComboBox cboPaciente;
        private CheckBox chkFiltrarFecha;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button btnBuscar;
        private DataGridView dgvHistorias;

        private Panel footerPanel;
        private FlowLayoutPanel flowFooter;
        private Button btnEditar;
        private Button btnAdjuntos;
        private Button btnExportarPDF;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(1100, 720);
            Font = new Font("Consolas", 12F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Historias Clínicas";
            Padding = new Padding(21, 12, 21, 12);

            // ===== HEADER =====
            headerPanel = new Panel
            {
                BackColor = Color.FromArgb(41, 57, 71),
                Dock = DockStyle.Top,
                Height = 48
            };

            picHeader = new PictureBox
            {
                Image = Properties.Resources.hcIcon,
                Location = new Point(14, 9),
                Size = new Size(35, 30),
                SizeMode = PictureBoxSizeMode.Zoom,
                TabStop = false
            };

            lblHeader = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(56, 13),
                Text = "Panel de Historias Clínicas"
            };

            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);

            // ===== GRUPO PRINCIPAL =====
            grpDatos = new GroupBox
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(14, 12, 14, 12),
                Text = "Listado de Historias Clínicas"
            };

            // ===== FILTROS SUPERIORES =====
            cboPaciente = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 250,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Margin = new Padding(4)
            };

            chkFiltrarFecha = new CheckBox
            {
                Text = "Filtrar por fecha",
                AutoSize = true,
                Margin = new Padding(4),
                Checked = false
            };

            dtpDesde = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Width = 130,
                Enabled = false,
                Margin = new Padding(4)
            };

            dtpHasta = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Width = 130,
                Enabled = false,
                Margin = new Padding(4)
            };

            chkFiltrarFecha.CheckedChanged += (s, e) =>
            {
                dtpDesde.Enabled = dtpHasta.Enabled = chkFiltrarFecha.Checked;
            };

            btnBuscar = new Button
            {
                Text = "Buscar",
                BackColor = Color.FromArgb(0, 136, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                AutoSize = true,
                Margin = new Padding(6, 2, 0, 2)
            };
            btnBuscar.FlatAppearance.BorderSize = 0;

            FlowLayoutPanel filtrosPanel = new()
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(4),
                WrapContents = false
            };
            filtrosPanel.Controls.Add(new Label { Text = "Paciente:", AutoSize = true, Margin = new Padding(4, 6, 4, 4) });
            filtrosPanel.Controls.Add(cboPaciente);
            filtrosPanel.Controls.Add(chkFiltrarFecha);
            filtrosPanel.Controls.Add(new Label { Text = "Desde:", AutoSize = true, Margin = new Padding(16, 6, 4, 4) });
            filtrosPanel.Controls.Add(dtpDesde);
            filtrosPanel.Controls.Add(new Label { Text = "Hasta:", AutoSize = true, Margin = new Padding(8, 6, 4, 4) });
            filtrosPanel.Controls.Add(dtpHasta);
            filtrosPanel.Controls.Add(btnBuscar);

            // ===== GRILLA =====
            dgvHistorias = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            dgvHistorias.DataBindingComplete += (s, e) =>
            {
                if (dgvHistorias.Columns.Contains("id_paciente"))
                    dgvHistorias.Columns.Remove("id_paciente");
            };

            grpDatos.Controls.Add(dgvHistorias);
            grpDatos.Controls.Add(filtrosPanel);

            // ===== FOOTER =====
            footerPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 56,
                Padding = new Padding(0, 8, 12, 8)
            };

            flowFooter = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false
            };

            btnExportarPDF = new Button
            {
                Text = "Exportar PDF",
                AutoSize = true,
                BackColor = Color.FromArgb(41, 57, 71),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(8, 8, 0, 8)
            };
            btnExportarPDF.FlatAppearance.BorderSize = 0;

            btnAdjuntos = new Button
            {
                Text = "Ver Adjuntos",
                AutoSize = true,
                BackColor = Color.FromArgb(0, 136, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(8, 8, 0, 8)
            };
            btnAdjuntos.FlatAppearance.BorderSize = 0;

            btnEditar = new Button
            {
                Text = "Editar HC",
                AutoSize = true,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(8, 8, 0, 8)
            };
            btnEditar.FlatAppearance.BorderSize = 0;

            flowFooter.Controls.Add(btnExportarPDF);
            flowFooter.Controls.Add(btnAdjuntos);
            flowFooter.Controls.Add(btnEditar);
            footerPanel.Controls.Add(flowFooter);

            // ===== ENSAMBLADO =====
            Controls.Add(grpDatos);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);

            // === Eventos ===
            Load += FormDashHC_Load;
            btnBuscar.Click += btnBuscar_Click;
            btnEditar.Click += btnEditar_Click;
            btnAdjuntos.Click += btnAdjuntos_Click;
            btnExportarPDF.Click += btnExportarPDF_Click;
        }
    }
}

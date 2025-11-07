using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormTurnosSecretaria
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        private GroupBox grpFiltros;
        private TableLayoutPanel gridFiltros;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblEstado;
        private ComboBox cboEstado;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private CheckBox chkSoloPendientes;
        private FlowLayoutPanel pnlBotoneraFiltros;
        private Button btnHoy;
        private Button btnLimpiar;
        private Button btnActualizar;

        private GroupBox grpListado;
        private DataGridView dgvTurnos;

        private Panel footerPanel;
        private Label lblHint;

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

            headerPanel = new Panel();
            picHeader = new PictureBox();
            lblHeader = new Label();

            grpFiltros = new GroupBox();
            gridFiltros = new TableLayoutPanel();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblEstado = new Label();
            cboEstado = new ComboBox();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            chkSoloPendientes = new CheckBox();
            pnlBotoneraFiltros = new FlowLayoutPanel();
            btnHoy = new Button();
            btnLimpiar = new Button();
            btnActualizar = new Button();

            grpListado = new GroupBox();
            dgvTurnos = new DataGridView();

            footerPanel = new Panel();
            lblHint = new Label();

            SuspendLayout();

            // ===== Header =====
            headerPanel.BackColor = Color.FromArgb(41, 57, 71);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 52;
            headerPanel.Padding = new Padding(14, 9, 14, 9);
            headerPanel.Controls.Add(picHeader);
            headerPanel.Controls.Add(lblHeader);

            picHeader.Image = Properties.Resources.medicoTurno;
            picHeader.SizeMode = PictureBoxSizeMode.Zoom;
            picHeader.Location = new Point(14, 10);
            picHeader.Size = new Size(34, 32);

            lblHeader.AutoSize = true;
            lblHeader.ForeColor = Color.White;
            lblHeader.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblHeader.Location = new Point(56, 12);
            lblHeader.Text = "Agenda del médico";

            // ===== Filtros =====
            grpFiltros.Text = "Filtros";
            grpFiltros.Dock = DockStyle.Top;
            grpFiltros.Padding = new Padding(14);
            grpFiltros.Height = 132;

            gridFiltros.Dock = DockStyle.Fill;
            gridFiltros.ColumnCount = 6;
            gridFiltros.RowCount = 2;
            gridFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            gridFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
            gridFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            gridFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            gridFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            gridFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            gridFiltros.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            gridFiltros.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

            lblFecha.Text = "Fecha";
            lblFecha.Anchor = AnchorStyles.Left;
            lblFecha.AutoSize = true;

            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy";
            dtpFecha.Anchor = AnchorStyles.Left;
            dtpFecha.Width = 200;

            lblEstado.Text = "Estado";
            lblEstado.Anchor = AnchorStyles.Left;
            lblEstado.AutoSize = true;

            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Anchor = AnchorStyles.Left;
            cboEstado.Width = 160;

            lblBuscar.Text = "Buscar";
            lblBuscar.Anchor = AnchorStyles.Left;
            lblBuscar.AutoSize = true;

            txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.PlaceholderText = "Paciente, motivo…";

            chkSoloPendientes.Text = "Solo pendientes";
            chkSoloPendientes.AutoSize = true;
            chkSoloPendientes.Anchor = AnchorStyles.Left;

            pnlBotoneraFiltros.FlowDirection = FlowDirection.LeftToRight;
            pnlBotoneraFiltros.Dock = DockStyle.Fill;
            pnlBotoneraFiltros.WrapContents = false;

            btnHoy.Text = "Hoy";
            btnHoy.AutoSize = true;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.AutoSize = true;
            btnActualizar.Text = "Actualizar";
            btnActualizar.AutoSize = true;

            pnlBotoneraFiltros.Controls.AddRange(new Control[] { btnHoy, btnLimpiar, btnActualizar });

            // Fila 0
            gridFiltros.Controls.Add(lblFecha, 0, 0);
            gridFiltros.Controls.Add(dtpFecha, 1, 0);
            gridFiltros.Controls.Add(lblEstado, 2, 0);
            gridFiltros.Controls.Add(cboEstado, 3, 0);
            gridFiltros.Controls.Add(lblBuscar, 4, 0);
            gridFiltros.Controls.Add(txtBuscar, 5, 0);
            // Fila 1
            gridFiltros.Controls.Add(chkSoloPendientes, 1, 1);
            gridFiltros.Controls.Add(pnlBotoneraFiltros, 5, 1);

            grpFiltros.Controls.Add(gridFiltros);

            // ===== Listado =====
            grpListado.Text = "Turnos";
            grpListado.Dock = DockStyle.Fill;
            grpListado.Padding = new Padding(14);

            dgvTurnos.Dock = DockStyle.Fill;
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.MultiSelect = false;
            dgvTurnos.ReadOnly = true;
            dgvTurnos.RowHeadersVisible = false;
            dgvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnos.BackgroundColor = Color.White;
            dgvTurnos.BorderStyle = BorderStyle.None;
            dgvTurnos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 57, 71);
            dgvTurnos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTurnos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvTurnos.EnableHeadersVisualStyles = false;
            dgvTurnos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTurnos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            grpListado.Controls.Add(dgvTurnos);

            // ===== Footer =====
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Height = 36;
            footerPanel.Padding = new Padding(14, 6, 14, 6);

            lblHint.AutoSize = true;
            lblHint.Text = "Doble clic para abrir turno. Botones para acciones rápidas.";
            footerPanel.Controls.Add(lblHint);

            // ===== Form =====
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new System.Drawing.Size(960, 560);
            Controls.Add(grpListado);
            Controls.Add(grpFiltros);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "FormTurnosMedico";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Turnos del Médico";

            ResumeLayout(false);
        }
        #endregion
    }
}

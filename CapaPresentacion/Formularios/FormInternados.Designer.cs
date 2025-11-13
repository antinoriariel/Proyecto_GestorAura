using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    partial class FormInternados
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private PictureBox picHeader;
        private Label lblHeader;

        private GroupBox grpPacientes;
        private DataGridView dgvPacientes;

        private Panel footerPanel;
        private Button btnActualizar;
        private Button btnCerrar;

        private DataGridViewTextBoxColumn colIdPaciente;
        private DataGridViewTextBoxColumn colDni;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colSexo;
        private DataGridViewTextBoxColumn colFechaNac;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDireccion;
        private DataGridViewTextBoxColumn colGrupo;
        private DataGridViewTextBoxColumn colAlergias;
        private DataGridViewCheckBoxColumn colActivo;

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
            grpPacientes = new GroupBox();
            dgvPacientes = new DataGridView();
            footerPanel = new Panel();
            btnActualizar = new Button();
            btnCerrar = new Button();
            colIdPaciente = new DataGridViewTextBoxColumn();
            colDni = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colSexo = new DataGridViewTextBoxColumn();
            colFechaNac = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colGrupo = new DataGridViewTextBoxColumn();
            colAlergias = new DataGridViewTextBoxColumn();
            colActivo = new DataGridViewCheckBoxColumn();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).BeginInit();
            grpPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
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
            picHeader.Image = Properties.Resources.hospitalBedIcon;
            picHeader.Location = new Point(14, 9);
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
            lblHeader.Size = new Size(189, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Datos de pacientes";
            // 
            // grpPacientes
            // 
            grpPacientes.BackColor = Color.White;
            grpPacientes.Controls.Add(dgvPacientes);
            grpPacientes.Dock = DockStyle.Fill;
            grpPacientes.Location = new Point(21, 62);
            grpPacientes.Name = "grpPacientes";
            grpPacientes.Padding = new Padding(14, 12, 14, 12);
            grpPacientes.Size = new Size(760, 360);
            grpPacientes.TabIndex = 1;
            grpPacientes.TabStop = false;
            grpPacientes.Text = "Listado de pacientes";
            // 
            // dgvPacientes
            // 
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.AllowUserToDeleteRows = false;
            dgvPacientes.AllowUserToResizeRows = false;
            dgvPacientes.AutoGenerateColumns = false;
            dgvPacientes.BackgroundColor = Color.White;
            dgvPacientes.BorderStyle = BorderStyle.None;
            dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacientes.Columns.AddRange(new DataGridViewColumn[]
            {
                colIdPaciente,
                colDni,
                colApellido,
                colNombre,
                colSexo,
                colFechaNac,
                colTelefono,
                colEmail,
                colDireccion,
                colGrupo,
                colAlergias,
                colActivo
            });
            dgvPacientes.Dock = DockStyle.Fill;
            dgvPacientes.Location = new Point(14, 28);
            dgvPacientes.MultiSelect = false;
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.ReadOnly = true;
            dgvPacientes.RowHeadersVisible = false;
            dgvPacientes.RowTemplate.Height = 25;
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPacientes.DataBindingComplete += dgvPacientes_DataBindingComplete;
            dgvPacientes.TabIndex = 0;
            // 
            // Columnas DataGridView
            // 
            colIdPaciente.DataPropertyName = "IdPaciente";
            colIdPaciente.HeaderText = "ID";
            colIdPaciente.Name = "colIdPaciente";
            colIdPaciente.ReadOnly = true;
            colIdPaciente.Visible = false;

            colDni.DataPropertyName = "Dni";
            colDni.HeaderText = "DNI";
            colDni.Name = "colDni";
            colDni.ReadOnly = true;

            colApellido.DataPropertyName = "Apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;

            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;

            colSexo.DataPropertyName = "Sexo";
            colSexo.HeaderText = "Sexo";
            colSexo.Name = "colSexo";
            colSexo.ReadOnly = true;

            colFechaNac.DataPropertyName = "FechaNac";
            colFechaNac.HeaderText = "F. Nacimiento";
            colFechaNac.Name = "colFechaNac";
            colFechaNac.ReadOnly = true;
            colFechaNac.DefaultCellStyle.Format = "dd/MM/yyyy";

            colTelefono.DataPropertyName = "Telefono";
            colTelefono.HeaderText = "Teléfono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;

            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;

            colDireccion.DataPropertyName = "Direccion";
            colDireccion.HeaderText = "Dirección";
            colDireccion.Name = "colDireccion";
            colDireccion.ReadOnly = true;

            colGrupo.DataPropertyName = "GrupoSanguineo";
            colGrupo.HeaderText = "Grupo Sanguíneo";
            colGrupo.Name = "colGrupo";
            colGrupo.ReadOnly = true;

            colAlergias.DataPropertyName = "Alergias";
            colAlergias.HeaderText = "Alergias";
            colAlergias.Name = "colAlergias";
            colAlergias.ReadOnly = true;

            colActivo.DataPropertyName = "Activo";
            colActivo.HeaderText = "Activo";
            colActivo.Name = "colActivo";
            colActivo.ReadOnly = true;
            colActivo.TrueValue = true;
            colActivo.FalseValue = false;
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
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
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
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += (s, e) => this.Close();
            // 
            // FormInternados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 244, 246);
            ClientSize = new Size(802, 482);
            ControlBox = false;
            Controls.Add(grpPacientes);
            Controls.Add(footerPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInternados";
            Padding = new Padding(21, 12, 21, 12);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Datos de pacientes";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeader).EndInit();
            grpPacientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            footerPanel.ResumeLayout(false);
            footerPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormInternados : Form
    {
        public FormInternados()
        {
            InitializeComponent();
            CargarCamas();
        }

        private void CargarCamas()
        {
            tblCamas.Controls.Clear();

            // Datos de ejemplo (nombre, apellido, dni, estado)
            string[,] camas = new string[,]
            {
                { "101", "Juan", "Pérez", "30123456", "Ocupada" },
                { "102", "", "", "", "Libre" },
                { "201", "María", "Gómez", "28987654", "Ocupada" },
                { "202", "", "", "", "Libre" },
                { "301", "Pedro", "Ruiz", "33222111", "Ocupada" },
                { "302", "", "", "", "Libre" },
                { "401", "Ana", "Torres", "27888999", "Ocupada" },
                { "402", "", "", "", "Libre" },
                { "501", "Carlos", "Díaz", "30111222", "Ocupada" },
                { "502", "", "", "", "Libre" },
                { "601", "", "", "", "Libre" },
                { "602", "Laura", "Rivas", "35666111", "Ocupada" }
            };

            int total = camas.GetLength(0);
            for (int i = 0; i < total; i++)
            {
                var panelCama = CrearPanelCama(
                    camas[i, 0],
                    camas[i, 1],
                    camas[i, 2],
                    camas[i, 3],
                    camas[i, 4]
                );
                tblCamas.Controls.Add(panelCama);
            }
        }

        private Panel CrearPanelCama(string nroCama, string nombre, string apellido, string dni, string estado)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(6),
                BackColor = estado == "Ocupada"
                    ? Color.LightCoral
                    : Color.LightGreen,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Layout interno para alinear ícono y texto
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, estado == "Ocupada" ? 60F : 0F)); // espacio para ícono solo si está ocupada
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            // Solo mostrar ícono si está ocupada
            if (estado == "Ocupada")
            {
                var picCama = new PictureBox
                {
                    Image = Properties.Resources.hospitalBedIcon,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(20) // padding de 20px
                };
                layout.Controls.Add(picCama, 0, 0);
            }

            // Texto
            var lbl = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                Text =
                    $"Cama {nroCama}\n" +
                    $"{(string.IsNullOrEmpty(nombre) ? "—" : nombre + " " + apellido)}\n" +
                    $"{(string.IsNullOrEmpty(dni) ? "" : "DNI: " + dni)}"
            };

            layout.Controls.Add(lbl, 0, 1);

            panel.Controls.Add(layout);
            return panel;
        }
    }
}

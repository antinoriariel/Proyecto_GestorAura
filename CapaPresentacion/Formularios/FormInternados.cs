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

            // Datos de ejemplo (hardcode)
            string[,] camas = new string[,]
            {
                { "101", "Juan Pérez", "Ocupada" },
                { "102", "", "Libre" },
                { "201", "María Gómez", "Ocupada" },
                { "202", "", "Libre" },
                { "301", "Pedro Ruiz", "Ocupada" },
                { "302", "", "Libre" },
                { "401", "Ana Torres", "Ocupada" },
                { "402", "", "Libre" },
                { "501", "Carlos Díaz", "Ocupada" },
                { "502", "", "Libre" },
                { "601", "", "Libre" },
                { "602", "Laura Rivas", "Ocupada" }
            };

            int total = camas.GetLength(0);
            for (int i = 0; i < total; i++)
            {
                var panelCama = CrearPanelCama(
                    camas[i, 0],
                    camas[i, 1],
                    camas[i, 2]
                );
                tblCamas.Controls.Add(panelCama);
            }
        }

        private Panel CrearPanelCama(string nroCama, string paciente, string estado)
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

            var lbl = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Text = $"Cama {nroCama}\n{(string.IsNullOrEmpty(paciente) ? "—" : paciente)}",
                ForeColor = Color.Black
            };

            panel.Controls.Add(lbl);
            return panel;
        }
    }
}

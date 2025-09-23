using System;
using System.Windows.Forms;
using CapaPresentacion.Controles;
using CapaPresentacion.Formularios;

namespace CapaPresentacion
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            // MDI
            this.IsMdiContainer = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class MantenimientoUC: UserControl
    {
        private readonly ElementosBajasCN mantenimientoCN;
        public MantenimientoUC(ElementosBajasCN mantenimientoCN)
        {
            InitializeComponent();
            this.mantenimientoCN = mantenimientoCN;
        }

        public void MostrarDatos()
        {
            var elementos = mantenimientoCN.GetAllElementos();
            dataGridView1.DataSource = elementos.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.MappersDTO;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class DevolucionUC: UserControl
    {
        private readonly DevolucionCN devolucionCN = null!;
        public DevolucionUC(DevolucionCN devolucionCN)
        {
            InitializeComponent();

            this.devolucionCN = devolucionCN;
        }

        public void MostrarDevoluciones()
        {
            dataGridView1.DataSource = devolucionCN.ObtenerElementos();
        }
    }
}

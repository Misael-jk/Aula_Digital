using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class CarritoUC : UserControl
    {
        private readonly CarritosCN carritosCN = null!;
        public CarritoUC(CarritosCN carritosCN)
        {
            InitializeComponent();

            this.carritosCN = carritosCN;
        }

        public void MostrarCarrito()
        {
            dataGridView1.DataSource = carritosCN.ListarCarritos();
        }
    }
}

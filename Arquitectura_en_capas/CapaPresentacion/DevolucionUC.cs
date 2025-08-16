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

namespace CapaPresentacion
{
    public partial class DevolucionUC: UserControl
    {
        private readonly MapperDevoluciones mapperDevoluciones = null!;
        public DevolucionUC(MapperDevoluciones mapperDevoluciones)
        {
            InitializeComponent();

            this.mapperDevoluciones = mapperDevoluciones;
        }

        public void MostrarDevoluciones()
        {
            dataGridView1.DataSource = mapperDevoluciones.GetAllDTO();
        }
    }
}

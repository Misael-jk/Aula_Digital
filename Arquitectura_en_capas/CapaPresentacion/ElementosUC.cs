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
    public partial class ElementosUC : UserControl
    {
        private readonly ElementosCN elementosCN = null!;
        public ElementosUC(ElementosCN elementosCN)
        {
            InitializeComponent();
            this.elementosCN = elementosCN;
        }
        
        public void CargarElementos()
        {
            try
            {
                var elementos = elementosCN.ObtenerElementos();
                dataGridView1.DataSource = elementos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los elementos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

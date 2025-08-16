using CapaDatos.Interfaces;
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
    public partial class DocentesUC : UserControl
    {
        private readonly IRepoDocentes repoDocentes = null!; 
        public DocentesUC(IRepoDocentes repoDocentes)
        {
            InitializeComponent();
            this.repoDocentes = repoDocentes;
        }

        public void MostrarDocentes()
        {
            dataGridView1.DataSource = repoDocentes.GetAll();
        }
    }
}

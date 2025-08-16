using CapaDatos.Interfaces;
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
    public partial class CategoriasUC : UserControl
    {
        private readonly IRepoTipoElemento repoTipoElemento = null!;
        public CategoriasUC(IRepoTipoElemento repoTipoElemento)
        {
            InitializeComponent();
            this.repoTipoElemento = repoTipoElemento;
        }

        public void MostrarCategoria()
        {
            dataGridView1.DataSource = repoTipoElemento.GetAll();
        }
    }
}

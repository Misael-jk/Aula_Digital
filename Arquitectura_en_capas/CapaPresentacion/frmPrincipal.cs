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
using CapaDatos.MappersDTO;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        private readonly IDbConnection conexion;
        private readonly ElementosCN _elementosCN;

        public frmPrincipal(IDbConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;

            MapperElementos mapper = new MapperElementos(conexion);
            _elementosCN = new ElementosCN(mapper);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#F5A623");
            panel2.BackColor = ColorTranslator.FromHtml("#4A1F47");

            var listaElementos = _elementosCN.ObtenerElementos();
            dataGridView1.DataSource = listaElementos.ToList();
        }
    }
}

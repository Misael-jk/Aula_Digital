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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#4A1F47");
            panel2.BackColor = ColorTranslator.FromHtml("#4A1F47");
            btnElementos.BackColor = ColorTranslator.FromHtml("#F5A623");
            btnCarritos.BackColor = ColorTranslator.FromHtml("#F5A623");
            btnDocentes.BackColor = ColorTranslator.FromHtml("#F5A623");
            btnPrestamos.BackColor = ColorTranslator.FromHtml("#F5A623");
            btnDevoluciones.BackColor = ColorTranslator.FromHtml("#F5A623");
            btnUsuarios.BackColor = ColorTranslator.FromHtml("#F5A623");
            btnCategorias.BackColor = ColorTranslator.FromHtml("#F5A623");
        }
    }
}

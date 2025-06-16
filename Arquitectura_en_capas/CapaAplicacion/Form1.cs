using System.Data;

namespace Sistema_de_notebooks
{
    public partial class Form1 : Form
    {
        private IDbConnection _conexion;

        public Form1(IDbConnection db)
        {
            InitializeComponent();
            _conexion = db;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

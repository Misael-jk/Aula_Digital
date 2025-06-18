using Sistema_de_notebooks.CapaEntidad;
using Sistema_de_notebooks.CapaDatos.Repos;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sistema_de_notebooks
{
    public partial class Form1 : Form
    {
        private IDbConnection conexion;

        public Form1(IDbConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RepoAlumnos repo = new RepoAlumnos(conexion);

            IEnumerable<Alumnos> alumnos = repo.ListarAlumnos();
            dataGridView1.DataSource = alumnos.ToList();
        }
    }
}

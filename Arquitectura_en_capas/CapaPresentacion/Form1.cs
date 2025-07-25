using Sistema_de_notebooks.CapaEntidad;
using Sistema_de_notebooks.CapaDatos.Repos;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sistema_de_notebooks
{
    public partial class Form1 : Form
    {
        private IDbConnection conexion;
        private RepoElemento repoNotebooks;
        private RepoEstadosNotebook repoEstados;

        public Form1(IDbConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.repoNotebooks = new RepoElemento(conexion);
            this.repoEstados = new RepoEstadosNotebook(conexion);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var todas = repoNotebooks.ListarNotebooks();
            dataGridView1.DataSource = todas;

            var estados = repoEstados.ListarEstadosNotebook();

            comboBoxEstados.DataSource = estados;
            comboBoxEstados.DisplayMember = "estadoNotebook"; 
            comboBoxEstados.ValueMember = "idEstadoNotebook"; 
            comboBoxEstados.SelectedIndex = -1; 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEstados.SelectedValue is int idEstados)
            {
                var filtradas = repoEstados.EstadosDeLaNotebook(idEstados);
                dataGridView1.DataSource = filtradas;
            }
            else
            {
                var todas = repoNotebooks.ListarNotebooks();
                dataGridView1.DataSource = todas;
            }

        }
    }
}


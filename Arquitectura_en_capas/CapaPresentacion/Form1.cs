using CapaEntidad;
using CapaDatos.Repos;
using System.Data;
using CapaNegocio;
using MySql.Data.MySqlClient;
using CapaDatos.Interfaces;
using System.Windows.Forms;
using CapaNegocio.DTOs;
using CapaPresentacion;

namespace Sistema_de_notebooks
{
    public partial class Form1 : Form
    {
        private IDbConnection conexion;
        private readonly ElementosCN _elementoService;
        private readonly RepoTipoElemento repoTipo;
        private readonly RepoEstadosElemento repoEstado;
        private readonly RepoCarritos repoCarrito;

        public Form1(IDbConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;

            var repoElemento = new RepoElemento(conexion);
            repoTipo = new RepoTipoElemento(conexion);
            repoEstado = new RepoEstadosElemento(conexion);
            repoCarrito = new RepoCarritos(conexion);

            _elementoService = new ElementosCN(repoElemento, repoTipo, repoEstado, repoCarrito);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarComboBuscarCarrito();


            var elementos = _elementoService.ObtenerTodosParaMostrar();
            dataGridView1.DataSource = elementos;

        }

        private void CargarCombos()
        {
            cmbTipoElemento.DataSource = repoTipo.GetAll();
            cmbTipoElemento.DisplayMember = "ElementoTipo";
            cmbTipoElemento.ValueMember = "IdTipoElemento";

            cmbEstado.DataSource = repoEstado.GetAll();
            cmbEstado.DisplayMember = "EstadoElementoNombre";
            cmbEstado.ValueMember = "IdEstadoElemento";

            cmbCarrito.DataSource = repoCarrito.GetAll();
            cmbCarrito.DisplayMember = "NumeroSerieCarrito";
            cmbCarrito.ValueMember = "IdCarrito";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var nuevoElemento = new Elemento
            {
                numeroSerie = txtNumeroSerie.Text,
                codigoBarra = txtCodigoBarra.Text,
                IdTipoElemento = (int)cmbTipoElemento.SelectedValue,
                IdEstadoElemento = (int)cmbEstado.SelectedValue,
                IdCarrito = ((int)cmbCarrito.SelectedValue == 0) ? null : (int?)cmbCarrito.SelectedValue
            };

            _elementoService.CrearElemento(nuevoElemento);

            MessageBox.Show("Elemento agregado correctamente.");

            var elementos = _elementoService.ObtenerTodosParaMostrar();
            dataGridView1.DataSource = elementos;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoBarraBuscar.Text.Trim();

            var elemento = _elementoService.ObtenerPorCodigoBarra(codigo);

            if (elemento != null)
            {
                dataGridView1.DataSource = new List<ElementosDTO> { elemento }; // ← lo convierte en lista de uno
            }
            else
            {
                MessageBox.Show("Elemento no encontrado.");
                dataGridView1.DataSource = null;
            }
        }

        private void btnBuscarCarrito_Click(object sender, EventArgs e)
        {
            if (cmbBuscarCarrito.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, seleccioná un carrito válido.");
                return;
            }

            int idCarrito = (int)cmbBuscarCarrito.SelectedValue;

            var elementos = _elementoService.ObtenerPorCarrito(idCarrito).ToList();

            if (elementos.Any())
            {
                dataGridView1.DataSource = elementos;
            }
            else
            {
                MessageBox.Show("No se encontraron elementos para ese carrito.");
                dataGridView1.DataSource = null;
            }
        }
        private void CargarComboBuscarCarrito()
        {
            var carritos = repoCarrito.GetAll().ToList();

            // Insertamos un ítem informativo al principio (Id 0)
            carritos.Insert(0, new Carritos
            {
                IdCarrito = 0,
                NumeroSerieCarrito = "Se",
                DisponibleCarrito = true
            });

            cmbBuscarCarrito.DataSource = carritos;
            cmbBuscarCarrito.DisplayMember = "NumeroSerieCarrito";
            cmbBuscarCarrito.ValueMember = "IdCarrito";
            cmbBuscarCarrito.SelectedIndex = 0; // ← Esto es clave
        }

    }
}


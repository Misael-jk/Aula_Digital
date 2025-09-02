using CapaDatos.MappersDTO;
using CapaDTOs;
using CapaEntidad;
using CapaNegocio;
using Google.Protobuf.Collections;
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
    public partial class Dashboard : UserControl
    {
        private readonly MapperTransaccion mapperTransaccion;
        public Dashboard(MapperTransaccion mapperTransaccion)
        {
            InitializeComponent();
            this.mapperTransaccion = mapperTransaccion;

        }

        public void MostrarDatos()
        {
            var elemento = mapperTransaccion.GetAllDTO();
            dataGridView1.DataSource = elemento.ToList();

            dataGridView1.Columns["IdPrestamo"].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 35;

            dataGridView1.Columns["NombreCurso"].HeaderText = "Curso";
            dataGridView1.Columns["ApellidoDocentes"].HeaderText = "Docente";
            //dataGridView1.Columns["ApellidoEncargados"].HeaderText = "Encargado";
            dataGridView1.Columns["NumeroSerieCarrito"].HeaderText = "Carrito";
            dataGridView1.Columns["EstadoPrestamo"].HeaderText = "Estado";

            dataGridView1.Columns["IdDevolucion"].HeaderText = "ID";
            dataGridView1.Columns[6].Width = 35;

            dataGridView1.RowHeadersVisible = false;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            

            
        }
    }
}

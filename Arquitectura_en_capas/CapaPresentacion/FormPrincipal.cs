using CapaDatos.Interfaces;
using CapaDatos.MappersDTO;
using CapaNegocio;
using CapaDatos.Repos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using CapaDatos.InterfacesDTO;

namespace CapaPresentacion
{
    public partial class FormPrincipal : Form
    {
        #region Variables de User Control
        private Dashboard dashboard;
        private ElementosUC elementosUC;
        private CarritoUC carritoUC;
        private DocentesUC docentesUC;
        private PrestamosUC prestamosUC;
        private DevolucionUC devolucionUC;
        private CategoriasUC categoriasUC;
        private UsuariosUC usuariosUC;
        #endregion

        #region Variables Interface
        private readonly IRepoCarritos repoCarritos;
        private readonly IRepoElemento repoElementos;
        private readonly IRepoTipoElemento repoTipoElemento;
        private readonly IRepoDocentes repoDocentes;
        private readonly IRepoPrestamos repoPrestamos;
        private readonly IRepoPrestamoDetalle repoPrestamoDetalle;
        private readonly IRepoDevolucion repoDevolucion;
        private readonly IRepoUsuarios repoUsuarios;
        private readonly IRepoRoles repoRoles;
        #endregion

        #region Variables Mappers Interface
        private readonly MapperElementos mapperElementos;
        private readonly MapperPrestamos mapperPrestamos;
        private readonly MapperDevoluciones mapperDevoluciones;
        private readonly MapperUsuarios mapperUsuarios;
        #endregion

        #region Variables capacidad Negocio
        private readonly ElementosCN elementoCN;
        private readonly CarritosCN carritosCN;
        private readonly DocentesCN docentesCN;
        private readonly PrestamosCN prestamosCN;
        private readonly TiposElementoCN tiposElementoCN;
        private readonly UsuariosCN usuariosCN;
        #endregion

        public FormPrincipal(IDbConnection conexion)
        {
            InitializeComponent();

            repoCarritos = new RepoCarritos(conexion);
            repoElementos = new RepoElemento(conexion);
            repoTipoElemento = new RepoTipoElemento(conexion);
            repoDocentes = new RepoDocentes(conexion);
            repoPrestamos = new RepoPrestamos(conexion);
            repoPrestamoDetalle = new RepoPrestamoDetalle(conexion); 
            repoDevolucion = new RepoDevolucion(conexion);
            repoUsuarios = new RepoUsuarios(conexion);
            repoRoles = new RepoRoles(conexion);

            mapperElementos = new MapperElementos(conexion);
            mapperPrestamos = new MapperPrestamos(conexion);
            mapperDevoluciones = new MapperDevoluciones(conexion);
            mapperUsuarios = new MapperUsuarios(conexion);

            elementoCN = new ElementosCN(mapperElementos, repoElementos);
            carritosCN = new CarritosCN(repoCarritos, repoElementos);
            docentesCN = new DocentesCN(repoDocentes);
            prestamosCN = new PrestamosCN(repoPrestamos, repoCarritos, repoElementos, repoPrestamoDetalle, mapperPrestamos);
            tiposElementoCN = new TiposElementoCN(repoTipoElemento);
            usuariosCN = new UsuariosCN(repoUsuarios, repoRoles, mapperUsuarios);
        }

        private void BtnCerrar1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            dashboard = new Dashboard();
            //tipoElementouc1.Dock = DockStyle.Fill;


            if (!pnlContenedor.Controls.Contains(dashboard))
            {
                pnlContenedor.Controls.Add(dashboard);
            }

            dashboard.Visible = true;

            //try
            //{
            //    tipoElementouc1.CargarDatos();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al cargar datos en TipoElementoUC: " + ex.Message);
            //}
        }

        private void BtnElementos_Click(object sender, EventArgs e)
        {
            elementosUC = new ElementosUC(elementoCN);

            if (!pnlContenedor.Controls.Contains(elementosUC))
            {
                pnlContenedor.Controls.Add(elementosUC);
            }

            elementosUC.Visible = true;
            elementosUC.BringToFront();

            try
            {
                elementosUC.CargarElementos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en TipoElementoUC: " + ex.Message);
            }
        }

        private void BtnCarritos_Click(object sender, EventArgs e)
        {
            carritoUC = new CarritoUC(carritosCN);

            if (!pnlContenedor.Controls.Contains(carritoUC))
            {
                pnlContenedor.Controls.Add(carritoUC);
            }

            carritoUC.Visible = true;
            carritoUC.BringToFront();

            try
            {
                carritoUC.MostrarCarrito();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en TipoElementoUC: " + ex.Message);
            }
        }

        private void BtnDocentes_Click(object sender, EventArgs e)
        {
            docentesUC = new DocentesUC(repoDocentes);

            if (!pnlContenedor.Controls.Contains(docentesUC))
            {
                pnlContenedor.Controls.Add(docentesUC);
            }

            docentesUC.Visible = true;
            docentesUC.BringToFront();

            try
            {
                docentesUC.MostrarDocentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en TipoElementoUC: " + ex.Message);
            }
        }

        private void BtnPrestamos_Click(object sender, EventArgs e)
        {
            prestamosUC = new PrestamosUC(prestamosCN);

            if (!pnlContenedor.Controls.Contains(prestamosUC))
            {
                pnlContenedor.Controls.Add(prestamosUC);
            }

            prestamosUC.Visible = true;
            prestamosUC.BringToFront();

            try
            {
                prestamosUC.MostrarPrestamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en TipoElementoUC: " + ex.Message);
            }
        }

        private void BtnDevolucion_Click(object sender, EventArgs e)
        {
            devolucionUC = new DevolucionUC(mapperDevoluciones);

            if (!pnlContenedor.Controls.Contains(devolucionUC))
            {
                pnlContenedor.Controls.Add(devolucionUC);
            }

            devolucionUC.Visible = true;
            devolucionUC.BringToFront();

            try
            {
                devolucionUC.MostrarDevoluciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en TipoElementoUC: " + ex.Message);
            }
        }

        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            categoriasUC = new CategoriasUC(repoTipoElemento);

            if (!pnlContenedor.Controls.Contains(categoriasUC))
            {
                pnlContenedor.Controls.Add(categoriasUC);
            }

            categoriasUC.Visible = true;
            categoriasUC.BringToFront();

            try
            {
                categoriasUC.MostrarCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en TipoElementoUC: " + ex.Message);
            }
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            usuariosUC = new UsuariosUC(usuariosCN);

            if (!pnlContenedor.Controls.Contains(usuariosUC))
            {
                pnlContenedor.Controls.Add(usuariosUC);
            }

            usuariosUC.Visible = true;
            usuariosUC.BringToFront();

            try
            {
                usuariosUC.MostrarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en TipoElementoUC: " + ex.Message);
            }
        }
    }
}

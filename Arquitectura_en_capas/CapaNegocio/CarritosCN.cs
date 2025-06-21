using Sistema_de_notebooks.CapaEntidad;
using System.Data;
using CapaDatos.Repos;

namespace Sistema_de_notebooks.CapaNegocio
{
    class CarritosCN
    {
        private readonly RepoCarritos carritos;

        public CarritosCN(IDbConnection conexion)
        {
            carritos = new RepoCarritos(conexion);
        }

        /*
        En esta region se crea el carrito con la disponibilidad
        con true para que este por default.
        */
        #region Dar alta al carrito
        public void CrearCarrito(Carritos newCarrito)
        {
            newCarrito.DisponibleCarrito = true;
            carritos.AltaCarrito(newCarrito);
        }
        #endregion


        // Aqui se imprime todos los datos del carrito para mostrarlo a la UI.
        #region Listar Carrito
        public IEnumerable<Carritos> ListarCarritos()
        {
            return carritos.ListarCarritos().ToList();
        }
        #endregion


        /*
        En esta parte si el docente eligio en el prestamo llevar por carrito se
        va a invocar este metodo para el prestamo.
        */
        #region Ocupar Carrito
        public void OcuparCarrito(int idCarrito)
        {
            Carritos? carritoOcupado = carritos.DetalleCarritos(idCarrito); //Busca el Id del carrito

            try
            {
                if (carritoOcupado != null)
                {
                    carritoOcupado.DisponibleCarrito = false;
                    carritos.ActualizarCarrito(carritoOcupado);
                }
            }
            catch(Exception)
            {
                throw new Exception("No se pudo encontrar el carrito. Ubicacion: capaNegocio");
            }
        }
        #endregion


        /*
        Esta parte cuando se haga la devolucion del carrito se debe invocar este metodo
        en la clase de prestamo para cambiar su disponibilidad
        */
        #region Desocupar Carrito
        public void DesocuparCarrito(int idCarrito)
        {
            Carritos? carritoLiberado = carritos.DetalleCarritos(idCarrito); // El Id

            if (carritoLiberado != null)
            {
                carritoLiberado.DisponibleCarrito = true;
                carritos.ActualizarCarrito(carritoLiberado);
            }
        }
        #endregion


        //Este metodo nos indica si el carrito existe, sino nos devuelve la disponibilidad del carrito
        #region Disponibilidad del carrito
        public bool EstaDisponible(int idCarrito)
        {
            Carritos? carrito = carritos.DetalleCarritos(idCarrito);

            if(carrito == null)
            {
                throw new ArgumentNullException("El carrito no existe. Ubicacion: CapaNegocio");
            }

            return carrito.DisponibleCarrito;
        }
        #endregion

    }
}


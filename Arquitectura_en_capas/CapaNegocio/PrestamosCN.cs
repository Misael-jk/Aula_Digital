using CapaDatos.Repos;
using CapaNegocio;
using Sistema_de_notebooks.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Sistema_de_notebooks.CapaNegocio
{
    public class PrestamosCN
    {
        private readonly RepoPrestamos repoPrestamos;
        private readonly CarritosCN carritoNegocio;
        private readonly RepoPrestamoDetalle repoPrestamoDetalle;
        private readonly NotebooksCN notebookCN;
        private readonly PrestamoDetalleCN prestamoDetalleCN;

        public PrestamosCN(IDbConnection conexion)
        {
            repoPrestamos = new RepoPrestamos(conexion);
            carritoNegocio = new CarritosCN(conexion);
            repoPrestamoDetalle = new RepoPrestamoDetalle(conexion);
            notebookCN = new NotebooksCN(conexion);
            prestamoDetalleCN = new PrestamoDetalleCN(conexion);
        }

        // Muestra los datos de los prestamos
        #region Mostrar los datos del prestamo
        public IEnumerable<Prestamos> ListarPrestamos()
        {
            return repoPrestamos.ListarPrestamos().ToList();
        }
        #endregion


        /*
        En esta region se realiza un prestamo y verifica si se cumplio correctamente con los requisitos. 
        Se verifica la fecha pactada; si pidio con carrito o no y si pidio ocupar dicho carrito. Ademas de
        insertar el prestamo tambien segun el prestamo recien insertado se inserta el detalle con la cantidad de
        notebooks que estan en el parametro.
        */
        #region Verificar un prestamo
        public bool HacerPrestamo(Prestamos newPrestamo, IEnumerable<int> idNotebooks)
        {
            // revisa si la fecha pactada sea menor a la fecha prestada
            if (newPrestamo.FechaPactada < DateTime.Now)
            {
                throw new Exception("Eliga otra fecha mayor a la actual");
            }

            /*
            aqui se verifica si el docente pide con carrito "!= null" y que si lo pide revisa si ese 
            carrito esta disponible o esta en uso, si esta en uso retorna false osea se cancela el prestamo,
            tambien si pide el carrito invoca el metodo OcuparCarrito para cambiar la disponibilidad del carrito
            */
            if (newPrestamo.IdCarrito != null)
            {
                bool disponible = carritoNegocio.EstaDisponible(newPrestamo.IdCarrito.Value);

                if (disponible != true)
                {
                    return false;
                }

                carritoNegocio.OcuparCarrito(newPrestamo.IdCarrito.Value);
            }

            // se guarda la fecha y se inserta el prestamo
            newPrestamo.FechaPrestamo = DateTime.Now;
            repoPrestamos.AltaPrestamo(newPrestamo);

            prestamoDetalleCN.AgregarDetalles(newPrestamo.IdPrestamo, idNotebooks);

            return true;
        }
        #endregion


        /*
        Esta region se realizara la devolucion, verificando si existe el prestamo y que ese prestamo tenga detalles
        Luego hace las funciones de cuando se devuelve un prestamo como cambiar su estado y la fecha de la devolucion
        para actualizarla en el detalle. Tambien verificamos si llevo carrito o no, si la llevo se cambia su disponibilidad
        tanto del carrito y sus respectivas notebook y sino pidio carrito tambien va a cambiar el estado de las notebook que 
        se llevo ya sea una o algunas sin carrito.
        */
        #region Devolucion del Prestamo
        public bool HacerDevolucion(int idPrestamo, int idEstadoDevuelto)
        {
            // Verifica si existe el prestamo 
            Prestamos? prestamo = repoPrestamos.DetallePrestamos(idPrestamo);

            if (prestamo == null)
            {
                return false;
            }

            // verifica que el prestamo tenga detalles
            IEnumerable<PrestamoDetalle> detalles = repoPrestamoDetalle.ListarDetallesPorPrestamo(idPrestamo);

            if (!detalles.Any())
            {
                return false;
            }

            // cambia el estado de las notebooks devueltas y la fecha para luego actualizarlas
            foreach (PrestamoDetalle detalle in detalles)
            {
                detalle.IdEstadoPrestamo = idEstadoDevuelto;
                detalle.FechaDevolucion = DateTime.Now;
                repoPrestamoDetalle.ActualizarDetalle(detalle);
            }

            /*
            Aqui se utiliza una funcion LINQ para traer las notebooks del detalle. Luego verifica si llevo
            carrito para desocuparla (cambia tambien a las notebooks que traia con ella) y si no llevo 
            cambia la disponibilidad de las notebooks del detalle (osea de las notebooks que se prestaron)
            */
            IEnumerable<int> idNotebooks = detalles.Select(d => d.IdNotebook).ToList();

            if (prestamo.IdCarrito != null)
            {
                carritoNegocio.DesocuparCarrito(prestamo.IdCarrito.Value);
            }
            else
            {
                notebookCN.CambiarDisponibilidadNotebooks(idNotebooks, true);
            }

            return true;
        }
        #endregion


    }
}

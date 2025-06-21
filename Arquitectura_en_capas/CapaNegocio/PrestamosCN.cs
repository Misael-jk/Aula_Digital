using CapaDatos.Repos;
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
        private readonly RepoPrestamos prestamos;
        private readonly CarritosCN carritoNegocio;

        public PrestamosCN(IDbConnection conexion)
        {
            prestamos = new RepoPrestamos(conexion);
            carritoNegocio = new CarritosCN(conexion);
        }

        /*
        En esta region se realiza un prestamo y verifica si se cumplio correctamente con los requisitos. 
        Se verifica la fecha pactada; si pidio con carrito o no y si pidio ocupar dicho carrito
        */
        #region Verificar un prestamo
        public bool HacerPrestamo(Prestamos newPrestamo)
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
            if(newPrestamo.IdCarrito != null)
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
            prestamos.AltaPrestamo(newPrestamo);

            return true;
        }
        #endregion


        // Muestra los datos de los prestamos
        #region Mostrar los datos del prestamo
        public IEnumerable<Prestamos> ListarPrestamos()
        {
            return prestamos.ListarPrestamos().ToList();
        }
        #endregion


        //public void FinalizarPrestamo(int idPrestamo)
        //{
        //    var prestamo = prestamos.DetallePrestamos(idPrestamo);

        //    if (prestamo != null)
        //    {
        //        carritoNegocio.DesocuparCarrito(prestamo.IdCarrito);
        //        prestamo.MarcarComoFinalizado(idPrestamo);
        //    }
        //}
    }
}

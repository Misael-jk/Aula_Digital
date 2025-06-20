using CapaDatos.Repos;
using Sistema_de_notebooks.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_notebooks.CapaNegocio
{
    public class PrestamosCN
    {
        private readonly RepoPrestamos prestamos;
        private readonly CarritosCN carritoNegocio;

        public PrestamosCN(RepoPrestamos prestamos, CarritosCN carritoNegocio)
        {
            this.prestamos = prestamos;
            this.carritoNegocio = carritoNegocio;
        }

        public bool HacerPrestamo(Prestamos newPrestamo)
        {
            // Validación básica: ¿El carrito está disponible?
            var disponible = carritoNegocio.EstaDisponible(nuevo.IdCarrito);
            if (!disponible)
                return false; // no se puede continuar

            // Validación: ¿La fecha pactada es después de la fecha de hoy?
            if (nuevo.FechaPactada < DateTime.Now)
                throw new Exception("La fecha pactada debe ser futura.");

            // Guardar el préstamo
            nuevo.FechaPrestamo = DateTime.Now;
            repo.InsertarPrestamo(nuevo);

            // Marcar carrito como ocupado
            carritoNegocio.OcuparCarrito(nuevo.IdCarrito);

            return true;
        }

        public List<Prestamo> ListarPrestamos()
        {
            return repo.ObtenerPrestamos();
        }

        public void FinalizarPrestamo(int idPrestamo)
        {
            // Lógica para finalizar un préstamo y liberar el carrito
            var prestamo = repo.ObtenerPorId(idPrestamo);
            if (prestamo != null)
            {
                carritoNegocio.LiberarCarrito(prestamo.IdCarrito);
                repo.MarcarComoFinalizado(idPrestamo); // podrías tener esta lógica
            }
        }
    }
}

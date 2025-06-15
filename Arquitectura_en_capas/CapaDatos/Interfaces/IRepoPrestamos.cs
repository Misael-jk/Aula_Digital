using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoPrestamos
    {
        public void Alta(Prestamos prestamo);
        public List<Prestamos> ListarPrestamos();
        public Prestamos? DetallePrestamos(int idPrestamo);
    }
}

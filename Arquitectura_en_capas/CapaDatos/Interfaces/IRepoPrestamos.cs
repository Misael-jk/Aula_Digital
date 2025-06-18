using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoPrestamos
    {
        public void AltaPrestamo(Prestamos prestamo);
        public IEnumerable<Prestamos> ListarPrestamos();
        public Prestamos? DetallePrestamos(int idPrestamo);
    }
}

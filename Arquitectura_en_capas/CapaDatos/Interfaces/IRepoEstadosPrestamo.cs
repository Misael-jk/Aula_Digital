using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoEstadosPrestamo
    {
        public void Alta(EstadosPrestamo estado);
        public List<EstadosPrestamo> ListarEstadosPrestamo();
        public EstadosPrestamo? DetalleEstadosPrestamo(int idEstadoPrestamo);
    }
}

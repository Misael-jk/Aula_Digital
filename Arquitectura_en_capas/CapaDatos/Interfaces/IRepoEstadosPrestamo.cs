using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces;

interface IRepoEstadosPrestamo
{
    public IEnumerable<EstadosPrestamo> ListarEstadosPrestamo();
}

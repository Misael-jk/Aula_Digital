using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoEstadosPrestamo
{
    public IEnumerable<EstadosPrestamo> GetAll();
    public EstadosPrestamo? GetById(int idEstadosPrestamo);
}

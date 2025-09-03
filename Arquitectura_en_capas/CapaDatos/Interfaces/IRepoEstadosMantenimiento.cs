using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoEstadosMantenimiento
{
    public IEnumerable<EstadosMantenimiento> GetAll();
    public EstadosMantenimiento? GetById(int idEstadoMantenimiento);
}

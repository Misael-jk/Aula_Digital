using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoEstadosElemento
{
    public IEnumerable<EstadosElemento> GetAll();
    public EstadosElemento? GetById(int idEstadosElemento);
}

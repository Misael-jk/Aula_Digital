using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoEstadosElemento
{
    public IEnumerable<EstadosElemento> GetAll();
    public EstadosElemento? GetById(int idEstadosElemento);
}

using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoTipoSeccion
{
    public IEnumerable<TipoSeccion> GetAll();
    public TipoSeccion? GetById(int idTipoSeccion);
}

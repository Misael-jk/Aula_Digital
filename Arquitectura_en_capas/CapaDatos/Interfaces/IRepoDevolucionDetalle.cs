using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoDevolucionDetalle
{
    public void Insert(DevolucionDetalle devolucionDetalle);
    public void Update(DevolucionDetalle devolucionDetalle);
    public void Delete(int idDevolucion, int idElemento);
    public IEnumerable<DevolucionDetalle> GetByDevolucion(int idDevolucion);
    public IEnumerable<DevolucionDetalle> GetAll();
}

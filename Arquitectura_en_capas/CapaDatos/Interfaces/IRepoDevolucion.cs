using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoDevolucion
{
    public void Insert(Devolucion devolucion);
    public Devolucion? GetById(int idDevolucion);
    public IEnumerable<Devolucion> GetAll();
    public IEnumerable<Devolucion> GetByPrestamo(int idPrestamo);
}

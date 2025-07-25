using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoDevolucion
{
    public void Insert(Devolucion devolucion);
    public Devolucion? GetById(int idDevolucion);
    public IEnumerable<Devolucion> GetAll();
    public Devolucion? GetByPrestamo(int idPrestamo);
}

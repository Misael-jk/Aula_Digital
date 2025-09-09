using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoNotebooks
{
    public void Insert(Notebooks notebook);
    public void Update(Notebooks notebook);
    public IEnumerable<Notebooks> GetAll();
    public IEnumerable<Notebooks> GetByCarrito(int idCarrito);
    public Notebooks? GetById(int idNotebook);
}

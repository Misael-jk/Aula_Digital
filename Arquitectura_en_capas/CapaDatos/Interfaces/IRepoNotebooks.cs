using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoNotebooks
{
    public void Insert(Notebooks notebook);
    public void Update(Notebooks notebook);
    public IEnumerable<Notebooks> GetAll();
    public IEnumerable<Notebooks> GetByCarrito(int idCarrito);
    public Notebooks? GetById(int idNotebook);
    public Notebooks? GetNotebookByPosicion(int idCarrito, int posicionCarrito);
    public bool DuplicatePosition(int idCarrito, int posicionCarrito);
    public bool GetDisponible(int idElemento);
    public void UpdateEstado(int idElemento, int idEstadoMantenimiento);
}

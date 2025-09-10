using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoHistorialNotebook
{
    public void Insert(HistorialNotebooks historialNotebooks);
    public IEnumerable<HistorialNotebooks> GetAll(HistorialNotebooks historialNotebooks);
}

using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoHistorialaCarrito
{
    public void Insert(HistorialCarritos historialCarritos);
    public IEnumerable<HistorialCarritos> GetAll(HistorialCarritos historialCarritos);
}

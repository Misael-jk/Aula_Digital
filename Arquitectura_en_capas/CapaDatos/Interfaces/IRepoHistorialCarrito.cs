using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoHistorialCarrito
{
    public void Insert(HistorialCarritos historialCarritos);
    public IEnumerable<HistorialCarritos> GetAll(HistorialCarritos historialCarritos);
}

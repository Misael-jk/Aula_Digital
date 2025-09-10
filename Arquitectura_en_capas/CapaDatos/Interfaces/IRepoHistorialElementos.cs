using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoHistorialElementos
{
    public void Insert(HistorialElementos historialElementos);
    public IEnumerable<HistorialElementos> GetAll(HistorialElementos historialElementos);
}

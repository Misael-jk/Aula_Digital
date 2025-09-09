using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoHistorialCambio
{
    public void Insert(HistorialCambios historialCambio);
    public IEnumerable<HistorialCambios> GetAll();
    public HistorialCambios? GetById(int idHistorialCambio);
    public IEnumerable<HistorialCambios> GetBySeccion(int idTipoSeccion);
    public IEnumerable<HistorialCambios> GetByAccion(int idTipoAccion);
}

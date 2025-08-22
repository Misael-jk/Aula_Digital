using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoHistorialElemento
{
    public void Insert(HistorialElemento historialElemento);
    public HistorialElemento? GetById(int idHistorialElemento);
    public IEnumerable<HistorialElemento> GetByElemento(int idElemento);
    public IEnumerable<HistorialElemento> GetByEstado(int idEstadoElemento);
    public IEnumerable<HistorialElemento> GetAll();
}

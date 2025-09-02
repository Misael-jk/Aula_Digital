using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoElemento
{
    public void Insert(Elemento elemento);
    public void Update(Elemento elemento);
    public void Delete(int idElemento);
    public void CambiarDisponible(int idElemento, bool disponible);
    public void UpdateEstado(int idElemento, int idEstadoElemento);
    public Elemento? GetByNumeroSerie(string numeroSerie);
    public Elemento? GetByCodigoBarra(string codigoBarra);
    public Elemento? GetById(int idElemento);
    public IEnumerable<Elemento> GetByCarrito(int idCarrito);
    public bool GetDisponible(int idElemento);
    public Elemento? GetNotebookByPosicion(int idCarrito, int posicionCarrito);
    public bool DuplicatePosition(int idCarrito, int posicionCarrito);
    public Elemento? GetNotebookBySerieOrCodigo(string nroSerie, string codigoBarra);
}

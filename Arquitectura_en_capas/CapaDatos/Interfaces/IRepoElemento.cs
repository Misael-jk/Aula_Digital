using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoElemento
{
    public void Insert(Elemento elemento);
    public void Update(Elemento elemento);
    public void Delete(int idElemento);
    public Elemento? GetByNumeroSerie(string numeroSerie);
    public Elemento? GetByCodigoBarra(string codigoBarra);
    public Elemento? GetById(int idElemento);
    public IEnumerable<Elemento> GetByCarrito(int idCarrito);

}

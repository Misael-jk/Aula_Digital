using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoElemento
{
    public void Insert(Elemento elemento);
    public void Update(Elemento elemento);
    public void Delete(int idElemento);
    public IEnumerable<Elemento> GetAll();
    public Elemento? GetByCodigoBarra(string codigoBarra);
    public IEnumerable<Elemento> GetByCarrito(int idCarrito);

}

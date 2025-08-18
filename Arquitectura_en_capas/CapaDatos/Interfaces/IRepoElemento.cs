using CapaEntidad;
using System.Data;

namespace CapaDatos.Interfaces;

public interface IRepoElemento
{
    public void Insert(Elemento elemento);
    public void Update(Elemento elemento);
    public void Delete(int idElemento);
    public void UpdateEstado(int idElemento, bool disponible);
    public Elemento? GetByNumeroSerie(string numeroSerie);
    public Elemento? GetByCodigoBarra(string codigoBarra);
    public Elemento? GetById(int idElemento);
    public IEnumerable<Elemento> GetByCarrito(int idCarrito);
    public bool GetDisponible(int idElemento);

}

using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoCarritos
{
    public void Insert(Carritos carrito);
    public void Update(Carritos carrito);
    public void Delete(int idCarrito);
    public IEnumerable<Carritos> GetAll();
    public Carritos? GetById(int idCarrito);
    public Carritos? GetByNumeroSerie(string numeroSerieCarrito);
    public void UpdateDisponible(int idCarrito, bool disponibleCarrito);
    public bool GetDisponible(int idCarrito);
}

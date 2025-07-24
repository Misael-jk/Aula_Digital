using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoCarritos
{
    public void Insert(Carritos carrito);
    public void Update(Carritos carrito);
    public void Delete(int idCarrito);
    public IEnumerable<Carritos> GetAll();
    public Carritos? GetById(int idCarrito);
}

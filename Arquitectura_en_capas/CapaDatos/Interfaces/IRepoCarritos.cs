using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoCarritos
    {
        public void Alta(Carritos carrito);
        public List<Carritos> ListarCarritos();
        public Carritos? DetalleCarritos(int idCarrito);
    }
}

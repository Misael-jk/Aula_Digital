using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoCarritos
    {
        public void AltaCarrito(Carritos carrito);
        public void ActualizarCarrito(Carritos carrito);
        public void EliminarCarrito(int idCarrito);

        public IEnumerable<Carritos> ListarCarritos();
        public Carritos? DetalleCarritos(int idCarrito);
    }
}

using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces;

interface IRepoCarritoNotebooks
{
    public IEnumerable<CarritoNotebooks> ListarNotebooksCarrito(int idCarrito);
}

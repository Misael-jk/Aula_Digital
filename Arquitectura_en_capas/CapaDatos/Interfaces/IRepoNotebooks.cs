using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoNotebooks
    {
        public void Alta(Notebook notebook);
        public List<Notebook> ListarNotebooks();
        public Notebook? DetalleNotebooks(int idNotebook);
    }
}

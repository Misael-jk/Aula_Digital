using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoNotebooks
    {
        public void AltaNotebook(Notebook notebook);
        public void ActualizarNotebook(Notebook notebook);
        public void EliminarNotebook(int idNotebook);
        public List<Notebook> ListarNotebooks();
        public Notebook? DetalleNotebooks(int idNotebook);
    }
}

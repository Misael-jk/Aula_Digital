using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoEstadosNotebook
    {
        public void Alta(EstadosNotebook estado);
        public List<EstadosNotebook> ListarEstadosNotebook();
        public EstadosNotebook? DetalleEstadosNotebook(int idEstadoNotebook);
    }
}

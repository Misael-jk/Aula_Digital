using CapaDatos.DTOs;
using Sistema_de_notebooks.CapaDatos.DTOs;
using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoEstadosNotebook
    {
        public IEnumerable<EstadosNotebook> ListarEstadosNotebook();
        public IEnumerable<EstadosNotebookDTO> EstadosDeLaNotebook(int idEstadoNotebook);
    }
}

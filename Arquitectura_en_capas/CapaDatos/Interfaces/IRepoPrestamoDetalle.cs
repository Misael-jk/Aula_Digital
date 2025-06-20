using CapaDatos.DTOs;
using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoPrestamoDetalle
    {
        public IEnumerable<PrestamoDetalle> ListarPrestamoDetalle();
        public IEnumerable<HistorialNotebookDTO> HistorialNotebook(int idNotebook);
        public IEnumerable<PrestamoDetalle> DetallePorPrestamo(int idPrestamo);

    }
}

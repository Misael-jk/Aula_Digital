using CapaDatos.DTOs;
using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces;

interface IRepoPrestamoDetalle
{
    public void AltaPrestamoDetalle(PrestamoDetalle prestamoDetalle);
    public IEnumerable<PrestamoDetalle> ListarPrestamoDetalle();
    public IEnumerable<HistorialNotebookDTO> HistorialNotebook(int idNotebook);
    public void ActualizarDetalle(PrestamoDetalle prestamoDetalle);
    public PrestamoDetalle? DetallePorPrestamo(int idPrestamo, int idNotebook);
    public IEnumerable<PrestamoDetalle> ListarDetallesPorPrestamo(int idPrestamo);

}

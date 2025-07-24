using CapaDatos.DTOs;
using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoPrestamoDetalle
{
    public void Insert(PrestamoDetalle prestamoDetalle);
    public void Delete(int idPrestamo, int idElemento);
    public IEnumerable<PrestamoDetalle> GetByPrestamo(int idPrestamo);
    public IEnumerable<PrestamoDetalle> GetAll();
    public PrestamoDetalle? GetByIds(int idPrestamo, int idNotebook);
    public IEnumerable<HistorialNotebookDTO> HistorialNotebook(int idNotebook);

}

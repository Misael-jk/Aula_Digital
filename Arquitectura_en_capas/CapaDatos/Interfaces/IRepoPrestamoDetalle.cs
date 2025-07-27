using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoPrestamoDetalle
{
    public void Insert(PrestamoDetalle prestamoDetalle);
    public void Update(PrestamoDetalle prestamoDetalle);
    public void Delete(int idPrestamo, int idElemento);
    public PrestamoDetalle? GetByPrestamo(int idPrestamo);
    public IEnumerable<PrestamoDetalle> GetAll();

}

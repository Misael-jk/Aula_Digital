using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoPrestamoDetalle
{
    public void Insert(PrestamoDetalle prestamoDetalle);
    public void Update(PrestamoDetalle prestamoDetalle);
    public void Delete(int idPrestamo, int idElemento);
    public IEnumerable<PrestamoDetalle> GetByPrestamo(int idPrestamo);
    public IEnumerable<PrestamoDetalle> GetAll();

}

using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoPrestamoDetalle
    {
        public interface IRepoPrestamoDetalle
        {
            public void Alta(PrestamoDetalle prestamoDetalle);
            public List<PrestamoDetalle> ListarPrestamoDetalle(int idPrestamo);
            public PrestamoDetalle? DetallePrestamoDetalle(int idPrestamo, byte idNotebook);

        }
    }
}

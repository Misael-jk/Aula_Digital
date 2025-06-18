using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoPermisosPrestamo
    {
        public void AltaPermisosPrestamo(PermisoPrestamo permiso);
        public int EliminarPermisosPrestamo(int idPermisoPrestamo);
        public IEnumerable<PermisoPrestamo> ListarPermisosPrestamo();
        public PermisoPrestamo? DetallePermisosPrestamo(int idPermiso);
    }
}

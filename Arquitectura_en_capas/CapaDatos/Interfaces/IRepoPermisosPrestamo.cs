using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoPermisosPrestamo
    {
        public void Alta(PermisoPrestamo permiso);
        public List<PermisoPrestamo> ListarPermisosPrestamo();
        public PermisoPrestamo? DetallePermisosPrestamo(int idPermiso);
    }
}

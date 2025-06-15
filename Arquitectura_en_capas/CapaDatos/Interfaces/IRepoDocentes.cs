using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoDocentes
    {
        public void Alta(Docentes docente);
        public List<Docentes> ListarDocentes();
        public Docentes? DetalleDocentes(int idDocente);
    }
}

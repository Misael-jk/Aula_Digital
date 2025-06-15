using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoAlumnos
    {
        public void Alta(Alumnos alumno);
        public List<Alumnos> ListarAlumnos();
        public Alumnos? DetalleAlumnos(int idAlumno);
    }
}

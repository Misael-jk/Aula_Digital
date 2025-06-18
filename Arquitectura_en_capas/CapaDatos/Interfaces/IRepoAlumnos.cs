using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoAlumnos
    {
        public void AltaAlumno(Alumnos alumnos);
        public void ActualizarAlumno(Alumnos alumnos);
        public void EliminarAlumno(int IdAlumno);
        public IEnumerable<Alumnos> ListarAlumnos();
        public Alumnos? DetalleAlumnos(int idAlumno);
    }
}

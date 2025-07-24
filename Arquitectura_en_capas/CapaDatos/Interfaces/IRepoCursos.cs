using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoCursos
{
    public Curso? GetById(int idCurso);
    public IEnumerable<Curso> GetAll();
}

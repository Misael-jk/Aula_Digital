using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoDocentes
{
    public void Insert(Docentes docente);
    public void Update(Docentes docente);
    public void Delete(int idDocente);
    public IEnumerable<Docentes> GetAll();
    public Docentes? GetById(int idDocente);
}

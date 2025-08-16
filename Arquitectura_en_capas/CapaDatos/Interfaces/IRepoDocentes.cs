using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoDocentes
{
    public void Insert(Docentes docente);
    public void Update(Docentes docente);
    public void Delete(int idDocente);
    public Docentes? GetById(int idDocente);
    public Docentes? GetByDni(string Dni);
    public Docentes? GetByEmail(string Email);
    public IEnumerable<Docentes> GetAll();
}

using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoEncargados
{
    public void Insert(Encargado encargados);
    public void Update(Encargado encargados);
    public void Delete(int idEncargado);
    public IEnumerable<Encargado> GetAll();
    public Docentes? GetById(int idEncargado);
}

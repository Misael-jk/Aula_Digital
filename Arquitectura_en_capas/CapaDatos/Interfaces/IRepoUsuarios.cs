using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoUsuarios
{
    public void Insert(Usuarios usuarios);
    public void Update(Usuarios usuarios);
    public void Delete(int idUsuarios);
    public IEnumerable<Usuarios> GetAll();
    public Usuarios? GetByUserPass(string user, string password);
}

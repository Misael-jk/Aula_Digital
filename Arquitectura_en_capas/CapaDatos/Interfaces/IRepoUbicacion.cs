using CapaEntidad;

namespace CapaDatos.Interfaces;

public interface IRepoUbicacion
{
    public void Insert(Ubicacion ubicacion);
    public void Update(Ubicacion ubicacion);
    public IEnumerable<Ubicacion> GetAll();
    public Ubicacion? GetIdByUbicacion(string ubicacion);
    public Ubicacion? GetById(int idUbicacion);
}

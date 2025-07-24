using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoElemento
{
    public void Insert(Elemento elemento);
    public void Update(Elemento elemento);
    public void Delete(int idElemento);
    public IEnumerable<Elemento> GetAll();
    public Elemento? GetById(int idElemento);
}

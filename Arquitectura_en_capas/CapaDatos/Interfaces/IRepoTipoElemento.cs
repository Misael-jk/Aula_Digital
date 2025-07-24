using CapaEntidad;

namespace CapaDatos.Interfaces;

interface IRepoTipoElemento
{
    public void Insert(TipoElemento tipoElemento);
    public void Update(TipoElemento tipoElemento);
    public void Delete(int idTipoElemento);
    public IEnumerable<TipoElemento> GetAll();
    public TipoElemento? GetById(int idTipoElemento);
}

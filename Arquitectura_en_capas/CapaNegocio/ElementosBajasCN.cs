using CapaDatos.Interfaces;
using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaEntidad;

namespace CapaNegocio;

public class ElementosBajasCN
{
    private readonly IRepoElemento _repoElemento;
    private readonly IMapperElementosBajas mapperElementosBajas;

    public ElementosBajasCN(IRepoElemento repoElemento, IMapperElementosBajas mapperElementosBajas)
    {
        _repoElemento = repoElemento;
        this.mapperElementosBajas = mapperElementosBajas;
    }

    public IEnumerable<ElementoBajasDTO> GetAllElementos()
    {
        return mapperElementosBajas.GetAllDTO();
    }

    //public IEnumerable<ElementoBajasDTO> GetElementosByTipo(int idTipoElemento)
    //{
    //    return mapperElementosBajas.GetByTipo(idTipoElemento);
    //}

    //public IEnumerable<ElementoBajasDTO> GetElementosByEstado(int idEstadoElemento)
    //{
    //    return mapperElementosBajas.GetByEstado(idEstadoElemento);
    //}

    public void HabilitarElemento(int idElemento, int idUsuario)
    {
        Elemento? elemento = _repoElemento.GetById(idElemento);

        if (elemento == null)
            throw new Exception("El elemento no existe.");

        if (elemento.Habilitado)
            throw new Exception("El elemento ya esta habilitado.");

        elemento.Habilitado = true;
        elemento.IdEstadoMantenimiento = 1;
        elemento.FechaBaja = null;

        _repoElemento.Update(elemento);

    }

    #region DELETE ELEMENTO 
    public void EliminarElemento(int idElemento)
    {
        Elemento? elementoOLD = _repoElemento.GetById(idElemento);

        if (elementoOLD == null)
        {
            throw new Exception("El elemento no existe.");
        }

        if (elementoOLD.IdEstadoMantenimiento == 2)
        {
            throw new Exception("No se puede eliminar un elemento que está en prestamo");
        }

        if (elementoOLD.Habilitado)
        {
            throw new Exception("El elemento debe estar deshabilitado antes de eliminarlo definitivamente.");
        }


        _repoElemento.Delete(idElemento);
    }
    #endregion
}

using CapaDatos.Interfaces;
using CapaDatos.InterfacesDTO;
using CapaDatos.Repos;
using CapaDTOs;
using CapaEntidad;

namespace CapaNegocio;

public class MantenimientoCN
{
    private readonly IRepoElemento _repoElemento;
    private readonly IMapperElementoMantenimiento mapperElementoMantenimiento;
    private readonly IRepoHistorialElemento repoHistorialElemento;

    public MantenimientoCN(IRepoElemento repoElemento, IMapperElementoMantenimiento mapperElementoMantenimiento, IRepoHistorialElemento repoHistorialElemento)
    {
        _repoElemento = repoElemento;
        this.mapperElementoMantenimiento = mapperElementoMantenimiento;
        this.repoHistorialElemento = repoHistorialElemento;
    }

    public IEnumerable<ElementoMantenimientoDTO> GetAllElementos()
    {
        return mapperElementoMantenimiento.GetAllDTO();
    }

    public IEnumerable<ElementoMantenimientoDTO> GetElementosByTipo(int idTipoElemento)
    {
        return mapperElementoMantenimiento.GetByTipo(idTipoElemento);
    }

    public IEnumerable<ElementoMantenimientoDTO> GetElementosByEstado(int idEstadoElemento)
    {
        return mapperElementoMantenimiento.GetByEstado(idEstadoElemento);
    }

    public void HabilitarElemento(int idElemento, int idUsuario)
    {
        Elemento? elemento = _repoElemento.GetById(idElemento);

        if (elemento == null)
            throw new Exception("El elemento no existe.");

        if (elemento.Disponible)
            throw new Exception("El elemento ya esta habilitado.");

        _repoElemento.CambiarDisponible(idElemento, true);

        HistorialElemento historialElemento = new HistorialElemento
        {
            IdElemento = idElemento,
            IdCarrito = elemento.IdCarrito,
            idUsuario = idUsuario,
            IdEstadoElemento = 1,
            FechaHora = DateTime.Now,
            Observacion = "El elemento ha sido habilitado."
        };
    }

    #region DELETE ELEMENTO 
    public void EliminarElemento(int idElemento)
    {
        Elemento? elementoOLD = _repoElemento.GetById(idElemento);

        if (elementoOLD == null)
        {
            throw new Exception("El elemento no existe.");
        }

        if (elementoOLD.IdEstadoElemento == 2)
        {
            throw new Exception("No se puede eliminar un elemento que está en prestamo");
        }

        if (elementoOLD.Disponible)
        {
            throw new Exception("El elemento debe estar deshabilitado antes de eliminarlo definitivamente.");
        }


        _repoElemento.Delete(idElemento);
    }
    #endregion
}

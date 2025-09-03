using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperElementoMantenimiento
{
    public IEnumerable<ElementoMantenimientoDTO> GetAllDTO();
    public IEnumerable<ElementoMantenimientoDTO> GetByTipo(int idTipoElemento);
    public IEnumerable<ElementoMantenimientoDTO> GetByEstado(int idEstadoMantenimiento);
}

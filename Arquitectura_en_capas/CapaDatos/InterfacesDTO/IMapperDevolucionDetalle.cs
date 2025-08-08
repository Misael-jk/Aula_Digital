using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperDevolucionDetalle
{
    IEnumerable<DevolucionDetalleDTO> GetAllDTO();
    DevolucionDetalleDTO? GetByIdDTO(int idDevolucion);
}

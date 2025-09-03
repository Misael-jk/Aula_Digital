using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperDevolucionDetalle
{
    public IEnumerable<DevolucionDetalleDTO> GetAllDTO();
    public DevolucionDetalleDTO? GetByIdDTO(int idDevolucion);
}

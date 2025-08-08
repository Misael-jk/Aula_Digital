using CapaDTO.DTOs;

namespace CapaDTO.Interface
{
    public interface IMapperDevolucionDetalle
    {
        IEnumerable<DevolucionDetalleDTO> GetAllDTO();
        DevolucionDetalleDTO? GetByIdDTO(int idDevolucion);
    }
}

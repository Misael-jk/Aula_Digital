using CapaDTO.DTOs;

namespace CapaDTO.Interface;

public interface IMapperDevoluciones
{
    IEnumerable<DevolucionesDTO> GetAllDTO();
    DevolucionesDTO? GetByIdDTO(int idPrestamo);
    IEnumerable<DevolucionesDTO> GetByDocenteDTO(int idDocente);
}

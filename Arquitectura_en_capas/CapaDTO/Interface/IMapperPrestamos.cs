using CapaDTO.DTOs;

namespace CapaDTO.Interface;

public interface IMapperPrestamos
{
    IEnumerable<PrestamosDTO> GetAllDTO();
    PrestamosDTO? GetByIdDTO(int idPrestamo);
    IEnumerable<PrestamosDTO> GetByDocenteDTO(int idDocente);
}

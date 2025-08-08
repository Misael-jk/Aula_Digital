using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperDevoluciones
{
    IEnumerable<DevolucionesDTO> GetAllDTO();
    DevolucionesDTO? GetByIdDTO(int idPrestamo);
    IEnumerable<DevolucionesDTO> GetByDocenteDTO(int idDocente);
}

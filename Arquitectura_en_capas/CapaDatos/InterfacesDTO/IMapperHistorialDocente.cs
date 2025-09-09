using CapaDTOs.AuditoriaDTO;

namespace CapaDatos.InterfacesDTO;

public interface IMapperHistorialDocente
{
    public IEnumerable<HistorialDocentesDTO> GetAllDTO();
}

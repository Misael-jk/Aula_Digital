using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperHistorialElemento
{
    public IEnumerable<HistorialElementoDTO> GetAllDTO();
    public IEnumerable<HistorialElementoDTO> GetByElementoDTO(int idElemento);
    public IEnumerable<HistorialElementoDTO> GetByEstadoDTO(int idEstadoElemento);

}

using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperNotebooks
{
    public IEnumerable<NotebooksDTO> GetAllDTO();
}

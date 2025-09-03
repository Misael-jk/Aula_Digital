using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperCarritos
{
    public IEnumerable<CarritosDTO> GetAllDTO();
}

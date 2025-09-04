using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperCarritosBajas
{
    public IEnumerable<CarrtiosBajasDTO> GetAllDTO();
}

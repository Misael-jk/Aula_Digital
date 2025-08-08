using CapaDTOs;
namespace CapaDatos.InterfacesDTO;

public interface IMapperElementos
{
    IEnumerable<ElementosDTO> GetAllDTO();
    ElementosDTO? GetByIdDTO(int idElemento);
    IEnumerable<ElementosDTO> GetByCarritoDTO(int idCarrito);
    IEnumerable<ElementosDTO> GetByTipoDTO(int idTipoElemento);
}

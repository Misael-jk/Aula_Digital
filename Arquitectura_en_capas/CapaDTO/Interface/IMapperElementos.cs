using CapaDTO.DTOs;

namespace CapaDTO.Interface;

public interface IMapperElementos
{
    IEnumerable<ElementosDTO> GetAllDTO();
    ElementosDTO? GetByIdDTO(int idElemento);
    IEnumerable<ElementosDTO> GetByCarritoDTO(int idCarrito);
    IEnumerable<ElementosDTO> GetByTipoDTO(int idTipoElemento);
}

using CapaDTO.DTOs;

namespace CapaDTO.Interface;

public interface IMapperUsuarios
{
    IEnumerable<UsuariosDTO> GetAllDTO();
    UsuariosDTO? GetById(int idUsuario);
}

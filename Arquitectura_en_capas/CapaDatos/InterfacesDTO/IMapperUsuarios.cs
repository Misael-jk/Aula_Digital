using CapaDTOs;

namespace CapaDatos.InterfacesDTO;

public interface IMapperUsuarios
{
    IEnumerable<UsuariosDTO> GetAllDTO();
    UsuariosDTO? GetById(int idUsuario);
}

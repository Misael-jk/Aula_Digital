using CapaNegocio.DTOs;
using CapaEntidad;

namespace CapaNegocio.MappersDTO;

public class UsuariosMapper
{
    public IEnumerable<UsuariosDTO> Mapear(IEnumerable<Usuarios> usuarios, Dictionary<int, string> roles)
    {
        return usuarios.Select(e => new UsuariosDTO
        {
            IdUsuario = e.IdUsuario,
            Usuario = e.Usuario,
            Password = e.Password,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            Rol = roles.GetValueOrDefault(e.IdRol),
            Email = e.Email
        }).ToList();
    }

    public UsuariosDTO ToDTO(Usuarios usuarios, Dictionary<int, string> roles)
    {
        return new UsuariosDTO
        {
            IdUsuario = usuarios.IdUsuario,
            Usuario = usuarios.Usuario,
            Password = usuarios.Password,
            Nombre = usuarios.Nombre,
            Apellido = usuarios.Apellido,
            Rol = roles.GetValueOrDefault(usuarios.IdRol),
            Email = usuarios.Email
        };
    }
}

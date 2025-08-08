//using CapaDatos;
//using CapaDatos.Interfaces;
//using CapaDatos.Repos;
//using CapaEntidad;
//using CapaNegocio.DTOs;
//using CapaNegocio.MappersDTO;
//using System.Data;

//namespace CapaNegocio;

//public class UsuariosCN
//{
//    private readonly IRepoUsuarios repoUsuarios;
//    private readonly IRepoRoles repoRoles;
//    private readonly UsuariosMapper usuariosMapper;

//    public UsuariosCN(IRepoUsuarios repoUsuarios, IRepoRoles repoRoles)
//    {
//        this.repoUsuarios = repoUsuarios;
//        this.repoRoles = repoRoles;
//        this.usuariosMapper = new UsuariosMapper();
//    }

//    public UsuariosDTO? ObtenerLogin(string user, string pass)
//    {
//        var usuario = repoUsuarios.GetByUserPass(user, pass);
//        if (usuario == null) return null;

//        return MapearAUnDTO(usuario);
//    }

//    private UsuariosDTO MapearAUnDTO(Usuarios usuarios)
//    {
//        try
//        {
//            Dictionary<int, string> rol = repoRoles.GetAll().ToDictionary(r => r.IdRol, r => r.Rol);
//            return usuariosMapper.ToDTO(usuarios, rol);
//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error al mapear los roles del usuario", ex);
//        }
//    }


//    private IEnumerable<UsuariosDTO> MapearAListaDTO(IEnumerable<Usuarios> lista)
//    {
//        Dictionary<int, string> rol = repoRoles.GetAll().ToDictionary(r => r.IdRol, r => r.Rol);

//        return usuariosMapper.Mapear(lista, rol);
//    }
//}

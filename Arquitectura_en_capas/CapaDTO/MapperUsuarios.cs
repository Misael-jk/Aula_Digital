using Dapper;
using CapaDatos;
using CapaDTO.Interface;
using System.Data;
using CapaDTO.DTOs;
using CapaEntidad;

namespace CapaDTO
{
    public class MapperUsuarios : RepoBase, IMapperUsuarios
    {
        public MapperUsuarios(IDbConnection conexion) 
            : base(conexion) 
        {
        }

        public IEnumerable<UsuariosDTO> GetAllDTO()
        {
            return Conexion.Query<Usuarios, Roles, UsuariosDTO>(
                "GetUsuariosDTO",
                (usuario, rol) => new UsuariosDTO
                {
                    IdUsuario = usuario.IdUsuario,
                    Usuario = usuario.Usuario,
                    Password = usuario.Password,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Rol = rol.Rol,
                    Email = usuario.Email
                },
                commandType: CommandType.StoredProcedure,
                splitOn: "Rol"
            ).ToList();
        }

        public UsuariosDTO? GetById(int idUsuario)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idUsuario", idUsuario, DbType.Int32, ParameterDirection.Input);

            return Conexion.Query<Usuarios, Roles, UsuariosDTO>(
                "GetUsuarioByIdDTO",
                (usuario, rol) => new UsuariosDTO
                {
                    IdUsuario = usuario.IdUsuario,
                    Usuario = usuario.Usuario,
                    Password = usuario.Password,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Rol = rol.Rol,
                    Email = usuario.Email
                },
                parametros,
                commandType: CommandType.StoredProcedure,
                splitOn: "Rol"
            ).FirstOrDefault();
        }
    }
}

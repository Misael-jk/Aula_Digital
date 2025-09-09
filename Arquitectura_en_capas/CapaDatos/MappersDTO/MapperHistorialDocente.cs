using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaDTOs.AuditoriaDTO;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperHistorialDocente : RepoBase, IMapperHistorialDocente
{
    public MapperHistorialDocente(IDbConnection conexion) : base(conexion)
    {
    }

    public IEnumerable<HistorialDocentesDTO> GetAllDTO()
    {
        return Conexion.Query<HistorialCambios, TipoAccion, Docentes, UsuariosDTO, HistorialDocentesDTO>(
            "GetHistorialDocentesDTO",
            (historial, accion, docente, usuario) => new HistorialDocentesDTO
            {
                NombreDocente = docente.Nombre,
                ApellidoDocente = docente.Apellido,
                DNI = docente.Dni,
                Email = docente.Email,
                Descripcion = historial?.Descripcion,
                FechaCambio = historial.FechaCambio,
                AccionRealizada = accion.Accion,
                Usuario = usuario.Apellido
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "FechaCambio,Accion,Nombre,Apellido"
        ).ToList();
    }
}

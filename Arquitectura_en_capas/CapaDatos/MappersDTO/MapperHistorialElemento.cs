using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaDTOs.AuditoriaDTO;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperHistorialElemento : RepoBase, IMapperHistorialElemento
{
    public MapperHistorialElemento(IDbConnection conexion) : base(conexion)
    {
    }
    public IEnumerable<HistoralElementoDTO> GetAllDTO()
    {
        return Conexion.Query<HistorialCambios, TipoAccion, ElementosDTO, UsuariosDTO, HistoralElementoDTO>(
            "GetHistorialElementosDTO",
            (historial, accion, elemento, usuario) => new HistoralElementoDTO
            {
                NumeroSerie = elemento.NumeroSerie,
                CodigoBarra = elemento.CodigoBarra,
                Modelo = elemento.Modelo,
                TipoElemento = elemento.TipoElemento,
                UbicacionActual = elemento.Ubicacion,
                EstadoMantenimiento = elemento.Estado,
                Descripcion = historial?.Descripcion,
                FechaCambio = historial.FechaCambio,
                AccionRealizada = accion.Accion,
                Usuario = usuario.Apellido
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "FechaCambio,Accion,NombreElemento,Apellido"
        ).ToList();
    }
}

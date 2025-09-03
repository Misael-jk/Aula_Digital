using CapaDTOs;
using CapaDatos.InterfacesDTO;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperElementoMantenimiento : RepoBase, IMapperElementoMantenimiento
{
    public MapperElementoMantenimiento(IDbConnection conexion) 
        : base(conexion)
    {
    }

    public IEnumerable<ElementoMantenimientoDTO> GetAllDTO()
    {
        return Conexion.Query<Elemento, TipoElemento, EstadosMantenimiento, ElementoMantenimientoDTO>(
            "GetElementosMantenimientoDTO",
            (elemento, tipo, estado) => new ElementoMantenimientoDTO
            {
                IdElemento = elemento.IdElemento,
                TipoElemento = tipo.ElementoTipo,
                NumeroSerie = elemento.numeroSerie,
                Estado = estado.EstadoMantenimientoNombre,
                Disponible = elemento.Habilitado,
                FechaBaja = elemento.FechaBaja
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "numeroSerie,ElementoTipo,EstadoMantenimientoNombre"
        ).ToList();
    }

    public IEnumerable<ElementoMantenimientoDTO> GetByTipo(int idTipoElemento)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("unidTipoElemento", idTipoElemento);

        return Conexion.Query<Elemento, TipoElemento, EstadosMantenimiento, ElementoMantenimientoDTO>(
            "GetElementosMantenimientoByTipoDTO",
            (elemento, tipo, estado) => new ElementoMantenimientoDTO
            {
                IdElemento = elemento.IdElemento,
                TipoElemento = tipo.ElementoTipo,
                NumeroSerie = elemento.numeroSerie,
                Estado = estado.EstadoMantenimientoNombre,
                Disponible = elemento.Habilitado,
                FechaBaja = elemento.FechaBaja
            },
            parameters,
            commandType: CommandType.StoredProcedure,
            splitOn: "numeroSerie,ElementoTipo,EstadoMantenimientoNombre"
        ).ToList();
    }

    public IEnumerable<ElementoMantenimientoDTO> GetByEstado(int idEstadoElemento)
    {
        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("unidEstadoElemento", idEstadoElemento);

        return Conexion.Query<Elemento, TipoElemento, EstadosMantenimiento, ElementoMantenimientoDTO>(
            "GetElementosMantenimientoByEstadoDTO",
            (elemento, tipo, estado) => new ElementoMantenimientoDTO
            {
                IdElemento = elemento.IdElemento,
                TipoElemento = tipo.ElementoTipo,
                NumeroSerie = elemento.numeroSerie,
                Estado = estado.EstadoMantenimientoNombre,
                Disponible = elemento.Habilitado,
                FechaBaja = elemento.FechaBaja
            },
            parameters,
            commandType: CommandType.StoredProcedure,
            splitOn: "numeroSerie,ElementoTipo,EstadoMantenimientoNombre"
        ).ToList();
    }
}

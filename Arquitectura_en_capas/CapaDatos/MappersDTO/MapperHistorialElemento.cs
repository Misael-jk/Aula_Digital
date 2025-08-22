using CapaEntidad;
using CapaDTOs;
using CapaDatos.InterfacesDTO;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperHistorialElemento : RepoBase, IMapperHistorialElemento
{
    public MapperHistorialElemento(IDbConnection conexion)
        : base(conexion)
    {
    }

    public IEnumerable<HistorialElementoDTO> GetAllDTO()
    {
        return Conexion.Query<HistorialElemento, TipoElemento, Elemento, Carritos, EstadosElemento, HistorialElementoDTO>(
            "GetHistorialElementosDTO",
            (historial, tipo, elemento, carrito, estado) => new HistorialElementoDTO
            {
                IdHistorialElemento = historial.IdHistorialElemento,
                TipoElemento = tipo.ElementoTipo,
                NumeroSerie = elemento.numeroSerie,
                NumeroSerieCarrito = carrito?.NumeroSerieCarrito ?? "Sin Carrito",
                EstadoElemento = estado.EstadoElementoNombre,
                FechaHora = historial.FechaHora,
                Observacion = historial.Observacion
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo,numeroSerie,NumeroSerieCarrito,EstadoElementoNombre"
        ).ToList();
    }

    public IEnumerable<HistorialElementoDTO> GetByElementoDTO(int idElemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("@idElemento", idElemento, DbType.Int32, ParameterDirection.Input);

        return Conexion.Query<HistorialElemento, TipoElemento, Elemento, Carritos, EstadosElemento, HistorialElementoDTO>(
            "GetHistorialByElementoDTO",
            (historial, tipo, elemento, carrito, estado) => new HistorialElementoDTO
            {
                IdHistorialElemento = historial.IdHistorialElemento,
                TipoElemento = tipo.ElementoTipo,
                NumeroSerie = elemento.numeroSerie,
                NumeroSerieCarrito = carrito?.NumeroSerieCarrito ?? "Sin Carrito",
                EstadoElemento = estado.EstadoElementoNombre,
                FechaHora = historial.FechaHora,
                Observacion = historial.Observacion
            },
            parametros,
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo,numeroSerie,NumeroSerieCarrito,EstadoElementoNombre"
        ).ToList();
    }

    public IEnumerable<HistorialElementoDTO> GetByEstadoDTO(int idEstadoElemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("@idEstadoElemento", idEstadoElemento, DbType.Int32, ParameterDirection.Input);

        return Conexion.Query<HistorialElemento, TipoElemento, Elemento, Carritos, EstadosElemento, HistorialElementoDTO>(
            "GetHistorialByEstadoElementoDTO",
            (historial, tipo, elemento, carrito, estado) => new HistorialElementoDTO
            {
                IdHistorialElemento = historial.IdHistorialElemento,
                TipoElemento = tipo.ElementoTipo,
                NumeroSerie = elemento.numeroSerie,
                NumeroSerieCarrito = carrito?.NumeroSerieCarrito ?? "Sin Carrito",
                EstadoElemento = estado.EstadoElementoNombre,
                FechaHora = historial.FechaHora,
                Observacion = historial.Observacion
            },
            parametros,
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo,numeroSerie,NumeroSerieCarrito,EstadoElementoNombre"
        ).ToList();
    }
}

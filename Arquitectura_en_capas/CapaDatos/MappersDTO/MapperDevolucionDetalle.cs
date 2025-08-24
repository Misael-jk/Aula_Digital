using CapaEntidad;
using Dapper;
using CapaDatos.InterfacesDTO;
using CapaDTOs;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperDevolucionDetalle : RepoBase, IMapperDevolucionDetalle
{
    public MapperDevolucionDetalle(IDbConnection conexion)
    : base(conexion)
    {
    }

    public IEnumerable<DevolucionDetalleDTO> GetAllDTO()
    {
        return Conexion.Query<Devolucion, Elemento, TipoElemento, Carritos, EstadosElemento, DevolucionDetalleDTO>(
            "GetDevolucionDetalleDTO",
            (devolucion, elemento, tipo, carrito, estado) => new DevolucionDetalleDTO
            {
                TipoElemento = tipo.ElementoTipo,
                NumeroSerieElemento = elemento.numeroSerie,
                NumeroSerieCarrito = carrito?.NumeroSerieCarrito ?? "Sin carrito",
                EstadoElemento = estado.EstadoElementoNombre,
                FechaDevolucion = devolucion.FechaDevolucion,
                Observacion = devolucion.Observaciones ?? "Sin observaciones"
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "FechaDevolucion,numeroSerie,ElementoTipo, NumeroSerieCarrito,EstadoElementoNombre"
        ).ToList();
    }

    public DevolucionDetalleDTO? GetByIdDTO(int idDevolucion)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@idDevolucion", idDevolucion, dbType: DbType.Int32, ParameterDirection.Input);

        return Conexion.Query<Devolucion, Elemento, TipoElemento, Carritos, EstadosElemento, DevolucionDetalleDTO>(
            "GetDevolucionDetalleDTO",
            (devolucion, elemento, tipo, carrito, estado) => new DevolucionDetalleDTO
            {
                TipoElemento = tipo.ElementoTipo,
                NumeroSerieElemento = elemento.numeroSerie,
                NumeroSerieCarrito = carrito?.NumeroSerieCarrito ?? "Sin carrito",
                EstadoElemento = estado.EstadoElementoNombre,
                FechaDevolucion = devolucion.FechaDevolucion,
                Observacion = devolucion.Observaciones ?? "Sin observaciones"
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo, numeroSerie, NumeroSerieCarrito, FechaDevolucion, EstadoElementoNombre"
        ).FirstOrDefault();
    }

}

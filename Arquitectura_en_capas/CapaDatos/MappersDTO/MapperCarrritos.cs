using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperCarrritos : RepoBase, IMapperCarritos
{
    public MapperCarrritos(IDbConnection conexion) : base(conexion)
    {
    }

    public IEnumerable<CarritosDTO> GetAllDTO()
    {
        return Conexion.Query<Carritos, EstadosMantenimiento, CarritosDTO>(
        "GetCarritosDTO",
        (carrito, estadoMantenimiento) => new CarritosDTO
        {
            IdCarrito = carrito.IdCarrito,
            NumeroSerieCarrito = carrito.NumeroSerieCarrito,
            EstadoMantenimiento = estadoMantenimiento.EstadoMantenimientoNombre
        },
        commandType: CommandType.StoredProcedure,
        splitOn: "EstadoMantenimientoNombre");
    }
}

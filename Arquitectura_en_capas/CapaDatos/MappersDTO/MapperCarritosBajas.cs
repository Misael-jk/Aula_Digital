using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperCarritosBajas : RepoBase, IMapperCarritosBajas
{
    public MapperCarritosBajas(IDbConnection conexion)
        : base(conexion)
    {
    }

    public IEnumerable<CarrtiosBajasDTO> GetAllDTO()
    {
        return Conexion.Query<Carritos, EstadosMantenimiento, CarrtiosBajasDTO>(
            "GetCarritosBajasDTO",
            (carrito, estado) => new CarrtiosBajasDTO
            {
                IdCarrito = carrito.IdCarrito,
                NumeroSerieCarrito = carrito.NumeroSerieCarrito,
                EstadoMantenimiento = estado.EstadoMantenimientoNombre,
                FechaBaja = carrito.FechaBaja
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "NumeroSerieCarrito,EstadoMantenimientoNombre"
        ).ToList();
    }
}

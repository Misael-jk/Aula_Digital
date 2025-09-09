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
        return Conexion.Query<Carritos, Ubicacion, Modelos, EstadosMantenimiento, CarritosDTO>(
        "GetCarritosDTO",
        (carrito, ubicacion, modelo, estadoMantenimiento) => new CarritosDTO
        {
            IdCarrito = carrito.IdCarrito,
            NumeroSerieCarrito = carrito.NumeroSerieCarrito,
            EstadoMantenimiento = estadoMantenimiento.EstadoMantenimientoNombre,
            UbicacionActual = ubicacion.NombreUbicacion,
            Modelo = modelo.NombreModelo,
        },
        commandType: CommandType.StoredProcedure,
        splitOn: "NombreUbicacion,NombreModelo,EstadoMantenimientoNombre");
    }
}

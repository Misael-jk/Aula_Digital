using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaDTOs.AuditoriaDTO;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperHistorialCarrito : RepoBase, IMapperHistorialCarrito
{
    public MapperHistorialCarrito(IDbConnection conexion) : base(conexion)
    {
    }

    public IEnumerable<HistorialCarritosDTO> GetAllDTO()
    {
        return Conexion.Query<HistorialCambios, TipoAccion, CarritosDTO, UsuariosDTO, HistorialCarritosDTO>(
            "GetHistorialCarritosDTO",
            (historial, accion, carrito, usuario) => new HistorialCarritosDTO
            {
                NumeroSerie = carrito.NumeroSerieCarrito,
                UbicacionActual = carrito.UbicacionActual,
                Modelo = carrito.Modelo,
                EstadoMantenimiento = carrito.EstadoMantenimiento,
                Descripcion = historial?.Descripcion,
                FechaCambio = historial.FechaCambio,
                AccionRealizada = accion.Accion,
                Usuario = usuario.Apellido

            },
            commandType: CommandType.StoredProcedure,
            splitOn: "FechaCambio,Accion,NumeroSerieCarrito,Apellido"
        ).ToList();
    }
}

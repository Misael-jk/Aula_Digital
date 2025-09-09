using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaDTOs.AuditoriaDTO;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperHistorialNotebook : RepoBase, IMapperHistorialNotebook
{
    public MapperHistorialNotebook(IDbConnection conexion) : base(conexion)
    {
    }

    public IEnumerable<HistorialNotebooksDTO> GetAllDTO()
    {
        return Conexion.Query<HistorialCambios, TipoAccion, NotebooksDTO, UsuariosDTO, HistorialNotebooksDTO>(
            "GetHistorialNotebooksDTO",
            (historial, accion, notebook, usuario) => new HistorialNotebooksDTO
            {
                NumeroSerie = notebook.NumeroSerieNotebook,
                CodigoBarra = notebook.CodigoBarra,
                Modelo = notebook.Modelo,
                Carrito = notebook.NumeroSerieCarrito,
                PosicionCarrito = notebook.PosicionCarrito,
                EstadoMantenimiento = notebook.Estado,
                Descripcion = historial?.Descripcion,
                FechaCambio = historial.FechaCambio,
                AccionRealizada = accion.Accion,
                Usuario = usuario.Apellido
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "FechaCambio,Accion,NombreNotebook,Apellido"
        ).ToList();
    }
}

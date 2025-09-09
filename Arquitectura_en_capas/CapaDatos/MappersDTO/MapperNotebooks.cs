using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.MappersDTO;

public class MapperNotebooks : RepoBase, IMapperNotebooks
{
    public MapperNotebooks(IDbConnection conexion) : base(conexion)
    {
    }

    public IEnumerable<NotebooksDTO> GetAllDTO()
    {
        return Conexion.Query<Notebooks, Carritos, ElementosDTO, NotebooksDTO>(
            "GetNotebooksDTO",
            (notebook, carritos, elementos) => new NotebooksDTO
            {
                IdNotebook = notebook.IdElemento,
                NumeroSerieNotebook = notebook.NumeroSerie,
                CodigoBarra = notebook.CodigoBarra,
                Patrimonio = notebook.Patrimonio,
                Modelo = elementos.Modelo,
                NumeroSerieCarrito = carritos.NumeroSerieCarrito,
                PosicionCarrito = notebook.PosicionCarrito,
                Estado = elementos.Estado
            },
            commandType: CommandType.StoredProcedure
        ).ToList();
    }
}

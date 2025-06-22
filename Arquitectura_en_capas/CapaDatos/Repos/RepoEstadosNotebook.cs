using Dapper;
using Sistema_de_notebooks.CapaDatos.DTOs;
using Sistema_de_notebooks.CapaDatos.Interfaces;
using Sistema_de_notebooks.CapaEntidad;
using System.Data;

namespace Sistema_de_notebooks.CapaDatos.Repos;

public class RepoEstadosNotebook : RepoBase, IRepoEstadosNotebook
{
    public RepoEstadosNotebook(IDbConnection conexion)
   : base(conexion)
    {
    }

    public IEnumerable<EstadosNotebook> ListarEstadosNotebook()
    {
        string query = "select idEstadoNotebook, estadoNotebook from EstadosNotebook order by idEstadoNotebook asc";

        try
        {
            return Conexion.Query<EstadosNotebook>(query);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los datos de los estados de las notebooks");
        }
    }

    public IEnumerable<EstadosNotebookDTO> EstadosDeLaNotebook(int idEstadoNotebook)
    {
        string query = "select * from WievEstadosDeLaNotebook where idEstadoNotebook = @idEstadoNotebook";

        try
        {
            return Conexion.Query<EstadosNotebookDTO>(query, new { idEstadoNotebook }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al mostrar los estados de las notebook" + ex.Message);
        }
    }

}

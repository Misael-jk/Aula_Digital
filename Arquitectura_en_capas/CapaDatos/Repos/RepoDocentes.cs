using Dapper;
using Sistema_de_notebooks.CapaDatos;
using Sistema_de_notebooks.CapaDatos.Interfaces;
using Sistema_de_notebooks.CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoDocentes : RepoBase, IRepoDocentes
{
    public RepoDocentes(IDbConnection conexion)
   : base(conexion)
    {
    }

    #region Alta Docente
    public void AltaDocente(Docentes docentes)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidDocente", dbType: DbType.Int32, direction: ParameterDirection.Output);

        parametros.Add("undni", docentes.Dni);
        parametros.Add("unnombre", docentes.Nombre);
        parametros.Add("unapellido", docentes.Apellido);
        parametros.Add("unemail", docentes.Email);

        try
        {
            Conexion.Execute("AltaAlumno", parametros, commandType: CommandType.StoredProcedure);
            docentes.IdDocente = parametros.Get<int>("unidDocente");
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar un docente");
        }
    }
    #endregion

    #region Actualizar Docente
    public void ActualizarDocente(Docentes docentes)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidDocente", docentes.IdDocente);
        parametros.Add("undni", docentes.Dni);
        parametros.Add("unnombre", docentes.Nombre);
        parametros.Add("unapellido", docentes.Apellido);
        parametros.Add("unemail", docentes.Email);

        try
        {
            Conexion.Execute("UpdateAlumno", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al actualizar un docente");
        }
    }
    #endregion

    #region Eliminar Docente
    public void EliminarDocente(int idDocente)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidDocente", idDocente);

        try
        {
            Conexion.Execute("DeleteDocente", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al eliminar un docente");
        }
    }
    #endregion

    #region Obtener todo los datos
    public IEnumerable<Docentes> ListarDocentes()
    {
        string query = "select * from Docentes";

        try
        {
            return Conexion.Query<Docentes>(query);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los datos de los docentes");
        }
    }
    #endregion

    #region Obtener por Id
    public Docentes? DetalleDocentes(int idDocente)
    {
        string query = "select * from Docentes where idDocente = unidDocente";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("unidDocente", idDocente);
            return Conexion.QueryFirstOrDefault<Docentes>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el id del docente");
        }
    }
    #endregion
}

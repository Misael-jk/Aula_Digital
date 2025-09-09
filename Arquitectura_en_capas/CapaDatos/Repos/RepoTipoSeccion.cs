using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoTipoSeccion : RepoBase, IRepoTipoSeccion
{
    public RepoTipoSeccion(string conexion) : base(conexion)
    {
    }

    public IEnumerable<TipoSeccion> GetAll()
    {
        string query = "select * from TipoSeccion";

        try
        {
            return Conexion.Query<TipoSeccion>(query);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al traer las secciones");
        }
    }

    public TipoSeccion? GetById(int idTipoSeccion)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidTipoSeccion", idTipoSeccion);

        string sql = "select * from TipoSeccion where idTipoSeccion = @unidTipoSeccion";

        try
        {
            return Conexion.QueryFirstOrDefault<TipoSeccion>(sql, parameters);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al traer la seccion");
        }
    }
}

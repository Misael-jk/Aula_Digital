using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoModelo : RepoBase, IRepoModelo
{
    public RepoModelo(IDbConnection dbConnection) : base(dbConnection)
    {
    }

    public void Insert(Modelos modelo)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidModelo", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("unnombre", modelo.NombreModelo);
        parameters.Add("unidTipoElemento", modelo.IdTipoElemento);
        try
        {
            Conexion.Execute("InsertModelo", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar un modelo");
        }
    }

    public void Update(Modelos modelo)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidModelo", modelo.IdModelo);
        parameters.Add("unnombre", modelo.NombreModelo);
        parameters.Add("unidTipoElemento", modelo.IdTipoElemento);
        try
        {
            Conexion.Execute("UpdateModelo", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al actualizar un modelo");
        }
    }

    public IEnumerable<Modelos> GetAll()
    {
        string query = "selecto * from Modelos";

        return Conexion.Query<Modelos>(query);
    }

    public Modelos? GetById(int idModelo)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidModelo", idModelo);

        string query = "select * from Modelos where idModelo = @unidModelo";
        
        try
        {
            return Conexion.QueryFirstOrDefault<Modelos>(query, parameters);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al obtener un modelo por id");
        }
    }

    public IEnumerable<Modelos> GetByTipo(int idTipoElemento)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidTipoElemento", idTipoElemento);

        string query = "select * from Modelos where idTipoElemento = @unidTipoElemento";

        try
        {
            return Conexion.Query<Modelos>(query, parameters);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al obtener los modelos por tipo de elemento");
        }
    }
}

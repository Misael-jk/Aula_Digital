using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoHistorialElemento : RepoBase, IRepoHistorialElemento
{
    public RepoHistorialElemento(IDbConnection conexion)
        : base(conexion)
    {
    }

    public void Insert(HistorialElemento historialElemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidHistorialElemento", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parametros.Add("unidElemento", historialElemento.IdElemento);
        parametros.Add("unidCarrito", historialElemento.IdCarrito);
        parametros.Add("unidUsuario", historialElemento.idUsuario);
        parametros.Add("unidEstadoElemento", historialElemento.IdEstadoElemento);
        parametros.Add("unFechaHora", historialElemento.FechaHora);
        parametros.Add("unObservacion", historialElemento.Observacion);

        try
        {
            Conexion.Execute("InsertHistorialElemento", parametros, commandType: CommandType.StoredProcedure);
            historialElemento.IdHistorialElemento = parametros.Get<int>("unidHistorialElemento");
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar el historial del elemento");
        }
    }

    public HistorialElemento? GetById(int idHistorialElemento) 
    {
        string query = "SELECT * FROM HistorialElementos WHERE IdHistorialElemento = @idHistorialElemento";

        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("idHistorialElemento", idHistorialElemento);

        try
        {
            return Conexion.QueryFirstOrDefault<HistorialElemento>(query, parameters);
        }
        catch (Exception)
        {
            throw new Exception("No se encontró el historial del elemento con el id proporcionado");
        }
    }

    public IEnumerable<HistorialElemento> GetByElemento(int idElemento)
    {
        string query = "SELECT * FROM HistorialElementos WHERE IdElemento = @idElemento";
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("idElemento", idElemento);
        try
        {
            return Conexion.Query<HistorialElemento>(query, parameters);
        }
        catch (Exception)
        {
            throw new Exception("No se encontraron los historiales para el elemento con el id proporcionado");
        }
    }

    public IEnumerable<HistorialElemento> GetByEstado(int idEstadoElemento)
    {
        string query = "SELECT * FROM HistorialElementos WHERE IdEstadoElemento = @idEstadoElemento";

        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("idEstadoElemento", idEstadoElemento);

        try
        {
            return Conexion.Query<HistorialElemento>(query, parameters);
        }
        catch (Exception)
        {
            throw new Exception("No se encontraron los historiales para el estado del elemento con el id proporcionado");
        }
    }

    public IEnumerable<HistorialElemento> GetAll()
    {
        string query = "SELECT * FROM HistorialElementos";
        try
        {
            return Conexion.Query<HistorialElemento>(query);
        }
        catch (Exception)
        {
            throw new Exception("No se encontraron los historiales de elementos");
        }
    }
}

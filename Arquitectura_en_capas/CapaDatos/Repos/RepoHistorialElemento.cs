using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoHistorialElemento : RepoBase, IRepoHistorialElementos
{
    public RepoHistorialElemento(IDbConnection conexion) : base(conexion)
    {
    }

    public void Insert(HistorialElementos historialElementos)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidHistorialCambio", historialElementos.IdHistorialCambio);
        parameters.Add("unidElemento", historialElementos.IdElementos);

        try
        {
            Conexion.Execute("InsertHistorialElemento", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar un historial de elemento");
        }
    }

    public IEnumerable<HistorialElementos> GetAll(HistorialElementos historialElementos)
    {
        string query = "select * from HistorialElementos";
        return Conexion.Query<HistorialElementos>(query);
    }
}

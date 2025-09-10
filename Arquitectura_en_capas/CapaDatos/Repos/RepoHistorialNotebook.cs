using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoHistorialNotebook : RepoBase, IRepoHistorialNotebook
{
    public RepoHistorialNotebook(IDbConnection conexion) : base(conexion)
    {
    }

    public void Insert(HistorialNotebooks historialNotebooks)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidHistorialCambio", historialNotebooks.IdHistorialCambio);
        parameters.Add("unidNotebook", historialNotebooks.IdNotebook);
        try
        {
            Conexion.Execute("InsertHistorialNotebook", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar un historial de notebook");
        }
    }

    public IEnumerable<HistorialNotebooks> GetAll(HistorialNotebooks historialNotebooks)
    {
        string query = "select * from HistorialNotebooks";
        return Conexion.Query<HistorialNotebooks>(query);
    }
}

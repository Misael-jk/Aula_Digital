using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoHistorialCarrito : RepoBase, IRepoHistorialaCarrito
{
    public RepoHistorialCarrito(IDbConnection conexion) : base(conexion)
    {
    }

    public void Insert(HistorialCarritos historialCarritos)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidHistorialCambio", historialCarritos.IdHistorialCambio);
        parameters.Add("unidCarrito", historialCarritos.IdCarrito);
        try
        {
            Conexion.Execute("InsertHistorialCarrito", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar un historial de carrito");
        }
    }

    public IEnumerable<HistorialCarritos> GetAll(HistorialCarritos historialCarritos)
    {
        string query = "select * from HistorialCarritos";
        return Conexion.Query<HistorialCarritos>(query);
    }
}

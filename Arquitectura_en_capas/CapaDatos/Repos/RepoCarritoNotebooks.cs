using Dapper;
using System.Data;
using Sistema_de_notebooks.CapaDatos;
using Sistema_de_notebooks.CapaDatos.Interfaces;
using Sistema_de_notebooks.CapaEntidad;

namespace CapaDatos.Repos;

public class RepoCarritoNotebooks : RepoBase, IRepoCarritoNotebooks
{
    public RepoCarritoNotebooks(IDbConnection conexion) : base(conexion)
    {
    }

    public IEnumerable<CarritoNotebooks> ListarNotebooksCarrito(int idCarrito)
    {
        string query = "select * from CarritoNotebooks where idCarrito = @idCarrito";

        try
        {
            return Conexion.Query<CarritoNotebooks>(query, new { idCarrito });
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener la relación carrito-notebooks.");
        }
    }


}

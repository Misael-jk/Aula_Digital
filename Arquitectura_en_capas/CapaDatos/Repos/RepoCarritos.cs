using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoCarritos : RepoBase, IRepoCarritos
{
    public RepoCarritos(IDbConnection conexion)
   : base(conexion)
    {
    }

    #region Alta Carrito
    public void Insert(Carritos carritos)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidCarrito", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parametros.Add("unDisponibleCarrito", carritos.DisponibleCarrito);

        try
        {
            Conexion.Execute("InsertCarrito", parametros, commandType: CommandType.StoredProcedure);
            carritos.IdCarrito = parametros.Get<int>("unidCarrito");
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar un carrito");
        }
    }
    #endregion 

    #region Actualizar Carrito
    public void Update(Carritos carritos)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidCarrito", carritos.IdCarrito);
        parametros.Add("unDisponibleCarrito", carritos.DisponibleCarrito);


        try
        {
            Conexion.Execute("UpdateCarrito", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al actualizar un carrito");
        }
    }
    #endregion

    #region Eliminar Carrito
    public void Delete(int idCarrito)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidCarrito", idCarrito);

        try
        {
            Conexion.Execute("DeleteCarrito", parametros, commandType: CommandType.StoredProcedure);
        }
        catch(Exception)
        {
            throw new Exception("Hubo un error al eliminar un carrito");
        }
    }
    #endregion

    #region Obtener todos los datos
    public IEnumerable<Carritos> GetAll()
    {
        string query = "select * from Carritos";
        try
        {
            return Conexion.Query<Carritos>(query);
        }
        catch (Exception)
        {
            throw new Exception("No se pudo Obtener los datos de los carritos");
        }
    }
    #endregion

    #region Obtener por Id
    public Carritos? GetById(int idCarrito)
    {
        string query = "select * from Carritos where idCarrito = unidCarrito";

        DynamicParameters parametros = new DynamicParameters();

        try
        {
            parametros.Add("unidCarrito", idCarrito);
            return Conexion.QueryFirstOrDefault<Carritos>(query, parametros);
        }
        catch(Exception)
        {
            throw new Exception("Error al obtener el id del carrito");
        }
        
    }
    #endregion
}

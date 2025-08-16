using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;
using System.Data.Common;

namespace CapaDatos.Repos;

public class RepoElemento : RepoBase, IRepoElemento
{
    public RepoElemento(IDbConnection conexion)
   : base(conexion)
    {
    }

    #region Alta Elemento 
    public void Insert(Elemento elemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidElemento", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parametros.Add("unidTipoElemento", elemento.IdTipoElemento);
        parametros.Add("unidCarrito", elemento.IdCarrito);
        parametros.Add("unidEstadoElemento", elemento.IdEstadoElemento);
        parametros.Add("unnumeroSerie", elemento.numeroSerie);
        parametros.Add("uncodigoBarra", elemento.codigoBarra);
        parametros.Add("unDisponible", elemento.Disponible);


        try
        {
            Conexion.Execute("InsertElemento", parametros, commandType: CommandType.StoredProcedure);
            elemento.IdElemento = parametros.Get<int>("unidElemento");
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar un elemento");
        }
    }
    #endregion

    #region Actualizar Elemento
    public void Update(Elemento elemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidElemento", elemento.IdElemento);
        parametros.Add("unidTipoElemento", elemento.IdTipoElemento);
        parametros.Add("unidCarrito", elemento.IdCarrito);
        parametros.Add("unidEstadoElemento", elemento.IdEstadoElemento);
        parametros.Add("unnumeroSerie", elemento.numeroSerie);
        parametros.Add("uncodigoBarra", elemento.codigoBarra);
        parametros.Add("unDisponible", elemento.Disponible); ;

        try
        {
            Conexion.Execute("UpdateElemento", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al actualizar un Elemento");
        }
    }
    #endregion

    #region Eliminar Elemento
    public void Delete(int idElemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidElemento", idElemento);

        try
        {
            Conexion.Execute("DeleteElemento", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al eliminar un elemento");
        }
    }
    #endregion

    #region Obtener por numero de serie
    public Elemento? GetByNumeroSerie(string numeroSerieElemento)
    {
        string query = "select * from Elementos where numeroSerie = @numeroSerieElemento";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("@numeroSerieElemento", numeroSerieElemento);
            return Conexion.QueryFirstOrDefault<Elemento>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("No se encontro el elemento con su numero de serie");
        }
    }
    #endregion

    #region Obtener por codigo de Barra
    public Elemento? GetByCodigoBarra(string codigoBarra)
    {
        string query = "select * from Elementos where codigoBarra = @codigoBarra";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("codigoBarra", codigoBarra);
            return Conexion.QueryFirstOrDefault<Elemento>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("No se encontro el elemento con su codigo de barra");
        }
    }
    #endregion

    #region Obtener por Id elemento
    public Elemento? GetById(int idElemento)
    {
        string query = "select * from Elementos where idElemento = @idElemento";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("@idElemento", idElemento);
            return Conexion.QueryFirstOrDefault<Elemento>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("No se encontro el id del elemento");
        }
    }
    #endregion

    #region Obtener por Carrito
    public IEnumerable<Elemento> GetByCarrito(int idCarrito)
    {
        string query = "select * from Elementos where idCarrito = @idCarrito";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("idCarrito", idCarrito);
            return Conexion.Query<Elemento>(query, parametros).ToList();
        }
        catch (Exception)
        {
            throw new Exception("No se encontro el carrito de los elementos");
        }
    }
    #endregion

    public bool GetDisponible(int idElemento)
    {

        string sql = "select * from Elementos where IdElemento = @IdElemento and IdEstadoElemento = 1 and Disponible = true limit 1;";

        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("IdElemento", idElemento);

        int disponible = Conexion.ExecuteScalar<int>(sql, parameters);

        return disponible > 0;
    }

    public void UpdateEstado(int idElemento, bool disponible)
    {
        string sql = @"update Elementos
                       set idEstadoElemento = 2, Disponible = @Disponible
                       where idElemento = @IdElemento";

        DynamicParameters parameters = new DynamicParameters();

        parameters.Add("@Disponible", disponible);
        parameters.Add("@IdElemento", idElemento);

        Conexion.Execute(sql, parameters);
    }
}

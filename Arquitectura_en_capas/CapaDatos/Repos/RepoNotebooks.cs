using CapaDatos.Interfaces;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.Repos;

public class RepoNotebooks : RepoBase, IRepoNotebooks
{
    public RepoNotebooks(IDbConnection conexion) : base(conexion)
    {
    }

    public void Insert(Notebooks notebooks)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidNotebook", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("unidModelo", notebooks.IdModelo);
        parameters.Add("unidCarrito", notebooks.IdCarrito);
        parameters.Add("unaposicionCarrito", notebooks.PosicionCarrito);
        parameters.Add("unidEstado", notebooks.IdEstadoMantenimiento);
        parameters.Add("unnumeroSerie", notebooks.NumeroSerie);
        parameters.Add("uncodigoBarra", notebooks.CodigoBarra);
        parameters.Add("unpatrimonio", notebooks.Patrimonio);
        parameters.Add("unhabilitado", notebooks.Habilitado);
        parameters.Add("unfechaBaja", notebooks.FechaBaja);

        try
        {
            Conexion.Execute("InsertNotebook", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar una notebook");
        }
    }

    public void Update(Notebooks notebooks)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidNotebook", notebooks.IdElemento);
        parameters.Add("unnumeroSerie", notebooks.NumeroSerie);
        parameters.Add("uncodigoBarra", notebooks.CodigoBarra);
        parameters.Add("unidModelo", notebooks.IdModelo);
        parameters.Add("unidCarrito", notebooks.IdCarrito);
        parameters.Add("unaposicionCarrito", notebooks.PosicionCarrito);
        parameters.Add("unidEstado", notebooks.IdEstadoMantenimiento);
        parameters.Add("unpatrimonio", notebooks.Patrimonio);
        parameters.Add("unhabilitado", notebooks.Habilitado);
        parameters.Add("unfechaBaja", notebooks.FechaBaja);
        try
        {
            Conexion.Execute("UpdateNotebook", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al actualizar una notebook");
        }
    }

    public Notebooks? GetById(int idNotebook)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidNotebook", idNotebook);

        try
        {
            return Conexion.QueryFirstOrDefault<Notebooks>("sp_ObtenerNotebookPorId", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al obtener la notebook por id");
        }
    }

    public IEnumerable<Notebooks> GetAll()
    {
        string query = "select * from view_GetAllNotebooks";

        try
        {
            return Conexion.Query<Notebooks>(query);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al traer las notebooks");
        }
    }

    public IEnumerable<Notebooks> GetByCarrito(int idCarrito)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("pIdCarrito", idCarrito);

        try
        {
            return Conexion.Query<Notebooks>("sp_ListarNotebooksPorCarrito", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al obtener las notebooks por carrito");
        }
    }
}

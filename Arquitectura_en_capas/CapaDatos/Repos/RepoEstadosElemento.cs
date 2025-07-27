using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoEstadosElemento : RepoBase, IRepoEstadosElemento
{
    public RepoEstadosElemento(IDbConnection conexion)
    : base(conexion)
    {
    }

    #region Mostrar todos los estados de los elementos
    public IEnumerable<EstadosElemento> GetAll()
    {
        string query = "select idEstadoElemento, estadoElemento AS estadoelementonombre from EstadosElemento";

        try
        {
            return Conexion.Query<EstadosElemento>(query);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los estados de los Elementos");
        }
    }
    #endregion

    #region Mostrar por id estados
    public EstadosElemento? GetById(int idEstadoElemento)
    {
        string query = "select * from EstadosElemento where idEstadoElemento = @idEstadoElemento";

        DynamicParameters parameters = new DynamicParameters();
        try
        {
            parameters.Add("unidEstadoElemento", idEstadoElemento);

            return Conexion.QueryFirstOrDefault<EstadosElemento>(query, parameters);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al mostrar ese estado del Elemento" + ex.Message);
        }
    }
    #endregion
}

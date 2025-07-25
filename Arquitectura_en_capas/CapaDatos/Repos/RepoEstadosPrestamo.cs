using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoEstadosPrestamo : RepoBase, IRepoEstadosPrestamo
{
    public RepoEstadosPrestamo(IDbConnection conexion)
    : base(conexion)
    {
    }

    #region Obtener todo los estados de los Prestamos
    public IEnumerable<EstadosPrestamo> GetAll()
    {
        string query = "select * from EstadosPrestamo";

        try
        {
            return Conexion.Query<EstadosPrestamo>(query);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los datos de los estados del prestamo");
        }
    }
    #endregion

    #region Obtener por Id los estados de los prestamos
    public EstadosPrestamo? GetById(int idEstadoPrestamo)
    {
        string query = "select * from EstadosPrestamo where idEstadoPrestamo = @idEstadoPrestamo";

        DynamicParameters parameters = new DynamicParameters();
        try
        {
            parameters.Add("unidEstadoPrestamo", idEstadoPrestamo);

            return Conexion.QueryFirstOrDefault<EstadosPrestamo>(query, parameters);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al mostrar ese estado del Prestamo" + ex.Message);
        }
    }
    #endregion
}

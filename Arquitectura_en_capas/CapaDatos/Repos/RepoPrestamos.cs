using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoPrestamos : RepoBase, IRepoPrestamos
{
    public RepoPrestamos(IDbConnection conexion)
   : base(conexion)
    {
    }

    #region Alta Prestamo
    public void Insert(Prestamos prestamos)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidPrestamo", dbType: DbType.Int32, direction: ParameterDirection.Output);

        parametros.Add("unidCurso", prestamos.IdCurso);
        parametros.Add("unidDocente", prestamos.IdDocente);
        parametros.Add("unidCarrito", prestamos.IdCarrito);
        parametros.Add("unidEncargado", prestamos.IdEncargado);
        parametros.Add("unafechaPrestamo", prestamos.FechaPrestamo);

        try
        {
            Conexion.Execute("InsertPrestamo", parametros, commandType: CommandType.StoredProcedure);
            prestamos.IdPrestamo = parametros.Get<int>("unidPrestamo");
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar un Prestamo");
        }
    }
    #endregion

    #region Actualizar Prestamo
    public void Update(Prestamos prestamos)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidPrestamo", prestamos.IdPrestamo);
        parametros.Add("unidCurso", prestamos.IdCurso);
        parametros.Add("unidDocente", prestamos.IdDocente);
        parametros.Add("unidCarrito", prestamos.IdCarrito);
        parametros.Add("unidEncargado", prestamos.IdEncargado);
        parametros.Add("unafechaPrestamo", prestamos.FechaPrestamo);

        try
        {
            Conexion.Execute("UpdatePrestamo", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al Actualizar un Prestamo");
        }
    }
    #endregion

    #region Eliminar Prestamo
    public void Delete(int idPrestamo)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidPrestamo", idPrestamo);

        try
        {
            Conexion.Execute("DeletePrestamo", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al eliminar un Prestamo");
        }
    }
    #endregion

    #region ver los prestamos
    public IEnumerable<Prestamos> GetAll()
    {
        string query = "select * from Prestamos";

        try
        {
            return Conexion.Query<Prestamos>(query);
        }
        catch(Exception)
        {
            throw new Exception("Error al ver los datos de los prestamos");
        }
    }
    #endregion

    #region obtener por Id
    public Prestamos? GetById(int idPrestamo)
    {
        string query = "select * from Prestamos where idPrestamo = unidPrestamo";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("unidPrestamo", idPrestamo);
            return Conexion.QueryFirstOrDefault<Prestamos>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el id del prestamo");
        }
    }
    #endregion

    #region obtener por id Docente
    public Prestamos? GetByDocente(int idDocente)
    {
        string query = "select * from Prestamos where idDocente = unidDocente";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("unidDocente", idDocente);
            return Conexion.QueryFirstOrDefault<Prestamos>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el id del Docente en Prestamo");
        }
    }
    #endregion
}

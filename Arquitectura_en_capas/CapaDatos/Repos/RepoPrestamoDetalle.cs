using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoPrestamoDetalle : RepoBase, IRepoPrestamoDetalle
{
    public RepoPrestamoDetalle(IDbConnection conexion)
   : base(conexion)
    {
    }

    #region Insertar Detalle del Prestamo
    public void Insert(PrestamoDetalle prestamoDetalle)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidPrestamo", prestamoDetalle.IdPrestamo);
        parametros.Add("unidElemento", prestamoDetalle.IdElemento);
        parametros.Add("unidEstadoPrestamo", prestamoDetalle.IdEstadoPrestamo);

        try
        {
            Conexion.Execute("InsertPrestamoDetalle", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al dar de alta el detalle del prestamo");
        }
    }
    #endregion

    #region Actualizar los detalles
    public void Update(PrestamoDetalle prestamoDetalle)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidPrestamo", prestamoDetalle.IdPrestamo);
        parametros.Add("unidElemento", prestamoDetalle.IdElemento);
        parametros.Add("unidEstadoPrestamo", prestamoDetalle.IdEstadoPrestamo);

        try
        {
            Conexion.Execute("UpdatePrestamoDetalle", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al actualizar el Detalle del prestamo");
        }
    }
    #endregion

    #region ver los datos del detalle
    public IEnumerable<PrestamoDetalle> GetAll()
    {
        string query = "select * from PrestamoDetalle";

        try
        {
            return Conexion.Query<PrestamoDetalle>(query);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los datos del detalle");
        }
    }
    #endregion

    #region Historial de la notebook
    public IEnumerable<HistorialNotebookDTO> HistorialNotebook(int idNotebook)
    {
        string query = "select * from WievHistorialNotebook where idNotebook = @idNotebook";

        try
        {
            return Conexion.Query<HistorialNotebookDTO>(query, new {idNotebook}).ToList();
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el historial de la notebook");
        }
    }
    #endregion

    #region Obtener Detalle por prestamos y notebooks
    public PrestamoDetalle? DetallePorPrestamo(int idPrestamo, int idNotebook)
    {
        string query = "select * from PrestamoDetalle where idPrestamo = @idPrestamo and idNotebook = @idNotebook";

        DynamicParameters parametros = new DynamicParameters();
        parametros.Add("unidPrestamo", idPrestamo);
        parametros.Add("unidNotebook", idNotebook);

        try
        {
            return Conexion.QueryFirstOrDefault<PrestamoDetalle>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los detalles del prestamo y la notebook");
        }
    }
    #endregion

    #region Listar por prestamos
    public IEnumerable<PrestamoDetalle> ListarDetallesPorPrestamo(int idPrestamo)
    {
        string query = "select * from PrestamoDetalle where idPrestamo = @unidPrestamo";

        DynamicParameters parametros = new DynamicParameters();
        parametros.Add("unidPrestamo", idPrestamo);

        try
        {
            return Conexion.Query<PrestamoDetalle>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los detalles del préstamo");
        }
    }

    #endregion

}

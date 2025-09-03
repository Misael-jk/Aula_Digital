﻿using CapaDatos.Interfaces;
using CapaEntidad;
using Dapper;
using System.Data;

namespace CapaDatos.Repos;

public class RepoDevolucionDetalle : RepoBase, IRepoDevolucionDetalle
{
    public RepoDevolucionDetalle(IDbConnection conexion)
        : base(conexion)
    {
    }

    #region Insertar Detalle de la devolucion
    public void Insert(DevolucionDetalle devolucionDetalle)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidDevolucion", devolucionDetalle.IdDevolucion);
        parametros.Add("unidElemento", devolucionDetalle.IdElemento);
        parametros.Add("unidEstadoMantenimiento", devolucionDetalle.IdEstadoMantenimiento);
        parametros.Add("unaObservacion", devolucionDetalle.Observaciones);

        try
        {
            Conexion.Execute("InsertDevolucionDetalle", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al dar de alta el detalle de la devolucion");
        }
    }
    #endregion

    #region Actualizar los detalles
    public void Update(DevolucionDetalle devolucionDetalle)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidDevolucion", devolucionDetalle.IdDevolucion);
        parametros.Add("unidElemento", devolucionDetalle.IdElemento);
        parametros.Add("unidEstadoMantenimiento", devolucionDetalle.IdEstadoMantenimiento);
        parametros.Add("unaObservacion", devolucionDetalle.Observaciones);

        try
        {
            Conexion.Execute("UpdateDevolucionDetalle", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al actualizar el Detalle de la devolucion");
        }
    }
    #endregion

    #region Eliminar detalles
    public void Delete(int idDevolucion, int idElemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidPrestamo", idDevolucion);
        parametros.Add("unidElemento", idElemento);

        try
        {
            Conexion.Execute("DeleteDevolucionDetalle", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al eliminar los detalles de la devolucion");
        }
    }
    #endregion

    #region ver los datos del detalle
    public IEnumerable<DevolucionDetalle> GetAll()
    {
        string query = "select * from DevolucionDetalle";

        try
        {
            return Conexion.Query<DevolucionDetalle>(query);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los datos del detalle de la devolucion");
        }
    }
    #endregion

    #region Obtener Detalle por prestamos y notebooks
    public IEnumerable<DevolucionDetalle> GetByDevolucion(int idDevolucion)
    {
        string query = "select * from DevolucionDetalle where idDevolucion = @idDevolucion";

        DynamicParameters parametros = new DynamicParameters();


        try
        {
            parametros.Add("unidDevolucion", idDevolucion);
            return Conexion.Query<DevolucionDetalle>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los detalles de la devolucion");
        }
    }
    #endregion

}

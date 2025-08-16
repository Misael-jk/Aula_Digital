﻿using Dapper;
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

    #region Eliminar detalles
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
            throw new Exception("Hubo un error al eliminar los detalles del prestamo");
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

    #region Obtener Detalle por prestamos y notebooks
    public IEnumerable<PrestamoDetalle> GetByPrestamo(int idPrestamo)
    {
        string query = "select * from PrestamoDetalle where idPrestamo = @idPrestamo";

        DynamicParameters parametros = new DynamicParameters();
        

        try
        {
            parametros.Add("unidPrestamo", idPrestamo);
            return Conexion.Query<PrestamoDetalle>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los detalles del prestamo");
        }
    }
    #endregion


}

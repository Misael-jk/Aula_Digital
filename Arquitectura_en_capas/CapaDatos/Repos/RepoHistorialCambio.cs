﻿using System.Data;
using CapaDatos.Interfaces;
using CapaEntidad;
using Dapper;

namespace CapaDatos.Repos;

public class RepoHistorialCambio : RepoBase, IRepoHistorialCambio
{
    public RepoHistorialCambio(IDbConnection conexion) : base(conexion)
    {
    }

    public void Insert(HistorialCambios historialCambio)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidHistorialCambio", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("unidTipoAccion", historialCambio.IdTipoAccion);
        parameters.Add("unfechaCambio", historialCambio.FechaCambio);
        parameters.Add("unadescripcion", historialCambio.Descripcion);
        parameters.Add("unidUsuario", historialCambio.IdUsuario);

        try
        {
            Conexion.Execute("InsertHistorialCambio", parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar un historial de cambio");
        }
    }

    public IEnumerable<HistorialCambios> GetAll()
    {
        string query = "select * from HistorialCambios";

        return Conexion.Query<HistorialCambios>(query);
    }

    public HistorialCambios? GetById(int idHistorialCambio)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidHistorialCambio", idHistorialCambio);
        string query = "select * from HistorialCambios where idHistorialCambio = @unidHistorialCambio";

        try
        {
            return Conexion.QueryFirstOrDefault<HistorialCambios>(query, parameters);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al obtener un historial de cambio por id");
        }
    }

    public IEnumerable<HistorialCambios> GetByAccion(int idTipoAccion)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("unidTipoAccion", idTipoAccion);

        string query = "select * from HistorialCambios where idTipoAccion = @unidTipoAccion";

        try
        {
            return Conexion.Query<HistorialCambios>(query, parameters);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al obtener los historiales de cambio por accion");
        }
    }
}

﻿using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoTipoElemento : RepoBase, IRepoTipoElemento
{
    public RepoTipoElemento( IDbConnection conexion) 
    : base(conexion)
    {
    }

    #region Insertar Tipo del Elemento
    public void Insert(TipoElemento tipoElemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidTipoElemento", tipoElemento.IdTipoElemento);
        parametros.Add("unidElemento", tipoElemento.ElementoTipo);

        try
        {
            Conexion.Execute("InsertTipoElemento", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al dar de alta el tipo de Elemento");
        }
    }
    #endregion

    #region Actualizar el tipo del elemento
    public void Update(TipoElemento tipoElemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidTipoElemento", tipoElemento.IdTipoElemento);
        parametros.Add("unidElemento", tipoElemento.ElementoTipo);

        try
        {
            Conexion.Execute("UpdateTipoElemento", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al actualizar el tipo de Elemento");
        }
    }
    #endregion

    #region Eliminar tipo del elemento
    public void Delete(int idTipoElemento)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidTipoElemento", idTipoElemento);

        try
        {
            Conexion.Execute("DeleteTipoElemento", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al eliminar el tipo del Elemento");
        }
    }
    #endregion

    #region ver los datos los tipos de los elementos
    public IEnumerable<TipoElemento> GetAll()
    {

        string query = "select idTipoElemento, elemento AS elementoTipo from tipoElemento";

        try
        {
            return Conexion.Query<TipoElemento>(query);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener los datos de los tipos del elemento");
        }
    }
    #endregion

    #region Obtener id del Tipo elemento
    public TipoElemento? GetById(int idTipoElemento)
    {
        string query = "select * from TipoElemento where idTipoElemento = @unidTipoElemento";

        DynamicParameters parametros = new DynamicParameters();
        parametros.Add("unidTipoElemento", idTipoElemento);

        try
        {
            return Conexion.QueryFirstOrDefault<TipoElemento>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el id Del tipo del Elemento");
        }
    }
    #endregion

    public TipoElemento? GetByTipo(string elementoTipo)
    {
        string query = "select * from TipoElemento where tipoElemento = @elementoTipo";

        DynamicParameters parametros = new DynamicParameters();
        parametros.Add("@elementoTipo", elementoTipo);

        try
        {
            return Conexion.QueryFirstOrDefault<TipoElemento>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el tipo del Elemento");
        }
    }
}

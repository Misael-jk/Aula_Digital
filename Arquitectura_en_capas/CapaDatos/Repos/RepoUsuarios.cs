﻿using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos;

public class RepoUsuarios : RepoBase, IRepoUsuarios
{
    public RepoUsuarios(IDbConnection conexion) 
    : base (conexion)
    {
    }

    #region Alta Encargado 
    public void Insert(Usuarios usuarios)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidUsuario", dbType: DbType.Int32, direction: ParameterDirection.Output);

        parametros.Add("unusuario", usuarios.Usuario);
        parametros.Add("unpassword", usuarios.Password);
        parametros.Add("unnombre", usuarios .Nombre);
        parametros.Add("unapellido", usuarios.Apellido);
        parametros.Add("unrol", usuarios.IdRol);
        parametros.Add("unemail", usuarios.Email);
        parametros.Add("unfotoPerfil", usuarios.FotoPerfil);
        parametros.Add("unhabilitado", usuarios.Habilitado);
        parametros.Add("unfechaBaja", usuarios.FechaBaja);

        try
        {
            Conexion.Execute("InsertUsuario", parametros, commandType: CommandType.StoredProcedure);
            usuarios.IdUsuario = parametros.Get<int>("unidUsuario");
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al insertar a un Usuario");
        }
    }
    #endregion

    #region Actualizar Encargado
    public void Update(Usuarios usuarios)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidEncargado", usuarios.IdUsuario);
        parametros.Add("unusuario", usuarios.Usuario);
        parametros.Add("unpassword", usuarios.Password);
        parametros.Add("unnombre", usuarios.Nombre);
        parametros.Add("unapellido", usuarios.Apellido);
        parametros.Add("unrol", usuarios.IdRol);
        parametros.Add("unemail", usuarios.Email);
        parametros.Add("unfotoPerfil", usuarios.FotoPerfil);
        parametros.Add("unhabilitado", usuarios.Habilitado);
        parametros.Add("unfechaBaja", usuarios.FechaBaja);

        try
        {
            Conexion.Execute("UpdateUsuario", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al Actualizar a un Usuario");
        }
    }
    #endregion

    #region Eliminar Elemento
    public void Delete(int idUsuario)
    {
        DynamicParameters parametros = new DynamicParameters();

        parametros.Add("unidUsuario", idUsuario);

        try
        {
            Conexion.Execute("DeleteUsuario", parametros, commandType: CommandType.StoredProcedure);
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al eliminar un Usuario");
        }
    }
    #endregion

    #region Obtener por usuario y contraseña
    public Usuarios? GetByUserPass(string user, string pass)
    {
        string query = "select * from Usuarios where usuario = @unuser and pass = @unpass";

        DynamicParameters parametros = new DynamicParameters();

        try
        {
            parametros.Add("@unuser", user);
            parametros.Add("@unpass", pass);
            return Conexion.QueryFirstOrDefault<Usuarios>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el usuario y contraseña");
        }
    }
    #endregion

    #region Obtener por Email
    public Usuarios? GetByEmail(string Email)
    {
        string query = "select * from Usuarios where email = @email";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("@email", Email);
            return Conexion.QueryFirstOrDefault<Usuarios>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el email del Usuario");
        }
    }
    #endregion

    #region Obtener por ID
    public Usuarios? GetById(int idUsuario)
    {
        string query = "select * from Usuarios where idUsuario = @idUsuario";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("@idUsuario", idUsuario);
            return Conexion.QueryFirstOrDefault<Usuarios>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el ID del Usuario");
        }
    }
    #endregion

    #region Obtener por Usuario
    public Usuarios? GetByUser(string user)
    {
        string query = "select * from Usuarios where usuario = @usuario";

        DynamicParameters parametros = new DynamicParameters();
        try
        {
            parametros.Add("@usuario", user);
            return Conexion.QueryFirstOrDefault<Usuarios>(query, parametros);
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener el user del Usuario");
        }
    }
    #endregion
}

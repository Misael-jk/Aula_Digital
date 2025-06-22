﻿using System.Data;

namespace Sistema_de_notebooks.CapaDatos;

public abstract class RepoBase
{
    protected readonly IDbConnection Conexion;

    protected RepoBase(IDbConnection conexion)
    {
        Conexion = conexion;
    }
}

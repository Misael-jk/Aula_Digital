﻿using CapaEntidad;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace CapaDatos.Interfaces;

public interface IRepoUsuarios
{
    public void Insert(Usuarios usuarios);
    public void Update(Usuarios usuarios);
    public void Delete(int idUsuarios);
    public Usuarios? GetByEmail(string email);
    public Usuarios? GetByUserPass(string user, string password);
    public Usuarios? GetById(int idUsuario);
    public Usuarios? GetByUser(string usuario);
}

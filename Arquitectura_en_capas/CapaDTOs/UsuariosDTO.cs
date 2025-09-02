﻿namespace CapaDTOs;

public class UsuariosDTO
{
    public int IdUsuario { get; set; }
    public required string Usuario { get; set; }
    public required string Password { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Rol { get; set; }
    public required string Email { get; set; }
    public string? FotoPerfil { get; set; }
}
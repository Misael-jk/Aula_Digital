namespace CapaEntidad;

public class Usuarios
{
    public int IdUsuario {get; set;}
    public required string Usuario {get; set;}
    public required string Password {get; set;}
    public required string Nombre {get; set;}
    public required string Apellido {get; set;}
    public int IdRol { get; set; }
    public required string Email {get; set;}
}

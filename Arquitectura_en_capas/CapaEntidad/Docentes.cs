namespace Sistema_de_notebooks.CapaEntidad;

public class Docentes
{
    public int IdDocente {get; set;}
    public int Dni {get; set;}
    public required string Nombre {get; set;}
    public required string Apellido {get; set;}
    public required string Email {get; set;}
}

namespace CapaEntidad;

public class Devolucion
{
    public int IdDevolucion {get; set;}
    public int IdPrestamo {get; set;}
    public int IdDocente {get; set;}
    public int IdUsuario {get; set;}
    public DateTime FechaDevolucion {get; set;}
    public required string Observaciones {get; set;}
}

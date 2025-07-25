namespace CapaEntidad;

public class Prestamos
{
    public int IdPrestamo {get; set;}
    public int IdCurso {get; set;}
    public int IdEncargado {get; set;}
    public int IdDocente {get; set;}
    public int? IdCarrito {get; set;} 
    public DateTime FechaPrestamo {get; set;}
}

namespace Sistema_de_notebooks.CapaEntidad;

public class Prestamos
{
    public int IdPrestamo {get; set;}
    public int IdDocente {get; set;}
    public int? IdCarrito {get; set;} 
    public DateTime FechaPrestamo {get; set;}
    public DateTime FechaPactada {get; set;}
}

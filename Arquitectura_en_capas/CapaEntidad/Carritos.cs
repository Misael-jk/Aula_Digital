namespace CapaEntidad;

public class Carritos
{
    public int IdCarrito {get; set;}
    public required string NumeroSerieCarrito { get; set; }
    public int IdEstadoMantenimiento { get; set; }
    public bool Habilitado { get; set; }
    public DateTime? FechaBaja { get; set; }
}

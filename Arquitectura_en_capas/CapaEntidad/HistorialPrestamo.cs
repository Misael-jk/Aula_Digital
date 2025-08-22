namespace CapaEntidad;

public class HistorialPrestamo
{
    public int IdHistorialPrestamo { get; set; } 
    public int IdPrestamo { get; set; }
    public int IdEstadoPrestamo { get; set; }
    public DateTime FechaHora { get; set; }
    public required string Observacion { get; set; }
}

namespace CapaEntidad;

public class HistorialElemento
{
    public long IdHistorialElemento { get; set; } 
    public int IdElemento { get; set; }
    public int? IdCarrito { get; set; }
    public int idUsuario { get; set; }
    public int IdEstadoElemento { get; set; }
    public DateTime FechaHora { get; set; }
    public required string Observacion { get; set; }
}

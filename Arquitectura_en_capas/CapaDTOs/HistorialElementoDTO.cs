namespace CapaDTOs;

public class HistorialElementoDTO
{
    public int IdHistorialElemento { get; set; }
    public required string TipoElemento { get; set; }
    public required string NumeroSerie { get; set; }
    public string? NumeroSerieCarrito { get; set; }
    public required string ApellidoEncargado { get; set; }
    public required string EstadoElemento { get; set; }
    public DateTime FechaHora { get; set; }
    public required string Observacion { get; set; }
}

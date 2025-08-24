namespace CapaDTOs;

public class ElementoMantenimientoDTO
{
    public int IdElemento { get; set; }
    public required string TipoElemento { get; set; } 
    public required string Estado { get; set; } 
    public required string NumeroSerie { get; set; }
    public bool Disponible { get; set; }
    public DateTime? FechaBaja { get; set; }
}

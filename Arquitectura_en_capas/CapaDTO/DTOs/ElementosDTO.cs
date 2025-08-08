namespace CapaDTO.DTOs;

public class ElementosDTO
{
    public int IdElemento { get; set; }
    public required string TipoElemento { get; set; }
    public required string Carrito { get; set; }
    public required string Estado { get; set; }
    public required string NumeroSerie { get; set; }
    public required string CodigoBarra { get; set; }
}

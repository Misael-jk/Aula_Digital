using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CapaDTO.DTOs;

public class DevolucionDetalleDTO
{
    public required string TipoElemento { get; set; }
    public required string NumeroSerieElemento { get; set; }
    public required string NumeroSerieCarrito { get; set; }
    public DateTime FechaDevolucion { get; set; }
}

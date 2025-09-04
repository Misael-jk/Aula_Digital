namespace CapaDTOs;

public class CarrtiosBajasDTO
{
    public int IdCarrito { get; set; }
    public required string NumeroSerieCarrito { get; set; }
    public required string EstadoMantenimiento { get; set; }
    public bool Habilitado { get; set; }
    public DateTime FechaBaja { get; set; }
}

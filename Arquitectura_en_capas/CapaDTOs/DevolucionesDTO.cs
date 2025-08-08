namespace CapaDTOs;

public class DevolucionesDTO
{
    public int IdDevolucion { get; set; }
    public required string ApellidoDocente { get; set; }
    public required string ApellidoEncargado { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaDevolucion { get; set; }
    public required string Observaciones { get; set; }
}


namespace CapaDTOs;

public class TransaccionDTO
{
    public int IdPrestamo { get; set; }
    public string? NombreCurso { get; set; }
    public required string ApellidoDocentes { get; set; }
    //public required string ApellidoEncargados { get; set; }
    public string? NumeroSerieCarrito { get; set; }
    public required string EstadoPrestamo { get; set; }
    public DateTime FechaPrestamo { get; set; }


    public int? IdDevolucion { get; set; }
    public string? ApellidoDocente { get; set; }
    public string? ApellidoEncargado { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public string? EstadoDevolucion { get; set; }
    public string? Observaciones { get; set; }
}

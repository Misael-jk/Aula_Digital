namespace CapaDTOs.AuditoriaDTO;

public class HistorialDocentesDTO
{
    public int IdHistorialDocente { get; set; }
    public required string NombreDocente { get; set; }
    public required string ApellidoDocente { get; set; }
    public required string DNI { get; set; }
    public required string Email { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaCambio { get; set; }
    public required string AccionRealizada { get; set; }
    public required string Usuario { get; set; }
}

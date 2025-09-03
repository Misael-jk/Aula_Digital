namespace CapaEntidad;

public class Elemento
{
    public int IdElemento {get; set;}
    public int IdTipoElemento {get; set;}
    public int? IdCarrito {get; set;}
    public int? PosicionCarrito { get; set; }
    public int IdEstadoMantenimiento {get; set;}
    public required string numeroSerie {get; set;}
    public required string codigoBarra {get; set;}
    public bool Habilitado {get; set;}
    public DateTime? FechaBaja { get; set; }
}

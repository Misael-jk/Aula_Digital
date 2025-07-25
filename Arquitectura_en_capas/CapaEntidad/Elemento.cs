namespace CapaEntidad;
public class Elemento
{
    public int IdElemento {get; set;}
    public int IdTipoElemento {get; set;}
    public int? IdCarrito {get; set;}
    public int IdEstadoElemento {get; set;}
    public required string numeroSerie {get; set;}
    public required string codigoBarra {get; set;}
    public bool Disponible {get; set;}
}

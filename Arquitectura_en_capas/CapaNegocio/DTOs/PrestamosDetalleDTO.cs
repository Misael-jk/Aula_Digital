
namespace CapaNegocio.DTOs
{
    public class PrestamosDetalleDTO
    {
        public int IdPrestamo { get; set; }
        public required string TipoElemento { get; set; }
        public required string NumeroSerieElemento { get; set; }
        public required string NumeroSerieCarrito { get; set; }
        public required string Usuario { get; set; }
    }
}

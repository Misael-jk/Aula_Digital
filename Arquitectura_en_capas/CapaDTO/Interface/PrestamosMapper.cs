using CapaEntidad;
using CapaNegocio.DTOs;

namespace CapaNegocio.MappersDTO
{
    class PrestamosMapper
    {

        #region Mapear listas (varios objetos)
        public IEnumerable<PrestamosDTO> MapearLista(IEnumerable<Prestamos> prestamos, Dictionary<int, string> curso, Dictionary<int, string> docente, Dictionary<int, string> carrito, Dictionary<int, string> usuario)
        {
            return prestamos.Select(e => new PrestamosDTO
            {
                IdPrestamo = e.IdPrestamo,
                ApellidoEncargado = usuario.GetValueOrDefault(e.IdUsuario, "Error"),
                ApellidoDocente = docente.GetValueOrDefault(e.IdDocente, "Error"),
                NombreCurso = e.IdCurso.HasValue ? curso.GetValueOrDefault(e.IdCurso.Value) : "Sin curso",
                NumeroSerieCarrito = e.IdCarrito.HasValue ? carrito.GetValueOrDefault(e.IdCarrito.Value) : "Sin carrito",
                FechaPrestamo = e.FechaPrestamo
            }).ToList();
        }
        #endregion

        #region Mapear un solo objeto
        public PrestamosDTO MapearDTO(Prestamos prestamos, Dictionary<int, string> curso, Dictionary<int, string> docente, Dictionary<int, string> carrito, Dictionary<int, string> usuario)
        {
            return new PrestamosDTO
            {
                IdPrestamo = prestamos.IdPrestamo,
                ApellidoEncargado = usuario.GetValueOrDefault(prestamos.IdUsuario, "Error"),
                ApellidoDocente = docente.GetValueOrDefault(prestamos.IdDocente, "Error"),
                NombreCurso = prestamos.IdCurso.HasValue ? curso.GetValueOrDefault(prestamos.IdCurso.Value) : "Sin curso",
                NumeroSerieCarrito = prestamos.IdCarrito.HasValue ? carrito.GetValueOrDefault(prestamos.IdCarrito.Value) : "Sin carrito",
                FechaPrestamo = prestamos.FechaPrestamo
            };
        }
        #endregion
    }
}

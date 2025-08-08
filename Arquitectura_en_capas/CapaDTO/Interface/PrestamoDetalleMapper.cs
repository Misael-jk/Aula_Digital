using CapaDatos;
using CapaEntidad;
using CapaNegocio.DTOs;
using System.Data;
using Dapper;

namespace CapaNegocio.MappersDTO;

public class PrestamoDetalleMapper : RepoBase
{
    public PrestamoDetalleMapper(IDbConnection conexion)
        : base(conexion)
    {
    }

    #region consulta join con splitOn para mostrar en la UI
    public IEnumerable<PrestamosDetalleDTO> ShowAll()
    {
        return Conexion.Query<Elemento, Carritos, TipoElemento, Prestamos, PrestamosDetalleDTO>(
            "MostrarPrestamoDetalle",
            (elemento, carrito, tipo, prestamo) => new PrestamosDetalleDTO
            {
                NumeroSerieElemento = elemento.numeroSerie,
                TipoElemento = tipo.ElementoTipo,
                NumeroSerieCarrito = carrito?.NumeroSerieCarrito ?? "Sin carrito"
            },
            commandType: CommandType.StoredProcedure,
            splitOn: "ElementoTipo,EstadoElementoNombre,NumeroSerieCarrito"
        ).ToList();
    }
    #endregion


    #region Mapear listas (varios objetos)
    public IEnumerable<PrestamosDetalleDTO> Mapear()
    {
        var prestamoDetalle = ShowAll();

        return prestamoDetalle.Select(e => new PrestamosDetalleDTO
        {
            TipoElemento = prestamoDetalle.GroupBy(p => p.TipoElemento).Select(g => g.Key).FirstOrDefault("error"),
            NumeroSerieCarrito = prestamoDetalle.GroupBy(p => p.NumeroSerieCarrito).Select(g => g.Key).FirstOrDefault(),
            NumeroSerieElemento = prestamoDetalle.GroupBy(p => p.NumeroSerieElemento).Select(g => g.Key).FirstOrDefault("error")

        }).ToList();
    }
    #endregion

    #region Mapear un solo objeto
    public ElementosDTO ToDTO(Elemento entidad, Dictionary<int, string> tipos, Dictionary<int, string> estados, Dictionary<int, string> carritos)
    {
        return new ElementosDTO
        {
            IdElemento = entidad.IdElemento,
            TipoElemento = tipos.GetValueOrDefault(entidad.IdTipoElemento),
            Carrito = estados.GetValueOrDefault(entidad.IdEstadoElemento),
            Estado = entidad.IdCarrito.HasValue ? carritos.GetValueOrDefault(entidad.IdCarrito.Value) : "Sin carrito",
            NumeroSerie = entidad.numeroSerie,
            CodigoBarra = entidad.codigoBarra
        };
    }
    #endregion
}

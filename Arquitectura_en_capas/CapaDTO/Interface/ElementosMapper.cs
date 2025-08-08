using CapaNegocio.DTOs;
using CapaEntidad;
using System.Data;
using CapaDatos;
using Dapper;

namespace CapaNegocio.MappersDTO;

public class ElementosMapper : RepoBase
{
    

    #region Mapear listas (varios objetos)
    public IEnumerable<ElementosDTO> Mapear(IEnumerable<Elemento> elementos, Dictionary<int, string> tipos, Dictionary<int, string> estados, Dictionary<int, string> carritos)
    {
        return elementos.Select(e => new ElementosDTO
        {
            IdElemento = e.IdElemento,
            NumeroSerie = e.numeroSerie,
            CodigoBarra = e.codigoBarra,
            TipoElemento = tipos.GetValueOrDefault(e.IdTipoElemento),
            Estado = estados.GetValueOrDefault(e.IdEstadoElemento),
            Carrito = e.IdCarrito.HasValue ? carritos.GetValueOrDefault(e.IdCarrito.Value) : "Sin carrito"
        }).ToList();
    }
    #endregion

    #region Mapear un solo objeto
    public ElementosDTO ToDTO(Elemento entidad, Dictionary<int, string> tipos, Dictionary<int, string> estados, Dictionary<int, string> carritos)
    {
        return new ElementosDTO
        {
            IdElemento = entidad.IdElemento,
            TipoElemento = tipos.GetValueOrDefault(entidad.IdElemento),
            Carrito = estados.GetValueOrDefault(entidad.IdEstadoElemento),
            Estado = entidad.IdCarrito.HasValue ? carritos.GetValueOrDefault(entidad.IdCarrito.Value) : "Sin carrito",
            NumeroSerie = entidad.numeroSerie,
            CodigoBarra = entidad.codigoBarra
        };
    }
    #endregion
}

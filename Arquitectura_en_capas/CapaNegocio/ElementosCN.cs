using CapaDatos;
using CapaDatos.Interfaces;
using CapaDatos.Repos;
using CapaEntidad;
using CapaNegocio.DTOs;
using CapaNegocio.MappersDTO;
using System.Data;

namespace CapaNegocio;

public class ElementosCN
{
    private readonly IRepoElemento _repoElemento;
    private readonly IRepoTipoElemento _repoTipo;
    private readonly IRepoEstadosElemento _repoEstado;
    private readonly IRepoCarritos _repoCarrito;
    private readonly ElementosMapper elementosMapper;

    public ElementosCN(IRepoElemento repoElemento, IRepoTipoElemento repoTipo,
        IRepoEstadosElemento repoEstado, IRepoCarritos repoCarrito)
    {
        _repoElemento = repoElemento;
        _repoTipo = repoTipo;
        _repoEstado = repoEstado;
        _repoCarrito = repoCarrito;
        elementosMapper = new ElementosMapper();
    }

    public void CrearElemento(Elemento elemento)
    {
        _repoElemento.Insert(elemento);
    }

    public IEnumerable<ElementosDTO> ObtenerTodosParaMostrar()
    {
        var lista = _repoElemento.GetAll();
        return MapearAListaDTO(lista);
    }

    public IEnumerable<ElementosDTO> ObtenerPorCarrito(int idCarrito)
    {
        var lista = _repoElemento.GetByCarrito(idCarrito);
        return MapearAListaDTO(lista);
    }

    public ElementosDTO? ObtenerPorCodigoBarra(string codigoBarra)
    {
        var elemento = _repoElemento.GetByCodigoBarra(codigoBarra);
        if (elemento == null) return null;

        return MapearAUnDTO(elemento);
    }


    private ElementosDTO MapearAUnDTO(Elemento elemento)
    {
        var tipos = _repoTipo.GetAll().ToDictionary(t => t.IdTipoElemento, t => t.ElementoTipo);
        var estados = _repoEstado.GetAll().ToDictionary(e => e.IdEstadoElemento, e => e.EstadoElementoNombre);
        var carritos = _repoCarrito.GetAll().ToDictionary(c => c.IdCarrito, c => c.NumeroSerieCarrito);

        return elementosMapper.ToDTO(
            elemento,
            tipos.GetValueOrDefault(elemento.IdTipoElemento),
            elemento.IdCarrito.HasValue ? carritos.GetValueOrDefault(elemento.IdCarrito.Value) : "Sin carrito",
            estados.GetValueOrDefault(elemento.IdEstadoElemento)
        );
    }


    private IEnumerable<ElementosDTO> MapearAListaDTO(IEnumerable<Elemento> lista)
    {
        var tipos = _repoTipo.GetAll().ToDictionary(t => t.IdTipoElemento, t => t.ElementoTipo);
        var estados = _repoEstado.GetAll().ToDictionary(e => e.IdEstadoElemento, e => e.EstadoElementoNombre);
        var carritos = _repoCarrito.GetAll().ToDictionary(c => c.IdCarrito, c => c.NumeroSerieCarrito);

        return elementosMapper.Mapear(lista, tipos, estados, carritos);
    }


    ///*
    //En esta region lo que hace es cambiar la disponibilidad de las notebooks que se pidan ya sea
    //individual o con carrito, si lo pidio con carrito este metodo cambiara los estados de varias notebooks
    //y si pidio algunas notebooks sin carrito tambien lo validara.
    //*/
    //#region Cambiar estados de varias o una notebook
    //public void CambiarDisponibilidadNotebooks(IEnumerable<int> idNotebooks, bool disponible)
    //{
    //    repoNotebooks.CambiarDisponibilidad(idNotebooks, disponible);
    //}
    //#endregion


    // Este metodo nos retorna la disponibilidad de la notebook para poder reutilizarla en el detalle
    //    #region Disponibilidad de la notebook
    //    public bool EstaDisponible(int idNotebook)
    //    {
    //        Notebook? notebook = repoNotebooks.DetalleNotebooks(idNotebook);

    //        if (notebook == null)
    //        {
    //            throw new Exception("La notebook no existe");
    //        }

    //        return notebook.DisponibleNotebook;
    //    }
    //    #endregion
}

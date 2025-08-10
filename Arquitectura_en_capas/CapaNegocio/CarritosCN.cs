using CapaEntidad;
using System.Data;
using CapaDatos.Repos;
using CapaNegocio;
using CapaDatos.Interfaces;

namespace CapaNegocio;

public class CarritosCN
{
    private readonly IRepoCarritos repoCarrito;

    public CarritosCN(IRepoCarritos repoCarrito)
    {
        this.repoCarrito = repoCarrito;
    }

    #region INSERT CARRITO
    public void CrearCarrito(Carritos CarritoNEW)
    {
        if(string.IsNullOrWhiteSpace(CarritoNEW.NumeroSerieCarrito))
        {
            throw new Exception("El numero de serie del carrito es obligatorio");
        }

        if(repoCarrito.GetByNumeroSerie(CarritoNEW.NumeroSerieCarrito) != null)
        {
            throw new Exception("Ya existe un carrito con ese numero de serie, por favor elija uno nuevo");
        }

        repoCarrito.Insert(CarritoNEW);
    }
    #endregion

    #region UPDATE CARRITO
    public void ActualizarCarrito(Carritos carritoNEW)
    {
        if (string.IsNullOrWhiteSpace(carritoNEW.NumeroSerieCarrito))
        {
            throw new Exception("El numero de serie del carrito es obligatorio");
        } 

        Carritos? carritoOLD = repoCarrito.GetById(carritoNEW.IdCarrito);

        if (carritoOLD == null)
        {
            throw new Exception("El carrito no existe");
        }

        if (carritoOLD.NumeroSerieCarrito != carritoNEW.NumeroSerieCarrito && repoCarrito.GetByNumeroSerie(carritoNEW.NumeroSerieCarrito) != null)
        {
            throw new Exception("Ya existe otro carrito con el mismo numero de serie");
        }

        repoCarrito.Update(carritoNEW);
    }
    #endregion

    #region DELETE CARRITO
    public void EliminarCarrito(int idCarrito)
    {
        Carritos? carrito = repoCarrito.GetById(idCarrito);

        if (carrito == null)
        {
            throw new Exception("El carrito no existe");
        }

        repoCarrito.Delete(idCarrito);
    }
    #endregion

    #region READ CARRITO
    public IEnumerable<Carritos> ListarCarritos()
    {
        return repoCarrito.GetAll();
    }
    #endregion


    ///*
    //En esta parte si el docente eligio en el prestamo llevar por carrito se
    //va a invocar este metodo para el prestamo.
    //*/
    //#region Ocupar Carrito
    //public void OcuparCarrito(int idCarrito)
    //{
    //    Carritos? carritoOcupado = repoCarritos.DetalleCarritos(idCarrito);

    //    if (carritoOcupado == null)
    //    {
    //        throw new Exception("No se pudo encontrar el carrito. Ubicacion: capaNegocio");
    //    }

    //    carritoOcupado.DisponibleCarrito = false;
    //    repoCarritos.ActualizarCarrito(carritoOcupado);
    //    carritoNotebooksCN.DisponibilidadCarritoNotebook(idCarrito, false);
    //}
    //#endregion


    ///*
    //Esta parte cuando se haga la devolucion del carrito se debe invocar este metodo
    //en la clase de prestamo para cambiar su disponibilidad para el carrito y las notebooks del carrito
    //*/
    //#region Desocupar Carrito
    //public void DesocuparCarrito(int idCarrito)
    //{
    //    Carritos? carritoDesocupado = repoCarritos.DetalleCarritos(idCarrito);

    //    if (carritoDesocupado == null)
    //    {
    //        throw new Exception("No se pudo encontrar el carrito. Ubicacion: capaNegocio");
    //    }
    //    carritoDesocupado.DisponibleCarrito = true;
    //    repoCarritos.ActualizarCarrito(carritoDesocupado);
    //    carritoNotebooksCN.DisponibilidadCarritoNotebook(idCarrito, true);
    //}
    //#endregion

}


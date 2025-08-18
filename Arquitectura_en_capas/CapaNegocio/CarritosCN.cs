using CapaEntidad;
using System.Data;
using CapaDatos.Repos;
using CapaNegocio;
using CapaDatos.Interfaces;
using System.Transactions;
using System.Xml.Linq;

namespace CapaNegocio;

public class CarritosCN
{
    private readonly IRepoCarritos repoCarrito;
    private readonly IRepoElemento repoElementos;

    public CarritosCN(IRepoCarritos repoCarrito, IRepoElemento repoElementos)
    {
        this.repoCarrito = repoCarrito;
        this.repoElementos = repoElementos;
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

    #region Manejo de Notebooks en Carrito
    public void AgregarNotebookAlCarrito(int idCarrito, int idElemento)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            Carritos? carrito = repoCarrito.GetById(idCarrito);

            if (carrito == null)
            {
                throw new Exception("El carrito no existe");
            }

            Elemento? elemento = repoElementos.GetById(idElemento);

            if (elemento == null)
            {
                throw new Exception("Elemento no encontrado");
            }

            if (!repoElementos.GetDisponible(idElemento))
            {
                throw new Exception("La notebook no esta disponible");
            }

            if (elemento.IdCarrito.HasValue && elemento.IdCarrito != idCarrito)
            {
                throw new Exception("La notebook ya esta en otro carrito.");
            }

            int totalNotebooks = repoElementos.GetByCarrito(idCarrito).Count();

            if (totalNotebooks >= 25)
            {
                throw new Exception("El carrito ya contiene el máximo de 25 notebooks");
            }

            elemento.IdCarrito = idCarrito;

            repoElementos.Update(elemento);

            scope.Complete();
        }
    }

    public void QuitarNotebookDelCarrito(int idCarrito, int idElemento)
    {
        Elemento? elemento = repoElementos.GetById(idElemento);

        if (elemento == null || elemento.IdCarrito != idCarrito)
        {
            throw new Exception("La notebook no esta asignada a este carrito");
        }

        using (TransactionScope scope = new TransactionScope())
        {
            elemento.IdCarrito = null;
            repoElementos.Update(elemento); 
            scope.Complete();
        }
    }

    #endregion
}


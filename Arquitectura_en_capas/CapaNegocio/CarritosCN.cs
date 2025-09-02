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

        if(!repoCarrito.GetDisponible(CarritoNEW.IdCarrito))
        {
            throw new Exception("No se puede crear un carrito en prestamo");
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
    public void AddNotebook(int idCarrito, int posicion, int idElemento, int idUsuario)
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

            if (repoCarrito.GetCountByCarrito(elemento.IdCarrito ?? 0) >= 25 && elemento.IdCarrito != null)
            {
                throw new Exception("El carrito que selecciono esta al maximo de notebooks");
            }

            if (elemento.PosicionCarrito < 1 || elemento.PosicionCarrito > 25)
            {
                throw new Exception("La posición en el carrito debe estar entre 1 y 25.");
            }

            if (elemento.IdTipoElemento == 1 && elemento.IdCarrito != null)
            {
                if (repoElementos.DuplicatePosition(elemento.IdCarrito ?? 0, elemento.PosicionCarrito ?? 0))
                {
                    throw new Exception("La posición dentro del carrito ya está ocupada, por favor elija otra.");
                }

                if (elemento.PosicionCarrito == null || elemento.PosicionCarrito <= 0)
                {
                    throw new Exception("Debe asignar una posición válida dentro del carrito.");
                }
            }
            else
            {
                if (elemento.PosicionCarrito != null)
                {
                    throw new Exception("Solo las notebooks pueden tener posición en carrito.");
                }
            }

            elemento.IdCarrito = idCarrito;
            elemento.PosicionCarrito = posicion;

            repoElementos.Update(elemento);

            HistorialElemento historial = new HistorialElemento
            {
                IdElemento = idElemento,
                IdEstadoElemento = elemento.IdEstadoElemento,
                IdCarrito = idCarrito,
                idUsuario = idUsuario,
                FechaHora = DateTime.Now,
                Observacion = "Notebook agregada al carrito"
            };

            scope.Complete();
        }
    }

    public void RemoveNotebook(int idCarrito, int idElemento, int idUsuario)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            Elemento? elemento = repoElementos.GetById(idElemento);

            if (elemento == null || elemento.IdCarrito != idCarrito)
            {
                throw new Exception("La notebook no esta asignada a este carrito");
            }

            if (!repoElementos.GetDisponible(idElemento))
            {
                throw new Exception("La notebook no esta disponible para quitar del carrito");
            }

            elemento.IdCarrito = null;
            elemento.PosicionCarrito = null;

            repoElementos.Update(elemento);

            HistorialElemento historial = new HistorialElemento
            {
                IdElemento = idElemento,
                IdEstadoElemento = elemento.IdEstadoElemento,
                IdCarrito = idCarrito,
                idUsuario = idUsuario,
                FechaHora = DateTime.Now,
                Observacion = "Notebook quitada del carrito"
            };
            scope.Complete();
        }
    }

    #endregion

}


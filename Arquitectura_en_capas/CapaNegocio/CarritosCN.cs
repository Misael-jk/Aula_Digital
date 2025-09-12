using CapaEntidad;
using CapaDatos.Interfaces;
using System.Transactions;
using CapaDatos.InterfacesDTO;
using CapaDTOs;
using CapaDatos.Repos;

namespace CapaNegocio;

public class CarritosCN
{
    private readonly IRepoCarritos repoCarrito;
    private readonly IRepoEstadosMantenimiento repoEstadosMantenimiento;
    private readonly IRepoUbicacion repoUbicacion;
    private readonly IRepoModelo repoModelo;
    private readonly IRepoNotebooks repoNotebooks;
    private readonly IRepoHistorialCambio repoHistorialCambio;
    private readonly IRepoHistorialCarrito repoHistorialCarrito;
    private readonly IMapperCarritos mapperCarritos;

    public CarritosCN(IRepoCarritos repoCarrito, IRepoNotebooks repoNotebooks, IRepoUbicacion repoUbicacion, IRepoModelo repoModelo, IRepoHistorialCambio repoHistorialCambio, IRepoHistorialCarrito repoHistorialCarrito, IMapperCarritos mapperCarritos)
    {
        this.repoCarrito = repoCarrito;
        this.repoNotebooks = repoNotebooks;
        this.repoUbicacion = repoUbicacion;
        this.repoModelo = repoModelo;
        this.repoHistorialCambio = repoHistorialCambio;
        this.repoHistorialCarrito = repoHistorialCarrito; 
        this.mapperCarritos = mapperCarritos;
    }

    #region Mostrar Carritos
    public IEnumerable<CarritosDTO> MostrarCarritos()
    {
        return mapperCarritos.GetAllDTO();
    }
    #endregion

    #region INSERT CARRITO
    public void CrearCarrito(Carritos CarritoNEW, int idUsuario)
    {
        if(string.IsNullOrWhiteSpace(CarritoNEW.NumeroSerieCarrito))
        {
            throw new Exception("El numero de serie del carrito es obligatorio");
        }

        if(repoCarrito.GetByNumeroSerie(CarritoNEW.NumeroSerieCarrito) != null)
        {
            throw new Exception("Ya existe un carrito con ese numero de serie, por favor elija uno nuevo");
        }

        if(repoEstadosMantenimiento.GetById(CarritoNEW.IdEstadoMantenimiento) == null)
        {
            throw new Exception("El estado de mantenimiento del carrito no es valido");
        }

        if(repoUbicacion.GetById(CarritoNEW.IdUbicacion) == null)
        {
            throw new Exception("La ubicacion del carrito no es valido");
        }

        if(repoModelo.GetById(CarritoNEW.IdModelo) == null)
        {
            throw new Exception("El modelo del carrito no es valido");
        }

        if (CarritoNEW.IdEstadoMantenimiento != 1)
        {
            throw new Exception("El carrito debe estar disponible al crearse");
        }

        repoCarrito.Insert(CarritoNEW);

        HistorialCambios historial = new HistorialCambios
        {
            IdTipoAccion = 1,
            FechaCambio = DateTime.Now,
            Descripcion = $"Se creó el carrito con número de serie {CarritoNEW.NumeroSerieCarrito}.",
            IdUsuario = idUsuario
        };

        repoHistorialCambio.Insert(historial);

        repoHistorialCarrito.Insert(new HistorialCarritos
        {
            IdHistorialCambio = historial.IdHistorialCambio,
            IdCarrito = CarritoNEW.IdCarrito
        });
    }
    #endregion

    #region UPDATE CARRITO
    public void ActualizarCarrito(Carritos carritoNEW, int idUsuario)
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

        if (repoEstadosMantenimiento.GetById(carritoNEW.IdEstadoMantenimiento) == null)
        {
            throw new Exception("El estado de mantenimiento seleccionado no es válido");
        }

        if (repoUbicacion.GetById(carritoNEW.IdUbicacion) == null)
        {
            throw new Exception("La ubicación seleccionada no existe");
        }

        if (repoModelo.GetById(carritoNEW.IdModelo) == null)
        {
            throw new Exception("El modelo seleccionado no es válido");
        }

        if (!repoCarrito.GetDisponible(carritoNEW.IdCarrito))
        {
            throw new Exception("No se puede actualizar un carrito que está en préstamo");
        }

        var estado = repoEstadosMantenimiento.GetById(carritoNEW.IdEstadoMantenimiento);

        if (carritoOLD.NumeroSerieCarrito != carritoNEW.NumeroSerieCarrito && repoCarrito.GetByNumeroSerie(carritoNEW.NumeroSerieCarrito) != null)
        {
            throw new Exception("Ya existe otro carrito con el mismo numero de serie");
        }

        if (carritoOLD.IdUbicacion != carritoNEW.IdUbicacion)
        {
            IEnumerable<Notebooks> notebooksEnCarrito = repoNotebooks.GetByCarrito(carritoNEW.IdCarrito);

            IEnumerable<int> idsNotebooks = notebooksEnCarrito.Select(p => p.IdElemento);

            foreach(int idNotebook in idsNotebooks)
            {
                if(!repoNotebooks.GetDisponible(idNotebook))
                {
                    throw new Exception($"El elemento {idNotebook} no esta disponible.");
                }
            }

            foreach (Notebooks? notebook in notebooksEnCarrito)
            {
                notebook.IdUbicacion = carritoNEW.IdUbicacion;
                repoNotebooks.Update(notebook);
            }
        }

        if (estado != null && carritoNEW.IdEstadoMantenimiento == 2)
        {
            throw new Exception("No se puede poner el estado de mantenimiento del carrito en 'En Préstamo'.");
        }

        if (carritoOLD.IdEstadoMantenimiento != carritoNEW.IdEstadoMantenimiento && carritoNEW.IdEstadoMantenimiento == 2)
        {
            throw new Exception("No se puede cambiar el estado de mantenimiento del carrito a 'En Préstamo' si tiene notebooks en préstamo.");
        }

        repoCarrito.Update(carritoNEW);

        HistorialCambios historial = new HistorialCambios
        {
            IdTipoAccion = 2,
            FechaCambio = DateTime.Now,
            Descripcion = $"Se actualizó el carrito con número de serie {carritoNEW.NumeroSerieCarrito}.",
            IdUsuario = idUsuario
        };

        repoHistorialCambio.Insert(historial);

        repoHistorialCarrito.Insert(new HistorialCarritos
        {
            IdHistorialCambio = historial.IdHistorialCambio,
            IdCarrito = carritoNEW.IdCarrito
        });
    }
    #endregion

    public void DeshabilitarCarrito(Carritos carritos, int idEstadoMantenimiento, int idUsuario)
    {
        if (string.IsNullOrWhiteSpace(carritos.NumeroSerieCarrito))
        {
            throw new Exception("El numero de serie del carrito es obligatorio");
        } 

        Carritos? carritoOLD = repoCarrito.GetById(carritos.IdCarrito);

        if (carritoOLD == null)
        {
            throw new Exception("El carrito no existe");
        }

        if (repoEstadosMantenimiento.GetById(carritos.IdEstadoMantenimiento) == null)
        {
            throw new Exception("El estado de mantenimiento seleccionado no es válido");
        }

        if (repoUbicacion.GetById(carritos.IdUbicacion) == null)
        {
            throw new Exception("La ubicación seleccionada no existe");
        }

        if (repoModelo.GetById(carritos.IdModelo) == null)
        {
            throw new Exception("El modelo seleccionado no es válido");
        }

        if (!repoCarrito.GetDisponible(carritos.IdCarrito))
        {
            throw new Exception("No se puede deshabilitar un carrito que está en préstamo");
        }

        if (repoNotebooks.GetByCarrito(carritoOLD.IdCarrito).Any())
        {
            throw new Exception("No se puede deshabilitar un carrito que aún contiene notebooks.");
        }

        carritos.IdEstadoMantenimiento = idEstadoMantenimiento;
        carritos.FechaBaja = DateTime.Now;
        carritos.Habilitado = false;

        repoCarrito.Update(carritoOLD);

        HistorialCambios historial = new HistorialCambios()
        {
            IdTipoAccion = 3,
            IdUsuario = idUsuario,
            Descripcion = $"Se deshabilito el carrito con numero de serie {carritos.NumeroSerieCarrito}",
            FechaCambio = DateTime.Now
        };

        repoHistorialCambio.Insert(historial);

        repoHistorialCarrito.Insert(new HistorialCarritos
        {
            IdHistorialCambio = historial.IdHistorialCambio,
            IdCarrito = carritos.IdCarrito
        });

    }

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

    public void AddNotebook(int idCarrito, int posicion, int idNotebook, int idUsuario)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            Carritos? carrito = repoCarrito.GetById(idCarrito);

            if (carrito == null)
            {
                throw new Exception("El carrito no existe");
            }

            Notebooks? notebooks = repoNotebooks.GetById(idNotebook);

            if (notebooks == null)
            {
                throw new Exception("Notebook no encontrado");
            }

            if (notebooks.IdEstadoMantenimiento == 2 && notebooks.IdCarrito != null)
            {
                throw new Exception("Un elemento en prestamo no puede estar asignado a un carrito");
            }

            if (!repoNotebooks.GetDisponible(idNotebook))
            {
                throw new Exception("La notebook no esta disponible");
            }

            if (notebooks.IdCarrito.HasValue && notebooks.IdCarrito != idCarrito)
            {
                throw new Exception("La notebook ya esta en otro carrito.");
            }

            if (repoCarrito.GetCountByCarrito(idCarrito) >= 25)
            {
                throw new Exception("El carrito que selecciono esta al maximo de notebooks");
            }

            if (notebooks.PosicionCarrito < 1 || notebooks.PosicionCarrito > 25)
            {
                throw new Exception("La posición en el carrito debe estar entre 1 y 25.");
            }

            if (notebooks.IdTipoElemento == 1 && notebooks.IdCarrito != 0)
            {
                if (notebooks.IdCarrito.HasValue && notebooks.PosicionCarrito.HasValue && repoNotebooks.DuplicatePosition(notebooks.IdCarrito.Value, notebooks.PosicionCarrito.Value))
                {
                    throw new Exception("La posición dentro del carrito ya está ocupada, por favor elija otra.");
                }

                if (notebooks.PosicionCarrito <= 0)
                {
                    throw new Exception("Debe asignar una posición válida dentro del carrito.");
                }
            }
            else
            {
                if (notebooks.PosicionCarrito != 0)
                {
                    throw new Exception("Solo las notebooks pueden tener posición en carrito.");
                }
            }

            notebooks.IdUbicacion = carrito.IdUbicacion;
            notebooks.IdCarrito = idCarrito;
            notebooks.PosicionCarrito = posicion;

            repoNotebooks.Update(notebooks);


            scope.Complete();
        }
    }

    public void RemoveNotebook(int idCarrito, int idNotebook, int idUsuario, int idUbicacion)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            Notebooks? notebooks = repoNotebooks.GetById(idNotebook);

            if (notebooks == null || notebooks.IdCarrito != idCarrito)
            {
                throw new Exception("La notebook no esta asignada a este carrito");
            }

            if (!repoNotebooks.GetDisponible(idNotebook))
            {
                throw new Exception("La notebook no esta disponible para quitar del carrito");
            }

            notebooks.IdUbicacion = idUbicacion;
            notebooks.IdCarrito = null;
            notebooks.PosicionCarrito = null;

            repoNotebooks.Update(notebooks);

            scope.Complete();
        }
    }

    #endregion

}


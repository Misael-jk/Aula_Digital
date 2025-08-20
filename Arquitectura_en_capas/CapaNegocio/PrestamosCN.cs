using CapaDatos.Repos;
using CapaNegocio;
using CapaEntidad;
using System.Data;
using CapaDatos.Interfaces;
using CapaDatos.InterfacesDTO;
using CapaDTOs;
using System.Transactions;
using System.Data.Common;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace CapaNegocio;

public class PrestamosCN
{
    private readonly IRepoPrestamos repoPrestamos;
    private readonly IRepoCarritos repoCarritos;
    private readonly IRepoElemento repoElemento;
    private readonly IRepoDocentes repoDocentes;
    private readonly IRepoPrestamoDetalle repoPrestamoDetalle;
    private readonly IRepoUsuarios repoUsuarios;
    private readonly IMapperPrestamos mapperPrestamos;

    public PrestamosCN(IRepoPrestamos repoPrestamos, IRepoCarritos repoCarritos, IRepoElemento repoElemento, IRepoPrestamoDetalle repoPrestamoDetalle, IRepoUsuarios repoUsuarios, IRepoDocentes repoDocentes, IMapperPrestamos mapperPrestamos)
    {
        this.repoPrestamos = repoPrestamos;
        this.mapperPrestamos = mapperPrestamos;
        this.repoCarritos = repoCarritos;
        this.repoElemento = repoElemento;
        this.repoDocentes = repoDocentes;
        this.repoUsuarios = repoUsuarios;
        this.repoPrestamoDetalle = repoPrestamoDetalle;
    }

    public IEnumerable<PrestamosDTO> ObtenerTodo()
    {
        return mapperPrestamos.GetAllDTO();
    }

    public void CrearPrestamo(Prestamos prestamo, IEnumerable<int> idsElementos, int? idCarrito)
    {
        using (TransactionScope scope = new TransactionScope())
        {

            if(repoDocentes.GetById(prestamo.IdDocente) == null)
            {
                throw new Exception("El docente no existe");
            }

            if (repoUsuarios.GetById(prestamo.IdUsuario) == null)
            {
                throw new Exception("El usuario no existe");
            }

            if (idsElementos == null || !idsElementos.Any())
            {
                throw new Exception("Debe prestar al menos un elemento.");
            }

            if (idCarrito.HasValue)
            {
                if (!repoCarritos.GetDisponible(idCarrito.Value))
                {
                    throw new Exception("El carrito no esta disponible.");
                }

                prestamo.IdCarrito = idCarrito.Value;

                repoCarritos.UpdateDisponible(idCarrito.Value, false);
            }

            foreach (int idElemento in idsElementos)
            {
                if (!repoElemento.GetDisponible(idElemento))
                {
                    throw new Exception($"El elemento {idElemento} no esta disponible.");
                }
            }

            repoPrestamos.Insert(prestamo);

            foreach (int idElemento in idsElementos)
            {
                repoPrestamoDetalle.Insert(new PrestamoDetalle
                {
                    IdPrestamo = prestamo.IdPrestamo,
                    IdElemento = idElemento
                });

                repoElemento.UpdateEstado(idElemento, false);
            }

            scope.Complete();
        }
    }

    public void ActualizarPrestamo(Prestamos prestamo, IEnumerable<int> nuevosIdsElementos, int? nuevoIdCarrito)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            if (repoDocentes.GetById(prestamo.IdDocente) == null)
            {
                throw new Exception("El docente no existe");
            }

            if (repoUsuarios.GetById(prestamo.IdUsuario) == null)
            {
                throw new Exception("El usuario no existe");
            }

            if (nuevosIdsElementos == null || !nuevosIdsElementos.Any())
            {
                throw new Exception("Debe prestar al menos un elemento.");
            }

            if (nuevoIdCarrito.HasValue)
            {
                if (!repoCarritos.GetDisponible(nuevoIdCarrito.Value))
                {
                    throw new Exception("El carrito no esta disponible");
                }
                prestamo.IdCarrito = nuevoIdCarrito.Value;

                repoCarritos.UpdateDisponible(nuevoIdCarrito.Value, false);
            }


            foreach (int idElemento in nuevosIdsElementos)
            {
                if (!repoElemento.GetDisponible(idElemento))
                {
                    throw new Exception($"El elemento {idElemento} no esta disponible");
                }
            }

            repoPrestamos.Update(prestamo);

            repoPrestamoDetalle.Delete(prestamo.IdPrestamo);

            foreach (int idElemento in nuevosIdsElementos)
            {
                repoPrestamoDetalle.Insert(new PrestamoDetalle
                {
                    IdPrestamo = prestamo.IdPrestamo,
                    IdElemento = idElemento,
                });

                repoElemento.UpdateEstado(idElemento, false);
            }

            scope.Complete();
        }
    }

    public void EliminarPrestamo(int idPrestamo)
    {
        using (TransactionScope scope = new TransactionScope())
        {
            Prestamos? prestamo = repoPrestamos.GetById(idPrestamo);

            if (prestamo == null)
            {
                throw new Exception("El prestamo no existe.");
            }

            if (prestamo.IdCarrito.HasValue)
            {
                repoCarritos.UpdateDisponible(prestamo.IdCarrito.Value, true);
            }

            IEnumerable<PrestamoDetalle> detalles = repoPrestamoDetalle.GetByPrestamo(idPrestamo);

            foreach (var detalle in detalles)
            {
                repoElemento.UpdateEstado(detalle.IdElemento, true);
            }

            repoPrestamoDetalle.Delete(idPrestamo);

            repoPrestamos.Delete(idPrestamo);

            scope.Complete();
        }
    }

}

//    ///*
//    //En esta region se realiza un prestamo con carrito cumpliendo con los requisitos necesario para hacer
//    //un prestamo, verifica que la fecha pactada deba ser mayor a la actual y que el carrito que eliga este
//    //disponible para luego insertarla en el prestamo, Luego obtiene las notebooks asociadas al carrito para
//    //dar de alta tambien al detalle.
//    //*/
//    //#region Hacer un prestamo con carrito
//    //public bool HacerPrestamoCarrito(Prestamos newPrestamo)
//    //{
//    //    if (newPrestamo.FechaPactada < DateTime.Now)
//    //    {
//    //        throw new Exception("La fecha debe ser fecha mayor a la actual");
//    //    }

//    //    bool disponible = carritoNegocio.EstaDisponible(newPrestamo.IdCarrito.Value);

//    //    if (disponible != true)
//    //    {
//    //        throw new Exception("El carrito que eligio no esta disponible");
//    //    }

//    //    /*
//    //    En esta parte cuando elige un carrito disponible ocupa el carrito actualizando la disponibilidad tanto
//    //    del carrito como de sus notebooks que la componen tambien, luego inserta todos los datos del prestamo para
//    //    luego obtener las notebooks del carrito e insertar los detalles
//    //    */
//    //    carritoNegocio.OcuparCarrito(newPrestamo.IdCarrito.Value);

//    //    newPrestamo.FechaPrestamo = DateTime.Now;
//    //    repoPrestamos.AltaPrestamo(newPrestamo);

//    //    IEnumerable<int> idNotebooks = carritoNotebooksCN.NotebooksDelCarrito(newPrestamo.IdCarrito.Value);
//    //    prestamoDetalleCN.AgregarDetalles(newPrestamo.IdPrestamo, idNotebooks);

//    //    return true;
//    //}
//    //#endregion


//    ///*
//    //Aqui se realiza el prestamo pero sin carrito, es decir que va a pedir prestado al menos una notebook
//    //se verifica que haiga una al menos una notebook, la fecha pactada correspondiente, poner el idCarrito en 
//    //null e insertar el prestamo y los detalles.
//    //*/
//    //#region Hacer un prestamo individual
//    //public bool HacerPrestamoNotebooks(Prestamos newPrestamo, IEnumerable<int> idNotebooks)
//    //{
//    //    if (idNotebooks == null)
//    //    {
//    //        throw new Exception("Se debe prestar al menos una notebook");
//    //    }

//    //    if (newPrestamo.FechaPactada < DateTime.Now)
//    //    {
//    //        throw new Exception("la fecha debe ser mayor a la actual");
//    //    }

//    //    newPrestamo.IdCarrito = null; 
//    //    newPrestamo.FechaPrestamo = DateTime.Now;

//    //    repoPrestamos.AltaPrestamo(newPrestamo);
//    //    prestamoDetalleCN.AgregarDetalles(newPrestamo.IdPrestamo, idNotebooks);

//    //    return true;
//    //}
//    //#endregion




//    ///*
//    //Esta region se realizara la devolucion, verificando si existe el prestamo y que ese prestamo tenga detalles
//    //Luego hace las funciones de cuando se devuelve un prestamo como cambiar su estado y la fecha de la devolucion
//    //para actualizarla en el detalle. Tambien verificamos si llevo carrito o no, si la llevo se cambia su disponibilidad
//    //tanto del carrito y sus respectivas notebook y sino pidio carrito tambien va a cambiar el estado de las notebook que 
//    //se llevo ya sea una o algunas sin carrito.
//    //*/
//    //#region Devolucion del Prestamo
//    //public bool HacerDevolucion(int idPrestamo, int idEstadoDevuelto)
//    //{
//    //    Prestamos? prestamo = repoPrestamos.DetallePrestamos(idPrestamo);

//    //    if (prestamo == null)
//    //    {
//    //        throw new Exception("El prestamo que eligiste no existe");
//    //    }

//    //    // cambia el estado de las notebooks devueltas y la fecha para luego actualizarlas
//    //    IEnumerable<PrestamoDetalle> detalles = repoPrestamoDetalle.ListarDetallesPorPrestamo(idPrestamo);

//    //    foreach (PrestamoDetalle detalle in detalles)
//    //    {
//    //        detalle.IdEstadoPrestamo = idEstadoDevuelto;
//    //        detalle.FechaDevolucion = DateTime.Now;
//    //        repoPrestamoDetalle.ActualizarDetalle(detalle);
//    //    }

//    //    /*
//    //    Aqui se utiliza una funcion LINQ para traer las notebooks del detalle. Luego verifica si llevo
//    //    carrito para desocuparla (cambia tambien a las notebooks que traia con ella) y si no llevo 
//    //    cambia la disponibilidad de las notebooks del detalle (osea de las notebooks que se prestaron)
//    //    */
//    //    IEnumerable<int> idNotebooks = detalles.Select(d => d.IdNotebook).ToList();

//    //    if (prestamo.IdCarrito != null)
//    //    {
//    //        carritoNegocio.DesocuparCarrito(prestamo.IdCarrito.Value);
//    //    }
//    //    else
//    //    {
//    //        notebookCN.CambiarDisponibilidadNotebooks(idNotebooks, true);
//    //    }

//    //    return true;
//    //}
//    //#endregion


//}


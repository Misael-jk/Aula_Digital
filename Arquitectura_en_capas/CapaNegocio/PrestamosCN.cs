//using CapaDatos.Repos;
//using CapaNegocio;
//using CapaEntidad;
//using System.Data;
//using CapaDatos.Interfaces;
//using CapaNegocio.MappersDTO;
//using CapaNegocio.DTOs;

//namespace CapaNegocio;

//public class PrestamosCN
//{
//    private readonly PrestamosMapper prestamosMapper;
//    private readonly IRepoPrestamos repoPrestamos;
//    private readonly IRepoCarritos repoCarritos;
//    private readonly IRepoCursos repoCursos;
//    private readonly IRepoDocentes repoDocentes;
//    private readonly IRepoUsuarios repoUsuarios;

//    public PrestamosCN(IRepoPrestamos repoPrestamos, IRepoCarritos repoCarritos, 
//        IRepoCursos repoCursos, IRepoDocentes repoDocentes, IRepoUsuarios repoUsuarios)
//    {
//        this.repoPrestamos = repoPrestamos;
//        this.repoCarritos = repoCarritos;
//        this.repoCursos = repoCursos;
//        this.repoDocentes = repoDocentes;
//        this.repoUsuarios = repoUsuarios;
//        prestamosMapper = new PrestamosMapper();
//    }

//    public void HacerPrestamo(Prestamos prestamos)
//    {
//        repoPrestamos.Insert(prestamos);
//    }

//    public IEnumerable<PrestamosDTO> GetsAll()
//    {
//        IEnumerable<Prestamos> lista = repoPrestamos.GetAll();

//        return MapearLista(lista);
//    }

//    private PrestamosDTO MapearDTO(Prestamos prestamos)
//    {
//        Dictionary<int, string> usuarios = repoUsuarios.GetAll().ToDictionary(u => u.IdUsuario, u => u.Apellido);
//        Dictionary<int, string> docentes = repoDocentes.GetAll().ToDictionary(d => d.IdDocente, d => d.Apellido);
//        Dictionary<int, string> carritos = repoCarritos.GetAll().ToDictionary(c => c.IdCarrito, c => c.NumeroSerieCarrito);
//        Dictionary<int, string> cursos = repoCursos.GetAll().ToDictionary(cs => cs.IdCurso, cs => cs.NombreCurso);

//        return prestamosMapper.MapearDTO(prestamos, usuarios, docentes, cursos, carritos);
//    }


//    private IEnumerable<PrestamosDTO> MapearLista(IEnumerable<Prestamos> lista)
//    {
//        Dictionary<int, string> usuario = repoUsuarios.GetAll().ToDictionary(u => u.IdUsuario, u => u.Apellido);
//        Dictionary<int, string> docente = repoDocentes.GetAll().ToDictionary(d => d.IdDocente, d => d.Apellido);
//        Dictionary<int, string> carrito = repoCarritos.GetAll().ToDictionary(c => c.IdCarrito, c => c.NumeroSerieCarrito);
//        Dictionary<int, string> curso = repoCursos.GetAll().ToDictionary(cs => cs.IdCurso, cs => cs.NombreCurso);

//        return prestamosMapper.MapearLista(lista, curso, docente, carrito, usuario);
//    }


//    //// Muestra los datos de los prestamos
//    //#region Mostrar los datos del prestamo
//    //public IEnumerable<Prestamos> ListarPrestamos()
//    //{
//    //    return repoPrestamos.ListarPrestamos().ToList();
//    //}
//    //#endregion


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


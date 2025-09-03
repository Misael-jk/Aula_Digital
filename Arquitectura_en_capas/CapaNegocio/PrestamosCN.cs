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
using System.Configuration;

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
    private readonly IRepoHistorialElemento repoHistorialElemento;

    public PrestamosCN(IRepoPrestamos repoPrestamos, IRepoCarritos repoCarritos, IRepoElemento repoElemento, IRepoPrestamoDetalle repoPrestamoDetalle, IRepoUsuarios repoUsuarios, IRepoDocentes repoDocentes, IMapperPrestamos mapperPrestamos, IRepoHistorialElemento repoHistorialElemento)
    {
        this.repoPrestamos = repoPrestamos;
        this.mapperPrestamos = mapperPrestamos;
        this.repoCarritos = repoCarritos;
        this.repoElemento = repoElemento;
        this.repoDocentes = repoDocentes;
        this.repoUsuarios = repoUsuarios;
        this.repoPrestamoDetalle = repoPrestamoDetalle;
        this.repoHistorialElemento = repoHistorialElemento;
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
                if(repoCarritos.GetById(idCarrito.Value) == null)
                {
                    throw new Exception("El carrito no existe.");
                }

                if(repoCarritos.GetCountByCarrito(idCarrito.Value) < 25)
                {
                    throw new Exception("El carrito debe tener al menos 25 elementos para ser prestado.");
                }

                if (!repoCarritos.GetDisponible(idCarrito.Value))
                {
                    throw new Exception("El carrito no esta disponible.");
                }

                prestamo.IdCarrito = idCarrito.Value;

                repoCarritos.UpdateDisponible(idCarrito.Value, 2);
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

                repoElemento.UpdateEstado(idElemento, 2);

                repoHistorialElemento.Insert(new HistorialElemento
                {
                    IdElemento = idElemento,
                    IdCarrito = prestamo.IdCarrito,
                    idUsuario = prestamo.IdUsuario,
                    IdEstadoMantenimiento = 2, 
                    FechaHora = DateTime.Now,
                    Observacion = "Elemento prestado"
                });
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
                if (repoCarritos.GetById(nuevoIdCarrito.Value) == null)
                {
                    throw new Exception("El carrito no existe");
                }

                if (repoCarritos.GetCountByCarrito(nuevoIdCarrito.Value) < 25)
                {
                    throw new Exception("El carrito debe tener al menos 25 elementos para ser prestado");
                }

                if (!repoCarritos.GetDisponible(nuevoIdCarrito.Value))
                {
                    throw new Exception("El carrito no esta disponible");
                }
                prestamo.IdCarrito = nuevoIdCarrito.Value;

                repoCarritos.UpdateDisponible(nuevoIdCarrito.Value, 2);
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

                repoElemento.UpdateEstado(idElemento, 2);

                repoHistorialElemento.Insert(new HistorialElemento
                {
                    IdElemento = idElemento,
                    IdCarrito = prestamo.IdCarrito,
                    idUsuario = prestamo.IdUsuario,
                    IdEstadoMantenimiento = 2, 
                    FechaHora = DateTime.Now,
                    Observacion = "Elemento prestado"
                });
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
                repoCarritos.UpdateDisponible(prestamo.IdCarrito.Value, 1);
            }

            IEnumerable<PrestamoDetalle> detalles = repoPrestamoDetalle.GetByPrestamo(idPrestamo);

            foreach (var detalle in detalles)
            {
                repoElemento.UpdateEstado(detalle.IdElemento, 1);

                repoHistorialElemento.Insert(new HistorialElemento
                {
                    IdElemento = detalle.IdElemento,
                    IdCarrito = prestamo.IdCarrito,
                    idUsuario = prestamo.IdUsuario,
                    IdEstadoMantenimiento = 1, 
                    FechaHora = DateTime.Now,
                    Observacion = "Elemento devuelto"
                });
            }

            repoPrestamoDetalle.Delete(idPrestamo);

            repoPrestamos.Delete(idPrestamo);

            scope.Complete();
        }
    }

}



using CapaDatos.Repos;
using CapaNegocio;
using CapaEntidad;
using System.Data;
using CapaDatos.Interfaces;
using CapaDatos.InterfacesDTO;
using CapaDTOs;
using System.Transactions;
using System.Data.Common;

namespace CapaNegocio;

public class DevolucionCN
{
    private readonly IRepoDevolucion repoDevolucion;
    private readonly IRepoPrestamos repoPrestamos;
    private readonly IRepoUsuarios repoUsuarios;
    private readonly IRepoElemento repoElementos;
    private readonly IRepoDocentes repoDocentes;
    private readonly IRepoEstadosPrestamo repoEstadosPrestamo;
    private readonly IRepoDevolucionDetalle repoDevolucionDetalle;
    private readonly IMapperDevoluciones mapperDevolucion;

    public DevolucionCN(IRepoDevolucion repoDevolucion, IRepoPrestamos repoPrestamos, IRepoUsuarios repoUsuarios, IRepoElemento repoElementos, IRepoEstadosPrestamo repoEstadosPrestamo, IRepoDocentes repoDocentes, IRepoDevolucionDetalle repoDevolucionDetalle, IMapperDevoluciones mapperDevolucion)
    {
        this.repoDevolucion = repoDevolucion;
        this.repoPrestamos = repoPrestamos;
        this.repoUsuarios = repoUsuarios;
        this.repoElementos = repoElementos;
        this.repoDocentes = repoDocentes;
        this.repoEstadosPrestamo = repoEstadosPrestamo;
        this.repoDevolucionDetalle = repoDevolucionDetalle;
        this.mapperDevolucion = mapperDevolucion;
    }

    public IEnumerable<DevolucionesDTO> ObtenerElementos()
    {
        return mapperDevolucion.GetAllDTO();
    }

    #region INSERT DEVOLUCION
    public void CrearDevolucion(Devolucion devolucionNEW, IEnumerable<int> idsElementos, IEnumerable<int> idsEstadosElemento)
    {
        using (TransactionScope scope = new TransactionScope())
        {

            Prestamos? prestamo = repoPrestamos.GetById(devolucionNEW.IdPrestamo);

            if (prestamo == null)
            {
                throw new Exception("El prestamo no existe");
            }

            if (repoDevolucion.GetByPrestamo(devolucionNEW.IdPrestamo) != null)
            {
                throw new Exception("El prestamo ya fue devuelto");
            }

            if (repoDocentes.GetById(devolucionNEW.IdDocente) == null)
            {
                throw new Exception("El docente no existe");
            }

            if (repoUsuarios.GetById(devolucionNEW.IdUsuario) == null)
            {
                throw new Exception("El usuario no existe");
            }

            foreach (int idElemento in idsElementos)
            {
                if (repoElementos.GetDisponible(idElemento))
                {
                    throw new Exception($"El elemento {idElemento} no debe estar disponible.");
                }
            }

            if (idsElementos.Count() != idsEstadosElemento.Count())
            {
                throw new Exception("Error: el número de elementos y estados no coincide.");
            }

            if (idsElementos.Count() == 0)
            {
                throw new Exception("Debe seleccionar al menos un elemento para devolver.");
            }

            repoDevolucion.Insert(devolucionNEW);

            //foreach (int idElemento in idsElementos)
            //{
            //    repoDevolucionDetalle.Insert(new DevolucionDetalle
            //    {
            //        IdDevolucion = devolucionNEW.IdDevolucion,
            //        IdElemento = idElemento,
            //        IdEstadoElemento = idsEstadosElemento.First()
            //    });

            //    repoElementos.UpdateEstado(idElemento, true);
            //}

            
            scope.Complete();
        }
    }
    #endregion
}

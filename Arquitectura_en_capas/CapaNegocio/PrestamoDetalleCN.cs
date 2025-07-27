using CapaDatos.Repos;
using CapaEntidad;
using System.Data;

namespace CapaNegocio;

public class PrestamoDetalleCN
{
    //private readonly RepoPrestamoDetalle repoDetalle;
    //private readonly ElementosCN notebooksCN;

    //public PrestamoDetalleCN(IDbConnection conexion)
    //{
    //    repoDetalle = new RepoPrestamoDetalle(conexion);
    //    notebooksCN = new ElementosCN(conexion);
    //}

    //public IEnumerable<PrestamoDetalle> listarDetalles()
    //{
    //    return repoDetalle.ListarPrestamoDetalle();
    //}

    //public void AgregarDetalles(int idPrestamo, IEnumerable<int> idNotebooks)
    //{
    //    foreach (int idNotebook in idNotebooks)
    //    {
    //        PrestamoDetalle detalle = new PrestamoDetalle()
    //        {
    //            IdPrestamo = idPrestamo,
    //            IdNotebook = idNotebook,
    //            IdEstadoPrestamo = 1,
    //            FechaDevolucion = null
    //        };

    //        repoDetalle.AltaPrestamoDetalle(detalle);
    //        notebooksCN.CambiarDisponibilidadNotebooks(idNotebooks, false);
    //    }
    //}

    //public IEnumerable<PrestamoDetalle> ListarDetallePorPrestamo(int idPrestamo)
    //{
    //    return repoDetalle.ListarDetallesPorPrestamo(idPrestamo);
    //}
}


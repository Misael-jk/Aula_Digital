using CapaDatos.Repos;
using CapaEntidad;
using System.Data;

namespace CapaNegocio;

class CarritoNotebooksCN
{
    //private readonly RepoCarritoNotebooks repoCarritoNotebooks;
    //private readonly NotebooksCN notebooksNegocio;

    //public CarritoNotebooksCN(IDbConnection conexion)
    //{
    //    repoCarritoNotebooks = new RepoCarritoNotebooks(conexion);
    //    notebooksNegocio = new NotebooksCN(conexion);
    //}

    ///*
    //Esta region busca en la lista de los carritos asociados con las notebooks para poder obtener
    //los Ids de las notebooks para poder cambiar sus disponibilidades.
    //*/
    //#region Obtener notebooks asociadas al carrito
    //public IEnumerable<int> NotebooksDelCarrito(int idCarrito)
    //{
    //    IEnumerable<CarritoNotebooks> lista = repoCarritoNotebooks.ListarNotebooksCarrito(idCarrito);

    //    try
    //    {
    //        /*
    //        Es una funcion de LINQ (Language Integrated Query) para seleccionar las notebooks asociadas.
    //        Estas funciones son de la inteface del IEnumerable<> hice una lista de sus propiedades 
    //        en el documento compartido.
    //        */
    //        return lista.Select(cn => cn.IdNotebook);
    //    }
    //    catch(Exception)
    //    {
    //        throw new Exception("No se encontraron las notebooks del carrito. Ubicacion: capaNegocio, Class: carritoNotebook");
    //    }
    //}
    //#endregion


    //// Esta region utiliza el metodo anterior para poder cambiar la disponibilidad de cada notebook en el carrito
    //#region Cambiar la disponibilidad de las notebooks del carrito
    //public void DisponibilidadCarritoNotebook(int idCarrito, bool disponible)
    //{
    //    IEnumerable<int> idNotebooks = NotebooksDelCarrito(idCarrito);

    //    notebooksNegocio.CambiarDisponibilidadNotebooks(idNotebooks, disponible);
    //}
    //#endregion
}

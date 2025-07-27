using CapaEntidad;
using System.Data;
using CapaDatos.Repos;
using CapaNegocio;

namespace Sistema_de_notebooks.CapaNegocio;

class CarritosCN
{
    //private readonly RepoCarritos repoCarritos;
    //private readonly CarritoNotebooksCN carritoNotebooksCN;

    //public CarritosCN(IDbConnection conexion)
    //{
    //    repoCarritos = new RepoCarritos(conexion);
    //    carritoNotebooksCN = new CarritoNotebooksCN(conexion);
    //}

    ///*
    //En esta region se crea el carrito con la disponibilidad
    //con true para que este por default.
    //*/
    //#region Dar alta al carrito
    //public void CrearCarrito(Carritos newCarrito)
    //{
    //    newCarrito.DisponibleCarrito = true;
    //    repoCarritos.AltaCarrito(newCarrito);
    //}
    //#endregion


    //// Aqui se imprime todos los datos del carrito para mostrarlo a la UI.
    //#region Listar Carrito
    //public IEnumerable<Carritos> ListarCarritos()
    //{
    //    return repoCarritos.ListarCarritos().ToList();
    //}
    //#endregion


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


    ////Este metodo nos indica si el carrito existe, sino nos devuelve la disponibilidad del carrito
    //#region Disponibilidad del carrito
    //public bool EstaDisponible(int idCarrito)
    //{
    //    Carritos? carrito = repoCarritos.DetalleCarritos(idCarrito);

    //    if(carrito == null)
    //    {
    //        throw new Exception("El carrito no existe. Ubicacion: CapaNegocio");
    //    }

    //    return carrito.DisponibleCarrito;
    //}
    //#endregion

}


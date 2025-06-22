using Sistema_de_notebooks.CapaDatos.Repos;
using Sistema_de_notebooks.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NotebooksCN
    {
        private readonly RepoNotebooks repoNotebooks;

        public NotebooksCN(IDbConnection conexion)
        {
            repoNotebooks = new RepoNotebooks(conexion);
        }

        /*
        En esta region lo que hace es cambiar la disponibilidad de las notebooks que se pidan ya sea
        individual o con carrito, si lo pidio con carrito este metodo cambiara los estados de varias notebooks
        y si pidio algunas notebooks sin carrito tambien lo validara.
        */
        #region Cambiar estados de varias o una notebook
        public void CambiarDisponibilidadNotebooks(IEnumerable<int> idNotebooks, bool disponible)
        {
            repoNotebooks.CambiarDisponibilidad(idNotebooks, disponible);
        }
        #endregion


        // Este metodo nos retorna la disponibilidad de la notebook para poder reutilizarla en el detalle
        #region Disponibilidad de la notebook
        public bool EstaDisponible(int idNotebook)
        {
            Notebook? notebook = repoNotebooks.DetalleNotebooks(idNotebook);

            if (notebook == null)
            {
                throw new Exception("La notebook no existe");
            }

            return notebook.DisponibleNotebook;
        }
        #endregion
    }

}

using Sistema_de_notebooks.CapaDatos.Repos;
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

        public bool EstaDisponible(int idNotebook)
        {
            var notebook = repoNotebooks.DetalleNotebooks(idNotebook);
            if (notebook == null)
                throw new ArgumentNullException("La notebook no existe.");

            return notebook.DisponibleNotebook;
        }

        public void CambiarDisponibilidad(int idNotebook, bool disponible)
        {
            var notebook = repoNotebooks.DetalleNotebooks(idNotebook);
            if (notebook == null)
                throw new ArgumentNullException("La notebook no existe.");

            repoNotebooks.CambiarDisponibilidad(idNotebook, disponible);
        }
    }
}

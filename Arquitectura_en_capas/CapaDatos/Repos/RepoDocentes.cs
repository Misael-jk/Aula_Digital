using Sistema_de_notebooks.CapaDatos;
using Sistema_de_notebooks.CapaDatos.Interfaces;
using Sistema_de_notebooks.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repos
{
    class RepoDocentes : RepoBase, IRepoDocentes
    {
        public RepoDocentes(IDbConnection conexion)
       : base(conexion)
        {
        }

        public void Alta(Docentes docentes)
        {
        }

        public List<Docentes> ListarDocentes()
        {
            return new List<Docentes>();
        }
        public Docentes? DetalleDocentes(int idDocente)
        {
            return null;
        }
    }
}

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
    class RepoNotebooks : RepoBase, IRepoNotebooks
    {
        public RepoNotebooks(IDbConnection conexion)
       : base(conexion)
        {
        }

        public void Alta(Notebook alumnos)
        {
        }

        public List<Notebook> ListarNotebooks()
        {
            return new List<Notebook>();
        }
        public Notebook? DetalleNotebooks(int idAlumno)
        {
            return null;
        }
    }
}

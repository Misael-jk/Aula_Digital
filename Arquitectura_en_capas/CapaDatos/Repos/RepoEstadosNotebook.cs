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
    class RepoEstadosNotebook : RepoBase, IRepoEstadosNotebook
    {
        public RepoEstadosNotebook(IDbConnection conexion)
       : base(conexion)
        {
        }

        public void Alta(EstadosNotebook alumnos)
        {
        }

        public List<EstadosNotebook> ListarEstadosNotebook()
        {
            return new List<EstadosNotebook>();
        }
        public EstadosNotebook? DetalleEstadosNotebook(int idAlumno)
        {
            return null;
        }
    }
}

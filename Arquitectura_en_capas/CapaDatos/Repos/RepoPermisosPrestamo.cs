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
    class RepoPermisosPrestamo : RepoBase, IRepoPermisosPrestamo
    {
        public RepoPermisosPrestamo(IDbConnection conexion)
       : base(conexion)
        {
        }

        public void Alta(PermisoPrestamo alumnos)
        {
        }

        public List<PermisoPrestamo> ListarPermisosPrestamo()
        {
            return new List<PermisoPrestamo>();
        }
        public PermisoPrestamo? DetallePermisosPrestamo(int idAlumno)
        {
            return null;
        }
    }
}

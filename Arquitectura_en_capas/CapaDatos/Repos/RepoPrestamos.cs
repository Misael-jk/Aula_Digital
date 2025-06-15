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
    class RepoPrestamos : RepoBase, IRepoPrestamos
    {
        public RepoPrestamos(IDbConnection conexion)
       : base(conexion)
        {
        }

        public void Alta(Prestamos alumnos)
        {
        }

        public List<Prestamos> ListarPrestamos()
        {
            return new List<Prestamos>();
        }
        public Prestamos? DetallePrestamos(int idAlumno)
        {
            return null;
        }
    }
}

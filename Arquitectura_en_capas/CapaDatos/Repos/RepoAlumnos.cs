using Sistema_de_notebooks.CapaDatos.Interfaces;
using Sistema_de_notebooks.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_notebooks.CapaDatos.Repos
{
    class RepoAlumnos : RepoBase, IRepoAlumnos
    {
       public RepoAlumnos(IDbConnection conexion)
       : base(conexion) 
       {
       }

        public void Alta(Alumnos alumnos)
        {
        }

        public List<Alumnos> ListarAlumnos()
        {
            return new List<Alumnos>();
        }
        public Alumnos? DetalleAlumnos(int idAlumno)
        {
            return null;
        }
    }
}

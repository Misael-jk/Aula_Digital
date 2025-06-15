using Sistema_de_notebooks.CapaDatos;
using Sistema_de_notebooks.CapaDatos.Interfaces;
using Sistema_de_notebooks.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDatos.Repos
{
    class RepoEstadosPrestamo : RepoBase, IRepoEstadosPrestamo
    {
        public RepoEstadosPrestamo(IDbConnection conexion)
        : base(conexion)
        {
        }

        public void Alta(EstadosPrestamo alumnos)
        {
        }

        public List<EstadosPrestamo> ListarEstadosPrestamo()
        {
            return new List<EstadosPrestamo>();
        }
        public EstadosPrestamo? DetalleEstadosPrestamo(int idAlumno)
        {
            return null;
        }
    }
}

using Sistema_de_notebooks.CapaDatos;
using Sistema_de_notebooks.CapaDatos.Interfaces;
using Sistema_de_notebooks.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace CapaDatos.Repos
{
    public class RepoEstadosPrestamo : RepoBase, IRepoEstadosPrestamo
    {
        public RepoEstadosPrestamo(IDbConnection conexion)
        : base(conexion)
        {
        }

        public IEnumerable<EstadosPrestamo> ListarEstadosPrestamo()
        {
            string query = "select * from EstadosPrestamo";

            try
            {
                return Conexion.Query<EstadosPrestamo>(query);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los datos de los estados del prestamo");
            }
        }
    }
}

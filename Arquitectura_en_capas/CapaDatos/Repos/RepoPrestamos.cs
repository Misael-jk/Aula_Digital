using Dapper;
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
    public class RepoPrestamos : RepoBase, IRepoPrestamos
    {
        public RepoPrestamos(IDbConnection conexion)
       : base(conexion)
        {
        }

        #region Alta Prestamo
        public void AltaPrestamo(Prestamos prestamos)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidPrestamo", dbType: DbType.Int32, direction: ParameterDirection.Output);

            parametros.Add("unidDocente", prestamos.IdDocente);
            parametros.Add("unidCarrito", prestamos.IdCarrito);
            parametros.Add("unafechaPrestamo", prestamos.FechaPrestamo);
            parametros.Add("unafechaPactada", prestamos.FechaPactada);

            try
            {
                Conexion.Execute("InsertPrestamo", parametros, commandType: CommandType.StoredProcedure);
                prestamos.IdPrestamo = parametros.Get<int>("unidPrestamo");
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al insertar un Prestamo");
            }
        }
        #endregion

        #region ver los prestamos
        public IEnumerable<Prestamos> ListarPrestamos()
        {
            string query = "señect * from Prestamos";

            try
            {
                return Conexion.Query<Prestamos>(query);
            }
            catch(Exception)
            {
                throw new Exception("Error al ver los datos de los prestamos");
            }
        }
        #endregion

        #region obtener por Id
        public Prestamos? DetallePrestamos(int idPrestamo)
        {
            string query = "select * from Prestamos where idPrestamo = unidPrestamo";

            DynamicParameters parametros = new DynamicParameters();
            try
            {
                parametros.Add("unidPrestamo", idPrestamo);
                return Conexion.QueryFirstOrDefault<Prestamos>(query, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el id del prestamo");
            }
        }
        #endregion
    }
}

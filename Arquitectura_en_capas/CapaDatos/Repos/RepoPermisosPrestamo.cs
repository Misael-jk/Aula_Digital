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
    class RepoPermisosPrestamo : RepoBase, IRepoPermisosPrestamo
    {
        public RepoPermisosPrestamo(IDbConnection conexion)
       : base(conexion)
        {
        }

        #region dar de alta permiso
        public void AltaPermisosPrestamo(PermisoPrestamo permiso)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidPermisosPrestamo", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parametros.Add("unidAlumno", permiso.IdAlumno);
            parametros.Add("unidDocente", permiso.IdDocente);
            parametros.Add("unafechaPrestamo", permiso.FechaPermiso, dbType: DbType.DateTime);

            try
            {
                Conexion.Execute("InsertPermisosPrestamo", parametros, commandType: CommandType.StoredProcedure);
                permiso.IdPermiso = parametros.Get<int>("unidPermisosPrestamo");
            }
            catch(Exception)
            {
                throw new Exception("Error al insertar un permiso");
            }
        }
        #endregion

        #region Eliminar Permiso
        public int EliminarPermisosPrestamo(int idPermisosPrestamo)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidPermisosPrestamo", idPermisosPrestamo);

            try
            {
                return Conexion.Execute("DeletePermisosPrestamo", parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al eliminar un permiso");
            }
        }
        #endregion

        #region Ver los datos del permiso
        public IEnumerable<PermisoPrestamo> ListarPermisosPrestamo()
        {
            string query = "select * from PermisoPrestamo";

            try
            {
                return Conexion.Query<PermisoPrestamo>(query);
            }
            catch (Exception)
            {
                throw new Exception("Error al mostrar los datos de los permisos");
            }
        }
        #endregion

        #region Ver permiso por id
        public PermisoPrestamo? DetallePermisosPrestamo(int idPermisoPrestamo)
        {
            string query = "select * from PermisoPrestamo where idPermisoPrestamo = unidPermisoPrestamo";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("unidPermisoPrestamo", idPermisoPrestamo);

            try
            {
                return Conexion.QueryFirstOrDefault<PermisoPrestamo>(query, parametros);
            }
            catch(Exception)
            {
                throw new Exception("Error al obtener el id del permiso");
            }

        }
        #endregion
    }
}

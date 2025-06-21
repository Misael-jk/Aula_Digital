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

namespace Sistema_de_notebooks.CapaDatos.Repos
{
    public class RepoNotebooks : RepoBase, IRepoNotebooks
    {
        public RepoNotebooks(IDbConnection conexion)
       : base(conexion)
        {
        }

        #region Alta Notebook 
        public void AltaNotebook(Notebook notebook)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidNotebook", dbType: DbType.Int32, direction: ParameterDirection.Output);

            parametros.Add("unidEstadoNotebook", notebook.IdEstadoNotebook);

            try
            {
                Conexion.Execute("InsertNotebook", parametros, commandType: CommandType.StoredProcedure);
                notebook.IdNotebook = parametros.Get<int>("unidNotebook");
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al insertar una notebook");
            }
        }
        #endregion

        #region Actualizar Notebook
        public void ActualizarNotebook(Notebook notebook)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidNotebook", notebook.IdNotebook);
            parametros.Add("unidEstadoNotebook", notebook.IdEstadoNotebook);

            try
            {
                Conexion.Execute("UpdateNotebook", parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al actualizar una notebook");
            }
        }
        #endregion

        #region Eliminar Notebook
        public void EliminarNotebook(int idNotebook)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidNotebook", idNotebook);

            try
            {
                Conexion.Execute("DeleteNotebook", parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al eliminar una notebook");
            }
        }
        #endregion

        #region Cammbiar el estado de la notebook
        public void CambiarDisponibilidad(int idNotebook, bool disponibleNotebook)
        {
            string sql = "update Notebooks set disponibleNotebook = @disponibleNotebook where idNotebook = @idNotebook";

            Conexion.Execute(sql, new { disponibleNotebook, idNotebook });
        }
        #endregion 

        #region Obtener los datos
        public IEnumerable<Notebook> ListarNotebooks()
        {
            string query = "select * from Notebooks";

            try
            {
                return Conexion.Query<Notebook>(query);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los datos de las notebooks");
            }
        }
        #endregion

        #region Obtener por Id
        public Notebook? DetalleNotebooks(int idNotebook)
        {
            string query = "select * from Notebooks where idNotebook = unidNotebook";

            DynamicParameters parametros = new DynamicParameters();
            try
            {
                parametros.Add("unidNotebook", idNotebook);
                return Conexion.QueryFirstOrDefault<Notebook>(query, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el id de la notebook");
            }
        }
        #endregion
    }
}

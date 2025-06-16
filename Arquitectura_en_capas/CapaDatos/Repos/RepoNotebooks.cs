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
    class RepoNotebooks : RepoBase, IRepoNotebooks
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
                Conexion.Execute("AltaNotebook", parametros, commandType: CommandType.StoredProcedure);
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
                Conexion.Execute("UpdateAlumno", parametros, commandType: CommandType.StoredProcedure);
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

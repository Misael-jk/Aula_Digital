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
    class RepoCarritos : RepoBase, IRepoCarritos
    {
        public RepoCarritos(IDbConnection conexion)
       : base(conexion)
        {
        }

        #region Alta Carrito
        public void AltaCarrito(Carritos carritos)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidCarrito", dbType: DbType.Int32, direction: ParameterDirection.Output);

            parametros.Add("unidDocente", carritos.IdDocente);

            try
            {
                Conexion.Execute("InsertCarrito", parametros, commandType: CommandType.StoredProcedure);
                carritos.IdCarrito = parametros.Get<int>("unidCarrito");
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al insertar un carrito");
            }
        }
        #endregion

        #region Actualizar Carrito
        public void ActualizarCarrito(Carritos carritos)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidCarrito", carritos.IdCarrito);
            parametros.Add("unidDocente", carritos.IdDocente);

            try
            {
                Conexion.Execute("UpdateCarrito", parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al actualizar un carrito");
            }
        }
        #endregion

        #region Eliminar Carrito
        public void EliminarCarrito(int idCarrito)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidCarrito", idCarrito);

            try
            {
                Conexion.Execute("DeleteCarrito", parametros, commandType: CommandType.StoredProcedure);
            }
            catch(Exception)
            {
                throw new Exception("Hubo un error al eliminar un carrito");
            }
        }
        #endregion

        public List<Carritos> ListarCarritos()
        {
            return new List<Carritos>();
        }
        public Carritos? DetalleCarritos(int idAlumno)
        {
            return null;
        }
    }
}

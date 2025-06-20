using Dapper;
using System.Data;
using Sistema_de_notebooks.CapaDatos;
using Sistema_de_notebooks.CapaDatos.Interfaces;
using Sistema_de_notebooks.CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repos
{
    public class RepoCarritoNotebooks : RepoBase, IRepoCarritoNotebooks
    {
        public RepoCarritoNotebooks(IDbConnection conexion) : base(conexion)
        {
        }

        public IEnumerable<CarritoNotebooks> ListarNotebooksCarrito(int idCarrito)
        {
            throw new NotImplementedException();
        }

        #region Buscar las notebooks del carrito
        public IEnumerable<Notebook> ListarNotebooksPorCarrito(int idCarrito)
        {
            string query = "select * from WievNotebooksDelCarrito where idCarrito = @idCarrito";

            try
            {
                return Conexion.Query<Notebook>(query, new { idCarrito });
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener las notebook del carrito");
            }
        }
        #endregion


    }
}

using CapaDatos.DTOs;
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
    public class RepoPrestamoDetalle : RepoBase, IRepoPrestamoDetalle
    {
        public RepoPrestamoDetalle(IDbConnection conexion)
       : base(conexion)
        {
        }

        #region ver los datos del detalle
        public IEnumerable<PrestamoDetalle> ListarPrestamoDetalle()
        {
            string query = "select * from PrestamoDetalle";

            try
            {
                return Conexion.Query<PrestamoDetalle>(query);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los datos del detalle");
            }
        }
        #endregion

        #region Historial de la notebook
        public IEnumerable<HistorialNotebookDTO> HistorialNotebook(int idNotebook)
        {
            string query = "select * from WievHistorialNotebook where idNotebook = @idNotebook";

            try
            {
                return Conexion.Query<HistorialNotebookDTO>(query, new {idNotebook}).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el historial de la notebook");
            }
        }
        #endregion

        #region Obtener Detalle por prestamos
        public IEnumerable<PrestamoDetalle> DetallePorPrestamo(int idPrestamo)
        {
            var parametros = new DynamicParameters();
            parametros.Add("unidPrestamo", idPrestamo);

            return Conexion.Query<PrestamoDetalle>("DetallePorPrestamo", parametros, commandType: CommandType.StoredProcedure
            );
        }
        #endregion
    }
}

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

        #region Insertar Detalle del Prestamo
        public void AltaPrestamoDetalle(PrestamoDetalle prestamoDetalle)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidPrestamo", prestamoDetalle.IdPrestamo);
            parametros.Add("unidNotebook", prestamoDetalle.IdNotebook);
            parametros.Add("unidEstadoPrestamo", prestamoDetalle.IdEstadoPrestamo);
            parametros.Add("unafechaDevolucion", prestamoDetalle.FechaDevolucion);

            try
            {
                Conexion.Execute("InsertPrestamoDetalle", parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al insertar una notebook");
            }
        }
        #endregion

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

        #region Obtener Detalle por prestamos y notebooks
        public PrestamoDetalle? DetallePorPrestamo(int idPrestamo, int idNotebook)
        {
            string query = "select * from PrestamoDetalle where idPrestamo = @idPrestamo and idNotebook = @idNotebook";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("unidPrestamo", idPrestamo);
            parametros.Add("unidNotebook", idNotebook);

            try
            {
                return Conexion.QueryFirstOrDefault<PrestamoDetalle>(query, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los detalles del prestamo y la notebook");
            }
        }
        #endregion

        #region Listar por prestamos
        public IEnumerable<PrestamoDetalle> ListarDetallesPorPrestamo(int idPrestamo)
        {
            string query = "select * from PrestamoDetalle where idPrestamo = @unidPrestamo";

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add("unidPrestamo", idPrestamo);

            try
            {
                return Conexion.Query<PrestamoDetalle>(query, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los detalles del préstamo");
            }
        }

        #endregion

        #region Actualizar los detalles
        public void ActualizarDetalle(PrestamoDetalle prestamoDetalle)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidPrestamo", prestamoDetalle.IdPrestamo);
            parametros.Add("unidNotebook", prestamoDetalle.IdNotebook);
            parametros.Add("unidEstadoPrestamo", prestamoDetalle.IdEstadoPrestamo);
            parametros.Add("unafechaDevolucion", prestamoDetalle.FechaDevolucion);

            try
            {
                Conexion.Execute("UpdatePrestamoDetalle", parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al actualizar el Detalle del prestamo");
            }
        }
        #endregion
    }
}

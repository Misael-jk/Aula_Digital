using Dapper;
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
    public class RepoAlumnos : RepoBase, IRepoAlumnos
    {
       public RepoAlumnos(IDbConnection conexion)
       : base(conexion) 
       {
       }

        #region Dar alta a Alumnos
        public void AltaAlumno(Alumnos alumnos)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidAlumno", dbType: DbType.Int32, direction: ParameterDirection.Output);

            parametros.Add("undni", alumnos.Dni);
            parametros.Add("unnombre", alumnos.Nombre);
            parametros.Add("unapellido", alumnos.Apellido);
            parametros.Add("unemail", alumnos.Email);
            parametros.Add("uncurso", alumnos.Curso);

            try
            {
                Conexion.Execute("InsertAlumno", parametros, commandType: CommandType.StoredProcedure);
                alumnos.IdAlumno = parametros.Get<int>("unidAlumno");
            }
            catch(Exception)
            {
                throw new Exception("Hubo un error al insertar un alumno");
            }
        }
        #endregion

        #region Actualizar Alumnos
        public void ActualizarAlumno(Alumnos alumnos)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidAlumno", alumnos.IdAlumno);
            parametros.Add("undni", alumnos.Dni);
            parametros.Add("unnombre", alumnos.Nombre);
            parametros.Add("unapellido", alumnos.Apellido);
            parametros.Add("unemail", alumnos.Email);
            parametros.Add("uncurso", alumnos.Curso);

            try
            {
                Conexion.Execute("UpdateAlumno", parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al actualizar un alumno");
            }
        }
        #endregion

        #region Eliminar Alumnos
        public void EliminarAlumno(int idAlumno)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidAlumno", idAlumno);
            try
            {
                Conexion.Execute("DeleteAlumno", parametros, commandType: CommandType.StoredProcedure);
            }
            catch(Exception)
            {
                throw new Exception("Hubo un error al eliminar un alumno");
            }
        }
        #endregion

        #region Obtener todos los datos
        public IEnumerable<Alumnos> ListarAlumnos()
        {
            string query = "select * from Alumnos";

            try
            {
                return Conexion.Query<Alumnos>(query);
            }
            catch(Exception ex)
            {
                throw new Exception("No se pudo obtener los datos del alumno"+ ex.Message);
            }
        }
        #endregion

        #region Obtener por Id
        public Alumnos? DetalleAlumnos(int idAlumno)
        {
            string query = "select * from Alumnos where idAlumno = unidAlumno";

            DynamicParameters parametros = new DynamicParameters();

            try
            {
                parametros.Add("unidAlumno", idAlumno);
                return Conexion.QueryFirstOrDefault<Alumnos>(query, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener id del Alumno");
            }

        }
        #endregion
    }
}
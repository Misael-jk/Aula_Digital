using Dapper;
using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data;

namespace CapaDatos.Repos
{
    class RepoEncargados : RepoBase, IRepoEncargados
    {
        public RepoEncargados(IDbConnection conexion) 
        : base (conexion)
        {
        }

        #region Alta Encargado 
        public void Insert(Encargado encargado)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidEncargado", dbType: DbType.Int32, direction: ParameterDirection.Output);

            parametros.Add("unusuario", encargado.Usuario);
            parametros.Add("unpassword", encargado.Password);
            parametros.Add("unnombre", encargado.Nombre);
            parametros.Add("unapellido", encargado.Apellido);
            parametros.Add("unemail", encargado.Email);

            try
            {
                Conexion.Execute("InsertEncargado", parametros, commandType: CommandType.StoredProcedure);
                encargado.IdEncargado = parametros.Get<int>("unidEncargado");
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al insertar a un Encargado");
            }
        }
        #endregion

        #region Actualizar Encargado
        public void Update(Encargado encargado)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidEncargado",encargado.IdEncargado);
            parametros.Add("unusuario", encargado.Usuario);
            parametros.Add("unpassword", encargado.Password);
            parametros.Add("unnombre", encargado.Nombre);
            parametros.Add("unapellido", encargado.Apellido);
            parametros.Add("unemail", encargado.Email);

            try
            {
                Conexion.Execute("UpdateEncargado", parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al Actualizar a un Encargado");
            }
        }
        #endregion

        #region Eliminar Elemento
        public void Delete(int idEncargado)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("unidEncargado", idEncargado);

            try
            {
                Conexion.Execute("DeleteEncargado", parametros, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                throw new Exception("Hubo un error al eliminar un Encargado");
            }
        }
        #endregion

        #region Obtener los datos
        public IEnumerable<Encargado> GetAll()
        {
            string query = "select * from Encargado";

            try
            {
                return Conexion.Query<Encargado>(query);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los datos de los Encargados");
            }
        }
        #endregion

        #region Obtener por Id
        public Encargado? GetById(int idEncargado)
        {
            string query = "select * from Encargado where idEncargado = unidEncargado";

            DynamicParameters parametros = new DynamicParameters();

            try
            {
                parametros.Add("unidElemento", idEncargado);
                return Conexion.QueryFirstOrDefault<Encargado>(query, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el id del Encargado");
            }
        }
        #endregion
    }
}

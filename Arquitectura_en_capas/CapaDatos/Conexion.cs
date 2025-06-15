using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace Sistema_de_notebooks.CapaDatos
{
    public class Conexion
    {
        private string _connectionString;
       
        public Conexion(string connectionString)
        {
            _connectionString = connectionString;
            
        }

        public void ObtenerTodo()
        {
            using(var conn = new MySqlConnection(_connectionString))
            {
                
            }
        }
    }
}

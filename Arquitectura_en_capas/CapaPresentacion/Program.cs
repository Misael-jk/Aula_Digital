using Microsoft.Extensions.Configuration;
using CapaDatos;
using System.Data;
using MySql.Data.MySqlClient;
using CapaPresentacion;

namespace Sistema_de_notebooks
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();
            string ConnectionString = configuration.GetConnectionString("Conexion");

                IDbConnection dbConnection = new MySqlConnection(ConnectionString);

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new frmLogin(dbConnection));
        }
    }
}
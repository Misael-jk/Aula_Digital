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

        public void Alta(Carritos alumnos)
        {
        }

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

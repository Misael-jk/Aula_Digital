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
    class RepoPrestamoDetalle : RepoBase, IRepoPrestamoDetalle
    {
        public RepoPrestamoDetalle(IDbConnection conexion)
       : base(conexion)
        {
        }

        public void Alta(PrestamoDetalle alumnos)
        {
        }

        public List<PrestamoDetalle> ListarPrestamoDetalle()
        {
            return new List<PrestamoDetalle>();
        }
        public PrestamoDetalle? DetallePrestamoDetalle(int idAlumno)
        {
            return null;
        }
    }
}

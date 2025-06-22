using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Repos;
using Sistema_de_notebooks.CapaEntidad;

namespace Sistema_de_notebooks.CapaDatos.Interfaces
{
    interface IRepoCarritoNotebooks
    {
        public IEnumerable<CarritoNotebooks> ListarNotebooksCarrito(int idCarrito);
    }
}

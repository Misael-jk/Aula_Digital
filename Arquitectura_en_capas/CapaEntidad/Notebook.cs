using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_notebooks.CapaEntidad
{
    public class Notebook
    {
        public int IdNotebook {get; set;}
        public int IdEstadoNotebook {get; set;}
        public bool DisponibleNotebook { get; set; }
    }
}

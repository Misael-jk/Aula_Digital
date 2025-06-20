using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_notebooks.CapaEntidad
{
    public class Carritos
    {
        public int IdCarrito {get; set;}
        public int IdDocente {get; set;}
        public required bool Disponible { get; set; }
    }
}

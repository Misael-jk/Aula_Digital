using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_notebooks.CapaEntidad
{
    public class Prestamos
    {
        public int IdPrestamo {get; set;}
        public int? IdPermiso {get; set;} 
        public int IdDocente {get; set;}
        public int? IdCarrito {get; set;} 
        public DateTime FechaPrestamo {get; set;}
        public DateTime FechaPactada {get; set;}
        public required string TipoPrestamo {get; set;} 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    class PermisoPrestamo
    {
        public int IdPermiso {get; set;}
        public int IdAlumno {get; set;} 
        public int IdDocente {get; set;}
        public DateTime FechaPermiso {get; set;}
    }
}

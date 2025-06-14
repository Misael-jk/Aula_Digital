using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    class PrestamoDetalle
    {
        public int IdPrestamo {get; set;}
        public int IdNotebook {get; set;}
        public int IdEstadoPrestamo {get; set;}
        public DateTime? FechaDevolucion {get; set;}
    }
}

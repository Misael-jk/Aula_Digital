using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_notebooks.CapaEntidad
{
    public class PrestamoDetalle
    {
        public int IdPrestamo {get; set;}
        public int IdNotebook {get; set;}
        public int IdEstadoPrestamo {get; set;}
        public DateTime? FechaDevolucion {get; set;}
    }
}

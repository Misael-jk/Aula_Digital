using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTOs
{
    public class HistorialNotebookDTO
    {
        public int IdPrestamo { get; set; }
        public string Docente { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string EstadoPrestamo { get; set; }
    }
}

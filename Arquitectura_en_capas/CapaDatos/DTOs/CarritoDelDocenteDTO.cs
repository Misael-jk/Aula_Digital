using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTOs
{
    public class CarritoDelDocenteDTO
    {
        public int IdCarrito { get; set; }
        public string DocenteResponsable { get; set; }
        public int CantidadNotebooks { get; set; }
    }
}

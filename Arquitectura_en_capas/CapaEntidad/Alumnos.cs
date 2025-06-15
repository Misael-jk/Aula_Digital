using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_notebooks.CapaEntidad
{
    public class Alumnos
    {
        public int IdAlumno {get; set;}
        public int Dni {get; set;}
        public required string Nombre {get; set;}
        public required string Apellido {get; set;}
        public required string Email {get; set;}
        public required string Curso {get; set;}
    }
}

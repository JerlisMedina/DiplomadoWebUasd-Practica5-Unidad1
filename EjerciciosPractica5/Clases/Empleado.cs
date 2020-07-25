using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EjerciciosPractica5.Clases;

namespace EjerciciosPractica5.Clases
{
    public class Empleado : Persona
    {
        public decimal Sueldo { get; set; }
        public DateTime Horario { get; set; }
        public string Puesto { get; set; }
        public string Seguro { get; set; }
    }
}

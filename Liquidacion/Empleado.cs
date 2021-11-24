using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquidacion
{
    public class Empleado
    {
        public int id { get; set; }
        public int legajo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDni { get; set; }
        public int numeroDni { get; set; }
        public string cuit { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int mesesAnteriores { get; set; }
        public bool activo { get; set; }
        public DateTime fechaBaja { get; set; }
        //public double sueldoAcordado { get; set; }
        public double Sueldo { get; set; }

        public int Convenio { get; set; }
        public int Contrato { get; set; }
    }
}

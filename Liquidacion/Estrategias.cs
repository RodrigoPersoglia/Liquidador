using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquidacion
{
    class PorHoras : ILiquidacion
    {
        public Concepto liquidar(Empleado empleado, double ingreso, Concepto concepto)
        {
            //double sueldo;
            //if (empleado.sueldoAcordado > 0) {sueldo = empleado.sueldoAcordado;}
            //else { sueldo = empleado.SueldoConvenio;}
            double importe = empleado.Sueldo * ingreso * concepto.Factor;
            concepto.Cantidad = (int)ingreso;
            concepto.Importe = importe;
            return concepto;
        }
    }
    class PorDia : ILiquidacion
    {
        public Concepto liquidar(Empleado empleado, double ingreso, Concepto concepto)
        {
            //double sueldo;
            //if (empleado.sueldoAcordado > 0) { sueldo = empleado.sueldoAcordado; }
            //else { sueldo = empleado.SueldoConvenio; }
            double importe = empleado.Sueldo / 30 * ingreso * concepto.Factor;
            concepto.Cantidad = (int)ingreso;
            concepto.Importe = importe;
            return concepto;
        }
    }

    class PorImporte : ILiquidacion
    {
        public Concepto liquidar(Empleado empleado, double ingreso, Concepto concepto)
        {
            double importe = concepto.Cantidad * ingreso * concepto.Factor;
            concepto.Importe = importe;
            return concepto;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liquidacion
{
    class PorHoras : ILiquidacion
    {
        public Concepto liquidar(Empleado empleado, double ingreso, Concepto concepto, DateTime fechaLiquidacion)
        {
            double importe = empleado.Sueldo * ingreso * concepto.Factor;
            concepto.Cantidad = (int)ingreso;
            concepto.Importe = importe;
            return concepto;
        }
    }
    class PorDia : ILiquidacion
    {
        public Concepto liquidar(Empleado empleado, double ingreso, Concepto concepto, DateTime fechaLiquidacion)
        {
            double importe = empleado.Sueldo / 30 * ingreso * concepto.Factor;
            concepto.Cantidad = (int)ingreso;
            concepto.Importe = importe;
            return concepto;
        }
    }

    class PorImporte : ILiquidacion
    {
        public Concepto liquidar(Empleado empleado, double ingreso, Concepto concepto, DateTime fechaLiquidacion)
        {
            double importe = concepto.Cantidad * ingreso;
            concepto.Importe = importe;
            return concepto;
        }
    }


    class PorPorcentaje : ILiquidacion
    {
        public Concepto liquidar(Empleado empleado, double ingreso, Concepto concepto, DateTime fechaLiquidacion)
        {
            double importe = concepto.Cantidad * concepto.Factor /100 * ingreso;
            concepto.Importe = importe;
            return concepto;
        }
    }


    class PorAntigüedad : ILiquidacion
    {
        public Concepto liquidar(Empleado empleado, double ingreso, Concepto concepto, DateTime fechaLiquidacion)
        {
            int cantidad = (fechaLiquidacion - empleado.fechaIngreso).Days;
            cantidad = (int)Math.Truncate(cantidad / 365.25 + empleado.mesesAnteriores / 12) ;
            double importe = (cantidad * ingreso)/100*concepto.Factor;
            concepto.Importe = importe;
            return concepto;
        }
    }
}

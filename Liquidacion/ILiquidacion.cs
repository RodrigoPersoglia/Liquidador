using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquidacion
{
    interface ILiquidacion
    {
        Concepto liquidar(Empleado empleado,double ingreso, Concepto concepto);

    }
}

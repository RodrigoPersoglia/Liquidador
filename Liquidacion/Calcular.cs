using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquidacion
{
    class Calcular
    {
        public Concepto Concepto { get; set; }
        ILiquidacion Estrategia;
        public Empleado Empleado { get; set; }
        public double Ingreso { get; set; }


        public Calcular(Concepto concepto, Empleado empleado, double ingreso)
        {
            Concepto = concepto;
            Estrategia = new PorDia();
            Empleado = empleado;
            Ingreso = ingreso;

        }

        public Concepto CalcularLiquidacion()
        {
            return Estrategia.liquidar(Empleado, Ingreso, Concepto);
        }

        public void CambiarEstrategia(ILiquidacion nuevaEstrategia)
        {
            Estrategia = nuevaEstrategia;
        }
    }
}

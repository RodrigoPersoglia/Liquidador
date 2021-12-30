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
        public DateTime fecha { get; set; }


        public Calcular(Concepto concepto, Empleado empleado, double ingreso, DateTime fechaLiquidacion)
        {
            Concepto = concepto;
            Estrategia = new PorDia();
            Empleado = empleado;
            Ingreso = ingreso;
            fecha = fechaLiquidacion;

        }

        public Concepto CalcularLiquidacion()
        {
            return Estrategia.liquidar(Empleado, Ingreso, Concepto, fecha);
        }

        public void CambiarEstrategia(ILiquidacion nuevaEstrategia)
        {
            Estrategia = nuevaEstrategia;
        }
    }
}

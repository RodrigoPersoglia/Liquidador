using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquidacion
{
    public class Concepto
    {
        
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double Importe { get; set; }
        public double Factor { get; set; }
        public int TipoConcepto { get; set; }
        public int Ingresa { get; set; }
        public int TipoContrato { get; set; }

        public Concepto(int id, int numero, string descrpcion, int cantidad, double importe, double factor, int tipoConcepto, int ingresa, int tipoContrato)
        {
            Id = id;
            Numero = numero;
            Descripcion = descrpcion;
            Cantidad = cantidad;
            Importe = importe;
            Factor = factor;
            TipoConcepto = tipoConcepto;
            Ingresa = ingresa;
            TipoContrato = tipoContrato;
            
        }

        public Concepto()
        {

        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquidacion
{
    public class Os
    {
        private int id;
        private int numero;
        private string descripcion;
        private string abreviatura;

        public int ID { get { return this.id; } set {this.id = value;} }
        public int Numero { get { return this.numero; } set { this.numero = value; } }
        public string Descripcion { get { return this.descripcion; } set { this.descripcion = value; } }
        public string Abreviatura { get { return this.abreviatura; } set {this.abreviatura = value; } }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Liquidacion
{
    public partial class Liquidar : Form
    {
        public Liquidar()
        {
            InitializeComponent();
        }

        Empleado empleado = new Empleado();
        Concepto concepto = new Concepto(1, 1, "pueba por horas", 1, 158.15, 1, 1, 1, 1);
        Calcular calculo;
        private void Liquidar_Load(object sender, EventArgs e)
        {

            //*** prueba***//
            
            empleado.sueldoAcordado = 0;
            empleado.SueldoConvenio = 46856.85;
            EstrategiaCBX.Text = "Por Importe";
            

        
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int numero;
            try
            {
                numero = int.Parse(NumTBX.Text);
                NumTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { NumTBX.ForeColor = System.Drawing.Color.Red; }
        }



        private void cuil2TBX_TextChanged(object sender, EventArgs e)
        {
            double numero;
            try
            {
                numero = double.Parse(IngresaTBX.Text);
                IngresaTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { IngresaTBX.ForeColor = System.Drawing.Color.Red; }

        }



        private void telefonoTBX_TextChanged(object sender, EventArgs e)
        {

        }

        private void CelularTBX_TextChanged(object sender, EventArgs e)
        {


        }


        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            calculo = new Calcular(concepto, empleado, double.Parse(IngresaTBX.Text));

            //if (EstrategiaCBX.Text == "Por Dia") { calculo.CambiarEstrategia(new PorDia()); }
            //if (EstrategiaCBX.Text == "Por Hora") { calculo.CambiarEstrategia(new PorHoras()); }
            //if (EstrategiaCBX.Text == "Por Importe") { calculo.CambiarEstrategia(new PorImporte()); }
            calculo.CambiarEstrategia(nuevaEstrategia);

            concepto = calculo.CalcularLiquidacion();
            int n = Cuadro.Rows.Add();
            Cuadro.Rows[n].Cells[0].Value = false;
            Cuadro.Rows[n].Cells[1].Value = concepto.Numero;
            Cuadro.Rows[n].Cells[2].Value = concepto.Descripcion;
            Cuadro.Rows[n].Cells[3].Value = concepto.Cantidad;
            Cuadro.Rows[n].Cells[4].Value = concepto.Importe;

        }

        private void Limpiar()
        {
            NumTBX.Text = "";
            descripcionTBX.Text = "";
            IngresaTBX.Text = "";
        }

        private void ModificarBTN_Click(object sender, EventArgs e)
        {
           
        }




            

        int n;
        private void Cuadro_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EliminarBTN_Click(object sender, EventArgs e)
        {
           
        }

        ILiquidacion nuevaEstrategia;
        private void EstrategiaCBX_TextChanged(object sender, EventArgs e)
        {
            
            if (EstrategiaCBX.Text == "Por Dia") { nuevaEstrategia= new PorDia(); }
            if (EstrategiaCBX.Text == "Por Hora") { nuevaEstrategia = new PorHoras(); }
            if (EstrategiaCBX.Text == "Por Importe") { nuevaEstrategia = new PorImporte(); }
        }
    }
}

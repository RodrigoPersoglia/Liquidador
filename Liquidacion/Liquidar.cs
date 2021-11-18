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

        Empleado empleado;
        Concepto concepto;// = new Concepto(1, 1, "pueba por horas", 1, 158.15, 1, 1, 1, 1);
        Calcular calculo;
        private void Liquidar_Load(object sender, EventArgs e)
        {

            //*** prueba***//

            //empleado.sueldoAcordado = 0;
            // empleado.SueldoConvenio = 46856.85;
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
                numero = int.Parse(NumConceptoTBX.Text);
                NumConceptoTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { NumConceptoTBX.ForeColor = System.Drawing.Color.Red; }
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
            calculo.CambiarEstrategia(nuevaEstrategia);
            concepto = calculo.CalcularLiquidacion();
            int n = Cuadro.Rows.Add();
            Cuadro.Rows[n].Cells[0].Value = false;
            Cuadro.Rows[n].Cells[1].Value = concepto.Numero;
            Cuadro.Rows[n].Cells[2].Value = concepto.Descripcion;
            Cuadro.Rows[n].Cells[3].Value = concepto.Cantidad;
            if (concepto.TipoConcepto == 1) 
            { 
                Cuadro.Rows[n].Cells[4].Value = Math.Round(concepto.Importe, 2);
                double remunerativo = Double.Parse(RemunerativoTXT.Text) + Math.Round(concepto.Importe, 2);
                RemunerativoTXT.Text = remunerativo.ToString();
                //Cuadro.Rows[n].Cells[5].Value = 0;
            }
            else if (concepto.TipoConcepto == 2)
            {
                //Cuadro.Rows[n].Cells[4].Value = 0;
                Cuadro.Rows[n].Cells[5].Value = Math.Round(concepto.Importe, 2);
                double exento = Double.Parse(ExentoTXT.Text) + Math.Round(concepto.Importe, 2);
                ExentoTXT.Text = exento.ToString();
            }

        }

        private void Limpiar()
        {
            NumConceptoTBX.Text = "";
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
            
            if (EstrategiaCBX.Text == "Por Dia") { nuevaEstrategia = new PorDia(); }
            if (EstrategiaCBX.Text == "Por Hora") { nuevaEstrategia = new PorHoras(); }
            if (EstrategiaCBX.Text == "Por Importe") { nuevaEstrategia = new PorImporte(); if (concepto != null) { concepto.Cantidad = 1;} }
        }

        private void cambiarEstrategia(int opcion)
        {

            if (opcion==1) { EstrategiaCBX.Text = "Por Dia"; nuevaEstrategia = new PorDia(); }
            if (opcion == 2) { EstrategiaCBX.Text = "Por Hora"; nuevaEstrategia = new PorHoras(); }
            if (opcion == 3) { EstrategiaCBX.Text = "Por Importe";  nuevaEstrategia = new PorImporte(); }
        }

        private void buscarConceptoBTN_Click(object sender, EventArgs e)
        {
            if (NumConceptoTBX.ForeColor != System.Drawing.Color.Red && NumConceptoTBX.Text != "")
            {


                if (empleado == null) { MessageBox.Show("Ingrese un empleado"); }
                else
                {
                    concepto = new Concepto();
                    concepto = Conexion.ObtenerConcepto(empleado.Contrato, int.Parse(NumConceptoTBX.Text));
                    if (concepto != null)
                    {
                        NumConceptoTBX.Text = concepto.Numero.ToString();
                        descripcionTBX.Text = concepto.Descripcion;
                        cambiarEstrategia(concepto.Ingresa);
                    }

                }
            }
            else { MessageBox.Show("ingrese un numero de concepto"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cuadro.Rows.Clear();
            empleado = new Empleado();
            empleado = Conexion.ObtenerEmpleado(LegajoTBX.Text);
            Empleado empleadoAuxiliar = empleado;
            if (empleado != null)
            {
                LegajoTBX.Text = empleado.legajo.ToString();
                empleado = empleadoAuxiliar;
                EmpleadoTBX.Text = empleado.nombre + " " + empleado.apellido;
                DniTXB.Text = empleado.numeroDni.ToString();
                NumConceptoTBX.Focus();
            }
            else
            {
                LegajoTBX.Text = "";
                EmpleadoTBX.Text = "";
                DniTXB.Text = "";
            }



        }

        private void LegajoTBX_TextChanged(object sender, EventArgs e)
        {
            empleado = null;
            EmpleadoTBX.Text = "";
            DniTXB.Text = "";
        }



        private void LegajoTBX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1_Click(sender, e);  }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }

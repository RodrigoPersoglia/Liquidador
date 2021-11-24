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
        Concepto concepto;
        Calcular calculo;
        private void Liquidar_Load(object sender, EventArgs e)
        {
            // COMBOBOX TURNO
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            MySqlDataReader reader;
            string consulta = "Select ID,descripcion From mes m order by m.numero";
            try
            {
                MesCBX.DataSource = null;
                MesCBX.Items.Clear();
                MySqlCommand comand = new MySqlCommand(consulta, conectar);
                reader = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow newRow = dt.NewRow();
                newRow["descripcion"] = "Seleccione Mes";
                dt.Rows.InsertAt(newRow, 0);
                MesCBX.DataSource = dt;
                MesCBX.DisplayMember = "descripcion";
                MesCBX.ValueMember = "ID";
            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }

            consulta = "Select ID,descripcion From periodo m order by m.id";
            try
            {
                PeriodoCBX.DataSource = null;
                PeriodoCBX.Items.Clear();
                MySqlCommand comand = new MySqlCommand(consulta, conectar);
                reader = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow newRow = dt.NewRow();
                newRow["descripcion"] = "Seleccione Periodo";
                dt.Rows.InsertAt(newRow, 0);
                PeriodoCBX.DataSource = dt;
                PeriodoCBX.DisplayMember = "descripcion";
                PeriodoCBX.ValueMember = "ID";
            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }

            finally { conectar.Close(); }
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
            try
            {


                if (nuevaEstrategia != null && concepto!=null)
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
                    }
                    else if (concepto.TipoConcepto == 2)
                    {
                        Cuadro.Rows[n].Cells[5].Value = Math.Round(concepto.Importe, 2);
                        double exento = Double.Parse(ExentoTXT.Text) + Math.Round(concepto.Importe, 2);
                        ExentoTXT.Text = exento.ToString();
                    }
                    else
                    {
                        Cuadro.Rows[n].Cells[6].Value = Math.Round(concepto.Importe, 2);
                        double descuentos = Double.Parse(DescuentosTXT.Text) + Math.Round(concepto.Importe, 2);
                        DescuentosTXT.Text = descuentos.ToString();
                    }

                    Cuadro.Rows[n].Cells[7].Value = EstrategiaCBX.Text;
                    actualizarCuadro();
                    NumConceptoTBX.Text = "0";
                    descripcionTBX.Text = "";
                    concepto = null;
                }
                else { MessageBox.Show("No seleccionó ningun concepto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception) { }
            }

        private void actualizarCuadro()
        {
            //ACTUALIZO LOS DESCUENTOS PORCENTUALES
            string textoAnterior = EstrategiaCBX.Text;
            for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
            {
                if (Cuadro.Rows[fila].Cells[6].Value != null && Cuadro.Rows[fila].Cells[7].Value.ToString() == "Por Porcentaje")
                {
                    double descuentosNuevo = Double.Parse(DescuentosTXT.Text);
                    descuentosNuevo -= (double)Cuadro.Rows[fila].Cells[6].Value;
                    concepto = Conexion.ObtenerConcepto(empleado.Contrato, (int)Cuadro.Rows[fila].Cells[1].Value);
                    if (concepto != null)
                    {
                        EstrategiaCBX.Text = "";
                        cambiarEstrategia(concepto.Ingresa);
                        NumConceptoTBX.Text = concepto.Numero.ToString();
                        descripcionTBX.Text = concepto.Descripcion;
                    }
                    calculo = new Calcular(concepto, empleado, double.Parse(IngresaTBX.Text));
                    calculo.CambiarEstrategia(nuevaEstrategia);
                    concepto = calculo.CalcularLiquidacion();
                    Cuadro.Rows[fila].Cells[6].Value = Math.Round(concepto.Importe, 2);
                    
                    descuentosNuevo += Math.Round(concepto.Importe, 2);
                    DescuentosTXT.Text = descuentosNuevo.ToString();
                }
            }
            EstrategiaCBX.Text = textoAnterior;


            TotalTXT.Text = (double.Parse(RemunerativoTXT.Text) + double.Parse(ExentoTXT.Text) - double.Parse(DescuentosTXT.Text)).ToString();
            double redondeo = (int)Math.Ceiling(decimal.Parse(TotalTXT.Text)) - double.Parse(TotalTXT.Text);
            RedondeoTXT.Text = (Math.Round(redondeo, 2)).ToString();

            if (CheckRedondeo.Checked) { TotalTXT.Text = (double.Parse(TotalTXT.Text) + redondeo).ToString(); }

            this.Cuadro.Sort(this.Cuadro.Columns["numero"], ListSortDirection.Ascending);

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
            try
            {
                n = e.RowIndex;
                if ((bool)Cuadro.Rows[n].Cells[0].Value == true)
                {
                    Cuadro.Rows[n].Cells[0].Value = false;
                    Cuadro.Rows[n].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    try
                    {
                        for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
                        {
                            Cuadro.Rows[fila].Cells[0].Value = false;
                            Cuadro.Rows[fila].DefaultCellStyle.BackColor = Color.White;
                        }
                        Cuadro.CurrentRow.DefaultCellStyle.BackColor = Color.Yellow;
                        Cuadro.CurrentRow.Cells[0].Value = true;
                    }
                    
                    catch (Exception) { }

                }

            }
            catch (Exception) { }
        }
    

        private void EliminarBTN_Click(object sender, EventArgs e)
        {
            try
            {

                for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
                {
                    if ((bool)Cuadro.Rows[fila].Cells[0].Value == true)
                    {
                        if(Cuadro.Rows[fila].Cells[4].Value != null)
                        {
                            RemunerativoTXT.Text = (double.Parse(RemunerativoTXT.Text) - (double)Cuadro.Rows[fila].Cells[4].Value).ToString();
                        }
                        if (Cuadro.Rows[fila].Cells[5].Value != null)
                        {
                            ExentoTXT.Text = (double.Parse(ExentoTXT.Text) - (double)Cuadro.Rows[fila].Cells[5].Value).ToString();
                        }
                        if (Cuadro.Rows[fila].Cells[6].Value != null)
                        {
                            DescuentosTXT.Text = (double.Parse(DescuentosTXT.Text) - (double)Cuadro.Rows[fila].Cells[6].Value).ToString();
                        }

                        Cuadro.Rows.RemoveAt(fila);
                        actualizarCuadro(); 
                        break;
                    }
                }


            }
            catch (Exception) { MessageBox.Show("No se pudo eliminar la fila"); }
        }
    

        ILiquidacion nuevaEstrategia;
        private void EstrategiaCBX_TextChanged(object sender, EventArgs e)
        {

            if (EstrategiaCBX.Text == "Por Dia") { nuevaEstrategia = new PorDia(); IngresaTBX.Visible = true;label4.Visible = true; IngresaTBX.Text = concepto.Cantidad.ToString(); }
            else if (EstrategiaCBX.Text == "Por Hora") { nuevaEstrategia = new PorHoras(); IngresaTBX.Visible = true; label4.Visible = true; IngresaTBX.Text = concepto.Cantidad.ToString(); }
            else if (EstrategiaCBX.Text == "Por Importe") { nuevaEstrategia = new PorImporte(); IngresaTBX.Visible = true; label4.Visible = true; concepto.Cantidad = 1; IngresaTBX.Text = concepto.Importe.ToString(); }
            else if (EstrategiaCBX.Text == "Por Porcentaje") { nuevaEstrategia = new PorPorcentaje(); IngresaTBX.Text = RemunerativoTXT.Text; IngresaTBX.Visible = false; label4.Visible = false; }
            else if (EstrategiaCBX.Text == "Por Antigüedad") { nuevaEstrategia = new PorAntigüedad(); IngresaTBX.Text = RemunerativoTXT.Text; IngresaTBX.Visible = false; label4.Visible = false; }
        }

        private void cambiarEstrategia(int opcion)
        {
            if (opcion == 1) { EstrategiaCBX.Text = "Por Dia"; }
            if (opcion == 2) { EstrategiaCBX.Text = "Por Hora"; nuevaEstrategia = new PorHoras(); }
            if (opcion == 3) { EstrategiaCBX.Text = "Por Importe";  nuevaEstrategia = new PorImporte(); }
            if (opcion == 4) { EstrategiaCBX.Text = "Por Antigüedad"; nuevaEstrategia = new PorAntigüedad(); }
            if (opcion == 6) { EstrategiaCBX.Text = "Por Porcentaje"; nuevaEstrategia = new PorPorcentaje(); }
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
                        EstrategiaCBX.Text = "";
                        cambiarEstrategia(concepto.Ingresa);
                        NumConceptoTBX.Text = concepto.Numero.ToString();
                        descripcionTBX.Text = concepto.Descripcion;
                    }

                }
            }
            else { MessageBox.Show("ingrese un numero de concepto"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cuadro.Rows.Clear();
            empleado = new Empleado();
            Empleado empleadoAuxiliar = Conexion.ObtenerEmpleado(LegajoTBX.Text);
            if (empleado != null)
            {
                LegajoTBX.Text = empleadoAuxiliar.legajo.ToString();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    }

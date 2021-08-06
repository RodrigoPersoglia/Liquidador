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
    public partial class obraSocial : Form
    {
        public obraSocial()
        {
            InitializeComponent();
        }

        private void obraSocial_Load(object sender, EventArgs e)
        {
            
            MySqlConnection conectar = Conexion.ObtenerConexion();
           // MySqlDataReader reader;
            conectar.Open();
            try
            {

                //completo el cuadro
                DataTable dt2 = Conexion.VerObraSocial();
                Cuadro.Rows.Clear();

                if (dt2 != null)
                {

                    foreach (DataRow x in dt2.Rows)
                    {
                        int n = Cuadro.Rows.Add();
                        Cuadro.Rows[n].Cells[0].Value = false;
                        Cuadro.Rows[n].Cells[1].Value = (int)x[0];
                        Cuadro.Rows[n].Cells[2].Value = (int)x[1];
                        Cuadro.Rows[n].Cells[3].Value = (string)x[2];
                        Cuadro.Rows[n].Cells[4].Value = (string)x[3];

                    }
                }

            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }
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
            if ( descripcionTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red  && NumTBX.Text != "" && abreviaturaTBX.Text != "")
            {
                try
                {
                   Conexion.AgregarObraSocial(int.Parse(NumTBX.Text), descripcionTBX.Text, abreviaturaTBX.Text);
                    Limpiar();
                    obraSocial_Load(sender, e);
                }
                
                catch (Exception) { MessageBox.Show("No se pudo agregar la categoría, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados");}
        }

        private void Limpiar()
        {
        
            NumTBX.Text = "";
            descripcionTBX.Text = "";
            abreviaturaTBX.Text = "";
        }

        private void ModificarBTN_Click(object sender, EventArgs e)
        {
            if ( descripcionTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red && NumTBX.Text != "" && abreviaturaTBX.Text != "")
            {
                try
                {
                    bool check = false;
                    for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
                    {
                        if ((bool)Cuadro.Rows[fila].Cells[0].Value == true)
                        {
                            check = true; break;
                        }
                    }

                    if (check == true)
                    {
                        Conexion.ModificarObraSocial((int)Cuadro.Rows[n].Cells[1].Value,int.Parse(NumTBX.Text),descripcionTBX.Text,abreviaturaTBX.Text);
                        Limpiar();
                        obraSocial_Load(sender, e);
                    }


                    else { MessageBox.Show("No hay ningun registro seleccionado"); }
                }
                catch (Exception) { MessageBox.Show("No se pudo modificar la categoría, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados"); }
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
                    Limpiar();
                    obraSocial_Load(sender, e);
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
                        Cuadro.Rows[n].Cells[0].Value = true;

                        NumTBX.Text = ((int)Cuadro.Rows[n].Cells[2].Value).ToString();
                        descripcionTBX.Text = (string)Cuadro.Rows[n].Cells[3].Value;
                        abreviaturaTBX.Text = (string)Cuadro.Rows[n].Cells[4].Value;


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
                bool check = false;
                for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
                {
                    if ((bool)Cuadro.Rows[fila].Cells[0].Value == true)
                    {
                        check = true; break;
                    }
                }

                if (check == true)
                {
                    Conexion.EliminarObraSocial((int)Cuadro.Rows[n].Cells[1].Value);
                    Limpiar();
                    obraSocial_Load(sender, e);
                }


                else { MessageBox.Show("No hay ningun registro seleccionado"); }
            }
            catch (Exception) { MessageBox.Show("No se pudo eliminar la categoría, revise los datos y reintente"); }
        }
    }
}

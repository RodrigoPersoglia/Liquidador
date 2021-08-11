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
    public partial class Convenio : Form
    {
        public Convenio()
        {
            InitializeComponent();
        }

        private void Convenio_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                //completo el cuadro
                DataTable dt2 = Conexion.VerConvenio();
                Cuadro.Rows.Clear();
                if (dt2 != null)
                {

                    foreach (DataRow x in dt2.Rows)
                    {
                        int n = Cuadro.Rows.Add();
                        Cuadro.Rows[n].Cells[0].Value = false;
                        Cuadro.Rows[n].Cells[1].Value = (int)x[0];
                        Cuadro.Rows[n].Cells[2].Value = (string)x[1];
                        Cuadro.Rows[n].Cells[3].Value = (string)x[2];
                        Cuadro.Rows[n].Cells[4].Value = (int)x[3];
                        Cuadro.Rows[n].Cells[5].Value = (int)x[4];

                    }
                }

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
                numero = int.Parse(NumTBX.Text);
                NumTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { NumTBX.ForeColor = System.Drawing.Color.Red; }
        }







        //private void telefonoTBX_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void CelularTBX_TextChanged(object sender, EventArgs e)
        //{


        //}


        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if ( CodigoTXT.Text!="" && descripcionTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red  && NumTBX.Text != "" && AñoTXT.ForeColor != System.Drawing.Color.Red && AñoTXT.Text!="")
            {
                try
                {
                  Conexion.AgregarConvenio(CodigoTXT.Text, descripcionTBX.Text, int.Parse(NumTBX.Text), int.Parse(AñoTXT.Text));
                    Limpiar();
                    Convenio_Load(sender, e);
                }
                
                catch (Exception) { MessageBox.Show("No se pudo agregar el convenio, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados");}
        }

        private void Limpiar()
        {
            AñoTXT.Text = "";
            NumTBX.Text = "";
            descripcionTBX.Text = "";
            CodigoTXT.Text = "";
        }

        private void ModificarBTN_Click(object sender, EventArgs e)
        {
            if (CodigoTXT.Text != "" && descripcionTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red && NumTBX.Text != "" && AñoTXT.ForeColor != System.Drawing.Color.Red && AñoTXT.Text != "")
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
                        Conexion.ModificarConvenio((int)Cuadro.Rows[n].Cells[1].Value, CodigoTXT.Text, descripcionTBX.Text, int.Parse(NumTBX.Text), int.Parse(AñoTXT.Text)); ;
                        Limpiar();
                        Convenio_Load(sender, e);
                    }


                    else { MessageBox.Show("No hay ningun registro seleccionado"); }
                }
                catch (Exception) { MessageBox.Show("No se pudo modificar la el convenio, revise los datos y reintente"); }
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
                    Convenio_Load(sender, e);
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
                        CodigoTXT.Text = (string)Cuadro.Rows[n].Cells[2].Value;
                        descripcionTBX.Text = (string)Cuadro.Rows[n].Cells[3].Value;
                        NumTBX.Text = ((int)Cuadro.Rows[n].Cells[4].Value).ToString();
                        AñoTXT.Text = ((int)Cuadro.Rows[n].Cells[5].Value).ToString();



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
                    Conexion.EliminarConvenio((int)Cuadro.Rows[n].Cells[1].Value);
                    Limpiar();
                    Convenio_Load(sender, e);
                }


                else { MessageBox.Show("No hay ningun registro seleccionado"); }
            }
            catch (Exception) { MessageBox.Show("No se pudo eliminar la categoría, revise los datos y reintente"); }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            BusquedaRapida selec = new BusquedaRapida("codigo","descripcion","Convenio");
            DialogResult resultado = selec.ShowDialog();
            int id = selec.IDBusqueda;
            Convenio_Load(sender, e);
            try
            {
                for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
                {
                    if ((int)Cuadro.Rows[fila].Cells[1].Value == id)
                    {
                        Cuadro.Rows[fila].DefaultCellStyle.BackColor = Color.Yellow;
                        Cuadro.Rows[fila].Cells[0].Value = true;
                        NumTBX.Text = ((int)Cuadro.Rows[fila].Cells[2].Value).ToString();
                        descripcionTBX.Text = (string)Cuadro.Rows[fila].Cells[3].Value;
                        CodigoTXT.Text = (string)Cuadro.Rows[fila].Cells[4].Value;
                        Cuadro.CurrentCell = Cuadro.Rows[fila].Cells[0];
                        n = fila;
                    }

                }



            }
            catch (Exception) { }
        }

        private void AñoTXT_TextChanged(object sender, EventArgs e)
        {
            int numero;
            try
            {
                numero = int.Parse(NumTBX.Text);
                AñoTXT.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { AñoTXT.ForeColor = System.Drawing.Color.Red; }

        }
    }
}

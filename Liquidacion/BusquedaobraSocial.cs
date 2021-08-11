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
    public partial class BusquedaobraSocial : Form
    {
        public BusquedaobraSocial()
        {
            InitializeComponent();
        }

        private Os dato = new Os();
         public Os Dato { get{ return this.dato; } }

        private void BusquedaobraSocial_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            MessageBox.Show((string)Cuadro.Rows[n].Cells[3].Value);
            dato.ID = int.Parse(Cuadro.Rows[n].Cells[1].Value.ToString());
            dato.Numero = int.Parse(Cuadro.Rows[n].Cells[2].Value.ToString());
            dato.Descripcion = Cuadro.Rows[n].Cells[3].Value.ToString();
            dato.Abreviatura = Cuadro.Rows[n].Cells[4].Value.ToString();
            this.Close();
        }

        private void Limpiar()
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
                    Buscar_Click(sender, e);
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

                        


                }
                catch (Exception) { }


            }

        }
            catch (Exception) { }
        }



        private void Buscar_Click(object sender, EventArgs e)
        {
            Cuadro.Rows.Clear();
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand(" BuscarObraSocial", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p1",descripcionTBX.Text);
                MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                adp.Fill(dt);

                foreach (DataRow x in dt.Rows)
                {
                    int n = Cuadro.Rows.Add();
                    Cuadro.Rows[n].Cells[0].Value = false;
                    Cuadro.Rows[n].Cells[1].Value = (int)x[0];
                    Cuadro.Rows[n].Cells[2].Value = (int)x[1];
                    Cuadro.Rows[n].Cells[3].Value = (string)x[2];
                    Cuadro.Rows[n].Cells[4].Value = (string)x[3];
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message);}
            finally { conectar.Close(); }
        }
    }
}

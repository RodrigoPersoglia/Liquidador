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
    public partial class Sucursal : Form
    {
        public Sucursal()
        {
            InitializeComponent();
        }

        private void Sucursal_Load(object sender, EventArgs e)
        {
            ProvinciaCBX.Text = "Seleccione";
            MySqlConnection conectar = Conexion.ObtenerConexion();
            // MySqlDataReader reader;
            conectar.Open();
            try
            {

                //completo el cuadro
                DataTable dt2 = Conexion.VerSucursales();
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
                        Cuadro.Rows[n].Cells[5].Value = (string)x[4];
                        Cuadro.Rows[n].Cells[6].Value = (string)x[5];
                        Cuadro.Rows[n].Cells[7].Value = (string)x[6];
                        Cuadro.Rows[n].Cells[8].Value = (string)x[7];

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



        private void cuil2TBX_TextChanged(object sender, EventArgs e)
        {


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
            if (ProvinciaCBX.Text != "Seleccione" && nombreTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red  && NumTBX.Text != "" && direccionTBX.Text != "" && LocalidadTBX.Text!="" && ProvinciaCBX.Text != "" && Telefono1TBX.Text!="" && Telefono2TBX.Text != "")
            {
                try
                {
                    Conexion.AgregarSucursal(int.Parse(NumTBX.Text),nombreTBX.Text,direccionTBX.Text,LocalidadTBX.Text,ProvinciaCBX.Text,Telefono1TBX.Text,Telefono2TBX.Text);
                    Limpiar();
                    Sucursal_Load(sender, e);
                }
                catch (Exception) { MessageBox.Show("No se pudo agregar la sucursal, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados"); }
        }

        private void Limpiar()
        {
            NumTBX.Text = "";
            nombreTBX.Text = "";
            direccionTBX.Text = "";
            LocalidadTBX.Text = "";
            ProvinciaCBX.Text = "Seleccione";
            Telefono1TBX.Text = "";
            Telefono2TBX.Text = "";

        }

        private void ModificarBTN_Click(object sender, EventArgs e)
        {
            if (ProvinciaCBX.Text != "Seleccione" && nombreTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red && NumTBX.Text != "" && direccionTBX.Text != "" && LocalidadTBX.Text != "" && ProvinciaCBX.Text != "" && Telefono1TBX.Text != "" && Telefono2TBX.Text != "")
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
                        Conexion.ModificarSucursal((int)Cuadro.Rows[n].Cells[1].Value, int.Parse(NumTBX.Text), nombreTBX.Text, direccionTBX.Text, LocalidadTBX.Text, ProvinciaCBX.Text, Telefono1TBX.Text, Telefono2TBX.Text);
                        Limpiar();
                        Sucursal_Load(sender, e);
                    }


                    else { MessageBox.Show("No hay ningun registro seleccionado"); }
                }
                catch (Exception) { MessageBox.Show("No se pudo modificar la sucursal, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados"); }
        }

    

        private void TipoContratoCBX_SelectionChangeCommitted(object sender, EventArgs e)
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
                    Limpiar();
                    TipoContratoCBX_SelectionChangeCommitted(sender, e);
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
                        nombreTBX.Text = (string)Cuadro.Rows[n].Cells[3].Value;
                        direccionTBX.Text = (string)Cuadro.Rows[n].Cells[4].Value;
                        LocalidadTBX.Text = (string)Cuadro.Rows[n].Cells[5].Value;
                        ProvinciaCBX.Text = (string)Cuadro.Rows[n].Cells[6].Value;
                        Telefono1TBX.Text = (string)Cuadro.Rows[n].Cells[7].Value;
                        Telefono2TBX.Text = (string)Cuadro.Rows[n].Cells[8].Value;



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
                    Conexion.EliminarSucursal((int)Cuadro.Rows[n].Cells[1].Value);
                    Limpiar();
                    Sucursal_Load(sender, e);
                }


                else { MessageBox.Show("No hay ningun registro seleccionado"); }
            }
            catch (Exception) { MessageBox.Show("No se pudo eliminar la sucursal, revise los datos y reintente"); }
        }




        private void TipoContratoCBX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

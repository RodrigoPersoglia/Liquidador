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
    public partial class Empresa : Form
    {
        public Empresa()
        {
            InitializeComponent();
        }

        private void Empresa_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                DataTable dt2 = Conexion.VerEmpresa();
                if (dt2 != null)
                {

                    foreach (DataRow x in dt2.Rows)
                    {
                        IDTBX.Text = ((int)x[0]).ToString();
                        razonSocialTBX.Text = (string)x[1];
                        direccionTBX.Text = (string)x[2];
                        LocalidadTBX.Text = (string)x[3];
                        ProvinciaCBX.Text = (string)x[4];
                        CPTBX.Text = (string)x[5];
                        cuil1TBX.Text = ((int)x[6]).ToString();
                        cuil2TBX.Text = ((int)x[7]).ToString();
                        cuil3TBX.Text = ((int)x[8]).ToString();
                        RubroTBX.Text = (string)x[9];
                        InicioActividadDTP.Value = (DateTime)x[10];
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





        private void ModificarBTN_Click(object sender, EventArgs e)
        {
            if (ProvinciaCBX.Text != "Seleccione" && razonSocialTBX.Text != "" && cuil1TBX.ForeColor != System.Drawing.Color.Red && cuil1TBX.Text != "" && cuil2TBX.ForeColor != System.Drawing.Color.Red && cuil2TBX.Text != "" && cuil3TBX.ForeColor != System.Drawing.Color.Red && cuil3TBX.Text != "" && direccionTBX.Text != "" && LocalidadTBX.Text != "" && ProvinciaCBX.Text != "" && CPTBX.Text != "" && RubroTBX.Text != "")
            {
                try
                {
                    Conexion.ModificarEmpresa(int.Parse(IDTBX.Text), razonSocialTBX.Text, direccionTBX.Text, LocalidadTBX.Text, ProvinciaCBX.Text, CPTBX.Text, int.Parse(cuil1TBX.Text), int.Parse(cuil2TBX.Text), int.Parse(cuil3TBX.Text), RubroTBX.Text, InicioActividadDTP.Value);
                    Empresa_Load(sender, e);
                }
                catch (Exception) { MessageBox.Show("No se pudo guardar, revise los datos y reintente"); }

            }

            else { MessageBox.Show("Revise los campos ingresados"); }
        }



        private void TipoContratoCBX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CancelarBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void cuil1TBX_TextChanged(object sender, EventArgs e)
        {
            int numero;
            try
            {
                numero = int.Parse(cuil1TBX.Text);
                cuil1TBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { cuil1TBX.ForeColor = System.Drawing.Color.Red; }

        }

        private void cuil2TBX_TextChanged(object sender, EventArgs e)
        {
            int numero;
            try
            {
                numero = int.Parse(cuil2TBX.Text);
                cuil2TBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { cuil2TBX.ForeColor = System.Drawing.Color.Red; }

        }

        private void cuil3TBX_TextChanged(object sender, EventArgs e)
        {
            int numero;
            try
            {
                numero = int.Parse(cuil3TBX.Text);
                cuil3TBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { cuil3TBX.ForeColor = System.Drawing.Color.Red; }
        }
    }
}

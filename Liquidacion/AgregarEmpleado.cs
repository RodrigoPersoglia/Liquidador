using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liquidacion
{
    public partial class AgregarEmpleado : Form
    {
        public AgregarEmpleado()
        {
            InitializeComponent();
        }

        private void AgregarEmpleado_Load(object sender, EventArgs e)
        {

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
                numero = int.Parse(NumDocTBX.Text);
                NumDocTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { NumDocTBX.ForeColor = System.Drawing.Color.Red; }
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

        private void telefonoTBX_TextChanged(object sender, EventArgs e)
        {

        }

        private void CelularTBX_TextChanged(object sender, EventArgs e)
        {


        }

        private void meseAnterioresTBX_TextChanged(object sender, EventArgs e)
        {
            int numero;
            try
            {
                numero = int.Parse(meseAnterioresTBX.Text);
                meseAnterioresTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { meseAnterioresTBX.ForeColor = System.Drawing.Color.Red; }
        }
    }
}

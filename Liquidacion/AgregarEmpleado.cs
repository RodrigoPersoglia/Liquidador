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
    public partial class AgregarEmpleado : Form
    {
        public AgregarEmpleado()
        {
            InitializeComponent();
        }

        private void AgregarEmpleado_Load(object sender, EventArgs e)
        {
            tipoDocCBX.Text = "DNI";
            ProvinciaCBX.Text = "Seleccione";
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();


            //COMBOBOX CONVENIO
            try
            {
                ConvenioCBX.DataSource = null;
                ConvenioCBX.Items.Clear();
                DataTable dt = Conexion.VerConvenio();
                if (dt != null)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["convenio"] = "Seleccione";
                    dt.Rows.InsertAt(newRow, 0);
                    ConvenioCBX.DataSource = dt;
                    ConvenioCBX.DisplayMember = "convenio";
                    ConvenioCBX.ValueMember = "ID";
                }
            }
            catch (Exception) { }


            // COMBOBOX TURNO
            MySqlDataReader reader;
            string consulta = "Select ID,descripcion From turno a order by a.descripcion";
            try
            {
                turnoCBX.DataSource = null;
                turnoCBX.Items.Clear();
                MySqlCommand comand = new MySqlCommand(consulta, conectar);
                reader = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow newRow = dt.NewRow();
                newRow["descripcion"] = "Seleccione";
                dt.Rows.InsertAt(newRow, 0);
                turnoCBX.DataSource = dt;
                turnoCBX.DisplayMember = "descripcion";
                turnoCBX.ValueMember = "ID";
            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }


            // COMBOBOX OBRA SOCIAL
            string consulta2 = "Select ID,concat(numero,' - ',abreviatura) as descripcion From obrasocial a order by a.numero";
            try
            {
                MySqlCommand comand = new MySqlCommand(consulta2, conectar);
                reader = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow newRow = dt.NewRow();
                newRow["descripcion"] = "Seleccione";
                dt.Rows.InsertAt(newRow, 0);
                obraSocialCBX.DataSource = dt;
                obraSocialCBX.DisplayMember = "descripcion";
                obraSocialCBX.ValueMember = "ID";

            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }


            // COMBOBOX SUCURSAL
            string consulta3 = "Select ID,concat(numero,' - ',nombre) as descripcion From sucursal a order by a.numero";
            try
            {
                MySqlCommand comand = new MySqlCommand(consulta3, conectar);
                reader = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow newRow = dt.NewRow();
                newRow["descripcion"] = "Seleccione";
                dt.Rows.InsertAt(newRow, 0);
                sucursalCBX.DataSource = dt;
                sucursalCBX.DisplayMember = "descripcion";
                sucursalCBX.ValueMember = "ID";

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
                numero = int.Parse(NumDocTBX.Text);
                NumDocTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { NumDocTBX.ForeColor = System.Drawing.Color.Red; }
        }

        private void cuil1TBX_TextChanged(object sender, EventArgs e)
        {
            //Controla que el texto ingresado sea un INT, sino cambia el color de la fuente a Rojo
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
            //Controla que el texto ingresado sea un INT, sino cambia el color de la fuente a Rojo
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
            //Controla que el texto ingresado sea un INT, sino cambia el color de la fuente a Rojo
            int numero;
            try
            {
                numero = int.Parse(cuil3TBX.Text);
                cuil3TBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { cuil3TBX.ForeColor = System.Drawing.Color.Red; }
        }



        private void meseAnterioresTBX_TextChanged(object sender, EventArgs e)
        {
            //Controla que el texto ingresado sea un INT, sino cambia el color de la fuente a Rojo
            int numero;
            try
            {
                numero = int.Parse(meseAnterioresTBX.Text);
                meseAnterioresTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { meseAnterioresTBX.ForeColor = System.Drawing.Color.Red; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Habilita o deshabilita el textbox de Sueldo acordado
            if (checkBox1.Checked == true) { SueldoAcordadoTBX.Enabled = false; }
            else { SueldoAcordadoTBX.Enabled = true; }
        }

        private void SueldoAcordadoTBX_TextChanged(object sender, EventArgs e)
        {
            //Controla que el texto ingresado sea un double, sino cambia el color de la fuente a Rojo
            double numero;
            try
            {
                numero = double.Parse(SueldoAcordadoTBX.Text);
                SueldoAcordadoTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { SueldoAcordadoTBX.ForeColor = System.Drawing.Color.Red; }

        }

        private void ConvenioCBX_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Habilita el combobox de TipoContrato en cascada cuando se seleccione una opcion del ConvenioCBX
            try
            {
                int numero = (int)ConvenioCBX.SelectedValue;
                string consulta5 = "select id, concat(numero,' - ', descripcion) as descripcion from tipocontrato tc where tc.convenio_ID=" + numero.ToString() + " order by tc.numero";
                MySqlConnection conectar = Conexion.ObtenerConexion();
                MySqlDataReader reader;
                conectar.Open();
                try
                {
                    categoriaCBX.DataSource = null;
                    MySqlCommand comand = new MySqlCommand(consulta5, conectar);
                    
                    reader = comand.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    DataRow newRow = dt.NewRow();
                    newRow["descripcion"] = "Seleccione";
                    dt.Rows.InsertAt(newRow,0);
                    tipoContratoCBX.DataSource = dt;
                    tipoContratoCBX.DisplayMember = "descripcion";
                    tipoContratoCBX.ValueMember = "ID";
                }
                catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }
                finally{ conectar.Close();}
            }
            catch (Exception) {
                tipoContratoCBX.DataSource = null;
                categoriaCBX.DataSource = null;
            }
        }

        private void tipoContratoCBX_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Habilita el combobox de Categoria en cascada cuando se seleccione una opcion del TipoContratoCBX
            try
            {
                
                int numero = (int)tipoContratoCBX.SelectedValue;
                MySqlConnection conectar = Conexion.ObtenerConexion();
                MySqlDataReader reader;
                conectar.Open();
                string consulta5 = "select id, concat(numero,' - ', descripcion) as descripcion from categoria tc where tc.tipoContrato_ID=" + numero.ToString() + " order by tc.numero";
                try
                {
                    MySqlCommand comand = new MySqlCommand(consulta5, conectar);
                    reader = comand.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    DataRow newRow = dt.NewRow();
                    newRow["descripcion"] = "Seleccione";
                    dt.Rows.InsertAt(newRow, 0);
                    categoriaCBX.DataSource = dt;
                    categoriaCBX.DisplayMember = "descripcion";
                    categoriaCBX.ValueMember = "ID";
                }
                catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }
                finally { conectar.Close(); }
            }
            catch (Exception)
            {
                categoriaCBX.DataSource = null;
            }

        }

        private void Limpiar()
        {
            nombreTBX.Text = "";
            apellidoTBX.Text = "";
            cuil1TBX.Text = "";
            cuil2TBX.Text = "";
            cuil3TBX.Text = "";
            direccionTBX.Text = "";
            LocalidadTBX.Text = "";
            ProvinciaCBX.Text = "Seleccione";
            fechaNacDTP.Value = DateTime.Today;
            fechaIngresoDTP.Value = DateTime.Today;
            telefonoTBX.Text = "";
            CelularTBX.Text = "";
            legajoTBX.Text = "";
            meseAnterioresTBX.Text = "0";
            obraSocialCBX.Text = "Seleccione";
            turnoCBX.Text = "Seleccione";
            sucursalCBX.Text = "Seleccione";
            ConvenioCBX.Text = "Seleccione";
            tipoContratoCBX.DataSource = null; tipoContratoCBX.Items.Clear();
            categoriaCBX.DataSource = null; categoriaCBX.Items.Clear();
            checkBox1.Checked = true;
            SueldoAcordadoTBX.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            MySqlDataReader reader;
            conectar.Open();
            decimal Acordado = 0;
            if (checkBox1.Checked == false && SueldoAcordadoTBX.Text!="" && SueldoAcordadoTBX.ForeColor!= Color.Red) { Acordado = decimal.Parse(SueldoAcordadoTBX.Text); }
            try
            {
                if (legajoTBX.ForeColor != Color.Red && legajoTBX.Text != "" && nombreTBX.Text != "" && apellidoTBX.Text != "" && NumDocTBX.ForeColor != Color.Red && NumDocTBX.Text != ""
                    && cuil1TBX.ForeColor != Color.Red && cuil1TBX.Text != "" && cuil2TBX.ForeColor != Color.Red && cuil2TBX.Text != "" && cuil3TBX.ForeColor != Color.Red && cuil3TBX.Text != "" && direccionTBX.Text != "" && LocalidadTBX.Text != ""
                    && ProvinciaCBX.Text != "Seleccione" && telefonoTBX.Text != "" && CelularTBX.Text != ""
                    && meseAnterioresTBX.ForeColor != Color.Red && meseAnterioresTBX.Text != "" && tipoContratoCBX.Text != "" && categoriaCBX.Text != ""
                    && turnoCBX.Text != "Seleccione" && obraSocialCBX.Text != "Seleccione" && tipoContratoCBX.Text != "Seleccione" && categoriaCBX.Text != "Seleccione" && sucursalCBX.Text != "Seleccione" && ConvenioCBX.Text != "Seleccione"
                    )
                {


                    string consulta5 = "select * from empleado e where e.legajo=" + legajoTBX.Text + " or e.numeroDNI=" + NumDocTBX.Text;
                    MySqlCommand comand = new MySqlCommand(consulta5, conectar);
                    reader = comand.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    if (dt.Rows.Count > 0)
                    {
                        throw new ExisteException();
                    }


                    Conexion.AgregarEmpleado(int.Parse(legajoTBX.Text), nombreTBX.Text, apellidoTBX.Text, tipoDocCBX.Text, int.Parse(NumDocTBX.Text),
                        int.Parse(cuil1TBX.Text), int.Parse(cuil2TBX.Text), int.Parse(cuil3TBX.Text), direccionTBX.Text, LocalidadTBX.Text, ProvinciaCBX.Text,
                        fechaNacDTP.Value, telefonoTBX.Text, CelularTBX.Text, fechaIngresoDTP.Value, int.Parse(meseAnterioresTBX.Text), true, Acordado,
                        (int)turnoCBX.SelectedValue, (int)obraSocialCBX.SelectedValue, (int)tipoContratoCBX.SelectedValue, (int)categoriaCBX.SelectedValue, (int)sucursalCBX.SelectedValue, (int)ConvenioCBX.SelectedValue);

                    Limpiar();

                }
                else { MessageBox.Show("Revise los datos ingresados"); }
            }
            catch (ExisteException) { MessageBox.Show("El numero de legajo o dni ingresados ya existen"); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally {conectar.Close(); }
        }

        private void legajoTBX_TextChanged(object sender, EventArgs e)
        {
            //Controla que el texto ingresado sea un INT, sino cambia el color de la fuente a Rojo
            int numero;
            try
            {
                numero = int.Parse(legajoTBX.Text);
                legajoTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { legajoTBX.ForeColor = System.Drawing.Color.Red; }

        }
    }
}

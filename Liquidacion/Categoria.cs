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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            
            conectar.Open();

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



        private void cuil2TBX_TextChanged(object sender, EventArgs e)
        {
            double numero;
            try
            {
                numero = double.Parse(importeTBX.Text);
                importeTBX.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception) { importeTBX.ForeColor = System.Drawing.Color.Red; }

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
            if (ConvenioCBX.Text!="Seleccione" && TipoContratoCBX.Text != "Seleccione" && descripcionTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red && importeTBX.ForeColor != System.Drawing.Color.Red && NumTBX.Text != "" && importeTBX.Text != "")
            {
                try
                {
                    Conexion.AgregarCategoria(int.Parse(NumTBX.Text), descripcionTBX.Text, decimal.Parse(importeTBX.Text), (int)TipoContratoCBX.SelectedValue,(int)ConvenioCBX.SelectedValue);
                    Limpiar();
                    TipoContratoCBX_SelectionChangeCommitted(sender, e);
                }
                catch (Exception) { MessageBox.Show("No se pudo agregar la categoría, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados");}
        }

        private void Limpiar()
        {
            NumTBX.Text = "";
            descripcionTBX.Text = "";
            importeTBX.Text = "";
        }

        private void ModificarBTN_Click(object sender, EventArgs e)
        {
            if (ConvenioCBX.Text != "Seleccione" && TipoContratoCBX.Text != "Seleccione" && descripcionTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red && importeTBX.ForeColor != System.Drawing.Color.Red && NumTBX.Text != "" && importeTBX.Text != "")
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
                        Conexion.ModificarCategoria((int)Cuadro.Rows[n].Cells[1].Value,int.Parse(NumTBX.Text),descripcionTBX.Text,decimal.Parse(importeTBX.Text), (int)ConvenioCBX.SelectedValue);
                        Limpiar();
                        TipoContratoCBX_SelectionChangeCommitted(sender, e);
                    }


                    else { MessageBox.Show("No hay ningun registro seleccionado"); }
                }
                catch (Exception) { MessageBox.Show("No se pudo modificar la categoría, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados"); }
        }

    

        private void TipoContratoCBX_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //completo el cuadro
            DataTable dt2 = Conexion.VerCategoria((int)TipoContratoCBX.SelectedValue);
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
                    Cuadro.Rows[n].Cells[4].Value = (decimal)x[3];

                }
            }
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
                        descripcionTBX.Text = (string)Cuadro.Rows[n].Cells[3].Value;
                        importeTBX.Text = ((decimal)Cuadro.Rows[n].Cells[4].Value).ToString();


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
                    Conexion.EliminarCategoria((int)Cuadro.Rows[n].Cells[1].Value);
                    Limpiar();
                    TipoContratoCBX_SelectionChangeCommitted(sender, e);
                }


                else { MessageBox.Show("No hay ningun registro seleccionado"); }
            }
            catch (Exception) { MessageBox.Show("No se pudo eliminar la categoría, revise los datos y reintente"); }
        }

        private void ConvenioCBX_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cuadro.Rows.Clear();
           try
            {
                int numero = (int)ConvenioCBX.SelectedValue;
                string consulta5 = "select id, concat(numero,' - ', descripcion) as descripcion from tipocontrato tc where tc.convenio_ID=" + numero.ToString() + " order by tc.numero";
                MySqlConnection conectar = Conexion.ObtenerConexion();
                MySqlDataReader reader;
                conectar.Open();
                try
                {
                    MySqlCommand comand = new MySqlCommand(consulta5, conectar);
                    reader = comand.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    DataRow newRow = dt.NewRow();
                    newRow["descripcion"] = "Seleccione";
                    dt.Rows.InsertAt(newRow, 0);
                    TipoContratoCBX.DataSource = dt;
                    TipoContratoCBX.DisplayMember = "descripcion";
                    TipoContratoCBX.ValueMember = "ID";
                }
                catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }
                finally { conectar.Close(); }
            }
            catch (Exception) { Limpiar(); TipoContratoCBX.DataSource = null; }
        }
    }
}

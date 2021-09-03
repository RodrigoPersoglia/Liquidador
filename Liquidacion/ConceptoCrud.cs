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
    public partial class ConceptoCrud : Form
    {
        public ConceptoCrud()
        {
            InitializeComponent();
        }

        private void Concepto_Load(object sender, EventArgs e)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            //COMBOBOX DE CONVENIO
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

            // COMBOBOX TIPO CONTRATO
            MySqlDataReader reader;
            string consulta = "Select ID,descripcion From tipoConcepto a order by a.ID";
            try
            {
                TipoConceptoCBX.DataSource = null;
                TipoConceptoCBX.Items.Clear();
                MySqlCommand comand = new MySqlCommand(consulta, conectar);
                reader = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow newRow = dt.NewRow();
                newRow["descripcion"] = "Seleccione";
                dt.Rows.InsertAt(newRow, 0);
                TipoConceptoCBX.DataSource = dt;
                TipoConceptoCBX.DisplayMember = "descripcion";
                TipoConceptoCBX.ValueMember = "ID";
            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }

            // COMBOBOX INGRESA
            reader=null;
            consulta = "Select ID,descripcion From ingresa a order by a.id";
            try
            {
                IngresaCBX.DataSource = null;
                IngresaCBX.Items.Clear();
                MySqlCommand comand = new MySqlCommand(consulta, conectar);
                reader = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow newRow = dt.NewRow();
                newRow["descripcion"] = "Seleccione";
                dt.Rows.InsertAt(newRow, 0);
                IngresaCBX.DataSource = dt;
                IngresaCBX.DisplayMember = "descripcion";
                IngresaCBX.ValueMember = "ID";
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
            if (descripcionTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red && NumTBX.Text != "" && TipoContratoCBX.DataSource!=null && TipoContratoCBX.Text!="Seleccione" && TipoConceptoCBX.Text != "Seleccione" && IngresaCBX.Text != "Seleccione")
            {
                try
                {
                    Conexion.AgregarConcepto(int.Parse(NumTBX.Text),descripcionTBX.Text,decimal.ToInt32(CantidadNumeric.Value),importeNumeric.Value,FactorNumeric.Value,(int)TipoConceptoCBX.SelectedValue,(int)IngresaCBX.SelectedValue,(int)TipoContratoCBX.SelectedValue);
                    TipoContratoCBX_SelectionChangeCommitted(sender, e);
                }

                catch (Exception) { MessageBox.Show("No se pudo agregar el concepto, revise los datos y reintente"); }
            }
            else { MessageBox.Show("Revise los campos ingresados"); }
        }

        private void Limpiar()
        {
        
            NumTBX.Text = "";
            descripcionTBX.Text = "";
            CantidadNumeric.Value = 0;
            importeNumeric.Value = 0;
            FactorNumeric.Value = 1;
            TipoConceptoCBX.Text = "Seleccione";
            IngresaCBX.Text = "Seleccione";
           
        }

        private void ModificarBTN_Click(object sender, EventArgs e)
        {
            if (descripcionTBX.Text != "" && NumTBX.ForeColor != System.Drawing.Color.Red && NumTBX.Text != "" && TipoContratoCBX.DataSource != null && TipoContratoCBX.Text != "Seleccione" && TipoConceptoCBX.Text != "Seleccione" && IngresaCBX.Text != "Seleccione")
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
                        Conexion.ModificarConcepto((int)Cuadro.Rows[n].Cells[1].Value, int.Parse(NumTBX.Text), descripcionTBX.Text, decimal.ToInt32(CantidadNumeric.Value), importeNumeric.Value, FactorNumeric.Value, (int)TipoConceptoCBX.SelectedValue, (int)IngresaCBX.SelectedValue, (int)TipoContratoCBX.SelectedValue);
                        TipoContratoCBX_SelectionChangeCommitted(sender, e);
                    }


                    else { MessageBox.Show("No hay ningun registro seleccionado"); }
                }
                catch (Exception) { MessageBox.Show("No se pudo modificar el concepto, revise los datos y reintente"); }
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
                        CantidadNumeric.Value = (int)Cuadro.Rows[n].Cells[4].Value;
                        importeNumeric.Value = (decimal)Cuadro.Rows[n].Cells[5].Value;
                        FactorNumeric.Value = (decimal)Cuadro.Rows[n].Cells[6].Value;
                        TipoConceptoCBX.SelectedValue = (int)Cuadro.Rows[n].Cells[7].Value;
                        IngresaCBX.SelectedValue = (int)Cuadro.Rows[n].Cells[8].Value;



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
                    Conexion.EliminarConcepto((int)Cuadro.Rows[n].Cells[1].Value);

                    TipoContratoCBX_SelectionChangeCommitted(sender, e);
                }


                else { MessageBox.Show("No hay ningun registro seleccionado"); }
            }
            catch (Exception) { MessageBox.Show("No se pudo eliminar el concepto, revise los datos y reintente"); }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (TipoContratoCBX.Text != "Seleccione" && TipoContratoCBX.DataSource!=null)
            {
                BusquedaRapida selec = new BusquedaRapida("numero", "descripcion", "Conceptos", "t.tipoContrato_ID=",(int)TipoContratoCBX.SelectedValue);
                DialogResult resultado = selec.ShowDialog();
                int id = selec.IDBusqueda;
                try
                {
                    for (int fila = 0; fila < Cuadro.Rows.Count; fila++)
                    {
                        if ((int)Cuadro.Rows[fila].Cells[1].Value == id)
                        {
                            n = fila;
                            Cuadro.Rows[fila].DefaultCellStyle.BackColor = Color.Yellow;
                            Cuadro.Rows[fila].Cells[0].Value = true;
                            Cuadro.Rows[n].Cells[0].Value = true;
                            NumTBX.Text = ((int)Cuadro.Rows[n].Cells[2].Value).ToString();
                            descripcionTBX.Text = (string)Cuadro.Rows[n].Cells[3].Value;
                            CantidadNumeric.Value = (int)Cuadro.Rows[n].Cells[4].Value;
                            importeNumeric.Value = (decimal)Cuadro.Rows[n].Cells[5].Value;
                            FactorNumeric.Value = (decimal)Cuadro.Rows[n].Cells[6].Value;
                            TipoConceptoCBX.SelectedValue = (int)Cuadro.Rows[n].Cells[7].Value;
                            IngresaCBX.SelectedValue = (int)Cuadro.Rows[n].Cells[8].Value;
                            Cuadro.CurrentCell = Cuadro.Rows[fila].Cells[0];

                        }

                    }



                }
                catch (Exception) { }
            }
            else { MessageBox.Show("Seleccione un tipo de contrato"); }
        }

        private void IngresaCBX_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void ValorCBX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(IngresaCBX.Text == "Seleccione") { detalleTBX.Text = ""; }
                int valor = (int)IngresaCBX.SelectedValue;
                string consultaNueva = "select x.formula from ingresa x where x.id=" + valor.ToString();
                MySqlConnection conectar = Conexion.ObtenerConexion();
                conectar.Open();
                DataTable dt = new DataTable();
                try
                {
                    MySqlCommand comand = new MySqlCommand(consultaNueva, conectar);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                    adp.Fill(dt);
                    if (dt.Rows.Count == 0) { }
                    else
                    {
                        foreach (DataRow x in dt.Rows)
                        {

                            detalleTBX.Text = (string)x[0];
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); }
                finally { conectar.Close(); }
            }
            catch (Exception)
            { }

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

        private void TipoContratoCBX_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Limpiar();
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                int id = (int)TipoContratoCBX.SelectedValue;
                //completo el cuadro
                DataTable dt2 = Conexion.VerConcepto(id);
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
                        Cuadro.Rows[n].Cells[4].Value = (int)x[3];
                        Cuadro.Rows[n].Cells[5].Value = (decimal)x[4];
                        Cuadro.Rows[n].Cells[6].Value = (decimal)x[5];
                        Cuadro.Rows[n].Cells[7].Value = (int)x[6];
                        Cuadro.Rows[n].Cells[8].Value = (int)x[7];
                        Cuadro.Rows[n].Cells[9].Value = (int)x[8];
                        Cuadro.Rows[n].Cells[10].Value = (string)x[9];
                        Cuadro.Rows[n].Cells[11].Value = (string)x[10];

                    }
                }

            }
            catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); }
            finally { conectar.Close();}
        }
    }
}

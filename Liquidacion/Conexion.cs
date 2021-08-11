using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.NetworkInformation;

namespace Liquidacion
{
	/// <summary>
	/// Description of Conexion.
	/// </summary>
	public class Conexion
	{

		
		public static MySqlConnection ObtenerConexion()
		{
			try
			{
				//string LocalHost = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();

				MySqlConnection Conexion = new MySqlConnection("Server=192.168.0.45;database=liquidacion;Uid=cuaquierUsuario;pwd=;");

				return Conexion;
			}
			catch (Exception) { MessageBox.Show("No se pudo establecer la conexion con la base de datos");return null; }


		}


        public static void AgregarCategoria(int numero, string descripcion, decimal importe, int tipoContrato,int convenio_ID)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("AgregarCategoria", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p1", numero);
                comand.Parameters.AddWithValue("@p2", descripcion);
                comand.Parameters.AddWithValue("@p3", importe);
                comand.Parameters.AddWithValue("@p4", tipoContrato);
                comand.Parameters.AddWithValue("@p5", convenio_ID);


                comand.ExecuteNonQuery();
                MessageBox.Show("Categoria Agregada");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }

        public static void ModificarCategoria(int ID,int numero, string descripcion, decimal importe, int convenio_id)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("modificarCategoria", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);
                comand.Parameters.AddWithValue("@p1", numero);
                comand.Parameters.AddWithValue("@p2", descripcion);
                comand.Parameters.AddWithValue("@p3", importe);
                comand.Parameters.AddWithValue("@p4", convenio_id);




                comand.ExecuteNonQuery();
                MessageBox.Show("Categoria Modificada");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }

        public static void EliminarCategoria(int ID)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("eliminarCategoria", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);


                comand.ExecuteNonQuery();
                MessageBox.Show("Categoria Eliminada");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }


        public static DataTable VerCategoria(int tipoContrato)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand(" verCategoria", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p1", tipoContrato);
                MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else { MessageBox.Show("No hay categorías ingresadas "); return null; }

            }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
            finally { conectar.Close(); }
        }

        public static DataTable VerObraSocial()
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand(" verObraSocial", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else { MessageBox.Show("No hay obras sociales ingresadas "); return null; }

            }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
            finally { conectar.Close(); }
        }



        public static void AgregarObraSocial(int numero, string descripcion, string abreviatura)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("AgregarObraSocial", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p1", numero);
                comand.Parameters.AddWithValue("@p2", descripcion);
                comand.Parameters.AddWithValue("@p3", abreviatura);
                comand.ExecuteNonQuery();
                MessageBox.Show("Obra Social Agregada");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }


        public static void ModificarObraSocial(int ID, int numero, string descripcion, string abreviatura)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("modificarObraSocial", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);
                comand.Parameters.AddWithValue("@p1", numero);
                comand.Parameters.AddWithValue("@p2", descripcion);
                comand.Parameters.AddWithValue("@p3", abreviatura);




                comand.ExecuteNonQuery();
                MessageBox.Show("Obra Social Modificada");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }


        public static void EliminarObraSocial(int ID)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("eliminarObraSocial", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);


                comand.ExecuteNonQuery();
                MessageBox.Show("Obra Social Eliminada");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }


        public static DataTable VerTurno()
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand(" verTurno", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else { MessageBox.Show("No hay turnos ingresados "); return null; }

            }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
            finally { conectar.Close(); }
        }



        public static void AgregarTurno(string descripcion, string horaInicio, string horaFin)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("agregarTurno", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p1", descripcion);
                comand.Parameters.AddWithValue("@p2", horaInicio);
                comand.Parameters.AddWithValue("@p3", horaFin);
                comand.ExecuteNonQuery();
                MessageBox.Show("Turno Agregado");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }


        public static void ModificarTurno(int ID, string descripcion, string horaInicio, string horaFin)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("modificarTurno", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);
                comand.Parameters.AddWithValue("@p1", descripcion);
                comand.Parameters.AddWithValue("@p2", horaInicio);
                comand.Parameters.AddWithValue("@p3", horaFin);




                comand.ExecuteNonQuery();
                MessageBox.Show("Turno Modificado");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }


        public static void EliminarTurno(int ID)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("eliminarTurno", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);


                comand.ExecuteNonQuery();
                MessageBox.Show("Turno Eliminado");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }



        public static DataTable VerSucursales()
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand(" verSucursales", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else { MessageBox.Show("No hay turnos ingresados "); return null; }

            }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
            finally { conectar.Close(); }
        }


        public static void AgregarSucursal(int numero, string nombre, string direccion, string Localidad, string provincia, string telefono1,string telefono2)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("agregarSucursal", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p1", numero);
                comand.Parameters.AddWithValue("@p2", nombre);
                comand.Parameters.AddWithValue("@p3", direccion);
                comand.Parameters.AddWithValue("@p4", Localidad);
                comand.Parameters.AddWithValue("@p5", provincia);
                comand.Parameters.AddWithValue("@p6", telefono1);
                comand.Parameters.AddWithValue("@p7", telefono2);

                comand.ExecuteNonQuery();
                MessageBox.Show("Sucursal Agregada");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }

        public static void ModificarSucursal(int ID,int numero, string nombre, string direccion, string Localidad, string provincia, string telefono1, string telefono2)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("modificarSucursal", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);
                comand.Parameters.AddWithValue("@p1", numero);
                comand.Parameters.AddWithValue("@p2", nombre);
                comand.Parameters.AddWithValue("@p3", direccion);
                comand.Parameters.AddWithValue("@p4", Localidad);
                comand.Parameters.AddWithValue("@p5", provincia);
                comand.Parameters.AddWithValue("@p6", telefono1);
                comand.Parameters.AddWithValue("@p7", telefono2);
                comand.ExecuteNonQuery();
                MessageBox.Show("Sucursal Modificada");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }

        public static void EliminarSucursal(int ID)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("eliminarSucursal", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);


                comand.ExecuteNonQuery();
                MessageBox.Show("Sucursal Eliminada");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }



        public static void ModificarEmpresa(int ID, string razonSocial, string direccion, string Localidad, string provincia, string cp, int cuit1, int cuit2, int cuit3, string rubro,DateTime inicioActividades)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("modificarEmpresa", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);
                comand.Parameters.AddWithValue("@p1", razonSocial);
                comand.Parameters.AddWithValue("@p2", direccion);
                comand.Parameters.AddWithValue("@p3", Localidad);
                comand.Parameters.AddWithValue("@p4", provincia);
                comand.Parameters.AddWithValue("@p5", cp);
                comand.Parameters.AddWithValue("@p6", cuit1);
                comand.Parameters.AddWithValue("@p7", cuit2);
                comand.Parameters.AddWithValue("@p8", cuit3);
                comand.Parameters.AddWithValue("@p9", rubro);
                comand.Parameters.AddWithValue("@p10", inicioActividades);
                comand.ExecuteNonQuery();
                MessageBox.Show("Datos Guardados");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }


        public static DataTable VerEmpresa()
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand("verEmpresa", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else { MessageBox.Show("No hay datos ingresados "); return null; }

            }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
            finally { conectar.Close(); }
        }

        public static DataTable VerConvenio()
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand comand = new MySqlCommand(" VerConvenio", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter adp = new MySqlDataAdapter(comand);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else { MessageBox.Show("No hay convenios ingresados "); return null; }

            }
            catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
            finally { conectar.Close(); }
        }

        public static void AgregarConvenio(string codigo,string descripcion, int numero, int año)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("AgregarConvenio", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p1", codigo);
                comand.Parameters.AddWithValue("@p2", descripcion);
                comand.Parameters.AddWithValue("@p3", numero);
                comand.Parameters.AddWithValue("@p4", año);
                comand.ExecuteNonQuery();
                MessageBox.Show("Convenio Agregado");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }

        public static void ModificarConvenio(int ID, string codigo, string descripcion, int numero, int año)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("ModificarConvenio", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);
                comand.Parameters.AddWithValue("@p1", codigo);
                comand.Parameters.AddWithValue("@p2", descripcion);
                comand.Parameters.AddWithValue("@p3", numero);
                comand.Parameters.AddWithValue("@p4", año);
                comand.ExecuteNonQuery();
                MessageBox.Show("Convenio Modificado");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }

        public static void EliminarConvenio(int ID)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("EliminarConvenio", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", ID);


                comand.ExecuteNonQuery();
                MessageBox.Show("Convenio Eliminado");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }




        //public static Cliente ObtenerCliente(string busqueda)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //          try
        //          {
        //              MySqlCommand comand = new MySqlCommand("ObtenerCliente", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p1", busqueda);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count == 1)
        //		{
        //			Cliente cliente = new Cliente();
        //			foreach (DataRow x in dt.Rows)
        //			{
        //				cliente.ID = (int)x[0];
        //			cliente.Numero = (int)x[1];
        //			cliente.Alias = (string)x[2];

        //			if (x[3] != null)
        //			{
        //				try { cliente.RazonSocial = (string)x[3];}
        //				catch (Exception) { }
        //			}

        //			if (x[4] != null)
        //			{
        //				try { cliente.Cuit = (int)x[4]; }
        //				catch (Exception) { }
        //			}

        //			if (x[5] != null)
        //			{
        //				try { cliente.Telefono1 = (string)x[5]; }
        //				catch (Exception) { }
        //			}

        //			if (x[6] != null)
        //			{
        //				try { cliente.Telefono2 = (string)x[6]; }
        //				catch (Exception) { }
        //			}


        //			cliente.IDDireccion = (int)x[7];
        //			cliente.Direccion = (string)x[8];
        //			cliente.Ciudad = (string)x[9];
        //			cliente.Provincia = (string)x[10];
        //			cliente.CP = (string)x[11];

        //			cliente.IDDireccion2 = (int)x[12];
        //			cliente.Direccion2 = (string)x[13];
        //			cliente.Ciudad2 = (string)x[14];
        //			cliente.Provincia2 = (string)x[15];
        //			cliente.CP2 = (string)x[16];

        //			cliente.IVA = (string)x[17];
        //			cliente.TIPODOC = (string)x[18];



        //		}
        //			return cliente;
        //		}
        //		else { 
        //			VentanaSeleccion2 selec = new VentanaSeleccion2(busqueda);
        //			DialogResult resultado = selec.ShowDialog();
        //			return selec.ClienteSeleccionado; }

        //      }
        //          catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
        //          finally { conectar.Close(); }
        //      }





        //      public static bool ExisteArticulo(string busqueda)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	MySqlDataReader reader;
        //	// Hago la consulta a la base de datos
        //	string consulta = "SELECT a.codigo FROM articulo a";
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand(consulta, conectar);
        //		reader = comand.ExecuteReader();
        //		if (reader.HasRows)
        //		{
        //			while (reader.Read())
        //			{
        //				if (busqueda == reader.GetString(0)) { return true; }

        //			}
        //		}
        //		return false;
        //	}

        //	catch (MySqlException ex) { MessageBox.Show("Error al buscar " + ex.Message); return false; }
        //	finally {conectar.Close(); }

        //}

        //public static Pedido ObtenerPedido(string busqueda)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("consultaPedidos", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@parametro1", busqueda);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if(dt.Rows.Count == 1)
        //		{
        //			Pedido pedido = new Pedido();
        //			foreach (DataRow x in dt.Rows)
        //			{
        //				pedido.ID = (int)x[0];
        //				pedido.Numero = (int)x[1];
        //				pedido.Fecha = (DateTime)x[2];
        //                  try { pedido.KgEstimados = (double)x[3]; }
        //			catch (Exception) { pedido.KgEstimados = 0; }
        //				pedido.OrdenCompra = (string)x[4];
        //				pedido.Observaciones = (string)x[5];
        //				pedido.Cliente = (string)x[6];
        //				pedido.Articulo = (string)x[7];
        //				pedido.Unidad = (string)x[8];
        //				pedido.Terminacion = (string)x[9];
        //				pedido.Estado = (string)x[10];
        //				pedido.Prioridad = (string)x[11];
        //				pedido.Aleacion = (string)x[12];
        //				pedido.Temple = (string)x[13];
        //				pedido.Codigo_Articulo = x[17].ToString();
        //				pedido.Matriz = (int)x[18];
        //			}
        //			return pedido;
        //		}
        //		else{MessageBox.Show("El numero ingresado no corresponde a un pedido");return null;}

        //	}
        //	catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
        //	finally { conectar.Close(); }

        //}

        //public static DataTable ObtenerDetallepedido(string busqueda)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("consultaPedidoDetalle", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@parametro1", busqueda);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count>0)
        //		{

        //			return dt;
        //		}
        //		else { MessageBox.Show("El numero de pedido ingresado no tiene detalle"); return null; }

        //	}
        //	catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
        //	finally { conectar.Close(); }

        //}

        //public static void EliminarDetalle(string ID_Pedido)
        //      {
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("eliminardetalle", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@parametro1", ID_Pedido);
        //		comand.ExecuteNonQuery();

        //	}
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }
        //}

        //public static void ModificarPedido(int ID_Pedido,int numero,string fecha,double kgEstimados, string oc,string observaciones,int cliente,int articulo,int unidad, int terminacion, int prioridad,int aleacion,int temple)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("eliminardetalle", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p1", ID_Pedido);
        //		comand.Parameters.AddWithValue("@p2", numero);
        //		comand.Parameters.AddWithValue("@p3", fecha);
        //		comand.Parameters.AddWithValue("@p4", kgEstimados);
        //		comand.Parameters.AddWithValue("@p5", oc);
        //		comand.Parameters.AddWithValue("@p6", observaciones);
        //		comand.Parameters.AddWithValue("@p7", cliente);
        //		comand.Parameters.AddWithValue("@p8", articulo);
        //		comand.Parameters.AddWithValue("@p9", unidad);
        //		comand.Parameters.AddWithValue("@p10", terminacion);
        //		comand.Parameters.AddWithValue("@p11", prioridad);
        //		comand.Parameters.AddWithValue("@p12", aleacion);
        //		comand.Parameters.AddWithValue("@p13", temple);
        //		comand.ExecuteNonQuery();
        //		MessageBox.Show("Pedido modificado");
        //	}
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }
        //}



        //public static DataTable VerMatriz(string busqueda)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("verMatriz", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@parametro1", busqueda);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count >0)
        //		{
        //			return dt;
        //		}
        //		else { MessageBox.Show("El codigo ingresado no tiene matrices asociadas"); return null; }

        //	}
        //	catch (Exception ex) { MessageBox.Show("Error al buscar matriz " + ex.Message); return null; }
        //	finally { conectar.Close(); }
        //}


        //public static Matriz ObtenerMatriz(int busqueda)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //          try
        //          {
        //              MySqlCommand comand = new MySqlCommand("ObtenerMatriz", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@parametro1", busqueda);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count == 1)
        //		{
        //			Matriz matriz = new Matriz();
        //			foreach (DataRow x in dt.Rows)
        //			{

        //                      matriz.ID = (int)x[0];
        //                      matriz.Leyenda = (string)x[1];
        //                      matriz.Ejemplar = (int)x[2];
        //                      matriz.Salidas = (int)x[3];
        //                      matriz.Peso = decimal.ToDouble((decimal)x[4]);
        //                      matriz.Codigo = (string)x[5];
        //                      matriz.Estado = (string)x[6];
        //				matriz.Propietario = (int)x[7];
        //				matriz.KgAcumulados = (int)x[8];

        //			}
        //			return matriz;
        //		}
        //		else { MessageBox.Show("El numero ingresado no corresponde a un pedido"); return null; }

        //          }
        //          catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
        //          finally { conectar.Close(); }

        //      }

        //public static string VerEstado(string busqueda)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("verEstado", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p1", busqueda);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count == 1)
        //		{
        //			string estado = "";
        //			foreach (DataRow x in dt.Rows)
        //			{

        //				//matriz.ID = (int)x[0];
        //				estado = (string)x[1];

        //			}
        //			return estado;
        //		}
        //		else { MessageBox.Show("El numero ingresado no corresponde a un pedido"); return null; }

        //	}
        //	catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
        //	finally { conectar.Close(); }

        //}


        //public static void ModificarEstado(string numPedido,int EstadoID)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("modificarEstado", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p1", numPedido);
        //		comand.Parameters.AddWithValue("@p2", EstadoID);
        //		comand.ExecuteNonQuery();
        //		MessageBox.Show("Pedido modificado");
        //	}
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }
        //}






        //public static void EliminarLocalidad(string localidad)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("eliminarLocalidad", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p1", localidad);
        //		comand.ExecuteNonQuery();
        //		MessageBox.Show("Localidad Eliminada");

        //	}
        //	catch (MySqlException) { MessageBox.Show("No se puede eliminar una Localidad que registre actividad"); }
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }
        //}




        //public static void CrearCliente(string dirFisc,int provFisc,string CodPosFis,string dirEnt, int provEnt, string CodPosEnt,int numero,string Alias,string RazonSocial,long cuit,string tel1,string tel2,int tipoDoc,int IVA)
        //{
        //	int dirF = 0;
        //	int dirE = 0;
        //	DataTable dt = new DataTable();
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("guardarDireccion", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p1", dirFisc);
        //		comand.Parameters.AddWithValue("@p2", provFisc);
        //		comand.Parameters.AddWithValue("@p3", CodPosFis);
        //		comand.ExecuteNonQuery();

        //		MySqlCommand comand2 = new MySqlCommand("guardarDireccion", conectar);
        //		comand2.CommandType = CommandType.StoredProcedure;
        //		comand2.Parameters.AddWithValue("@p1", dirEnt);
        //		comand2.Parameters.AddWithValue("@p2", provEnt);
        //		comand2.Parameters.AddWithValue("@p3", CodPosEnt);
        //		comand2.ExecuteNonQuery();


        //		MySqlCommand comand3 = new MySqlCommand("UltimasDirecciones", conectar);
        //		comand3.CommandType = CommandType.StoredProcedure;
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand3);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count == 2)
        //		{
        //			int contador = 0;
        //			foreach (DataRow x in dt.Rows)
        //			{

        //				if (contador == 0)
        //				{
        //					dirE = (int)x[0];
        //				}
        //				else { dirF = (int)x[0]; }
        //				contador++;
        //			}
        //		}


        //		MySqlCommand comand4 = new MySqlCommand("CrearCliente", conectar);
        //              comand4.CommandType = CommandType.StoredProcedure;
        //		comand4.Parameters.AddWithValue("@p1", numero);
        //		comand4.Parameters.AddWithValue("@p2", Alias);
        //		comand4.Parameters.AddWithValue("@p3", RazonSocial);
        //		comand4.Parameters.AddWithValue("@p4", cuit);
        //		comand4.Parameters.AddWithValue("@p5", tel1);
        //		comand4.Parameters.AddWithValue("@p6", tel2);
        //		comand4.Parameters.AddWithValue("@p7", dirF);
        //		comand4.Parameters.AddWithValue("@p8", dirE);
        //		comand4.Parameters.AddWithValue("@p9", tipoDoc);
        //		comand4.Parameters.AddWithValue("@p10", IVA);
        //		comand4.ExecuteNonQuery();

        //                  MessageBox.Show("Cliente Creado correctamente");
        //	}
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }
        //}




        //public static void AgregarDetallePedido(DateTime fecha, string horaInicio, string horaFin, double kgs, int tiras, string largoPerfil, double pesoMetro, string colada, string observaciones, int largoTocho, int cantidadTochos, int matriz_ID, int puesto_ID, int pedido_ID, int turno_ID, int Aleacion_ID,  int Kg)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("AgregarDetalleFabricacion", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@fecha", fecha);
        //		comand.Parameters.AddWithValue("@horaInicio", horaInicio);
        //		comand.Parameters.AddWithValue("@horaFin", horaFin);
        //		comand.Parameters.AddWithValue("@kgs", kgs);
        //		comand.Parameters.AddWithValue("@tiras", tiras);
        //		comand.Parameters.AddWithValue("@largoPerfil", largoPerfil);
        //		comand.Parameters.AddWithValue("@pesoMetro", pesoMetro);
        //		comand.Parameters.AddWithValue("@colada", colada);
        //		comand.Parameters.AddWithValue("@observaciones", observaciones);
        //		comand.Parameters.AddWithValue("@largoTocho", largoTocho);
        //		comand.Parameters.AddWithValue("@cantidadTochos", cantidadTochos);
        //		comand.Parameters.AddWithValue("@matriz_ID", matriz_ID);
        //		comand.Parameters.AddWithValue("@puesto_ID", puesto_ID);
        //		comand.Parameters.AddWithValue("@pedido_ID", pedido_ID);
        //		comand.Parameters.AddWithValue("@turno_ID", turno_ID);
        //		comand.Parameters.AddWithValue("@Aleacion_ID", Aleacion_ID);
        //		comand.Parameters.AddWithValue("@kg_acumulados", Kg);

        //		comand.ExecuteNonQuery();
        //		MessageBox.Show("Detalle de fabricación guardado");
        //	}
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }

        //}



        //public static void ModificarCliente(int clienteID,int numero, string alias, string razonSocial, int cuit, string tel1, string tel2, int tipoDoc, int iva, string calleNumero, int LocalidadID, string codigoPostal,string  calleNumero2, int localidadID2, string codigoPostal2)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("ModificarCliente", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p0", clienteID);
        //		comand.Parameters.AddWithValue("@p1", numero);
        //		comand.Parameters.AddWithValue("@p2", alias);
        //		comand.Parameters.AddWithValue("@p3", razonSocial);
        //		comand.Parameters.AddWithValue("@p4", cuit);
        //		comand.Parameters.AddWithValue("@p5", tel1);
        //		comand.Parameters.AddWithValue("@p6", tel2);
        //		comand.Parameters.AddWithValue("@p7", tipoDoc);
        //		comand.Parameters.AddWithValue("@p8", iva);

        //		comand.Parameters.AddWithValue("@p9", calleNumero);
        //		comand.Parameters.AddWithValue("@p10", LocalidadID);
        //		comand.Parameters.AddWithValue("@p11", codigoPostal);

        //		comand.Parameters.AddWithValue("@p12", calleNumero2);
        //		comand.Parameters.AddWithValue("@p13", localidadID2);
        //		comand.Parameters.AddWithValue("@p14", codigoPostal2);

        //		comand.ExecuteNonQuery();
        //		MessageBox.Show("Cliente modificado");
        //	}
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }
        //}




        //public static Articulo ObtenerArticulo(string buscar, Form formulario)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //          try
        //          {
        //              MySqlCommand comand = new MySqlCommand("BuscarArticulo", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@busqueda", buscar);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count == 1)
        //		{
        //			Articulo articulo = new Articulo();
        //			foreach (DataRow x in dt.Rows)
        //			{

        //				articulo.ID = (int)x[0];
        //				articulo.Codigo = (string)x[1];
        //				articulo.Descripcion = (string)x[2];
        //				articulo.PesoNominal = decimal.ToDouble((decimal)x[3]);
        //				articulo.Tolerancia = (int)x[4];
        //				articulo.Multiplo = (int)x[5];

        //				articulo.Aleacion = (string)x[7];
        //				articulo.Temple = (string)x[8];
        //				articulo.Clasificacion = (string)x[9];
        //				articulo.Topologia = (string)x[10];
        //				articulo.Cliente = (string)x[11];
        //				articulo.Precio = decimal.ToDouble((decimal)x[12]);

        //			}
        //			return articulo;
        //		}
        //		else {
        //			SeleccionArticulo selec = new SeleccionArticulo(buscar);
        //			selec.ShowDialog();
        //			selec.Dispose();
        //			return selec.ArticuloSeleccionado;
        //		}

        //      }
        //	catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
        //	finally { conectar.Close(); }


        //}



        //public static void ModificarMatriz(int ID, int salidas, double peso, int cliente, int estado , int  kgAcumulados)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("ModificarMatriz", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p1", ID);
        //		comand.Parameters.AddWithValue("@p2", salidas);
        //		comand.Parameters.AddWithValue("@p3", peso);
        //		comand.Parameters.AddWithValue("@p4", cliente);
        //		comand.Parameters.AddWithValue("@p5", estado);
        //		comand.Parameters.AddWithValue("@p6", kgAcumulados);

        //		comand.ExecuteNonQuery();
        //		MessageBox.Show("Matriz modificada");
        //	}
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }
        //}



        //public static DataTable ObtenerProyeccion (DateTime fecha)
        //      {
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("proyeccion", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p1", fecha);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count > 0)
        //		{

        //			return dt;
        //		}
        //		else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

        //	}

        //	catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
        //	finally { conectar.Close(); }
        //}


        //public static DataTable ObtenerProyeccion2(DateTime fecha)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("proyeccion2", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		comand.Parameters.AddWithValue("@p1", fecha);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count > 0)
        //		{

        //			return dt;
        //		}
        //		else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

        //	}

        //	catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
        //	finally { conectar.Close(); }
        //}




        //public static void ModificarDetallePedido(int idDetalle,DateTime fecha, string horaInicio, string horaFin, double kgs, int tiras, string largoPerfil, double pesoMetro, string colada, string observaciones, int largoTocho, int cantidadTochos, int matriz_ID, int puesto_ID, int turno_ID, int Aleacion_ID,double kgs_Anteriores)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("ModificarDetalleFabricacion", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;

        //		comand.Parameters.AddWithValue("@p0", idDetalle);
        //		comand.Parameters.AddWithValue("@p1", pesoMetro);
        //		comand.Parameters.AddWithValue("@p2", fecha);
        //		comand.Parameters.AddWithValue("@p3", horaInicio);
        //		comand.Parameters.AddWithValue("@p4", horaFin);
        //		comand.Parameters.AddWithValue("@p5", puesto_ID);
        //		comand.Parameters.AddWithValue("@p6", turno_ID);
        //		comand.Parameters.AddWithValue("@p7", Aleacion_ID);
        //		comand.Parameters.AddWithValue("@p8", colada);
        //		comand.Parameters.AddWithValue("@p9", largoTocho);
        //		comand.Parameters.AddWithValue("@p10", cantidadTochos);
        //		comand.Parameters.AddWithValue("@p11", kgs);
        //		comand.Parameters.AddWithValue("@p12", tiras);
        //		comand.Parameters.AddWithValue("@p13", largoPerfil);
        //		comand.Parameters.AddWithValue("@p14", observaciones);
        //		comand.Parameters.AddWithValue("@p15", matriz_ID);
        //		comand.Parameters.AddWithValue("@p16", kgs_Anteriores);

        //		comand.ExecuteNonQuery();
        //		MessageBox.Show("Detalle de fabricación modificado");
        //	}
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }

        //}


        //public static void EliminarDetallePedido(int idDetalle, int matriz_ID, double kgs_Anteriores)
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("EliminarDetalleFabricacion", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;

        //		comand.Parameters.AddWithValue("@p0", idDetalle);
        //		comand.Parameters.AddWithValue("@p2", matriz_ID);
        //		comand.Parameters.AddWithValue("@p1", kgs_Anteriores);

        //		comand.ExecuteNonQuery();
        //		MessageBox.Show("Detalle de fabricación eliminado");
        //	}
        //	catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        //	finally { conectar.Close(); }

        //}


        //public static DataTable EnProduccion()
        //{
        //	MySqlConnection conectar = Conexion.ObtenerConexion();
        //	conectar.Open();
        //	DataTable dt = new DataTable();
        //	try
        //	{
        //		MySqlCommand comand = new MySqlCommand("EnProduccion", conectar);
        //		comand.CommandType = CommandType.StoredProcedure;
        //		//comand.Parameters.AddWithValue("@p1", fecha);
        //		MySqlDataAdapter adp = new MySqlDataAdapter(comand);
        //		adp.Fill(dt);
        //		if (dt.Rows.Count > 0)
        //		{

        //			return dt;
        //		}
        //		else { MessageBox.Show("No hay registros en el intervalo seleccionado"); return null; }

        //	}

        //	catch (Exception ex) { MessageBox.Show("Error al buscar " + ex.Message); return null; }
        //	finally { conectar.Close(); }
        //}


    }
}
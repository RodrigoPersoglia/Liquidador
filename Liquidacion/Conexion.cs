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


        public static void AgregarEmpleado(int legajo,string nombre,string apellido,string tipoDNI,int DNI,
            int cuit1,int cuit2,int cuit3,string direccion,string localidad,
            string provincia,DateTime fechaNacimiento,string telefono,string celular,DateTime fechaIngreso,
            int mesesAnteriores,bool activo,decimal sueldoAcordado,int turnoID,
            int obraSocialID,int tipoContratoID,int categoriaID,int sucursalID,int convenioID)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("AgregarEmpleado", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p1", legajo);
                comand.Parameters.AddWithValue("@p2", nombre);
                comand.Parameters.AddWithValue("@p3", apellido);
                comand.Parameters.AddWithValue("@p4", tipoDNI);
                comand.Parameters.AddWithValue("@p5", DNI);
                comand.Parameters.AddWithValue("@p6", cuit1);
                comand.Parameters.AddWithValue("@p7", cuit2);
                comand.Parameters.AddWithValue("@p8", cuit3);
                comand.Parameters.AddWithValue("@p9", direccion);
                comand.Parameters.AddWithValue("@p10", localidad);
                comand.Parameters.AddWithValue("@p11", provincia);
                comand.Parameters.AddWithValue("@p12", fechaNacimiento);
                comand.Parameters.AddWithValue("@p13", telefono);
                comand.Parameters.AddWithValue("@p14", celular);
                comand.Parameters.AddWithValue("@p15", fechaIngreso);
                comand.Parameters.AddWithValue("@p16", mesesAnteriores);
                comand.Parameters.AddWithValue("@p17", activo);
                //comand.Parameters.AddWithValue("@p18", fechaBaja);
                comand.Parameters.AddWithValue("@p18", null);
                comand.Parameters.AddWithValue("@p19", sueldoAcordado);
                comand.Parameters.AddWithValue("@p20", turnoID);
                comand.Parameters.AddWithValue("@p21", obraSocialID);
                comand.Parameters.AddWithValue("@p22", tipoContratoID);
                comand.Parameters.AddWithValue("@p23", categoriaID);
                comand.Parameters.AddWithValue("@p24", sucursalID);
                comand.Parameters.AddWithValue("@p25", convenioID);

                comand.ExecuteNonQuery();
                MessageBox.Show("Empleado Agregado");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }


        public static void ModificarEmpleado(int id,int legajo, string nombre, string apellido, string tipoDNI, int DNI,
           int cuit1, int cuit2, int cuit3, string direccion, string localidad,
           string provincia, DateTime fechaNacimiento, string telefono, string celular, DateTime fechaIngreso,
           int mesesAnteriores, bool activo, decimal sueldoAcordado, int turnoID,
           int obraSocialID, int tipoContratoID, int categoriaID, int sucursalID, int convenioID)
        {
            MySqlConnection conectar = Conexion.ObtenerConexion();
            conectar.Open();
            try
            {
                MySqlCommand comand = new MySqlCommand("ModificarEmpleado", conectar);
                comand.CommandType = CommandType.StoredProcedure;
                comand.Parameters.AddWithValue("@p0", id);
                comand.Parameters.AddWithValue("@p1", legajo);
                comand.Parameters.AddWithValue("@p2", nombre);
                comand.Parameters.AddWithValue("@p3", apellido);
                comand.Parameters.AddWithValue("@p4", tipoDNI);
                comand.Parameters.AddWithValue("@p5", DNI);
                comand.Parameters.AddWithValue("@p6", cuit1);
                comand.Parameters.AddWithValue("@p7", cuit2);
                comand.Parameters.AddWithValue("@p8", cuit3);
                comand.Parameters.AddWithValue("@p9", direccion);
                comand.Parameters.AddWithValue("@p10", localidad);
                comand.Parameters.AddWithValue("@p11", provincia);
                comand.Parameters.AddWithValue("@p12", fechaNacimiento);
                comand.Parameters.AddWithValue("@p13", telefono);
                comand.Parameters.AddWithValue("@p14", celular);
                comand.Parameters.AddWithValue("@p15", fechaIngreso);
                comand.Parameters.AddWithValue("@p16", mesesAnteriores);
                comand.Parameters.AddWithValue("@p17", activo);
                //comand.Parameters.AddWithValue("@p18", fechaBaja);
                comand.Parameters.AddWithValue("@p18", null);
                comand.Parameters.AddWithValue("@p19", sueldoAcordado);
                comand.Parameters.AddWithValue("@p20", turnoID);
                comand.Parameters.AddWithValue("@p21", obraSocialID);
                comand.Parameters.AddWithValue("@p22", tipoContratoID);
                comand.Parameters.AddWithValue("@p23", categoriaID);
                comand.Parameters.AddWithValue("@p24", sucursalID);
                comand.Parameters.AddWithValue("@p25", convenioID);

                comand.ExecuteNonQuery();
                MessageBox.Show("Datos del empleado actualizados");
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
            finally { conectar.Close(); }
        }






    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Controlador
{
    public class ConexionBD
    {
        public SqlDataReader lector { get; set; }
        public SqlConnection conexion { get; set; }
        public SqlCommand comando { get; set; }

        public ConexionBD()
        {
            conexion = new SqlConnection("Data Source = DESKTOP-D0QDMRI; Initial Catalog = VILLALTA_DB; Integrated Security = True");
            comando = new SqlCommand();
            comando.Connection = conexion;
        }

        public void setearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearStoreProcedure(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public string obtenerUltimoIdUser() 
        {
            string consulta = "SELECT TOP 1 IdUsuario FROM USUARIO ORDER BY IdUsuario DESC";
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            conexion.Open();
            string ulti = Convert.ToString(cmd.ExecuteScalar());
            conexion.Close();
            return ulti;  
        }

        public void ejecutarLector()
        {
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //conexion.Close();         
            }
        }

        public void cerrarConexion()
        {
            conexion.Close();
        }

/*internal*/public void ejecutarAccion()
        {
            try
            {
                conexion.Open();  
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cerrarConexion();
            }
        }
    }
}

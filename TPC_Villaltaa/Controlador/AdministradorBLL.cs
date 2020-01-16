using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class AdministradorBLL
    {
        public void agregarAdmin(Administrador admin)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string ulti = datos.obtenerUltimoIdUser();

                datos.setearQuery("INSERT INTO ADMINISTRADOR (IdUsuario_A, Estado) VALUES ('" + ulti + "', @Estado)");

                datos.agregarParametro("@Estado", admin.Estado);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Int16 obtenerIdUsuario_A()
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT IdUsuario_P FROM PROFESIONAL";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                //cmd.Parameters.AddWithValue("@Id", id);

                Int16 IdUsuarioA = Convert.ToInt16(cmd.ExecuteScalar());

                return IdUsuarioA;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

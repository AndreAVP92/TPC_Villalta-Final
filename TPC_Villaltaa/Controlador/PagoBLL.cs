using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class PagoBLL
    {
        public List<Pago> listarPago()
        {
            List<Pago> lista = new List<Pago>();
            Pago aux;

            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("SELECT* FROM PAGO WHERE Estado = 1");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Pago();

                    aux.IdPago = (Int32)datos.lector["IdPago"];
                    aux.DescripcionP = datos.lector.GetString(1);
                    aux.Estado = datos.lector.GetBoolean(2);

                    lista.Add(aux);
                }
                return lista;
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

        public void agregaPago(Pago pago)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO PAGO (Descripcion_P, Estado) VALUES (@Descripcion_P, @Estado)");

                datos.agregarParametro("@Descripcion_P", pago.DescripcionP);
                datos.agregarParametro("@Estado", pago.Estado);

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

        public void editarPago(Pago pago)
        {
            ConexionBD datos = new ConexionBD();
 
            try
            {
                datos.setearQuery("UPDATE PAGO SET Descripcion_P=@Descripcion, Estado=@Estado WHERE IdPago= @Id");
                datos.agregarParametro("@Descripcion", pago.DescripcionP);
                datos.agregarParametro("@Estado", pago.Estado);
                datos.agregarParametro("@Id", pago.IdPago);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarPago(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM PAGO WHERE IdPago =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerNombrePago(int id)
        {
            ConexionBD datos = new ConexionBD();
            
            try
            {
                string consulta = "SELECT Descripcion_P FROM PAGO WHERE IdPago = @Id";

                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                string descripcion = Convert.ToString(cmd.ExecuteScalar());

                return descripcion;
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

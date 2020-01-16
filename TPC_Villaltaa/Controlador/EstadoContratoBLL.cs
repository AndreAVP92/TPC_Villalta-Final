using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class EstadoContratoBLL
    {
        public List<EstadoContrato> listarEstadosContrato()
        {   
            List<EstadoContrato> lista = new List<EstadoContrato>();     
            //EstadoContrato aux;     
            
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("SELECT* FROM ESTADO_CONTRATO  WHERE Estado = 1");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    EstadoContrato aux = new EstadoContrato();

                    aux.IdEstadoContrato = (int)datos.lector["IdEstadoContrato"];
                    aux.Descripcion = datos.lector.GetString(1);
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

        public void agregarEstadoContrato(EstadoContrato estadoContrato)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO ESTADO_CONTRATO (Descripcion_EC, Estado) VALUES (@Descripcion_EC, @Estado)");

                datos.agregarParametro("@Descripcion_EC", estadoContrato.Descripcion);
                datos.agregarParametro("@Estado", estadoContrato.Estado);

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

        public void editarEstadoContrato(EstadoContrato ec)
        {
            ConexionBD datos = new ConexionBD();
           
            try
            {
                datos.setearQuery("UPDATE ESTADO_CONTRATO SET Descripcion_EC = @Desc WHERE IdEstadoContrato=@Id");
                datos.agregarParametro("@Desc", ec.Descripcion);
                datos.agregarParametro("@Id", ec.IdEstadoContrato);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarEstadoContrato(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM ESTADO_CONTRATO WHERE IdEstadoContrato =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 obtenerIdEstadoContrato(string descripcion)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT IdEstadoContrato FROM ESTADO_CONTRATO WHERE Descripcion_EC = @Descripcion";

                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                Int32 IdEC = Convert.ToInt32(cmd.ExecuteScalar());

                return IdEC;
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

        public string obtenerNombreEstadoContrato(int id)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT Descripcion_EC FROM ESTADO_CONTRATO WHERE IdEstadoContrato = @Id";

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

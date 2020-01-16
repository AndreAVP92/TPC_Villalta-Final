using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class RubroBLL
    {
        public List<Rubro> listarRubros()
        {
            List<Rubro> lista = new List<Rubro>();
            Rubro aux;

            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("SELECT r.IdRubro, r.Descripcion_R, r.Estado FROM RUBRO AS r WHERE r.Estado = 1");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Rubro();

                    aux.IdRubro = datos.lector.GetInt32(0);
                    aux.DescripcionR = datos.lector.GetString(1);
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
                //datos = null;
            }
        }

        public string ContarRubros()
        {
            ConexionBD datos = new ConexionBD();
 
            string contador = "SELECT COUNT(*) FROM RUBRO";
            datos.agregarParametro(contador, datos.conexion);
            datos.conexion.Open();
            contador = Convert.ToString(datos.comando.ExecuteScalar());
            datos.cerrarConexion();
 
            return contador;
        }

        public void agregarRubro(Rubro rubro)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO RUBRO (Descripcion_R, Estado) VALUES (@Descripcion_R, @Estado)");

                datos.agregarParametro("@Descripcion_R", rubro.DescripcionR);
                datos.agregarParametro("@Estado", rubro.Estado);

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

        public void editarRubro(Rubro rubro)
        {
            ConexionBD datos = new ConexionBD();
            //Rubro rubro = new Rubro();
            try
            {
                datos.setearQuery("UPDATE RUBRO SET Descripcion_R=@Descripcion Where IdRubro= @Id");
                datos.agregarParametro("@Descripcion", rubro.DescripcionR);
                datos.agregarParametro("@Id", rubro.IdRubro);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarRubro(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM RUBRO WHERE IdRubro =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///FUNCIONES EXTRAS
        public string obtenerNombreRubro(Int32 id)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT Descripcion_R FROM RUBRO WHERE IdRubro = @Id";

                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                string nombre = Convert.ToString(cmd.ExecuteScalar());

                return nombre;
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

        public int obtenerIdRubro (string descripcion)
        {
            ConexionBD datos = new ConexionBD();
            string consulta = "SELECT IdRubro FROM RUBRO WHERE Descripcion_R = @descripcion";
            try
            {
                datos.conexion.Open();
                
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                int IdRubro = Convert.ToInt32(cmd.ExecuteScalar());
                return IdRubro;
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
        
        //public int obtenerIdRubroxProfesional(Int64 IdProf)
        //{
        //    ConexionBD datos = new ConexionBD();

        //    try
        //    {
        //        string consulta = "SELECT IdRubro_RP FROM RUBROxPROFESIONAL WHERE IdProfesional_RP = @IdProfesional";

        //        datos.conexion.Open();
        //        SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
        //        cmd.Parameters.AddWithValue("@IdProfesional", IdProf);

        //        int IdRubro = Convert.ToInt32(cmd.ExecuteScalar());

        //        return IdRubro;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class SubRubroBLL
    {
        public List<SubRubro> listarSubRubros()
        {
            List<SubRubro> lista = new List<SubRubro>();
            SubRubro aux;

            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("SELECT sr.IdSubRubro, sr.Descripcion_SR, sr.Estado FROM SUB_RUBRO AS sr WHERE sr.Estado = 1");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new SubRubro();

                    aux.IdSubRubro = datos.lector.GetInt32(0);
                    aux.DescripcionSR = datos.lector.GetString(1);
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

        public bool agregarSubRubro(SubRubro subRubro)
        {   
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO SUB_RUBRO (Descripcion_SR, Estado) VALUES (@Descripcion_SR, @Estado)");

                datos.agregarParametro("@Descripcion_SR", subRubro.DescripcionSR);
                datos.agregarParametro("@Estado", subRubro.Estado);

                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex; 
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void editarSubRubro(SubRubro subrubro)
        {
            ConexionBD datos = new ConexionBD();           
            try
            {
                datos.setearQuery("UPDATE SUB_RUBRO SET Descripcion_SR=@Descripcion, Estado=@Estado Where IdSubRubro= @Id");
                datos.agregarParametro("@Descripcion", subrubro.DescripcionSR);
                datos.agregarParametro("@Estado", subrubro.Estado);
                //datos.agregarParametro("@Id", rubro.IdRubro);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarSubRubro(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM SUB_RUBRO WHERE IdSubRubro =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int obtenerIdRubro_SRR(int idSR)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT IdRubro_SRR FROM SUBRUBROxRUBRO WHERE IdSubRubro_SRR = " + idSR;
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                datos.conexion.Open();
                int idR = Convert.ToInt32(cmd.ExecuteScalar());
                datos.cerrarConexion();
                return idR;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // METODO PARA BORRAR PRIMERO EL REGISTRO DE LA TABLA INTERMEDIA "SUBRUBROxRUBRO"
        public void desvincularSubRubro(int idSR)
        {
            ConexionBD datos = new ConexionBD();
   
            int idR = obtenerIdRubro_SRR(idSR); //Obtengo el IdRubro de la tabla intermedia SUBRUBROxRUBRO

            try
            {
                datos.setearQuery("DELETE FROM SUBRUBROxRUBRO WHERE IdRubro_SRR = '" + idR + "' AND IdSubRubro_SRR = '" + idSR + "'");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int obtenerUltimoIdSubRubro()
        {
            ConexionBD datos = new ConexionBD();

            string consulta = "SELECT TOP 1 IdSubRubro FROM SUB_RUBRO ORDER BY IdSubRubro DESC";
            SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
            datos.conexion.Open();
            int idSubRubro = Convert.ToInt32(cmd.ExecuteScalar());
            datos.cerrarConexion();          
            return idSubRubro;
        }      
    }
}

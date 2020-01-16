using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class ClienteBLL
    {
        public List<Cliente> listarCliente()
        {
            List<Cliente> lista = new List<Cliente>();
            Cliente aux;
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("SELECT c.IdCliente, c.Valoracion, u.IdUsuario, u.Nombre, u.Email, u.Contrasenia, u.EstadoConexion, u.FechaRegistro, f.IdFoto, f.Imagen FROM CLIENTE c, USUARIO u, FOTO f WHERE u.IdUsuario = c.IdUsuario_C AND u.IdFoto_U = f.IdFoto");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Cliente();
                    aux.IdCliente = datos.lector.GetInt32(0);
                    aux.ValoracionC = datos.lector.GetDecimal(1);

                    aux.UsuarioC = new Usuario();
                    aux.UsuarioC.IdUsuario = (int)datos.lector["IdUsuario"];
                    aux.UsuarioC.NombreUsuario = datos.lector["Nombre"].ToString();
                    aux.UsuarioC.Email = datos.lector["Email"].ToString();
                    aux.UsuarioC.Contrasenia = datos.lector["Contrasenia"].ToString();
                    aux.UsuarioC.Contrasenia = datos.lector["EstadoConexion"].ToString();
                    aux.UsuarioC.FechaRegistro = DateTime.Today;
                    aux.UsuarioC.Foto.UrlImagen = datos.lector["Imagen"].ToString();

                    /*aux.UsuarioC.Foto = new Foto();                               
                    aux.UsuarioC.Foto.UrlImagen = datos.lector["Imagen"].ToString();*/

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

        public void agregarCliente(Cliente cliente)
        {
            ConexionBD datos = new ConexionBD();
            
            try
            {  
                string ulti = datos.obtenerUltimoIdUser();

                datos.setearQuery("INSERT INTO CLIENTE(IdUsuario_C, Valoracion, Estado) VALUES ('"+ ulti +"', @Valoracion, @Estado)");
            
                datos.agregarParametro("@Valoracion", cliente.ValoracionC);
                datos.agregarParametro("@Estado", cliente.Estado);

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

        public string obtenerNombreCliente(Int32 id)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT Nombre FROM CLIENTE INNER JOIN USUARIO ON USUARIO.IdUsuario = CLIENTE.IdUsuario_C WHERE IdCliente = @id";

                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@id", id);

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

        public Int64 obtenerIdUsuario_C()
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT IdUsuario_C FROM CLIENTE";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                //cmd.Parameters.AddWithValue("@Id", id);

                Int64 IdUsuarioC = Convert.ToInt64(cmd.ExecuteScalar());

                return IdUsuarioC;
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
        public Int32 obtenerIdCliente(string email)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT IdCliente FROM CLIENTE INNER JOIN USUARIO ON USUARIO.IdUsuario = CLIENTE.IdUsuario_C WHERE Email = @Email";

                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Email", email);

                Int32 IdCliente = Convert.ToInt32(cmd.ExecuteScalar());

                return IdCliente;
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

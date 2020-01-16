using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;

namespace Controlador
{
    public class UsuarioBLL
    {
        public List<Usuario> listarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            Usuario aux;

            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("SELECT u.IdUsuario, u.Nombre, u.Email, u.Contrasenia, u.EstadoConexion, u.FechaRegistro, u.Estado, u.Telefono, u.Rol FROM USUARIO AS u WHERE u.Estado = 1");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Usuario();

                    aux.IdUsuario = datos.lector.GetInt32(0);
                    aux.NombreUsuario = datos.lector.GetString(1);
                    aux.Email = datos.lector.GetString(2);
                    aux.Contrasenia = datos.lector.GetString(3);
                    aux.EstadoConexion = datos.lector.GetString(4);
                    aux.FechaRegistro = datos.lector.GetDateTime(5);
                    aux.Estado = datos.lector.GetBoolean(6);
                    aux.Telefono = datos.lector.GetInt32(7);
                    aux.Rol = datos.lector.GetChar(8);

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


        //HACER UN METODO QUE DESVINCULE EL CLIENTE DEL USUARIO

        public void eliminarUsuario(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM USUARIO WHERE IdUsuario =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarUsuario(Usuario usuario)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                /*datos.setearQuery("UPDATE PRODUCTOS SET '" + producto.Id + "', '" + producto.Titulo + "', '" + producto.Descripcion + "')");*/
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

        public void agregarUsuario(Usuario usuario)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO USUARIO (IdFoto_U, Nombre, Email, Contrasenia, EstadoConexion, Estado, Telfono, Rol) VALUES (NULL, @Nombre, @Email ,@Contrasenia, @EstadoConexion, @EstadoU, @Telefono, @Rol)");

                //datos.agregarParametro('NULL', usuario.Foto.IdFoto);
                datos.agregarParametro("@Nombre", usuario.NombreUsuario);
                datos.agregarParametro("@Email", usuario.Email);
                datos.agregarParametro("@Contrasenia", usuario.Contrasenia);
                datos.agregarParametro("@EstadoConexion", usuario.EstadoConexion);
                datos.agregarParametro("@EstadoU", usuario.Estado);
                datos.agregarParametro("@Telefono", usuario.Telefono);
                datos.agregarParametro("@Rol", usuario.Rol);

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

        public void editarUsuario(Usuario usuario)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("UPDATE USUARIO SET Nombre=@Nombre, Telfono=@Telefono, Email=@Email, Contrasenia=@Contrasenia WHERE Email = @Email");
                datos.agregarParametro("@Nombre", usuario.NombreUsuario);
                datos.agregarParametro("@Telefono", usuario.Telefono);
                datos.agregarParametro("@Email", usuario.Email);
                datos.agregarParametro("@Contrasenia", usuario.Contrasenia);
  
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void editarUsuarioCliente(Usuario usuario)
        //{
        //    ConexionBD datos = new ConexionBD();

        //    try
        //    {
        //        //datos.setearQuery("UPDATE USUARIO SET Nombre, Telfono, Email, Contrasenia, Cuit Where IdUsuario= @Id");
        //        //No hay nada que editar en la tabla Cliente y en la tabla Administrador
        //        datos.setearQuery("UPDATE USUARIO SET Nombre=@Nombre, Telfono=@Telefono, Email=@Email, Contrasenia=@Contrasenia WHERE IdUsuario = @Id");
        //        datos.agregarParametro("@Nombre", usuario.NombreUsuario);
        //        datos.agregarParametro("@Telefono", usuario.Telefono);
        //        datos.agregarParametro("@Email", usuario.Email);
        //        datos.agregarParametro("@Contrasenia", usuario.Contrasenia);

        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public bool validarLogin(string email, string pass)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT COUNT(*) FROM USUARIO WHERE Email= @Email AND Contrasenia=@Pass";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Pass", pass);

                int count = Convert.ToInt32(cmd.ExecuteScalar()); 
                
                if (count==0)
                {
                    return false;
                }
                else { return true; }
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

        public char obtenerRolUsuario(string email)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT Rol FROM USUARIO WHERE Email= @Email";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Email", email);

                char rol = Convert.ToChar(cmd.ExecuteScalar());
                               
                return rol;      
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

        public string mostrarNombreUsuario(string email)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                string consulta = "SELECT Nombre FROM USUARIO WHERE Email=@Email";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Email", email);

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

        public Int32 obtenerIdUsuario_P(string email)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT IdUsuario FROM USUARIO WHERE Email = @Email";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Email", email);

                Int32 IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());

                return IdUsuario;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class ProfesionalBLL
    {
        public List<Profesional> listarProfesional()
        {
            List<Profesional> lista = new List<Profesional>();
            Profesional aux;
            ConexionBD datos = new ConexionBD();
            try
            {
                //datos.setearQuery("SELECT p.IdProfesional, p.Cuit, p.Valoracion, u.IdUsuario, u.Nombre, u.Email, u.Contrasenia, u.EstadoConexion, u.FechaRegistro FROM PROFESIONAL p, USUARIO u WHERE u.IdUsuario = p.IdUsuario_P");
                datos.setearQuery("SELECT p.IdProfesional, p.Cuit, p.Valoracion, r.Descripcion_R, u.IdUsuario, u.Nombre, u.Email, u.Contrasenia, u.EstadoConexion, u.FechaRegistro FROM PROFESIONAL p, USUARIO u, RUBRO r, RUBROxPROFESIONAL rp WHERE u.IdUsuario = p.IdUsuario_P AND r.IdRubro = rp.IdRubro_RP AND rp.IdProfesional_RP = p.IdProfesional");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Profesional();
                    aux.IdProfesional = datos.lector.GetInt32(0);
                    aux.CuitCuil = datos.lector.GetInt64(1);
                    aux.ValoracionP = datos.lector.GetDecimal(2);

                    aux.Rubro = new Rubro();
                    aux.Rubro.DescripcionR = datos.lector.GetString(3);

                    aux.UsuarioP = new Usuario();
                    aux.UsuarioP.IdUsuario = (Int32)datos.lector["IdUsuario"];
                    aux.UsuarioP.NombreUsuario = datos.lector["Nombre"].ToString();
                    aux.UsuarioP.Email = datos.lector["Email"].ToString();
                    aux.UsuarioP.Contrasenia = datos.lector["Contrasenia"].ToString();
                    //acquí cambié contrasenia por estadoconexion. Repetí dos veces sin querer queriendo
                    aux.UsuarioP.EstadoConexion = datos.lector["EstadoConexion"].ToString(); 
                    aux.UsuarioP.FechaRegistro = DateTime.Today;
                    //aux.UsuarioP.Foto.UrlImagen = datos.lector["Imagen"].ToString();

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

        public Profesional ListarProfesionalxEmail(string email)
        {
            Profesional aux;
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("SELECT p.Cuit, p.Valoracion, u.Nombre, u.Email, u.Contrasenia, u.Telfono, u.FechaRegistro FROM PROFESIONAL p, USUARIO u WHERE u.Email = @Email");
                datos.agregarParametro("@Email", email);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    aux = new Profesional();
                    aux.CuitCuil = Convert.ToInt64(datos.lector["Cuit"]);
                    aux.ValoracionP = Convert.ToDecimal(datos.lector["Valoracion"]);

                    aux.UsuarioP = new Usuario();
                    aux.UsuarioP.NombreUsuario = datos.lector["Nombre"].ToString();
                    aux.UsuarioP.Email = datos.lector["Email"].ToString();
                    aux.UsuarioP.Contrasenia = datos.lector["Contrasenia"].ToString();
                    aux.UsuarioP.Telefono = Convert.ToInt32(datos.lector["Telfono"].ToString());
                    aux.UsuarioP.FechaRegistro = DateTime.Parse(datos.lector["FechaRegistro"].ToString());
                    /*aux.UsuarioC.Foto = new Foto();                               
                    aux.UsuarioC.Foto.UrlImagen = datos.lector["Imagen"].ToString();*/
                }
                else { aux = null; }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //datos.cerrarConexion();
            }
        }

        public void agregarProfesional(Profesional profesional)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string ulti = datos.obtenerUltimoIdUser();

                datos.setearQuery("INSERT INTO PROFESIONAL (IdUsuario_P, Cuit, Valoracion, Estado) VALUES ('" + ulti + "', @Cuit, @Valoracion, @Estado)");

                datos.agregarParametro("@Cuit", profesional.CuitCuil);
                datos.agregarParametro("@Valoracion", profesional.ValoracionP);
                datos.agregarParametro("@Estado", profesional.Estado);

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

        public void editarProfesional(Profesional profesional)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("UPDATE PROFESIONAL SET Cuit=@Cuit WHERE IdProfesional = @Id");

                datos.agregarParametro("@Cuit", profesional.CuitCuil);
                datos.agregarParametro("@Id", profesional.IdProfesional);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerNombreProfesional(int id)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT Nombre FROM PROFESIONAL INNER JOIN USUARIO ON USUARIO.IdUsuario = PROFESIONAL.IdUsuario_P WHERE IdProfesional = @Id";
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

        public Int64 obtenerCuit(int id)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT Cuit FROM PROFESIONAL WHERE IdProfesional = @Id";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                Int64 cuit = Convert.ToInt64(cmd.ExecuteScalar());

                return cuit;
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

        public Int64 obtenerIdUsuario_P(int id)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT IdUsuario_P FROM PROFESIONAL WHERE IdUsuario_P = @Id";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                Int64 IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());

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

        public Int32 obtenerIdProfesional(string email)
        {
            ConexionBD datos = new ConexionBD();
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            Int32 idUsuario = usuarioBLL.obtenerIdUsuario_P(email);

            try
            {
                string consulta = "SELECT IdProfesional FROM PROFESIONAL WHERE IdUsuario_P = @IdUsuario";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                Int32 IdProfesional = Convert.ToInt32(cmd.ExecuteScalar());

                return IdProfesional;
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

        public Int32 obtenerIdProfesionalxCuit(Int64 cuit)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                string consulta = "SELECT IdProfesional FROM PROFESIONAL WHERE Cuit = @Cuit";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Cuit", cuit);

                Int32 IdProfesional = Convert.ToInt32(cmd.ExecuteScalar());

                return IdProfesional;
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

        //ASIGNANDO RUBROS PARA CADA PROFESIONAL EN LA TABLA RUBROXPROFESIONAL
        public void agregarRubroProfesional(Int32 IdRubro, Int32 IdProfesional)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO RUBROxPROFESIONAL (IdProfesional_RP, IdRubro_RP) VALUES (@IdProfesional_RP, @IdRubro_RP)");
                datos.agregarParametro("@IdProfesional_RP", IdProfesional);
                datos.agregarParametro("@IdRubro_RP", IdRubro);
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

        public string obtenerNombrexCuit(Int64 cuit)
        {
            ConexionBD datos = new ConexionBD();
            ProfesionalBLL profesionalBLL = new ProfesionalBLL();

            try
            {
                string consulta = "SELECT Nombre FROM PROFESIONAL INNER JOIN USUARIO ON PROFESIONAL.IdUsuario_P = USUARIO.IdUsuario WHERE Cuit = @Cuit";
                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Cuit", cuit);

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

        public string obtenerRubroxProfesional(Int64 cuit)
        {
            ConexionBD datos = new ConexionBD();
            ProfesionalBLL profesionalBLL = new ProfesionalBLL();

            try
            {
                string consulta = "SELECT RUBRO.Descripcion_R FROM PROFESIONAL INNER JOIN USUARIO ON USUARIO.IdUsuario = PROFESIONAL.IdUsuario_P INNER JOIN RUBROxPROFESIONAL ON RUBROxPROFESIONAL.IdProfesional_RP = PROFESIONAL.IdProfesional INNER JOIN RUBRO ON RUBRO.IdRubro = RUBROxPROFESIONAL.IdRubro_RP WHERE Cuit = @Cuit";

                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Cuit", cuit);

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

        public string obtenerMailProfesional(Int64 cuit)
        {
            ConexionBD datos = new ConexionBD();
            ProfesionalBLL profesionalBLL = new ProfesionalBLL();

            try
            {
                string consulta = "SELECT Email FROM PROFESIONAL INNER JOIN USUARIO ON USUARIO.IdUsuario = PROFESIONAL.IdUsuario_P WHERE Cuit = @Cuit";

                datos.conexion.Open();
                SqlCommand cmd = new SqlCommand(consulta, datos.conexion);
                cmd.Parameters.AddWithValue("@Cuit", cuit);

                string email = Convert.ToString(cmd.ExecuteScalar());

                return email;
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

        public void ValoracionP(decimal puntaje)
        {
            //class promedio
            //{
            //    private double[] notas = new double[5];
            //    private int indice = 0;

            //public void insertar(double nota)
            //{
            //    if (indice < notas.Length)
            //    {
            //        notas[indice] = nota;
            //        indice++;
            //    }
            //}
           
            //public double promedios()
            //{
            //    return notas.Average();
            //}
        }
    }
}
 

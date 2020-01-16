using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class ReclamoBLL
    {
        public List<Reclamo> listarReclamos()
        {
            List<Reclamo> lista = new List<Reclamo>();
            Reclamo aux;

            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("SELECT r.IdReclamo, r.IdContrato_R, r.Motivo, r.FechaReclamo FROM RECLAMO AS r WHERE r.Estado = 1");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Reclamo();
                    aux.IdReclamo = datos.lector.GetInt32(0);
                    aux.Motivo = (String)datos.lector["Motivo"];
                    aux.FechaReclamo = (DateTime)datos.lector["FechaReclamo"];

                    aux.Contrato = new Contrato();
                    aux.Contrato.IdContrato = (int)datos.lector["IdContrato_R"];

                    //aux.Contrato.Cliente.UsuarioC = new Usuario();
                    //aux.Contrato.Cliente.UsuarioC.NombreUsuario = (String)datos.lector["Nombre"]; 
                    //¿Cómo distingo el nombre del cliente con el del profesional?

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

        public List<Reclamo> listarReclamosxIdCliente(Int32 IdCliente)
        {
            List<Reclamo> lista = new List<Reclamo>();
            Reclamo aux;

            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("SELECT r.IdReclamo, r.IdContrato_R, Nombre, Cuit, r.Motivo, r.FechaReclamo, r.Estado FROM RECLAMO as r, CONTRATO as c, PROFESIONAL as p, USUARIO u " +
                                  "WHERE c.IdContrato = r.IdContrato_R AND p.IdProfesional = c.IdProfesional_C AND u.IdUsuario = p.IdUsuario_P AND c.IdCliente_C = " + IdCliente);             
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Reclamo();
                    aux.IdReclamo = datos.lector.GetInt32(0);
                    aux.Motivo = (String)datos.lector["Motivo"];
                    aux.FechaReclamo = (DateTime)datos.lector["FechaReclamo"];

                    aux.Contrato = new Contrato();
                    aux.Contrato.IdContrato = (int)datos.lector["IdContrato_R"];

                    aux.Contrato.Profesional = new Profesional();
                    aux.Contrato.Profesional.CuitCuil = (Int64)datos.lector["Cuit"];

                    aux.Contrato.Profesional.UsuarioP = new Usuario();
                    aux.Contrato.Profesional.UsuarioP.NombreUsuario = (String)datos.lector["Nombre"];

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

        public void agregarReclamo(Reclamo reclamo)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO RECLAMO (IdContrato_R, Motivo, FechaReclamo, Estado) VALUES (@IdContrato_R, @Motivo, @FechaReclamo, @Estado)");

                datos.agregarParametro("@IdContrato_R", reclamo.Contrato.IdContrato);
                datos.agregarParametro("@Motivo", reclamo.Motivo);
                datos.agregarParametro("@FechaReclamo", reclamo.FechaReclamo);
                datos.agregarParametro("@Estado", reclamo.Estado);

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

        public void eliminarReclamo(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM RECLAMO WHERE IdReclamo =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;

namespace Controlador
{
    public class ContratoBLL
    {
        public List<Contrato> listarContrato()
        {
            List<Contrato> lista = new List<Contrato>();
            Contrato aux;
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("SELECT c.IdContrato, cli.IdCliente, pro.IdProfesional, ru.IdRubro, pa.IdPago, c.Descripcion_C, c.Direccion_C, c.Importe, c.Fecha_Contrato, ec.IdEstadoContrato, c.Estado FROM CONTRATO c, PROFESIONAL pro, CLIENTE cli, RUBRO ru, PAGO pa, ESTADO_CONTRATO ec WHERE cli.IdCliente = c.IdCliente_C AND c.IdProfesional_C = IdProfesional AND c.IdRubro_C = ru.IdRubro AND pa.IdPago = c.IdPago_C AND ec.IdEstadoContrato = c.IdEstadoContrato_C");
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Contrato();
                    aux.IdContrato = datos.lector.GetInt32(0); //(Int64)datos.lector["IdContrato"];
                    aux.Descripcion = datos.lector["Descripcion_C"].ToString();
                    aux.Direccion = datos.lector["Direccion_C"].ToString();
                    aux.Importe = Convert.ToDecimal(datos.lector["Importe"]);
                    aux.Profesional = new Profesional();
                    aux.Profesional.IdProfesional = (int)datos.lector["IdProfesional"]; //long ó Int64
                    
                    aux.Profesional.Rubro = new Rubro();
                    aux.Profesional.Rubro.IdRubro = (int)datos.lector["IdRubro"];
                    
                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = (int)datos.lector["IdCliente"];

                    aux.Pago = new Pago();
                    aux.Pago.IdPago = (int)datos.lector["IdPago"];

                    aux.FechaContrato = (DateTime)datos.lector["Fecha_Contrato"];

                    aux.EstadoContrato = new EstadoContrato();
                    aux.EstadoContrato.IdEstadoContrato = (int)datos.lector["IdEstadoContrato"];

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

        public List<Contrato> ListarContratoxIdProfesional(Int32 IdProfesional)
        {
            List<Contrato> lista = new List<Contrato>();
            Contrato aux;
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("SELECT c.IdContrato, cli.IdCliente, pro.IdProfesional, ru.IdRubro, pa.IdPago, c.Descripcion_C, c.Direccion_C, c.Importe, c.Fecha_Contrato, ec.IdEstadoContrato, c.Estado FROM CONTRATO c, PROFESIONAL pro, CLIENTE cli, RUBRO ru, PAGO pa, ESTADO_CONTRATO ec " +
                                    "WHERE cli.IdCliente = c.IdCliente_C AND c.IdProfesional_C = IdProfesional AND c.IdRubro_C = ru.IdRubro AND pa.IdPago = c.IdPago_C " +
                                    "AND ec.IdEstadoContrato = c.IdEstadoContrato_C AND pro.IdProfesional = " + IdProfesional);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Contrato();
                    aux.IdContrato = datos.lector.GetInt32(0); //(Int64)datos.lector["IdContrato"];
                    aux.Descripcion = datos.lector["Descripcion_C"].ToString();
                    aux.Direccion = datos.lector["Direccion_C"].ToString();
                    aux.Importe = Convert.ToDecimal(datos.lector["Importe"]);
                    aux.Profesional = new Profesional();
                    aux.Profesional.IdProfesional = (int)datos.lector["IdProfesional"]; //long ó Int64

                    aux.Profesional.Rubro = new Rubro();
                    aux.Profesional.Rubro.IdRubro = (int)datos.lector["IdRubro"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = (int)datos.lector["IdCliente"];

                    aux.Pago = new Pago();
                    aux.Pago.IdPago = (int)datos.lector["IdPago"];

                    aux.FechaContrato = (DateTime)datos.lector["Fecha_Contrato"];

                    aux.EstadoContrato = new EstadoContrato();
                    aux.EstadoContrato.IdEstadoContrato = (int)datos.lector["IdEstadoContrato"];

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

        public List<Contrato> listarContratoxIdCliente(Int32 IdCliente)
        {
            List<Contrato> lista = new List<Contrato>();
            Contrato aux;
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("SELECT c.IdContrato, cli.IdCliente, pro.IdProfesional, ru.IdRubro, pa.IdPago, c.Descripcion_C, c.Direccion_C, c.Importe, c.Fecha_Contrato, ec.IdEstadoContrato, c.Estado FROM CONTRATO c, PROFESIONAL pro, CLIENTE cli, RUBRO ru, PAGO pa, ESTADO_CONTRATO ec " +
                                    "WHERE cli.IdCliente = c.IdCliente_C AND c.IdProfesional_C = IdProfesional AND c.IdRubro_C = ru.IdRubro AND pa.IdPago = c.IdPago_C " +
                                    "AND ec.IdEstadoContrato = c.IdEstadoContrato_C AND cli.IdCliente = " + IdCliente);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    aux = new Contrato();
                    aux.IdContrato = datos.lector.GetInt32(0); //(Int64)datos.lector["IdContrato"];
                    aux.Descripcion = datos.lector["Descripcion_C"].ToString();
                    aux.Direccion = datos.lector["Direccion_C"].ToString();
                    aux.Importe = Convert.ToDecimal(datos.lector["Importe"]);
                    aux.Profesional = new Profesional();
                    aux.Profesional.IdProfesional = (int)datos.lector["IdProfesional"]; //long ó Int64

                    aux.Profesional.Rubro = new Rubro();
                    aux.Profesional.Rubro.IdRubro = (int)datos.lector["IdRubro"];

                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = (int)datos.lector["IdCliente"];

                    aux.Pago = new Pago();
                    aux.Pago.IdPago = (int)datos.lector["IdPago"];

                    aux.FechaContrato = (DateTime)datos.lector["Fecha_Contrato"];

                    aux.EstadoContrato = new EstadoContrato();
                    aux.EstadoContrato.IdEstadoContrato = (int)datos.lector["IdEstadoContrato"];

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
 
        public void agregarContrato(Contrato contrato)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO CONTRATO (IdCliente_C, IdProfesional_C, IdRubro_C, IdPago_C, Descripcion_C, Direccion_C, Importe, IdEstadoContrato_C, Estado) VALUES (@IdCliente_C, @IdProfesional_C, @IdRubro_C, @IdPago_C, @Descripcion_C, @Direccion_C, @Importe, @IdEstadoContrato, @Estado)");
 
                datos.agregarParametro("@IdCliente_C", contrato.Cliente.IdCliente);
                datos.agregarParametro("@IdProfesional_C", contrato.Profesional.IdProfesional);
                datos.agregarParametro("@IdRubro_C", contrato.Profesional.Rubro.IdRubro);
                datos.agregarParametro("@IdPago_C", contrato.Pago.IdPago);
                datos.agregarParametro("@Descripcion_C", contrato.Descripcion);
                datos.agregarParametro("@Direccion_C", contrato.Direccion);
                datos.agregarParametro("@Importe", contrato.Importe);
                datos.agregarParametro("@IdEstadoContrato", contrato.EstadoContrato.IdEstadoContrato);
                datos.agregarParametro("@Estado", contrato.Estado);

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

        public void eliminarContrato(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM CONTRATO WHERE IdContrato =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void actualizarPresupuesto(Contrato contrato)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("UPDATE CONTRATO SET Importe = @Importe WHERE IdContrato= @Id");
                datos.agregarParametro("@Id", contrato.IdContrato);
                datos.agregarParametro("@Importe", contrato.Importe);
 
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void actualizarEstadoContrato(Contrato contrato)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("UPDATE CONTRATO SET IdEstadoContrato_C= @ec WHERE IdContrato= @Id");
                datos.agregarParametro("@ec", contrato.EstadoContrato.IdEstadoContrato);
                datos.agregarParametro("@Id", contrato.IdContrato);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

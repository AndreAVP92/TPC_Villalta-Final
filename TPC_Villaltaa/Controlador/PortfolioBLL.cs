using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class PortfolioBLL
    {
        public void agregaPortFolio(PortFolio portFolio)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO PORTFOLIO (IdImagenPort_P, IdProfesional_P, Estado) VALUES (@IdImagenPort_P, @IdProfesional_P, @Estado)");

                datos.agregarParametro("@IdImagenPort_P", portFolio.IdPortFolio);
                datos.agregarParametro("@IdProfesional_P", portFolio.Profesional.IdProfesional);
                datos.agregarParametro("@Estado", portFolio.Estado);

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

        public void eliminarPortfolio(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM PORTFOLIO WHERE IdPort =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

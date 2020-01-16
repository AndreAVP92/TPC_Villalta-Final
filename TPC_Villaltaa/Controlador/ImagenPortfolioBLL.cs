using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class ImagenPortfolioBLL
    {
        public void agregarImagenPorfolio(ImagenPortfolio imgPortfolio)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO IMAGEN_PORTFOLIO (URLImagenPort, Descripcion_IP, Estado) VALUES (@URLImagenPort, @Descripcion_IP, @Estado)");

                datos.agregarParametro("@URLImagenPort", imgPortfolio.UrlImagen_IP);
                datos.agregarParametro("@Descripcion_IP", imgPortfolio.Descripcion_IP);
                datos.agregarParametro("@Estado", imgPortfolio.Estado);

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

        public void eliminarImagenPortfolio(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM IMAGEN_PORTFOLIO WHERE IdImagenPort =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

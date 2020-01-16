using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class FotoBLL
    {
        public void agregarFoto(Foto foto)
        {
            ConexionBD datos = new ConexionBD();

            try
            {
                datos.setearQuery("INSERT INTO FOTO (Imagen, Estado) VALUES (@Imagen, @Estado)");

                datos.agregarParametro("@Imagen", foto.UrlImagen);
                datos.agregarParametro("@Estado", foto.Estado);

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

        public void eliminarFoto(int id)
        {
            ConexionBD datos = new ConexionBD();
            try
            {
                datos.setearQuery("DELETE FROM FOTO WHERE IdFoto =" + id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

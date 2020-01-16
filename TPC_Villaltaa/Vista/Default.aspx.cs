using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;
using System.Threading;

namespace Vista
{
    public partial class _Default : Page
    {
        Administrador administrador = new Administrador();
        Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Login"] != null )
                {
                    Session["Usuario"] = "unknown";
                    Session["ErrorLogin"] = "";
                }
                else if (Session["Registro"] != null)
                {                  
                    Session["ErrorRegistro"] = "";
                }
                Response.AppendHeader("Cache-Control", "no-store");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            try
            {
                if(usuarioBLL.validarLogin(InputEmailL.Text, InputPasswordL.Text) == true)
                {
                    char rol = usuarioBLL.obtenerRolUsuario(InputEmailL.Text);

                    if (rol == 'A')
                    {
                        Session["Login"] = "SI";
                        Session["Usuario"] = InputEmailL.Text;                       
                        Response.Redirect("BienvenidoAdmin.aspx");
                        
                    }
                }
            }
            catch (ThreadAbortException ex1)
            {
                ///SIEMPRE PONER ESTE CATCH EN CASO DE IR AL CATCH DE ABAJO///
            }
            catch (Exception ex)
            {
                Session["ErrorLogin"] = "Email o Contraseña incorrecta";
                Response.Redirect("Error.aspx");
            }
        }

        protected void ButtonRegistro_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            AdministradorBLL administradorBLL = new AdministradorBLL();
            int contador=0;

            try
            {
                if (contador<=1)
                {
                    usuario = new Usuario();
                    usuario.NombreUsuario = InputNombreR.Text;
                    usuario.Email = InputEmailR.Text;
                    usuario.Contrasenia = InputPasswordR.Text;
                    usuario.EstadoConexion = "Conectado";
                    usuario.Estado = true;
                    usuario.Rol = 'A';
                    usuarioBLL.agregarUsuario(usuario);

                    administrador = new Administrador();
                    administrador.Estado = true;

                    administradorBLL.agregarAdmin(administrador);
                    contador++;
                    Session["Registro"] = "SI";
                    Response.Redirect("Default.aspx"); ///NO OLVIDAR PONER A QUÉ PÁGINA DIRECCIONAR
                }
                else
                {
                    Session["ErrorRegistro"] = "Error al registrarse";
                    Response.Redirect("Error.aspx");
                    contador = 0;
                }              
            }
            catch (ThreadAbortException ex1)
            {
                ///SIEMPRE PONER ESTE CATCH EN CASO DE IR AL CATCH DE ABAJO///
            }
            catch (Exception ex)
            {
                Session["ErrorRegistro"] = "Error al registrarse";
                Response.Redirect("Error.aspx");
                contador = 0;
            }
        }
    }
}
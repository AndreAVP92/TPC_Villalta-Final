using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Modelo;
using System.Threading;

namespace Vista
{
    public partial class PruebaLogin : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {               
                if (Session["Login"] != null)
                {
                    Session["Usuario"] = "Anonimo";
                    Session["ErrorLogin"] = "";                  
                }
                Response.AppendHeader("Cache-Control", "no-store");
                //Supuestamente ésto solucionaba para deshabilitar el boton retroceder y te dirija a la misma página.
                //Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                //Response.Cache.SetAllowResponseInBrowserHistory(false);
                //Response.Cache.SetNoStore();
            }
        }
 
    protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            try
            {
                if (usuarioBLL.validarLogin(InputEmail.Text, InputPassword.Text) == true)
                {
                    char rol = usuarioBLL.obtenerRolUsuario(InputEmail.Text);       

                    if (rol == 'C')
                    {
                        Session["Login"] = "SI";
                        Session["Usuario"] = InputEmail.Text;
                        Response.Redirect("BienvenidoCliente.aspx");        
                    }
                    else if (rol == 'P')
                    {
                        Session["Login"] = "SI";
                        Session["Usuario"] = InputEmail.Text;
                        Response.Redirect("BienvenidoProfesional.aspx");
                    }
                    //else if (rol == 'A')
                    //{
                    //    Session["Login"] = "SI";
                    //    Session["Usuario"] = InputEmail.Text;
                    //    Response.Redirect("BienvenidoAdmin.aspx");
                    //}
                }
                else
                {
                    Session["ErrorLogin"] = "Email o Contraseña incorrecta";
                    Response.Redirect("Error.aspx");
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
    }
}
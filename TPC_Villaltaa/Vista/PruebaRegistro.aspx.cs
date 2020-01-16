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
    public partial class PruebaRegistro : System.Web.UI.Page
    {
        Cliente cliente = new Cliente();
        Profesional profesional = new Profesional();
        Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Registro"] != null)
            {
                //Session["Usuario"] = "Anonimo";
                Session["ErrorRegistro"] = "";
            }
            Response.AppendHeader("Cache-Control", "no-store");
        }  

        protected void ButtonRegistrarse_Click(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            ProfesionalBLL profesionalBLL = new ProfesionalBLL();
            
            try
            {
                if (CheckBoxProfesional.Checked==false)
                {
                    usuario = new Usuario();
                    usuario.NombreUsuario = InputNombre.Text;
                    usuario.Email = InputEmail.Text;
                    usuario.Contrasenia = InputPassword.Text;
                    usuario.EstadoConexion = "Conectado";
                    usuario.Estado = true;
                    usuario.Rol = 'C'; 
                    usuarioBLL.agregarUsuario(usuario);

                    cliente = new Cliente();
                    cliente.ValoracionC = 0;
                    cliente.Estado = true;
                    clienteBLL.agregarCliente(cliente);

                    //bml.AddListaCliente();
                    Session["Registro"] = "SI";
                    //Session["Usuario"] = usuario.NombreUsuario;
                    Response.Redirect("PruebaLogin.aspx");
                }
                else
                {
                    usuario = new Usuario();
                    usuario.NombreUsuario = InputNombre.Text;
                    usuario.Email = InputEmail.Text;
                    usuario.Contrasenia = InputPassword.Text;
                    usuario.EstadoConexion = "Conectado";
                    usuario.Estado = true;
                    usuario.Rol = 'P';
                    usuarioBLL.agregarUsuario(usuario);

                    profesional = new Profesional();                  
                    profesional.CuitCuil = 0;
                    profesional.ValoracionP = 0;
                    profesional.Estado = true;
                    profesionalBLL.agregarProfesional(profesional);

                    Session["Registro"] = "SI";
                    //Session["Usuario"] = usuario.NombreUsuario;
                    Response.Redirect("PruebaLogin.aspx");
                }
            }
            catch(ThreadAbortException ex1)
            {
                ///SIEMPRE PONER ESTE CATCH EN CASO DE IR AL CATCH DE ABAJO///
            }
            catch (Exception ex)
            {
                Session["ErrorRegistro"] = "Error al registrarse";
                Response.Redirect("Error.aspx");
            }
        }
    }
}
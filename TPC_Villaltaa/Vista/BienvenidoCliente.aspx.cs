using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration.Internal;
using Modelo;
using Controlador;

namespace Vista
{
    public partial class BienvenidoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            if (Session["Usuario"] != null)
            {
                string mostrar = usuarioBLL.mostrarNombreUsuario(Session["Usuario"].ToString());
                username.Text = mostrar;
                
                ButtonEmailUser.Text = mostrar;
            }
        }
       
        // CERRAR SESION //
        protected void HLSignOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionID", ""));
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Redirect("indexCliente.aspx");
        }

        // VER MI PERFIL //
        protected void HLMiPerfil_Click(object sender, EventArgs e)
        {                       
            Panel1.Visible = true;                     
        }

        protected void ButtonOcultarPerfil_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void LBBuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarHandyman.aspx");
        }

        protected void LBVerSolicitudes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaContratos_C.aspx");
        }

        protected void LBReclamos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarReclamos_C.aspx");
        }
    }
}
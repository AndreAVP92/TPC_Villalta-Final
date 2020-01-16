using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;


namespace Vista
{
    public partial class BienvenidoAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            if (Session["Usuario"] != null)
            {
                string mostrar = usuarioBLL.mostrarNombreUsuario(Session["Usuario"].ToString());
                username.Text = mostrar;

                //ButtonEmailAdmin.Text = mostrar;
            }
        }

        // CERRAR SESION //
        protected void HLSignOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionID", ""));
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Redirect("Default.aspx");
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Modelo;
using Controlador;

namespace Vista
{
    public partial class BuscarHandyman : System.Web.UI.Page
    {
        public List<Profesional> ListaProfesionales { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ProfesionalBLL profesionalBLL = new ProfesionalBLL();
                ClienteBLL clienteBLL = new ClienteBLL();
                ListaProfesionales = profesionalBLL.listarProfesional();
                Session["MailCliente"] = Session["Usuario"].ToString();
                Session["IdCliente"] = clienteBLL.obtenerIdCliente(Session["Usuario"].ToString());
    
                Response.AppendHeader("Cache-Control", "no-store");
            }

            ///En un futuro, hacer que liste los profesionales que están desocupados!
        }
    }
}

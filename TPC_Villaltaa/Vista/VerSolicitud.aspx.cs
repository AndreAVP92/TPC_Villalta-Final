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
    public partial class VerSolicitud : System.Web.UI.Page
    {
        private List<Contrato> lista;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddListaContrato();
                //if (Session["Profesional"] != null) 
                    //ListarContrato();
            }
        }

        void AddListaContrato()
        {
            ContratoBLL contratoBLL = new ContratoBLL();

            GridViewContrato.DataSource = contratoBLL.listarContrato();
            GridViewContrato.DataBind();
        }

        //protected void ListarContrato()
        //{                 
        //    ContratoBLL contratoBLL = new ContratoBLL();

        //    //Contrato contrato = new Contrato();
        //    Int32 idProf = Convert.ToInt32(Session["Profesional"]);
        //    //Contrato contrato = contratoBLL.mostrarContrato(idProf);

        //    TextBoxIdContrato.Text = contrato.IdContrato.ToString();

        //    TextBoxNombreProfesional.Text = contrato.Profesional.IdProfesional.ToString();
        //    //contrato.Cliente = new Cliente();
        //    TextBoxNombreCliente.Text = contrato.Cliente.IdCliente.ToString();

        //    TextBoxDireccion.Text = contrato.Direccion;
        //    TextBoxDescripcion.Text = contrato.Descripcion;
        //}

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("BienvenidoProfesional.aspx");
        }
    }
}

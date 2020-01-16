using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;
using System.Web.Services;

namespace Vista
{
    public partial class ABM_EstadoContrato : System.Web.UI.Page
    {
        EstadoContrato estadoContrato = new EstadoContrato();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                AddListaEstadosContrato();
        }

        void AddListaEstadosContrato()
        {
            EstadoContratoBLL estadoContratoBLL = new EstadoContratoBLL();

            GridView_EC.DataSource = estadoContratoBLL.listarEstadosContrato();
            GridView_EC.DataBind();
        }

        protected void ButtonAltaEstado_Click(object sender, EventArgs e)
        {
            EstadoContratoBLL estadoContratoBLL = new EstadoContratoBLL();

            try
            {
                estadoContrato = new EstadoContrato();

                estadoContrato.Descripcion = InputDescripcion.Text;
                estadoContrato.Estado = true;

                estadoContratoBLL.agregarEstadoContrato(estadoContrato);

                AddListaEstadosContrato();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView_EC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            EstadoContratoBLL estadoContratoBLL = new EstadoContratoBLL();

            int index = int.Parse(e.CommandArgument.ToString());
            int id = int.Parse(GridView_EC.DataKeys[index].Value.ToString());

            if (e.CommandName == "DeleteRow")
            {
                estadoContratoBLL.eliminarEstadoContrato(id);
                AddListaEstadosContrato();
            }
            //else if (e.CommandName == "EditRow")
            //{
            //    estadoContrato = new EstadoContrato();

            //    estadoContratoBLL.editarEstadoContrato(estadoContrato);
            //    AddListaEstadosContrato();
            //}
        }
    }
}
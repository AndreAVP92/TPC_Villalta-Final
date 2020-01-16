using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Controlador;
using Modelo;

namespace Vista
{
    public partial class ListaContratos_C : System.Web.UI.Page
    {
        public List<Contrato> ListaContratoC { get; set; }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            ContratoBLL contratoBLL = new ContratoBLL();
            ClienteBLL clienteBLL = new ClienteBLL();

            string mailCliente = Session["Usuario"].ToString();
            int idCliente = clienteBLL.obtenerIdCliente(mailCliente);

            ListaContratoC = contratoBLL.listarContratoxIdCliente(idCliente);
        }
    }
}
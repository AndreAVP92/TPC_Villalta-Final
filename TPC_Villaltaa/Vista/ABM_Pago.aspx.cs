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
    public partial class ABM_Pago : System.Web.UI.Page
    {
        public List<Pago> ListaPagos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack) {
                    TextBoxDescripcion.Text = "";
                    TextBoxID.Text = "";
                    mostrar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void mostrar()
        {
            PagoBLL pagoBLL = new PagoBLL();
            ListaPagos = pagoBLL.listarPago();
        }

        protected void ButtonAddPago_Click(object sender, EventArgs e)
        {
            Pago pago;
            PagoBLL pagoBLL = new PagoBLL();
            
            try
            {
                pago = new Pago();

                pago.DescripcionP = InputDescripcion.Text;
                pago.Estado = true;

                pagoBLL.agregaPago(pago);

                mostrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ButtonGuardarEditar_Click(object sender, EventArgs e)
        {
            Pago pago;
            PagoBLL pagoBLL = new PagoBLL();

            try
            {
                pago = new Pago();

                pago.IdPago = Convert.ToInt32(TextBoxID.Text);
                pago.DescripcionP = TextBoxDescripcion.Text;
                pago.Estado = true;

                pagoBLL.editarPago(pago);

                mostrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                    
    }
}
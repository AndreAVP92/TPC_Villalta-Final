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
    public partial class VerContrato_P : System.Web.UI.Page
    {
        public Contrato contrato { get; set; }
        private Contrato ccc = null;
        ContratoBLL contratoBLL = new ContratoBLL();
        ClienteBLL clienteBLL = new ClienteBLL();
        ProfesionalBLL profesionalBLL = new ProfesionalBLL();
        EstadoContratoBLL estadoContratoBLL = new EstadoContratoBLL();
        RubroBLL rubroBLL = new RubroBLL();
        PagoBLL pagoBLL = new PagoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {              
                List<Contrato> listarContrato;
                listarContrato = contratoBLL.listarContrato();
                Int32 contratoSeleccionado = Convert.ToInt32(Request.QueryString["idcontrato"]);
                contrato = listarContrato.Find(Pp => Pp.IdContrato == contratoSeleccionado);

                TextBoxIDContrato.Text = contrato.IdContrato.ToString();
                TextBoxCliente.Text = clienteBLL.obtenerNombreCliente(contrato.Cliente.IdCliente).ToString();
                TextBoxProfesional.Text = profesionalBLL.obtenerNombreProfesional(contrato.Profesional.IdProfesional).ToString();
                TextBoxCuit.Text = profesionalBLL.obtenerCuit(contrato.Profesional.IdProfesional).ToString();
                TextBoxRubro.Text = rubroBLL.obtenerNombreRubro(contrato.Profesional.Rubro.IdRubro).ToString();
                TextBoxPago.Text = pagoBLL.obtenerNombrePago(contrato.Pago.IdPago).ToString();
                TextBoxDescripcion.Text = contrato.Descripcion;
                TextBoxDireccion.Text = contrato.Direccion;
                TextBoxEstadoContrato.Text = estadoContratoBLL.obtenerNombreEstadoContrato(contrato.EstadoContrato.IdEstadoContrato).ToString();  

                if (!IsPostBack)
                    {   
                    TextBoxImporte.Text = contrato.Importe.ToString();
                    }    
                if(TextBoxEstadoContrato.Text == "Confirmado")
                {
                    ButtonEnviarPresupuesto.Visible = false;
                    ButtonRechazar.Visible = false;
                    ButtonConfirmar.Visible = true;
                }
                else if (TextBoxEstadoContrato.Text == "Reparando")
                {
                    ButtonConfirmar.Visible = false;
                    ButtonTerminado.Visible = true;
                    ButtonRechazar.Visible = false;
                    ButtonEnviarPresupuesto.Visible = false;
                }
                else if(TextBoxEstadoContrato.Text == "Terminado")
                {                    
                    ButtonTerminado.Visible = false;
                    ButtonValorar.Visible = true;
                }
                else if(TextBoxEstadoContrato.Text == "Finalizado")
                {
                    ButtonTerminado.Visible = false;
                    ButtonValorar.Visible = true;
                    ButtonRechazar.Visible = false;
                    ButtonEnviarPresupuesto.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ButtonEnviarPresupuesto_Command(object sender, CommandEventArgs e)
        {
            ButtonEnviarPresupuesto.Visible = false;
            ButtonRechazar.Visible = false;
            ButtonTerminado.Visible = true;
          
            if (ccc == null)
            {
                ccc = new Contrato();
                ccc.Importe = Convert.ToDecimal(TextBoxImporte.Text);
                ccc.IdContrato = Convert.ToInt32(TextBoxIDContrato.Text);

                if(ccc.Importe > 0)
                {
                contratoBLL.actualizarPresupuesto(ccc);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Importe inválido');window.location ='VerContrato_P.aspx';", true);
                }
            }
            Response.Redirect("ListaContratos_P.aspx");
        }

        protected void ButtonConfirmar_Click(object sender, EventArgs e)
        {           
            if(TextBoxEstadoContrato.Text == "Confirmado")
            {
                ButtonConfirmar.Visible = false;
                ButtonTerminado.Visible = true;
                //TextBoxEstadoContrato.Text = "Reparando";
                
                ccc = new Contrato();
                ccc.IdContrato = Convert.ToInt32(TextBoxIDContrato.Text);

                ccc.EstadoContrato = new EstadoContrato();
                ccc.EstadoContrato.IdEstadoContrato = estadoContratoBLL.obtenerIdEstadoContrato("Reparando"); ;
                contratoBLL.actualizarEstadoContrato(ccc);
            }           
        }

        protected void ButtonTerminado_Click(object sender, EventArgs e)
        {
            ccc = new Contrato();
            ccc.IdContrato = Convert.ToInt32(TextBoxIDContrato.Text);

            ccc.EstadoContrato = new EstadoContrato();
            ccc.EstadoContrato.IdEstadoContrato = estadoContratoBLL.obtenerIdEstadoContrato("Finalizado"); ;
            contratoBLL.actualizarEstadoContrato(ccc);

            TextBoxEstadoContrato.Text = ccc.EstadoContrato.Descripcion; 

            Response.Redirect("ListaContratos_P.aspx");
        }
    }
}
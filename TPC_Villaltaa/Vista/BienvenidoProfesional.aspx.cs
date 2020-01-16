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
    public partial class BienvenidoProfesional : System.Web.UI.Page
    {
        public Profesional profesional;
        ProfesionalBLL profesionalBLL = new ProfesionalBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack){
                RubroBLL rubroBLL = new RubroBLL();
                DropDownListRubro.DataSource = rubroBLL.listarRubros();
                DropDownListRubro.DataValueField = "IdRubro";
                DropDownListRubro.DataTextField = "DescripcionR";
                DropDownListRubro.DataBind();

                if (Session["Usuario"] != null)
                {              
                    string mostrar = Session["Usuario"].ToString();              
                    ButtonEmailUser.Text = mostrar;
                    mostrarDatos(Session["Usuario"].ToString());
                }
            }                 
        }

        void mostrarDatos(string email)
        {                     
            email = Session["Usuario"].ToString();
            profesional = profesionalBLL.ListarProfesionalxEmail(email);
           
            //DropDownListRubro.Text = profesional.Rubro.DescripcionR;
            TextBoxCuit.Text = profesional.CuitCuil.ToString();

            TextBoxNombre.Text = profesional.UsuarioP.NombreUsuario;
            TextBoxEmail.Text = profesional.UsuarioP.Email;
            TextBoxContrasenia.Text = profesional.UsuarioP.Contrasenia;
            TextBoxTelefono.Text = profesional.UsuarioP.Telefono.ToString();
            TextBoxFecha.Text = profesional.UsuarioP.FechaRegistro.ToString();
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
            PanelVerPerfil.Visible = true;
            PanelCargarDatos.Visible = false;
        }

        protected void ButtonOcultarPerfil_Click(object sender, EventArgs e)
        {
            PanelVerPerfil.Visible = false;
        }

        protected void HLActualizarPerfil_Click(object sender, EventArgs e)
        {
            PanelCargarDatos.Visible = true;
            PanelVerPerfil.Visible = false;
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            Profesional profesional;
            ProfesionalBLL profesionalBLL = new ProfesionalBLL();
            try
            {
                string email = Session["Usuario"].ToString();

                profesional = new Profesional();
                profesional.IdProfesional = profesionalBLL.obtenerIdProfesional(email);
                profesional.CuitCuil = Convert.ToInt64(TextBoxCuit.Text);
                profesionalBLL.editarProfesional(profesional);
                
                profesional.UsuarioP = new Usuario();
                TextBoxEmail.Text = email;
                profesional.UsuarioP.NombreUsuario = TextBoxNombre.Text;
                profesional.UsuarioP.Email = TextBoxEmail.Text;
                profesional.UsuarioP.Contrasenia = TextBoxContrasenia.Text;
                profesional.UsuarioP.Telefono = Convert.ToInt32(TextBoxTelefono.Text);
                
                usuarioBLL.editarUsuario(profesional.UsuarioP); //GUARDO EL REGISTRO EN LAS TABLAS USUARIO Y PROFESIONAL              
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        protected void ButtonAgregarRubro_Click(object sender, EventArgs e)
        { 
            ProfesionalBLL profesionalBLL = new ProfesionalBLL();

            try
            {              
                int idRubro = Convert.ToInt32(DropDownListRubro.SelectedItem.Value);
                string email = Session["Usuario"].ToString();
                Int32 idProfesional = profesionalBLL.obtenerIdProfesional(email);
                
                profesionalBLL.agregarRubroProfesional(idRubro, idProfesional);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void LinkButtonVerSolicitud_Click1(object sender, EventArgs e)
        {
            string email = Session["Usuario"].ToString();
            //Session["Profesional"] = profesionalBLL.obtenerIdProfesional(email);
            Response.Redirect("ListaContratos_P.aspx");
        }
    }
}
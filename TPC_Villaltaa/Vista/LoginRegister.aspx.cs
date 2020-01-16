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
    public partial class LoginRegister : System.Web.UI.Page
    {
        //private List<Usuario> listadoUsuarios;
        Cliente cliente = new Cliente();
        Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonRegistro_Click(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            try
            {
                usuario = new Usuario();
                usuario.NombreUsuario = TextBoxNombre.Text;
                usuario.Email = TextBoxEmail.Text;
                usuario.Contrasenia = TextBoxPassword.Text;
                usuario.EstadoConexion = "Conectado";
                usuario.Estado = true;
                usuarioBLL.agregarUsuario(usuario);

                cliente = new Cliente();
                cliente.ValoracionC = 0;
                cliente.Estado = true;
                clienteBLL.agregarCliente(cliente);

                //AddLista();
                Response.Redirect("LoginRegister.aspx");

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}
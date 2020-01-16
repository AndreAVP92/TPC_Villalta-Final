<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="LoginRegister.aspx.cs" Inherits="Vista.LoginRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" >
 
<link href="HTML/estilos.css" rel="stylesheet" />   
    
<div class="body-login">

<h2>¿Buscas a tu handyman, qué esperas?</h2>
    <br />

    <div class="containerLogin" id="containerLogin">
        <div class="form-containerLogin Registro-containerLogin" <%--style="float: right"--%>>
                
            <h1  class="h1Login">Crear Cuenta</h1>
       
            <div class="social-container">
                <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
                <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
                <a href="#" class="social"><i class="fab fa-linkedin-in"></i></a>
            </div>
            <span>Usá tu mail para registrarse</span>
           <%-- <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
            <asp:TextBox ID="TextBoxNombre" class="In" runat="server">Nombre Usuario</asp:TextBox>
            <asp:TextBox ID="TextBoxEmail" class="In" runat="server">Email</asp:TextBox>
            <asp:TextBox ID="TextBoxPassword" class="In" runat="server">Password</asp:TextBox>

            <asp:Button ID="botonRegistro" CssClass="BT" runat="server" Text="Registrarse" OnClick="botonRegistro_Click"/>

        </div>


        <div class="form-containerLogin Login-container" <%--style="float: left"--%>>
            <%--<div class="h1-h1">--%>
                <h1 class="h1Login">Login</h1>
            <%--</div>--%>
            <div class="social-container">
                <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
                <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
                <a href="#" class="social"><i class="fab fa-linkedin-in"></i></a>
            </div>
            <span>o usá tu cuenta</span>

            <%--<label for="InputEmailCliente">Email</label>--%>
            <asp:TextBox ID="InputEmailCliente" class="In" type="email" runat="server">Email</asp:TextBox>

            <%--<label for="InputPasswordCliente">Password</label>--%>
            <asp:TextBox ID="InputPasswordCliente" class="In" type="password" runat="server">Password</asp:TextBox>
           
            <%--<input class="In" type="email" placeholder="Email" />
            <input class="In" type="password" placeholder="Password" />--%>
            <a href="#">Olvidaste tu contraseña?</a>
            <%--<button  ID="botonLogin" class="BT">LOGIN</button>--%>
            <asp:Button ID="botonLogin" CssClass="BT" runat="server" Text="Login" />           
        </div>
        <div class="overlay-container">
            <div class="overlay">
                <div class="overlay-panel overlay-left">
                    <h1>Bienvenido nuevamente!</h1>
                    <p>Para mantenerte conectado sólo logueate con tu cuenta </p>
                    <%--<button class="BT" id="login">Login</button>--%>
                    <asp:Button ID="login" CssClass="BT" class="ghost" runat="server" Text="Login" />
                </div>
                <div class="overlay-panel overlay-right">
                    <h1>Hola, Amigues!</h1>
                    <p>Ingresa tus datos personales y empezá a usar la app</p>
                    <%--<button class="BT" class="ghost" id="registro">Registrarse</button>--%>
                    <asp:Button ID="registro" CssClass="BT" class="ghost" runat="server" Text="Registrarse" />
                </div>
            </div>
        </div>
    </div>
</div>
    <script src="HTML/js/LoginRegister.js"></script>

</asp:Content>

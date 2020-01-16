<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vista._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<style>
.vl {
  border-left: 6px solid #0099cc;
  height: 300px;
  position: absolute;
  left: 50%;
  margin-left: -30px;
  margin-top: 150px;
  top: 20%;
}
</style>
    <div class="jumbotron">
        <h1>Bienvenido <asp:Label ID="username" runat="server" Text=""></asp:Label> al Portal Administrativo!</h1>
        <%--<h1>Bienvenido al Portal Administrativo</h1>   --%>    
    </div>

    <asp:Panel ID="Panel1" class="row" runat="server" Visible="true">
   <%-- <div class="row" >--%>
        <div class="col-md-6">
            <h2>Iniciar Sesión</h2>          
            <div class="form-group">
                <label for="InputEmailL">Email address</label>
                <asp:TextBox ID="InputEmailL" class="form-control" placeholder="Enter email" runat="server"></asp:TextBox>              
            </div>
            <div class="form-group">
                <label for="InputPasswordL">Password</label>
                <asp:TextBox ID="InputPasswordL" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
            </div>        
            <p>
                <asp:Button ID="ButtonLogin" class="btn btn-primary" runat="server" Text="Iniciar Sesión" onclick="ButtonLogin_Click"/>
            </p>
        </div>
        <div class="vl"></div>
        <div class="col-md-6">
            <h2>Registrarse</h2>
            <div class="form-group">
                <label for="InputNombreR">Nombre Usuario</label>
                <asp:TextBox ID="InputNombreR" class="form-control" placeholder="Enter name" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="InputEmailR">Email address</label>
                <asp:TextBox ID="InputEmailR" class="form-control" aria-describedby="emailHelpR" placeholder="Enter email" runat="server"></asp:TextBox>              
                <small id="emailHelpR" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>

            <div class="form-group">
                <label for="InputPasswordR">Password</label>
                <asp:TextBox ID="InputPasswordR" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
            </div>
            <p>
                <asp:Button ID="ButtonRegistro" class="btn btn-primary" runat="server" Text="Registrarse" onclick="ButtonRegistro_Click"/>               
            </p>
        </div>    
</asp:Panel>

    <asp:Panel ID="Panel2" class="dropdown" runat="server" Visible="false">
        <asp:Button ID="ButtonEmailAdmin" class="btn btn-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server" Text="" />       
        <div class="dropdown-menu" aria-labelledby="ButtonEmailAdmin">      
            <asp:LinkButton ID="HLSignOut" class="dropdown-item" runat="server" >Cerrar sesión</asp:LinkButton>
            <asp:LinkButton ID="HLMiPerfil" class="dropdown-item" runat="server" >Mi Perfil </asp:LinkButton>                         
        </div>
    </asp:Panel>

</asp:Content>

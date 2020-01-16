<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="BienvenidoCliente.aspx.cs" Inherits="Vista.BienvenidoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="HTML/estilos.css" rel="stylesheet" />   
   
    <%--<h1>BIENVENIDO <% = Session["Usuario"] %> ! </h1>--%>     
    <h1>BIENVENIDO <asp:Label ID="username" runat="server" Text=""></asp:Label> !</h1>      
    <%--<div class="dropdown">       
        
    </div> --%>
    <asp:Panel ID="Panel2" class="dropdown" runat="server">
        <asp:Button ID="ButtonEmailUser" class="btn btn-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server" Text="" />       
        <div class="dropdown-menu" aria-labelledby="ButtonEmailUser">      
            <asp:LinkButton ID="HLSignOut" class="dropdown-item" runat="server" OnClick="HLSignOut_Click">Cerrar sesión</asp:LinkButton>
            <asp:LinkButton ID="HLMiPerfil" class="dropdown-item" runat="server" Onclick="HLMiPerfil_Click">Mi Perfil </asp:LinkButton>
            <asp:LinkButton ID="LBBuscar" class="dropdown-item" runat="server" OnClick="LBBuscar_Click">Buscá a tu HandyMan</asp:LinkButton>
            <asp:HyperLink ID="HLFoto" class="dropdown-item" runat="server">Subir mi foto</asp:HyperLink>
            <asp:LinkButton ID="LBVerSolicitudes" class="dropdown-item" runat="server" OnClick="LBVerSolicitudes_Click">Mis Solicitudes</asp:LinkButton>
            <asp:LinkButton ID="LBReclamos" class="dropdown-item" runat="server" OnClick="LBReclamos_Click">Reclamos</asp:LinkButton>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel1" class="card" runat="server" style="width: 18rem;" Visible="false" >
        <img src="HTML/img/025-user.png" class="card-img-top" alt="userPic"/>
            <div class="card-body">
                <h5 class="card-title">MI PERFIL</h5>
                <asp:Label ID="LabelNombre" runat="server" Text="mostrar Nombre"></asp:Label> <hr />
                <asp:Label ID="LabelEmail"  runat="server" Text="mostrar Email"></asp:Label> <hr />
                <asp:Label ID="LabelValoracion" runat="server" Text="mostrar Valoracion"></asp:Label> <hr />
                <asp:Label ID="LabelFechaRegistro" runat="server" Text="mostrar Fecha de Registro"></asp:Label> <hr />                
                <asp:Button ID="ButtonOcultarPerfil" class="btn btn-primary" runat="server" Text="Ocultar" onClick="ButtonOcultarPerfil_Click"/>
            </div>
    </asp:Panel>
       
</asp:Content>

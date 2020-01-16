<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="BuscarHandyman.aspx.cs" Inherits="Vista.BuscarHandyman" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2> <% = Session["Usuario"] %> </h2>
    <h1>TE MOSTRAMOS LOS HANDYMANS DISPONIBLES DE TU ZONA</h1>

    <%--<h3>Buscar por Rubros: </h3>--%>
    <%--<asp:Label for="BusquedaxRubro" ID="Label1" runat="server"><h2>Buscar por Rubro:</h2></asp:Label>
    <asp:TextBox ID="BusquedaxRubro" runat="server"> No funciona, lo haré luego</asp:TextBox>--%>
    
    <hr />

<%--<asp:DropDownList runat="server" ID="cboRubros" />--%> 

    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
        <% foreach (var item in ListaProfesionales)
           { %>
                <div class="card">
                    <%--<img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">--%>
                    <img src="HTML/img/025-user.png">
                    <div class="card-body">                                       
                        <h5 class="card-title"><% = item.UsuarioP.NombreUsuario %></h5>
                        <p class="card-text">Cuit: <% = item.CuitCuil %></p>
                        <p class="card-text">Rubro: <% = item.Rubro.DescripcionR %></p>  <%-- Aquí tendría que hacer un foreach para los Rubros del profesional--%>
                        <p class="card-text">Valoración: <% = item.ValoracionP %></p>                       
                        <%--<p class="card-text">Estado: <% = item.UsuarioP.EstadoConexion %></p>--%>
                    </div>                   
                    <a class="btn btn-primary" href="VistaContrato.aspx?idprofesional=<% = item.IdProfesional.ToString()%>&cliente= <% = Session["IdCliente"].ToString() %>&rubro=<% = item.Rubro.DescripcionR%>">Seleccionar</a>                 
                </div>
                <br />
        <% } %>
    </div>

<asp:LinkButton href="indexCliente.aspx" ID="LinkButton1" runat="server"><h3>VOLVER AL PRINCIPIO</h3></asp:LinkButton>
       
</asp:Content>

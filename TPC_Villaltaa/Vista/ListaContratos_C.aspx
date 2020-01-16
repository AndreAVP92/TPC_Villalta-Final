<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ListaContratos_C.aspx.cs" Inherits="Vista.ListaContratos_C" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
    <%foreach (var item in ListaContratoC)
        { %>
        <div class="card">
            <img src="HTML/img/025-user.png">
            <div class="card-body">                                       
                <h5 class="card-title"><% = item.IdContrato %></h5>
                <%--<p class="card-text">Cliente: <% = item.Cliente.IdCliente %></p>--%>
                <p class="card-text">Profesional: <% = item.Profesional.IdProfesional %></p>  <%-- Aquí tendría que hacer un foreach para los Rubros del profesional--%>
               <%-- <p class="card-text">Rubro: <% = item.Profesional.Rubro.IdRubro %></p>                       
                <p class="card-text">Pago: <% = item.Pago.IdPago %></p>--%>
                <p class="card-text">Descripcion: <% = item.Descripcion %> </p>
                <p class="card-text">Direccion: <% = item.Direccion %> </p>
               <%-- <p class="card-text">Importe: <% = item.Importe %> </p>--%>
                <p class="card-text">Fecha Solicitud: <% = item.FechaContrato %> </p>
                <p class="card-text">Estado Contrato: <% = item.EstadoContrato.IdEstadoContrato %> </p>
            </div> 
            <a class="btn btn-primary" href="VerContrato_C.aspx?idcontrato=<% = item.IdContrato%>">Ver</a>                 
        </div>
    <%} %>
</div>

</asp:Content>

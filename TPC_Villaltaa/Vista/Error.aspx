<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Vista.Error" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>ERROR AL INICIAR SESIÓN o AL REGISTRARSE!</h1>
    <h4><% = Session["ErrorLogin"] %></h4>

    
</asp:Content>

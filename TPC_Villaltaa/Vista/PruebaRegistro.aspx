<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="PruebaRegistro.aspx.cs" Inherits="Vista.PruebaRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <label for="InputNombre">Nombre Usuario</label>
        <asp:TextBox ID="InputNombre" class="form-control" type="text" runat="server">Usuario</asp:TextBox>
    </div>

    <div class="form-group">
        <label for="InputEmail">Email address</label>
        <asp:TextBox ID="InputEmail" type="email" class="form-control" aria-describedby="emailHelp" runat="server">Email</asp:TextBox>
        <small id="emailHelp" class="form-text text-muted">No compartimos el mail a nadie.</small>
    </div>

    <div class="form-group">
        <label for="InputPassword">Password</label>
        <asp:TextBox ID="InputPassword" type="password" class="form-control" runat="server">Password</asp:TextBox>        
    </div>

    <asp:CheckBox ID="CheckBoxProfesional" runat="server" Text="¿Sos profesional?"/>
    <br /> <br />
    <asp:Button ID="ButtonRegistrarse" type="submit" class="btn btn-primary" runat="server" Text="Registrarse" onclick="ButtonRegistrarse_Click"/>

</asp:Content>

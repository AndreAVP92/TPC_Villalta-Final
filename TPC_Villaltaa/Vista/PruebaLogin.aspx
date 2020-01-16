<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="PruebaLogin.aspx.cs" Inherits="Vista.PruebaLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<div class="form-group">
        <label for="InputEmail">Email address</label>
        <asp:TextBox ID="InputEmail" type="email" class="form-control" aria-describedby="emailHelp" runat="server">Email</asp:TextBox>
        <small id="emailHelp" class="form-text text-muted">No compartimos el mail a nadie.</small>
    </div>

    <div class="form-group">
        <label for="InputPassword">Password</label>
        <asp:TextBox ID="InputPassword" type="password" class="form-control" runat="server">Password</asp:TextBox>        
    </div>
 
    <asp:Button ID="ButtonLogin" type="submit" class="btn btn-primary" runat="server" Text="LogIn" onClick="ButtonLogin_Click" />

</asp:Content>

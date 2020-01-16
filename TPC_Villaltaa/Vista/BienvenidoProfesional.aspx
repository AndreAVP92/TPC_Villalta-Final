<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="BienvenidoProfesional.aspx.cs" Inherits="Vista.BienvenidoProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<link href="HTML/estilos.css" rel="stylesheet" /> 
<style> 
        .flex-container {
            display: -webkit-flex;
            display: flex;
        }      
</style> 
    <h1>BIENVENIDO <% = Session["Usuario"] %> ! </h1>     
    
    <div class="dropdown">       
        <asp:Button ID="ButtonEmailUser" class="btn btn-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server" Text="" />       
        <div class="dropdown-menu" aria-labelledby="ButtonEmailUser">      
            <asp:LinkButton ID="HLSignOut" class="dropdown-item" runat="server" OnClick="HLSignOut_Click">Cerrar sesión</asp:LinkButton>
            <asp:LinkButton ID="HLActualizarPerfil" class="dropdown-item" runat="server" OnClick="HLActualizarPerfil_Click">Actualizar Perfil</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonVerSolicitud" class="dropdown-item" runat="server" OnClick="LinkButtonVerSolicitud_Click1">Ver Solicitudes</asp:LinkButton>
            <asp:HyperLink ID="HLFoto" class="dropdown-item" runat="server">Subir mi foto</asp:HyperLink>                    
        </div>
    </div>
    <asp:Panel ID="PanelVerPerfil" class="card" runat="server" style="width: 18rem;" Visible="false" >
        <img src="HTML/img/025-user.png" class="card-img-top" alt="userPic"/>
            <div class="card-body">
                <h5 class="card-title">MI PERFIL</h5>
                <asp:Label ID="LabelNombre" runat="server" Text="mostrar Nombre"></asp:Label> <hr />
                <asp:Label ID="LabelCuit"  runat="server" Text="mostrar Cuit"></asp:Label> <hr />
                <asp:Label ID="LabelEmail"  runat="server" Text="mostrar Email"></asp:Label> <hr />
                <asp:Label ID="LabelValoracion" runat="server" Text="mostrar Valoracion"></asp:Label> <hr />
                <asp:Label ID="LabelFechaRegistro" runat="server" Text="mostrar Fecha de Registro"></asp:Label> <hr />                
                <asp:Button ID="ButtonOcultarPerfil" class="btn btn-primary" runat="server" Text="Ocultar" onclick="ButtonOcultarPerfil_Click"/>
            </div>
    </asp:Panel>

    <asp:Panel ID="PanelCargarDatos" runat="server" Visible="false">       
       
        <img src="HTML/img/025-user.png" class="card-img-top" alt="userPic"/>
        
        <div class="form-group row">
            <label for="Nombre" class="col-sm-2 col-form-label">Nombre</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxNombre" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group mb-2">
            <label for="Rubros" class="col-sm-2 col-form-label">Rubro</label>
            <div class="form-group mx-sm-3 mb-2">
                <asp:DropDownList ID="DropDownListRubro" runat="server" class="form-control"></asp:DropDownList>
                <asp:Button ID="ButtonAgregarRubro" runat="server" class="btn btn-primary mb-2" Text="Agregar" OnClick="ButtonAgregarRubro_Click" />              
            </div> 
           
        </div>
 
        <fieldset disabled>
        <div class="form-group row">
            <label for="inputEmail" class="col-sm-2 col-form-label">Email</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxEmail" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>

        <div class="form-group row">
            <label for="inputPassword" class="col-sm-2 col-form-label">Contraseña</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxContrasenia" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label for="inputCuit" class="col-sm-2 col-form-label">Cuit</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxCuit" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label for="inputTelefono" class="col-sm-2 col-form-label">Teléfono</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxTelefono" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>

        <fieldset disabled>
        <div class="form-group row">       
            <label for="TextBoxFecha" class="col-sm-2 col-form-label">Fecha Registro</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxFecha" runat="server" class="form-control" ></asp:TextBox>  
            </div>
        </div>
        </fieldset>

        <div class="form-group row">
            <div class="col-sm-10" style="text-align:center">
                <asp:Button ID="ButtonGuardar" runat="server" class="btn btn-primary" Text="Guardar" OnClick="ButtonGuardar_Click"/>
            </div>
        </div>
        
    </asp:Panel>

</asp:Content>

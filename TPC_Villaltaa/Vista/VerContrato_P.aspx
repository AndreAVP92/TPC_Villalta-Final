<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="VerContrato_P.aspx.cs" Inherits="Vista.VerContrato_P" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelContrato" runat="server" Visible="true">       
       
        <img src="HTML/img/025-user.png" class="card-img-top" alt="profesionalPic"/>
          
        <fieldset disabled>
        <div class="form-group row">
            <label for="idContrato" class="col-sm-2 col-form-label">ID Contrato</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxIDContrato" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>

        <fieldset disabled>
        <div class="form-group row">
            <label for="inputNombreC" class="col-sm-2 col-form-label">Cliente</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxCliente" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>

        <fieldset disabled>
        <div class="form-group row">
            <label for="inputNombreP" class="col-sm-2 col-form-label">Profesional</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxProfesional" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>

        <fieldset disabled>
        <div class="form-group row">
            <label for="inputCuit" class="col-sm-2 col-form-label">CUIT</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxCuit" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>

        <fieldset disabled>
        <div class="form-group row">
            <label for="inputRubro" class="col-sm-2 col-form-label">Rubro</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxRubro" runat="server" class="form-control"></asp:TextBox>
            </div>          
        </div>
        </fieldset>

        <fieldset disabled>
        <div class="form-group row">
            <label for="inputTelefono" class="col-sm-2 col-form-label">Teléfono</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxTelefono" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>

        <fieldset disabled>
        <div class="form-group row">
            <label for="inputPago" class="col-sm-2 col-form-label">Pago</label>
            <div class="col-sm-10">
                 <asp:TextBox ID="TextBoxPago" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>
        
         <fieldset disabled>
        <div class="form-group row">
            <label for="inputDescripcion" class="col-sm-2 col-form-label">Descripción</label>
            <div class="col-sm-10">             
                <asp:TextBox ID="TextBoxDescripcion" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>

        <fieldset disabled>
        <div class="form-group row">
            <label for="inputDireccion" class="col-sm-2 col-form-label">Dirección</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxDireccion" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>
        
        <div class="form-group row">
            <label for="inputImporte" class="col-sm-2 col-form-label">Importe</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxImporte" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        
        <fieldset disabled>
        <div class="form-group row">
            <label for="inputEstadoContrato" class="col-sm-2 col-form-label">Estado</label>
            <div class="col-sm-10">
                <asp:TextBox ID="TextBoxEstadoContrato" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        </fieldset>
   
        <div class="form-group row">
            <div class="col-sm-10" style="text-align:center">
                <asp:Button ID="ButtonRechazar" runat="server" class="btn btn-primary" Text="Rechazar"/>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-10" style="text-align:center">
                <asp:Button ID="ButtonEnviarPresupuesto" runat="server" class="btn btn-primary" Text="Enviar Presupuesto" OnCommand="ButtonEnviarPresupuesto_Command"/>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-10" style="text-align:center">
                <asp:Button ID="ButtonConfirmar" runat="server" class="btn btn-primary" Text="Re-Confirmar" Visible="false" OnClick="ButtonConfirmar_Click"/>
            </div>
        </div>
        
        <div class="form-group row">
            <div class="col-sm-10" style="text-align:center">
                <asp:Button ID="ButtonTerminado" runat="server" class="btn btn-primary" Text="Trabajo Finalizado" Visible="false" OnClick="ButtonTerminado_Click"/>
            </div>
        </div>      
      
        <div class="form-group row">
            <div class="col-sm-10" style="text-align:center">
                <asp:Button ID="ButtonValorar" runat="server" class="btn btn-primary" Text="Valorar Cliente" Visible="false"/>
            </div>
        </div>

    </asp:Panel>
</asp:Content>

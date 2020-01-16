<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ListarReclamos_C.aspx.cs" Inherits="Vista.ListarReclamos_C" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<link href="ABMstyles.css" rel="stylesheet" />

<script type="text/javascript">
$(document).ready(function(){
	// Activate tooltip
	$('[data-toggle="tooltip"]').tooltip();
	
	// Select/Deselect checkboxes
	var checkbox = $('table tbody input[type="checkbox"]');
	$("#selectAll").click(function(){
		if(this.checked){
			checkbox.each(function(){
				this.checked = true;                        
			});
		} else{
			checkbox.each(function(){
				this.checked = false;                        
			});
		} 
	});
	checkbox.click(function(){
		if(!this.checked){
			$("#selectAll").prop("checked", false);
		}
	});
});
</script>

<div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-6">
						<h2><b>Mis Reclamos</b></h2>
					</div>
					<div class="col-sm-6">
						<a href="#addReclamo" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Agregar Reclamo</span></a>				
					</div>
                </div>
            </div>             			
        </div>
</div>
<div ID="addReclamo" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">				
					<div class="modal-header">						
						<h4 class="modal-title">Hacer Reclamo</h4>
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					</div>
					<div class="modal-body">					
						<div class="form-group">
							<label for="InputDescripcion">Motivo</label>
                            <asp:TextBox ID="TextBoxMotivo" type="text" class="form-control" UseSubmitBehavior="false" runat="server" ></asp:TextBox>
						</div>					
					</div>                     
					<div class="modal-footer">		
                        <asp:Button ID="ButtonCancelar" class="btn btn-danger" data-dismiss="modal" runat="server" Text="Cancelar" />                  
                        <asp:Button ID="ButtonAltaPago" CssClass="btn btn-warning" runat="server" Text="Agregar" UseSubmitBehavior="false" EnableViewState="true" Onclick="ButtonAltaPago_Click"/>                        
					</div>				
			</div>
		</div>
</div>

<div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
    <%foreach (var item in ListaReclamoC)
        { %>
        <div class="card">
            <img src="HTML/img/025-user.png">
            <div class="card-body">                                       
                <h5 class="card-title"><% = item.IdReclamo %></h5>
                <p class="card-text">N° Contrato: <% = item.Contrato.IdContrato %></p>
                <p class="card-text">Profesional: <% = item.Contrato.Profesional.UsuarioP.NombreUsuario %></p>                
                <p class="card-text">Cuit: <% = item.Contrato.Profesional.CuitCuil %></p>
                <p class="card-text">Motivo: <% = item.Motivo %> </p>
                <p class="card-text">Fecha Reclamo: <% = item.FechaReclamo %> </p>
                <p class="card-text">Estado Contrato: <% = item.Estado %> </p>
            </div>            
            <a class="btn btn-primary" href="VerReclamo_C.aspx?idreclamo=<% = item.IdReclamo%>">Ver</a>                 
        </div>
    <%} %>
</div>
  
</asp:Content>

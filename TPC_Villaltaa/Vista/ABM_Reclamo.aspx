<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM_Reclamo.aspx.cs" Inherits="Vista.ABM_Reclamo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<link href="ABMstyles.css" rel="stylesheet" />

<script type="text/javascript">
    $(document).ready(function () {
        // Activate tooltip
        $('[data-toggle="tooltip"]').tooltip();

        // Select/Deselect checkboxes
        var checkbox = $('table tbody input[type="checkbox"]');
        $("#selectAll").click(function () {
            if (this.checked) {
                checkbox.each(function () {
                    this.checked = true;
                });
            } else {
                checkbox.each(function () {
                    this.checked = false;
                });
            }
        });
        checkbox.click(function () {
            if (!this.checked) {
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
						<h2><b>Reclamos</b></h2>
					</div>
					<div class="col-sm-6">
						<a href="#addReclamo" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Agregar Reclamo</span></a>
						<a href="#deleteReclamo" class="btn btn-danger" data-toggle="modal"><i class="material-icons">&#xE15C;</i> <span>Eliminar Reclamo</span></a>						
					</div>
                </div>
            </div>    
            <table class="table table-striped table-hover">
                <thead>
                    <tr>                       
                        <th>ID RECLAMO</th>
                        <th>ID CONTRATO</th>
                        <th>MOTIVO</th>
                        <th>FECHA RECLAMO</th>
                        <th>ESTADO</th>
                  </tr>
                </thead>
                <tbody>
                     <%foreach (var item in ListaReclamos)
                    { %>  
                    <tr>                                                                                                       
                        <th><% = item.IdReclamo %></th>
                        <th><% = item.Contrato.IdContrato %></th>
                        <th><% = item.Motivo %></th>
                        <th><% = item.FechaReclamo %></th>
                        <th><% = item.Estado %></th>
                        <th>   
                            <%--<a href="ABM_Pago.aspx?idpago=<% = item.IdPago%>" class="edit"  data-toggle="modal" data-target="#editPago"><i class="material-icons" data-toggle="tooltip" title="Editar">&#xE254;</i></a>--%>
                            <a href="#deletePago" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Eliminar">&#xE872;</i></a>
                            <a href="#" class="edit" data-toggle="modal" data-target="#editPago"><i class="material-icons" data-toggle="tooltip" title="Editar">&#xE254;</i></a>                           
                        </th>                                                                    
                    </tr>
                    <%} %> 
                </tbody>
            </table>			
        </div>
</div>

<!-- Add Modal HTML -->
	<div ID="addReclamo" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">			
					<div class="modal-header">						
						<h4 class="modal-title">Agregar Pago</h4>
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					</div>

					<div class="modal-body">					
						<div class="form-group">                           
                            <label for="InputDescripcion">Descripción</label>
                            <asp:TextBox ID="InputDescripcion" type="text" class="form-control" runat="server" ></asp:TextBox>                          
						</div>					
					</div>
                      
					<div class="modal-footer">		
                        <asp:Button ID="ButtonCancelar" class="btn btn-danger" data-dismiss="modal" runat="server" Text="Cancelar" />               
                        <asp:Button ID="ButtonAddPago" CssClass="btn btn-warning" runat="server" Text="Agregar" AutoPostBack="true" EnableViewState="true" UseSubmitBehavior="false"/>                        
					</div>				
			</div>
		</div>
	</div>
	<!-- Editar Modal HTML -->
	<div id="editReclamo" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
					<div class="modal-header">						
						<h4 class="modal-title">Editar Rubro</h4>
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					</div>
					<div class="modal-body">					
						<div class="form-group">
                            <label>ID</label>
                            <asp:TextBox ID="TextBoxID" type="text" class="form-control" runat="server"></asp:TextBox>
							<label>Descripción</label>
							<asp:TextBox ID="TextBoxDescripcion" type="text" class="form-control" runat="server" ></asp:TextBox> 
						</div>				
					</div>
					<div class="modal-footer">						
                        <asp:Button ID="ButtonCancelarEditar" class="btn btn-default" data-dismiss="modal" runat="server" Text="Cancelar" />
						<asp:Button ID="ButtonGuardarEditar" class="btn btn-info" runat="server" Text="Guardar" AutoPostBack="true" EnableViewState="true" UseSubmitBehavior="false"/>
					</div>
			</div>
		</div>
	</div>
	<!-- Eliminar Modal HTML -->
	<div id="deleteReclamo" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<%--<form>--%>
					<div class="modal-header">						
						<h4 class="modal-title">Eliminar Reclamo</h4>
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					</div>
					<div class="modal-body">					
						<p>¿Seguro que desea eliminar?</p>
						<p class="text-warning"><small>Ojo eh!</small></p>
					</div>
					<div class="modal-footer">
                        <asp:Button ID="ButtonCancelarEliminar" class="btn btn-default" data-dismiss="modal" runat="server" Text="Cancelar"/>
						<asp:Button ID="ButtonEliminar" class="btn btn-danger" runat="server" Text="Eliminar" AutoPostBack="true" EnableViewState="true" UseSubmitBehavior="false"/>					
					</div>
				<%--</form>--%>
			</div>
		</div>
	</div>


</asp:Content>

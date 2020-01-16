<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM_Pago.aspx.cs" Inherits="Vista.ABM_Pago" %>

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
						<h2><b>Pagos</b></h2>
					</div>
					<div class="col-sm-6">
						<a href="#addPago" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Agregar Pago</span></a>
						<a href="#deletePago" class="btn btn-danger" data-toggle="modal"><i class="material-icons">&#xE15C;</i> <span>Eliminar Pago</span></a>						
					</div>
                </div>
            </div>    
            <table id="tablapago" class="table table-striped table-hover">
                <thead>
                    <tr>                       
                        <th>ID</th>
                        <th>DESCRIPCION</th>
                        <th>ESTADO</th>
                  </tr>
                </thead>
                <tbody>
                     <%foreach (var item in ListaPagos)
                    { %>  
                    <tr>                                                                                                       
                        <th><% = item.IdPago %></th>
                        <th><% = item.DescripcionP %></th>
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
	<div ID="addPago" class="modal fade">
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
                        <asp:Button ID="ButtonAddPago" CssClass="btn btn-warning" runat="server" Text="Agregar" AutoPostBack="true" EnableViewState="true" UseSubmitBehavior="false" Onclick="ButtonAddPago_Click"/>                        
					</div>				
			</div>
		</div>
	</div>
	<!-- Editar Modal HTML -->
	<div id="editPago" class="modal fade">
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
						<asp:Button ID="ButtonGuardarEditar" class="btn btn-info" runat="server" Text="Guardar" AutoPostBack="true" EnableViewState="true" UseSubmitBehavior="false" OnClick="ButtonGuardarEditar_Click"/>
					</div>
			</div>
		</div>
	</div>
	<!-- Eliminar Modal HTML -->
	<div id="deletePago" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<%--<form>--%>
					<div class="modal-header">						
						<h4 class="modal-title">Eliminar Rubro</h4>
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

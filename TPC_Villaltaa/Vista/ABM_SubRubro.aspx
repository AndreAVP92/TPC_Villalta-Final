<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM_SubRubro.aspx.cs" Inherits="Vista.ABM_SubRubro" %>
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

<%--<body>--%>
    <div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-6">
						<h2><b>Sub Rubros</b></h2>
					</div>
					<div class="col-sm-6">
						<a href="#addSubRubro" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Agregar SubRubro</span></a>
						<a href="#deleteSubRubro" class="btn btn-danger" data-toggle="modal"><i class="material-icons">&#xE15C;</i> <span>Eliminar Todo</span></a>						
					</div>
                </div>
            </div>    
            <table class="table table-striped table-hover">
                <%--<thead>
                    <tr>
                        <th> <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label> </th>
                        <th> <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label> </th>
                        <th> <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label> </th>
                        <%--<th>ID</th>
                        <th>Descripcion</th>
                        <th>Estado</th>
                  </tr>
                </thead>--%>
                <tbody>
                    <%--<tr> --%>                                                                       
                        <asp:GridView ID="tablaSubRubros" class="table table-bordered table-condensed table-hover" runat="server" DataKeyNames="IdSubRubro"  OnRowDeleting="tablaSubRubros_RowDeleting"
                                                                                                                                                             OnRowEditing="tablaSubRubros_RowEditing"
                                                                                                                                                             OnRowCancelingEdit="tablaSubRubros_RowCancelingEdit"
                                                                                                                                                             OnRowUpdating="tablaSubRubros_RowUpdating">
                            <Columns>
                                <asp:CommandField CancelImageUrl="~/HTML/img/003-detener.png" DeleteImageUrl="~/HTML/img/002-basura.png" EditImageUrl="~/HTML/img/004-editar.png" ShowDeleteButton="True" ShowEditButton="True" UpdateImageUrl="~/HTML/img/020-save.png" UpdateText="Guardar" ButtonType="Image"></asp:CommandField>
                            </Columns>       
                        </asp:GridView>
                                <%--<asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" UpdateImageUrl="HTML/img/020-save.png" CancelImageUrl="HTML/img/003-detener.png" DeleteImageUrl="HTML/img/002-basura.png" EditImageUrl="HTML/img/004-editar.png"></asp:CommandField>--%>
                                          
                        <%--<td>
                            <a href="#editSubRubro" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Editar">&#xE254;</i></a>
                            <a href="#deleteSubRubro" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Eliminar">&#xE872;</i></a>
                        </td>--%>
                   <%--</tr>--%>
                </tbody>
            </table>
			<div class="clearfix">
                <div class="hint-text">Showing <b>1</b> out of <b>25</b> entries</div>
                <ul class="pagination">
                    <li class="page-item disabled"><a href="#">Anterior</a></li>
                    <li class="page-item active"><a href="#" class="page-link">1</a></li>
                    <li class="page-item"><a href="#" class="page-link">2</a></li>
                    <li class="page-item"><a href="#" class="page-link">3</a></li>
                    <li class="page-item"><a href="#" class="page-link">Siguiente</a></li>
                </ul>
            </div>
        </div>
    </div>

	<!-- Add Modal HTML -->
	<div ID="addSubRubro" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">			
					<div class="modal-header">						
						<h4 class="modal-title">Agregar SubRubro</h4>
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					</div>

					<div class="modal-body">					
						<div class="form-group">
							<label for="InputDescripcion">Descripción</label>
                            <asp:TextBox ID="InputDescripcion" type="text" class="form-control" runat="server" ></asp:TextBox>
                            <label for="DropDownListRubros">Elija Rubro correspondiente</label>
                            <asp:DropDownList ID="DropDownListRubros" class="form-control" runat="server"></asp:DropDownList>                           
						</div>					
					</div>
                      
					<div class="modal-footer">		
                        <asp:Button ID="ButtonCancelar" class="btn btn-danger" data-dismiss="modal" runat="server" Text="Cancelar" />               
                        <asp:Button ID="ButtonAddSubRubro" CssClass="btn btn-warning" runat="server" Text="Agregar" AutoPostBack="true" EnableViewState="true" UseSubmitBehavior="false" OnClick="ButtonAddSubRubro_Click"/>                        
					</div>				
			</div>
		</div>
	</div>
	<!-- Editar Modal HTML -->
	<div id="editSubRubro" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<%--<form>--%>
					<div class="modal-header">						
						<h4 class="modal-title">Editar Rubro</h4>
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					</div>
					<div class="modal-body">					
						<div class="form-group">
							<label>Descripción</label>
							<input type="text" class="form-control" required>
						</div>				
					</div>
					<div class="modal-footer">						
                        <asp:Button ID="ButtonCancelarEditar" class="btn btn-default" data-dismiss="modal" runat="server" Text="Cancelar" />
						<asp:Button ID="ButtonGuardarEditar" class="btn btn-info" runat="server" Text="Guardar" />
                        <%--<input type="submit" class="btn btn-info" value="Guardar">--%>
					</div>
				<%--</form>--%>
			</div>
		</div>
	</div>
	<!-- Eliminar Modal HTML -->
	<div id="deleteSubRubro" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<%--<form>--%>
					<div class="modal-header">						
						<h4 class="modal-title">Eliminar todos los registros</h4>
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					</div>
					<div class="modal-body">					
						<p>Seguro que desea eliminar todos los registros de SubRubro?</p>
						<p class="text-warning"><small>Ojo eh!</small></p>
					</div>
					<div class="modal-footer">
                        <asp:Button ID="ButtonCancelarEliminar" class="btn btn-default" data-dismiss="modal" runat="server" Text="Cancelar"/>
						<asp:Button ID="ButtonEliminar" class="btn btn-danger" runat="server" Text="Eliminar"/>					
					</div>
				<%--</form>--%>
			</div>
		</div>
	</div>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM_Rubro.aspx.cs" Inherits="Vista.ABM_Rubro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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

<%--<body>--%>
    <div class="container">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-6">
						<h2><b>Rubros</b></h2>
					</div>
					<div class="col-sm-6">
						<a href="#addRubro" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Agregar Nuevo Rubro</span></a>
						<a href="#deleteRubro" class="btn btn-danger" data-toggle="modal"><i class="material-icons">&#xE15C;</i> <span>Eliminar Todo</span></a>						
					</div>
                </div>
            </div>                                                                       
                        <asp:GridView ID="tablaRubros" class="table table-bordered table-condensed table-hover" runat="server" OnRowCancelingEdit="Cancelar" OnRowDeleting="Eliminar" OnRowEditing="Editar" OnRowUpdating="Actualizar" AutoGenerateColumns="false" DataKeyNames="IdRubro">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelIdRubro" runat="server" Text='<% #Bind("IdRubro") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <asp:Label ID="LabelIdRubro" runat="server" Text='<% #Bind("IdRubro") %>'></asp:Label>
                                    </EditItemTemplate> --%>    
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="DESCRIPCION">
                                <ItemTemplate>
                                        <asp:Label ID="LabelDescripcion" runat="server" Text='<% #Bind("DescripcionR") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxDescripcion" runat="server" Text='<% #Bind("DescripcionR") %>'></asp:TextBox>                                       
                                    </EditItemTemplate>
                                </asp:TemplateField>  

                                <asp:TemplateField HeaderText="ESTADO">
                                <ItemTemplate>
                                        <asp:Label ID="LabelEstado" runat="server" Text='<% #Bind("Estado") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBoxEstado" runat="server" Text='<% #Bind("Estado") %>' />     
                                    </EditItemTemplate>
                                </asp:TemplateField> 
                                
                                <asp:CommandField   ButtonType="Image" 
                                                    DeleteImageUrl="HTML/img/002-basura.png"
                                                    EditImageUrl="HTML/img/004-editar.png" 
                                                    UpdateImageUrl="HTML/img/020-save.png"
                                                    CancelImageUrl="HTML/img/003-detener.png"
                                                    ShowCancelButton="true" ShowDeleteButton="true" ShowEditButton="true" />  
                            </Columns>
                        </asp:GridView>
    
                        <%--<td>
                            <a href="#editRubro" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Editar">&#xE254;</i></a>
                            <a href="#deleteRubro" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Eliminar">&#xE872;</i></a>
                        </td>--%>
                   <%--</tr>--%>
               <%-- </tbody>--%>
            <%--</table>--%>
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
	<div ID="addRubro" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				
					<div class="modal-header">						
						<h4 class="modal-title">Agregar Rubro</h4>
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
                        <asp:Button ID="ButtonAltaRubro" CssClass="btn btn-warning" runat="server" Text="Agregar" UseSubmitBehavior="false" onClick="ButtonAltaRubro_Click"/>                        
					</div>				
			</div>
		</div>
	</div>
	<!-- Editar Modal HTML -->
	<div id="editRubro" class="modal fade">
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
	<div id="deleteRubro" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<%--<form>--%>
					<div class="modal-header">						
						<h4 class="modal-title">Eliminar todos los registros</h4>
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
					</div>
					<div class="modal-body">					
						<p>Seguro que desea eliminar todos los registros de Rubro?</p>
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

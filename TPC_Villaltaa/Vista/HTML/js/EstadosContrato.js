function templateRow() {
    var template = "<tr>";

    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += "</tr>";
    return template;
}

function addRowDataTable() {
    var template = templateRow();
    for (var i = 0; i < 10; i++) {
        $("#tbl_body_table").append(template);
    }
}

function addRowDT(data) {
    var tabla = $("tbl_EstadosContrato").DataTable();
    for (var i = 0; i < data.length; i++){
        tabla.fnAddData([
            data[i].IdEstadoContrato,
            data[i].Descripcion,
            data[i].Estado
        ]);
    }
}

//addRowDataTable();

function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "ABM_EstadoContrato.aspx/ListadoEC",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            addRowDR(data.d);
        }
    });
}

// Llamando a la funcion Ajax al cargar el doc

function updateDataAjax() {

    var obj = JSON.stringify({ id: JSON.stringify(data[0]), direccion: $("#txtDescripcion").val() });

    $.ajax({
        type: "POST",
        url: "ABM_Pago.aspx/ActualizarPago",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',-
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            console.log(response);

        }
    });
}
//evento click para boton actualizar
$("#btnactualizar").click(function (e)){
    e.preventDefault();
}


sendDataAjax();
// 1. Capturar los registros de una fila en la tabla, para pasarlos al ModalActualizar
function seleccionarRegistroTabla(e, id, cantidadProducto, valorVenta, trabajador, cliente, inventario, fecha) {

    var selectedRow = $(e);
    var selectedRowGlobal = $(selectedRow[0].parentElement);
    selectedRowGlobal = selectedRowGlobal.find(".selected");

    if (selectedRowGlobal.find(".selected")) {
        selectedRowGlobal.removeClass("selected");
    }

    selectedRow.addClass("selected");

    $('#btn-update').removeAttr('hidden');
    $('#btn-delete').removeAttr('hidden');
    $('#btn-const').removeAttr('hidden');

    // esto es para mostrar los valores en el ModalActualizar
    document.getElementById("idUpdate").value = id;
    document.getElementById("cantidadProductoUpdate").value = cantidadProducto;
    document.getElementById("valorVentaUpdate").value = valorVenta;
    document.getElementById("trabajadorUpdate").value = trabajador;
    document.getElementById("clienteUpdate").value = cliente;
    document.getElementById("inventarioUpdate").value = inventario;
    document.getElementById("fechaUpdate").value = fecha;
}

$().ready(function() {

    $("#btn-update-modal").click(function() {

        // Enviar petición AJAX datos JSON
        var venta = { "Id": $("#idUpdate").val(), 
        "Inventario": $("#inventarioUpdate").val(), 
        "CantidadProducto": $("#cantidadProductoUpdate").val(), 
        "ValorVenta": $("#valorVentaUpdate").val(), 
        "Trabajador": $("#trabajadorUpdate").val(), 
        "Cliente": $("#clienteUpdate").val() };

        $.ajax({
                type: "POST",
                url: "/GestionVentas/Ventas?handler=UpdateJson",
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                headers: {
                    "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
                },
                data: JSON.stringify(venta),
            })
            .done(function(result) {
                alert(result);
                location.reload();
            })
            .fail(function(error) {
                alert(error);
            });
    });
});

$().ready(function() {

    $("#btn-update-modal-pro").click(function() {

        // Enviar petición AJAX datos JSON
        var venta = { "IdVentaUpdate": $("#idVentaUpdate").val(), "CantidadProductoUpdate": $("#cantidadProductoUpdate").val(), "ValorVentaUpdate": $("#valorVentaUpdate").val(), "TrabajadorVentaUpdate": $("#trabajadorVentaUpdate").val(), "ClienteVentaUpdate": $("#clienteVentaUpdate").val(), "InventarioVentaUpdate": $("#inventarioVentaUpdate").val() };

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

function seleccionarRegistroVentas(e, id, cantidadProducto, valorVenta, trabajador, cliente, inventario) {

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

    document.getElementById("idVentaUpdate").value = id;
    document.getElementById("cantidadProductoUpdate").value = cantidadProducto;
    document.getElementById("valorVentaUpdate").value = valorVenta;
    document.getElementById("trabajadorVentaUpdate").value = trabajador;
    document.getElementById("clienteVentaUpdate").value = cliente;
    document.getElementById("inventarioVentaUpdate").value = inventario;
}
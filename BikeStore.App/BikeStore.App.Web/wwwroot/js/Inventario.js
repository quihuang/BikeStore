// 1. Capturar los registros de una fila en la tabla, para pasarlos al ModalActualizar
function seleccionarRegistroTabla(e, id, productoId, existencias, numerorefcompra, preciouniventa, preciounicompra) {

    var selectedRow = $(e);
    var selectedRowGlobal = $(selectedRow[0].parentElement);
    selectedRowGlobal = selectedRowGlobal.find(".selected");

    if (selectedRowGlobal.find(".selected")) {
        selectedRowGlobal.removeClass("selected");
    }

    selectedRow.addClass("selected");

    $('#btn-update').removeAttr('hidden');
    $('#btn-delete').removeAttr('hidden');

    // Tomamos los parametros y se los asignamos a los campos del ModalActualizar para mostrarlos en Frontend
    document.getElementById("idUpdate").value = id;
    document.getElementById("productoUpdate").value = productoId;
    document.getElementById("existenciasUpdate").value = existencias;
    document.getElementById("numeroRefCompraUpdate").value = numerorefcompra;
    document.getElementById("precioUniVentaUpdate").value = preciouniventa;
    document.getElementById("precioUniCompraUpdate").value = preciounicompra;
}

// 2. Luego de modificar los campos en el ModalActualizar, al dar clic en el botón Actualizar se envia a la DB
$().ready(function() {

    $("#btn-update-modal").click(function() {

        //debugger;

        /* Enviar petición AJAX datos JSON */
        // Tomamos los campos del ModalActualizar para crear un objeto para enviarlo a la DB
        var inventario = { "Id": $("#idUpdate").val(), "ProductoId": $("#productoUpdate").val(), "Existencias": $("#existenciasUpdate").val(), "NumeroRefCompra": $("#numeroRefCompraUpdate").val(), "PrecioUniVenta": $("#precioUniVentaUpdate").val(), "PrecioUniCompra": $("#precioUniCompraUpdate").val() };

        $.ajax({
                type: "POST",
                url: "/GestionInventario/Inventario?handler=UpdateJson",
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                headers: {
                    "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
                },
                data: JSON.stringify(producto),
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

// función para limpiar el modal de Crear
function crear(text) {

    document.getElementById("producto").value = "";
    document.getElementById("existencias").value = "";
    document.getElementById("numerorefcompra").value = "";
    document.getElementById("preciouniventa").value = "";
    document.getElementById("preciounicompra").value = "";

    document.getElementById("titleModal").innerHTML = "Registro " + text;
    document.getElementById("btn-create-modal").innerHTML = "Crear";

}
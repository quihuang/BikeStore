// 1. Capturar los registros de una fila en la tabla, para pasarlos al ModalActualizar
function seleccionarRegistroTabla(e, id, productoId, existencias, numerorefcompra, preciouniventa, preciounicompra) {

    var selectedRow = $(e);
    var selectedRowGlobal = $(selectedRow[0].parentElement);
    selectedRowGlobal = selectedRowGlobal.find(".selected");

    if (selectedRowGlobal.find(".selected")) {
        selectedRowGlobal.removeClass("selected");
    }

    selectedRow.addClass("selected");

    debugger;

    var selectOption = $('.productoUpdateId');

    selectOption.removeAttr('selected');

    // debugger;

    $('#btn-const').removeAttr('hidden');
    $('#btn-delete').removeAttr('hidden');
    $('#btn-update').removeAttr('hidden');

    // Tomamos los parametros y se los asignamos a los campos del ModalActualizar para mostrarlos en Frontend
    document.getElementById("idUpdate").value = id;
    debugger
    $('#productoUpdateId-' + productoId).attr('selected', true);
    document.getElementById("existenciasUpdate").value = existencias;
    document.getElementById("numeroRefCompraUpdate").value = numerorefcompra;
    document.getElementById("precioUniVentaUpdate").value = preciouniventa;
    document.getElementById("precioUniCompraUpdate").value = preciounicompra;
}
// 2. Luego de modificar los campos en el ModalActualizar, al dar clic en el botón Actualizar se envia a la DB

// // funciones de JQUERY
$().ready(function() {

    // // Peticion AJAX para Actualizar
    $("#btn-update-modal").click(function() {

        /* Enviar petición AJAX datos JSON */
        // Tomamos los campos del ModalActualizar para crear un objeto para enviarlo a la DB
        var paquete = {
            "Id": parseInt($("#idUpdate").val()),
            "ProductoId": $("#productoUpdate").val(),
            "Existencias": $("#existenciasUpdate").val(),
            "NumeroRefCompra": $("#numeroRefCompraUpdate").val(),
            "PrecioUniVenta": $("#precioUniVentaUpdate").val(),
            "PrecioUniCompra": $("#precioUniCompraUpdate").val()
        };

        $.ajax({
                type: "POST",
                url: "/GestionInventario/Inventario?handler=UpdateJson",
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                headers: {
                    "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
                },
                data: JSON.stringify(paquete),
            })
            .done(function(result) {
                // // Muestra una ventana emergente dando a conocer el resultado de la acción y recarga la pagina
                $.confirm({
                    title: 'Info',
                    content: result,
                    type: 'dark',
                    typeAnimated: true,
                    buttons: {
                        confirm: function() { location.reload(); }
                    }
                });
            })
            .fail(function(error) {
                // // Muestra una ventana emergente dando a conocer el resultado de la acción y recarga la pagina
                $.confirm({
                    title: 'Error!',
                    content: error,
                    type: 'red',
                    typeAnimated: true,
                    buttons: {
                        tryAgain: {
                            text: 'OK',
                            btnClass: 'btn-red',
                            action: function() { location.reload(); }
                        },
                    }
                });
            });
    });


    // // Peticion AJAX para eliminar
    $("#btn-delete").click(function() {

        $.confirm({
            title: 'Alerta!',
            content: 'Seguro que desea eliminar este registro?',
            buttons: {
                cancel: function() {},
                somethingElse: {
                    text: 'OK',
                    btnClass: 'btn-blue',
                    keys: ['enter', 'shift'],
                    action: function() {
                        var paquete = {
                            "Id": parseInt($("#idUpdate").val()),
                        };

                        $.ajax({
                                type: "POST",
                                url: "/GestionInventario/Inventario?handler=DeleteJson",
                                contentType: "application/json; charset=utf-8",
                                dataType: "html",
                                headers: {
                                    "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
                                },
                                data: JSON.stringify(paquete),
                            })
                            .done(function(result) {
                                // // Muestra una ventana emergente dando a conocer el resultado de la acción y recarga la pagina
                                $.confirm({
                                    title: 'Info',
                                    content: result,
                                    type: 'dark',
                                    typeAnimated: true,
                                    buttons: {
                                        confirm: function() { location.reload(); }
                                    }
                                });
                            })
                            .fail(function(error) {
                                // // Muestra una ventana emergente dando a conocer el resultado de la acción y recarga la pagina
                                $.confirm({
                                    title: 'Error!',
                                    content: error,
                                    type: 'red',
                                    typeAnimated: true,
                                    buttons: {
                                        tryAgain: {
                                            text: 'OK',
                                            btnClass: 'btn-red',
                                            action: function() { location.reload(); }
                                        },
                                    }
                                });
                            });
                    }
                }
            }
        });
    });
});

function crear(text) {

    // limpia los inputs el modal de Crear
    document.getElementById("producto").value = "";
    document.getElementById("existencias").value = "";
    document.getElementById("numerorefcompra").value = "";
    document.getElementById("preciouniventa").value = "";
    document.getElementById("preciounicompra").value = "";

    // añade un titulo al modal de CREAR reamplazando el texto mostrado
    document.getElementById("titleModal").innerHTML = "Registro " + text;

    document.getElementById("btn-create-modal").innerHTML = "Crear";
}
// 1. Capturar los registros de una fila en la tabla, para pasarlos al ModalActualizar
function seleccionarRegistroTabla(e, id, productoId, existencias, numerorefcompra, preciouniventa, preciounicompra) {

    var selectedRow = $(e);
    var selectedRowGlobal = $(selectedRow[0].parentElement);
    selectedRowGlobal = selectedRowGlobal.find(".selected");

    if (selectedRowGlobal.find(".selected")) {
        selectedRowGlobal.removeClass("selected");
    }

    selectedRow.addClass("selected");

    var selectOption = $('.productoUpdateId');
    var selectOptionCons = $('.productoUpdateId');

    selectOptionCons.removeAttr('productoCosId');
    selectOption.removeAttr('selected');

    $('#btn-const').removeAttr('hidden');
    $('#btn-delete').removeAttr('hidden');
    $('#btn-update').removeAttr('hidden');

    // Tomamos los parametros y se los asignamos a los campos del ModalActualizar para mostrarlos en Frontend
    document.getElementById("idUpdate").value = id;
    $('#productoUpdateId-' + productoId).attr('selected', true);
    document.getElementById("existenciasUpdate").value = existencias;
    document.getElementById("numeroRefCompraUpdate").value = numerorefcompra;
    document.getElementById("precioUniVentaUpdate").value = preciouniventa;
    document.getElementById("precioUniCompraUpdate").value = preciounicompra;

    // Tomamos los parametros y se los asignamos a los campos del ModalActualizar para mostrarlos en Constancia
    $('#productoCosId-' + productoId).attr('selected', true);
    document.getElementById("existenciasContancia").value = existencias;
    document.getElementById("numerorefcompraContancia").value = numerorefcompra;
    document.getElementById("preciouniventaContancia").value = preciouniventa;
    document.getElementById("preciounicompraContancia").value = preciounicompra;

}
// 2. Luego de modificar los campos en el ModalActualizar, al dar clic en el botón Actualizar se envia a la DB

// // funciones de JQUERY
$().ready(function() {

    // // Peticion AJAX para Actualizar
    $("#btn-update-modal").click(function() {
        // Tomamos los campos del ModalActualizar para crear un objeto para enviarlo a la DB
        var paquete = {
            "Id": parseInt($("#idUpdate").val()),
            "ProductoId": parseInt($("#productoUpdate").val()),
            "Existencias": parseInt($("#existenciasUpdate").val()),
            "NumeroRefCompra": parseInt($("#numeroRefCompraUpdate").val()),
            "PrecioUniVenta": parseFloat($("#precioUniVentaUpdate").val()),
            "PrecioUniCompra": parseFloat($("#precioUniCompraUpdate").val())
        };


        var validation = true;

        // // validacion de los campos del formulario
        for (let x in paquete) {
            // tomamos el valor de cada propiedad y se convierte en String y se le quitan los espacios
            var text = paquete[x].toString().trim();
            console.log("campo: " + x + " -- tipo: " + typeof text + " -- valor: " + text);
            // Nota: cuando el campo es vacío, de tipo Entero o Select, entonces aparece como "NaN" por eso se incluye NaN en el condicional, tambien si el valor entero es cero lo acepta como valido por eso se incluye
            if (text == 0 || text == "NaN" || text.length <= 0) {
                validation = false;
                console.log(validation);
            }
        }

        if (validation) {

            // variable que se usará un poco mas abajo para ocultar el modal
            var modal = $('#ModalActualizar');

            /* Enviar petición AJAX datos JSON */
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
                    // // oculta el modal de actualizar
                    modal.on('hidden.bs.modal', function(e) {
                        return this.render();
                    });
                    $('#ModalActualizar').hide();
                    $('.modal-backdrop').remove();

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
                    // // Muestra una ventana emergente dando a conocer el ERROR pero NO recarga la pagina
                    $.confirm({
                        title: 'Error!',
                        content: 'No se puedo actualizar el registro : El registro tiene llaves foraneas en otras tablas. \nError.status:' + error.status,
                        type: 'red',
                        typeAnimated: true,
                        buttons: {
                            tryAgain: {
                                text: 'OK',
                                btnClass: 'btn-red',
                                action: function() {}
                            },
                        }
                    });
                });
        } else {
            $.confirm({
                title: 'Alerta!',
                content: 'No se aceptan campos vacíos, con cero o solo con especios',
                type: 'orange',
                buttons: {
                    confirm: function() {},
                }
            });
        }
    });


    // // Peticion AJAX para eliminar
    $("#btn-delete").click(function() {

        $.confirm({
            title: 'Alerta!',
            content: 'Seguro que desea eliminar este registro?',
            type: 'orange',
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
                                // // Muestra una ventana emergente dando a conocer el ERROR y recarga la pagina
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
// 1. Capturar los registros de una fila en la tabla, para pasarlos al ModalActualizar
function seleccionarRegistroTabla(e, id, nombre, descripcion) {

    var selectedRow = $(e);
    var selectedRowGlobal = $(selectedRow[0].parentElement);
    selectedRowGlobal = selectedRowGlobal.find(".selected");

    if (selectedRowGlobal.find(".selected")) {
        selectedRowGlobal.removeClass("selected");
    }

    selectedRow.addClass("selected");

    $('#btn-delete').removeAttr('hidden');
    $('#btn-update').removeAttr('hidden');

    // esto es para mostrar los valores en el ModalActualizar
    document.getElementById("idUpdate").value = id;
    document.getElementById("nombreUpdate").value = nombre;
    document.getElementById("descripcionUpdate").value = descripcion;
}
// 2. Luego de modificar los campos en el ModalActualizar, al dar clic en el botón Actualizar se envia a la DB mediante metodo ajax

// // funciones de JQUERY
$().ready(function() {

    // // Peticion AJAX para Actualizar
    $("#btn-update-modal").click(function() {

        var valitations = false;

        if ($("#nombreUpdate").val().trim().length > 0 && $("#descripcionUpdate").val().trim().length > 0) {
            valitations = true;
        }


        if (valitations) {

            // variable que se usará un poco mas abajo para ocultar el modal
            var modal = $('#ModalActualizar');

            /* Enviar petición AJAX datos JSON */
            // Tomamos los campos del ModalActualizar para crear un objeto para enviarlo a la DB
            var paquete = {
                "Id": parseInt($("#idUpdate").val()),
                "Nombre": $("#nombreUpdate").val(),
                "Descripcion": $("#descripcionUpdate").val()
            };

            $.ajax({
                    type: "POST",
                    url: "/GestionProductos/Productos?handler=UpdateJson",
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
                    modal.modal('hide');
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
                    error = 'No se puedo eliminar el registro : El registro tiene llaves foraneas en otras tablas';
                    $.confirm({
                        title: 'Error!',
                        content: error,
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
                content: 'Todos los campos tienen que estar diligenciados',
                type: 'orange',
                buttons: {
                    confirm: function() {},
                }
            });

        }

    });


    // // Petición AJAX para eliminar
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
                                url: "/GestionProductos/Productos?handler=DeleteJson",
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
    document.getElementById("nombre").value = "";
    document.getElementById("descripcion").value = "";

    // añade un titulo al modal de CREAR reamplazando el texto mostrado
    document.getElementById("titleModal").innerHTML = "Registrar " + text;

    document.getElementById("btn-create-modal").innerHTML = "Crear";
}
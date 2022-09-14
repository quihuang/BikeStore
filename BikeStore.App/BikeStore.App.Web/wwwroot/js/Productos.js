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

// 2. Luego de modificar los campos en el ModalActualizar, al dar clic en el botón Actualizar se envia a la DB
$().ready(function() {

    $("#btn-update-modal").click(function() {

        // debugger;

        /* Enviar petición AJAX datos JSON */
        var paquete = { "Id": $("#idUpdate").val(), 
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
                alert(result);
                location.reload();
            })
            .fail(function(error) {
                alert(error);
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
// 1. Capturar los registros de una fila en la tabla, para pasarlos al ModalActualizar
function seleccionarRegistroTabla(e, id, cedula, nombre, apellido, numeroTelefono, email, direccion) {

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
    document.getElementById("cedulaUpdate").value = cedula;
    document.getElementById("nombreUpdate").value = nombre;
    document.getElementById("apellidoUpdate").value = apellido;
    document.getElementById("numeroTelefonoUpdate").value = numeroTelefono;
    document.getElementById("emailUpdate").value = email;
    document.getElementById("direccionUpdate").value = direccion;
}

// 2. Luego de modificar los campos en el ModalActualizar, al dar clic en el botón Actualizar se envia a la DB
$().ready(function() {

    $("#btn-update-modal").click(function() {

        // Enviar petición AJAX datos JSON
        var venta = {
            "Id": $("#idUpdate").val(),
            "Cedula": $("#cedulaUpdate").val(),
            "Nombre": $("#nombreUpdate").val(),
            "Apellido": $("#apellidoUpdate").val(),
            "NumeroTelefono": $("#numeroTelefonoUpdate").val(),
            "Email": $("#emailUpdate").val(),
            "Direccion": $("#direccionUpdate").val()
        };

        $.ajax({
                type: "POST",
                url: "/GestionClientes/GestionClientes?handler=UpdateJson",
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

// función para limpiar el modal de Crear
function crear(text) {

    document.getElementById("cedula").value = "";
    document.getElementById("nombre").value = "";
    document.getElementById("apellido").value = "";
    document.getElementById("numeroTelefono").value = "";
    document.getElementById("email").value = "";
    document.getElementById("direccion").value = "";

    document.getElementById("titleModal").innerHTML = "Registro " + text;
    document.getElementById("btn-create-modal").innerHTML = "Crear";

}
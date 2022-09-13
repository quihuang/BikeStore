// 1. Capturar los registros de una fila en la tabla, para pasarlos al ModalActualizar
function seleccionarRegistroTabla(e, id, cedula, nombre, apellido, numeroTelefono, nombreUsuario, salario) {

    var selectedRow = $(e);
    var selectedRowGlobal = $(selectedRow[0].parentElement);
    selectedRowGlobal = selectedRowGlobal.find(".selected");

    if (selectedRowGlobal.find(".selected")) {
        selectedRowGlobal.removeClass("selected");
    }

    selectedRow.addClass("selected");

    $('#btn-update').removeAttr('hidden');
    $('#btn-delete').removeAttr('hidden');

    // esto es para mostrar los valores en el ModalActualizar
    document.getElementById("IdUpdate").value = id;
    document.getElementById("nombreUpdate").value = Cedula;
    document.getElementById("descripcionUpdate").value = descripcion;
    document.getElementById("IdUpdate").value = id;
    document.getElementById("nombreUpdate").value = nombre;
    document.getElementById("descripcionUpdate").value = descripcion;
}

// 2. Luego de modificar los campos en el ModalActualizar, al dar clic en el botón Actualizar se envia a la DB
$().ready(function() {

    $("#btn-update-modal").click(function() {

        // debugger;

        /* Enviar petición AJAX datos JSON */
        var producto = { "Id": $("#IdUpdate").val(), "Nombre": $("#nombreUpdate").val(), "Descripcion": $("#descripcionUpdate").val() };

        $.ajax({
                type: "POST",
                url: "/GestionUsuarios/Usuario?handler=UpdateJson",
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

    document.getElementById("nombre").value = "";
    document.getElementById("descripcion").value = "";

    document.getElementById("titleModal").innerHTML = "Registro " + text;
    document.getElementById("btn-create-modal").innerHTML = "Crear";

}
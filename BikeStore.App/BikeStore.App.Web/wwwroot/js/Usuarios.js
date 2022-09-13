// 1. Capturar los registros de una fila en la tabla, para pasarlos al ModalActualizar
function seleccionarRegistroTabla(e, id, cedula, nombre, apellido, numeroTelefono, nombreUsuario, salario, rol) {

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
    document.getElementById("cedulaUpdate").value = cedula;
    document.getElementById("nombreUpdate").value = nombre;
    document.getElementById("apellidoUpdate").value = apellido;
    document.getElementById("numeroTelefonoUpdate").value = numeroTelefono;
    document.getElementById("nombreUsuarioUpdate").value = nombreUsuario;
    // Ojito: el password NO se recibe de la tabla, pero toca capturarlo del Modal al momento de Actualizar
    document.getElementById("salarioUpdate").value = salario;
    document.getElementById("rolUpdate").value = rol;
}

// 2. Luego de modificar los campos en el ModalActualizar, al dar clic en el botón Actualizar se envia a la DB
$().ready(function() {

    $("#btn-update-modal").click(function() {

        // debugger;

        /* Enviar petición AJAX datos JSON */
        var paquete = { "Id": $("#idUpdate").val(), 
        "Cedula": $("#cedulaUpdate").val(), 
        "Nombre": $("#nombreUpdate").val(), 
        "Apellido": $("#apellidoUpdate").val(), 
        "NumeroTelefono": $("#numeroTelefonoUpdate").val(), 
        "NombreUsuario": $("#nombreUsuarioUpdate").val(), 
        "Contraseña": $("#passwordUpdate").val(), 
        "Salario": $("#salarioUpdate").val(), 
        "Rol": $("#rolUpdate").val() 
        };

        $.ajax({
                type: "POST",
                url: "/GestionUsuarios/Usuarios?handler=UpdateJson",
                contentType: "application/json; charset=utf-8",
                dataType: "html",
                headers: {
                    "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
                },
                data: JSON.stringify(paquete),
            })
            .done(function(result) {
                alert(result);
                console.log(result);
                location.reload();
            })
            .fail(function(error) {
                console.log(result);
                alert(error);
            });
    });
});

function crear(text) {

    // limpia los inputs el modal de Crear
    document.getElementById("cedula").value = "";
    document.getElementById("nombre").value = "";
    document.getElementById("apellido").value = "";
    document.getElementById("numeroTelefono").value = "";
    document.getElementById("nombreUsuario").value = "";
    document.getElementById("password").value = "";
    document.getElementById("rol").value = "";
    document.getElementById("salario").value = "";
    
    // añade un titulo al modal de CREAR reamplazando el texto mostrado
    document.getElementById("titleModal").innerHTML = "Registro " + text;

    document.getElementById("btn-create-modal").innerHTML = "Crear";
}
$().ready(function() {

    $("#btn-update-modal-pro").click(function() {

        debugger;

        /* Enviar petición AJAX datos JSON */
        var producto = { "Id": $("#IdProducto").val(), "Nombre": $("#nombreProducto").val(), "Descripcion": $("#descripcionProducto").val() };

        $.ajax({
                type: "POST",
                url: "/GestionProductos/Productos?handler=UpdateJson",
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
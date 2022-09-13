$().ready(function() {

    $("#btn-update-modal").click(function() {

        debugger;

        /* Enviar petición AJAX datos JSON */
        var producto = { "Id": $("#IdUpdate").val(), "Nombre": $("#nombreUpdate").val(), "Descripcion": $("#descripcionUpdate").val() };
        
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


function seleccionarRegistroTabla(e, id, nombre, descripcion) {

    var selectedRow = $(e);
    var selectedRowGlobal = $(selectedRow[0].parentElement);
    selectedRowGlobal = selectedRowGlobal.find(".selected");

    if (selectedRowGlobal.find(".selected")) {
        selectedRowGlobal.removeClass("selected");
    }

    selectedRow.addClass("selected");

    $('#btn-update').removeAttr('hidden');
    $('#btn-delete').removeAttr('hidden');

    document.getElementById("IdUpdate").value = id;
    document.getElementById("nombreUpdate").value = nombre;
    document.getElementById("descripcionUpdate").value = descripcion;

}
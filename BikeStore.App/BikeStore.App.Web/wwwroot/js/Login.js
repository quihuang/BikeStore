$().ready(function() {

    $("#btn-login").click(function() {

        var credentials = {
            "NombreUsuario": $("#inputEmail").val(),
            "Contraseña": $("#inputPassword").val()
        };

        var validation = true;

        // // validacion de los campos del formulario
        for (let x in credentials) {
            // tomamos el valor de cada propiedad y se convierte en String y se le quitan los espacios
            var text = credentials[x].toString().trim();
            console.log("campo: " + x + " -- tipo: " + typeof text + " -- valor: " + text);
            // Nota: cuando el campo es vacío, de tipo Entero o Select, entonces aparece como "NaN" por eso se incluye NaN en el condicional, tambien si el valor entero es cero lo acepta como valido por eso se incluye
            if (text == 0 || text == "NaN" || text.length <= 0) {
                validation = false;
                console.log(validation);
            }
        }

        if (validation) {

            $.ajax({
                    type: "POST",
                    url: "/Index?handler=ValidateLogin",
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    headers: {
                        "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
                    },
                    data: JSON.stringify(credentials),
                })
                .done(function(result) {
                    // // Muestra una ventana emergente dando a conocer el resultado de la acción y recarga la pagina
                    if (result == "0") {
                        $.confirm({
                            title: 'Info',
                            content: "Usuario y/o contraseña incorrectos",
                            type: 'dark',
                            typeAnimated: true,
                            buttons: {
                                confirm: function() {}
                            }
                        });
                    } else if (result == "2") {
                        window.location.href = "Bienvenida/Inicio";
                    } else if (result == "1") {
                        window.location.href = "Bienvenida/Inicio";
                    } else if (result == "3") {
                        window.location.href = "Bienvenida/Inicio";
                    }

                })
                .fail(function(error) {
                    // // Muestra una ventana emergente dando a conocer el ERROR pero NO recarga la pagina
                    $.confirm({
                        title: 'Error!',
                        content: 'Error.status: ' + error.status,
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
                content: 'Debe Ingresar un usuario y una contraseña para poder continuar',
                type: 'dark',
                buttons: {
                    confirm: function() {},
                }
            });
        }



    });

});
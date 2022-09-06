// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function editar(text) {
    document.getElementById("titleModal").innerHTML = "Actualizar " + text;
    document.getElementById("btn-create-modal").innerHTML = "Actualizar";
}

function crear(text) {
    document.getElementById("titleModal").innerHTML = "Registro " + text;
    document.getElementById("btn-create-modal").innerHTML = "Crear";

}

function seleccionarRegistro() {
    $('#btn-update').removeAttr('hidden');
    $('#btn-delete').removeAttr('hidden');
    $('#btn-const').removeAttr('hidden');
}

function imprimir(nombre) {
    var ficha = document.getElementById(nombre);
    var ventimp = window.open(' ', 'popimpr');
    ventimp.document.write(ficha.innerHTML);
    ventimp.document.close();
    ventimp.print();
    ventimp.close();
}
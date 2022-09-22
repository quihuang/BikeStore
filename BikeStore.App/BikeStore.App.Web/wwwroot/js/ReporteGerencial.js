$().ready(function() {

    var num = $("#totalInversion").text().replace(/\./g, '');
    if (!isNaN(num)) {
        num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
        num = num.split('').reverse().join('').replace(/^[\.]/, '');
        $("#totalInversion").text("$ " + num);
    }

});
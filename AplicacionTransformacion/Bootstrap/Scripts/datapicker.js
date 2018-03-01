$(document).ready(function () {

    sumaFecha = function (d, fecha) {
        var Fecha = new Date();
        var sFecha = fecha || (Fecha.getDate() + "/" + (Fecha.getMonth() + 1) + "/" + Fecha.getFullYear());
        var sep = sFecha.indexOf('/') != -1 ? '/' : '-';
        var aFecha = sFecha.split(sep);
        var fecha = aFecha[2] + '/' + aFecha[1] + '/' + aFecha[0];
        fecha = new Date(fecha);
        fecha.setDate(fecha.getDate() + parseInt(d));
        var anno = fecha.getFullYear();
        var mes = fecha.getMonth() + 1;
        var dia = fecha.getDate();
        mes = (mes < 10) ? ("0" + mes) : mes;
        dia = (dia < 10) ? ("0" + dia) : dia;
        var fechaFinal = dia + sep + mes + sep + anno;
        return (fechaFinal);
    }

    var f = new Date();
    var fecha = sumaFecha(8, (f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear()));


    console.log("Inicio");
    var array = [];

    for (var i = 0; i < 6; i++) {
        array.push(sumaFecha(i));
    }

    for (var i = 0; i < array.length ; i++) {
        console.log(array[i]);
    }

    $.datepicker.setDefaults($.datepicker.regional["es"]);

    $("#<%= txtfechaIdentificacion.ClientID %>").datepicker({
        dateFormat: 'dd/mm/yy',
        minDate: 0,
        beforeShowDay: function (date) {
            var string = jQuery.datepicker.formatDate('dd/mm/yy', date);
            return [array.indexOf(string) == -1]
        }
    });


});
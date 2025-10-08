function ConsultarNombre() {

    let identificacion = $("#Identificacion").val();
    $("#Nombre").val("");

    if (identificacion.length >= 9) {

        $.ajax({
            type: 'GET',
            url: "https://apis.gometa.org/cedulas/" + identificacion,
            dataType: 'json',
            success: function (result) {
                $("#Nombre").val(result.nombre);
            }
        });

    }
}
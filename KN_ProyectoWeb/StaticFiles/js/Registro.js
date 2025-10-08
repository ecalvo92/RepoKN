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

$(function () {

    $("#FormRegistro").validate({
        rules: {
            Identificacion: {
                required: true
            },
            Nombre: {
                required: true
            },
            CorreoElectronico: {
                required: true,
                email:true
            },
            Contrasenna: {
                required: true
            }
        },
        messages: {
            Identificacion: {
                required: "* Requerido",
            },
            Nombre: {
                required: "* Requerido",
            },
            CorreoElectronico: {
                required: "* Requerido",
                email: "* Formato",
            },
            Contrasenna: {
                required: "* Requerido",
            }
        }
    });

});
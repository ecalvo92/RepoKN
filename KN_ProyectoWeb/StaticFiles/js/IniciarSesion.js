$(function () {

    $("#FormIniciarSesion").validate({
        rules: {
            CorreoElectronico: {
                required: true,
                email: true
            },
            Contrasenna: {
                required: true
            }
        },
        messages: {
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
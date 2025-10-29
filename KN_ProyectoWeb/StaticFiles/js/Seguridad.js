$(function () {

    $("#FormSeguridad").validate({
        rules: {
            Contrasenna: {
                required: true,
                maxlength: 10
            },
            ContrasennaConfirmar: {
                required: true,
                equalTo: "#Contrasenna",
                maxlength: 10
            }
        },
        messages: {
            Contrasenna: {
                required: "* Requerido",
                maxlength: "* Máximo 10 caracteres"
            },
            ContrasennaConfirmar: {
                required: "* Requerido",
                equalTo: "* Las contraseñas deben coincidir",
                maxlength: "* Máximo 10 caracteres"
            }            
        }
    });

});
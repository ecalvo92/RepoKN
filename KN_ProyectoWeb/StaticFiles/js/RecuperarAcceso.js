$(function () {

    $("#FormRecuperarAcceso").validate({
        rules: {
            CorreoElectronico: {
                required: true,
                email: true
            }
        },
        messages: {
            CorreoElectronico: {
                required: "* Requerido",
                email: "* Formato",
            }
        }
    });

});
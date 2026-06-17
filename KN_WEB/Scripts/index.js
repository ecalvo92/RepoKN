$.validator.addMethod('specialChar', function (value) {
    return /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(value);
}, 'Mínimo 1 carácter especial.');

$(document).ready(function () {
    $('#IndexForm').validate({
        rules: {
            CorreoElectronico: {
                required: true,
                email: true
            },
            Contrasenna: {
                required: true,
                minlength: 5,
                specialChar: true
            }
        },
        messages: {
            CorreoElectronico: {
                required: 'Campo obligatorio.',
                email: 'Formato no válido.'
            },
            Contrasenna: {
                required: 'Campo obligatorio.',
                minlength: 'Mínimo 5 caracteres.'
            }
        },
        errorElement: 'span',
        errorClass: 'text-danger small',
        errorPlacement: function (error, element) {
            error.insertAfter(element.closest('.form-group'));
        },
        highlight: function (element) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element) {
            $(element).removeClass('is-invalid');
        }
    });
});

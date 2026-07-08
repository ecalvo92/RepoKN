$.validator.addMethod('specialChar', function (value) {
  return /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(value);
}, 'Mínimo 1 carácter especial.');

$(document).ready(function () {
  $('#CambiarContrasennaForm').validate({
    rules: {
      Contrasenna: {
        required: true,
        minlength: 5,
        specialChar: true
      },
      ConfirmarContrasenna: {
        required: true,
        equalTo: "#Contrasenna"
      }
    },
    messages: {
      Contrasenna: {
        required: 'Campo obligatorio.',
        minlength: 'Mínimo 5 caracteres.'
      },
      ConfirmarContrasenna: {
        required: 'Campo obligatorio.',
        equalTo: "Las contraseñas no coinciden."
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

$(document).ready(function () {
  $('#RecuperarAccesoForm').validate({
    rules: {
      CorreoElectronico: {
        required: true,
        email: true
      }
    },
    messages: {
      CorreoElectronico: {
        required: 'Campo obligatorio.',
        email: 'Formato no válido.'
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

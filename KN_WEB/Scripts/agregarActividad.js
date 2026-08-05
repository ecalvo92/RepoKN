$(document).ready(function () {

  InicializarCalendarios();

  $('#AgregarActividadForm').validate({
    ignore: ':hidden:not(#inputImagen)',
    rules: {
      Titulo: {
        required: true,
        minlength: 5
      },
      Inicio: {
        required: true,
        fechaMenorHoy: true
      },
      Fin: {
        required: true,
        finDespuesInicio: true
      },
      Imagen: {
        required: true,
        imagenFormato: true,
        imagenTamano: true
      }
    },
    messages: {
      Titulo: {
        required: 'Campo obligatorio.',
        minlength: 'Mínimo 5 caracteres.'
      },
      Inicio: {
        required: 'Campo obligatorio.'
      },
      Fin: {
        required: 'Campo obligatorio.'
      },
      Imagen: {
        required: 'Seleccione una imagen.'
      }
    },
    errorElement: 'span',
    errorClass: 'text-danger small',
    errorPlacement: function (error, element) {
      if (element.attr('id') === 'inputImagen') {
        error.insertAfter('#zonaImagen');
      } else {
        error.insertAfter(element.closest('.form-group'));
      }
    },
    highlight: function (element) {
      $(element).addClass('is-invalid');
    },
    unhighlight: function (element) {
      $(element).removeClass('is-invalid');
    }
  });

});
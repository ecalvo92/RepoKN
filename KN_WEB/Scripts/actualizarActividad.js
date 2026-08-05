$(document).ready(function () {

  InicializarCalendarios();

  if ($('#yaInicio').val() === 'true') {
    $('#ActulizarActividadForm :input').prop('disabled', true);
    $('#zonaImagen').off('click').css('pointer-events', 'none').css('opacity', '0.6');
    return;
  }

  $('#ActulizarActividadForm').validate({
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
        required: function () {
          return !$('#imagenExistente').val();
        },
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
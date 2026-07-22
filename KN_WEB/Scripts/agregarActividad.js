$(document).ready(function () {

  $.validator.addMethod('fechaDesdeManana', function (value) {
    if (!value) return false;
    var manana = new Date();
    manana.setDate(manana.getDate() + 1);
    manana.setHours(0, 0, 0, 0);
    return new Date(value) >= manana;
  }, 'La fecha de inicio debe ser a partir de mañana.');

  $.validator.addMethod('finDespuesInicio', function (value) {
    var inicio = new Date($('#Inicio').val());
    var fin = new Date(value);
    if (!$('#Inicio').val() || !value) return true;
    return fin > inicio;
  }, 'La fecha de finalización debe ser posterior a la fecha de inicio.');

  $.validator.addMethod('imagenFormato', function (value, element) {
    if (!element.files || !element.files[0]) return true;
    return /\.(jpg|jpeg|png)$/i.test(element.files[0].name);
  }, 'Solo se permiten imágenes JPG, JPEG o PNG.');

  $.validator.addMethod('imagenTamano', function (value, element) {
    if (!element.files || !element.files[0]) return true;
    return element.files[0].size <= 1 * 1024 * 1024;
  }, 'La imagen no debe superar 1 MB.');

  $('#AgregarActividadForm').validate({
    ignore: ':hidden:not(#inputImagen)',
    rules: {
      Titulo: {
        required: true,
        minlength: 5
      },
      Inicio: {
        required: true,
        fechaDesdeManana: true
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

function previsualizarImagen(input)
{
  if (!input.files || !input.files[0])
    return;

  var reader = new FileReader();
  reader.onload = function (e)
  {
    document.getElementById('previstaImagen').src = e.target.result;
    document.getElementById('previstaImagen').classList.remove('d-none');
    document.getElementById('textoImagen').classList.add('d-none');
    document.getElementById('zonaImagen').classList.add('sin-borde');
  };

  reader.readAsDataURL(input.files[0]);
}
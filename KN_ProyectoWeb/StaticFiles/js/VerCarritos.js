$(function () {

  new DataTable('#tCarritos', {
    language: {
      url: 'https://cdn.datatables.net/plug-ins/2.3.4/i18n/es-ES.json',
    },
    columnDefs: [{ targets: '_all', className: 'text-start' }]
  });

  $("#FormRealizarPago").validate({
    rules: {
      MetodoPago: {
        required: true,
        maxlength: 50
      }
    },
    messages: {
      MetodoPago: {
        required: "* Requerido",
        maxlength: "* Máximo 50 caracteres"
      }
    }
  });

});
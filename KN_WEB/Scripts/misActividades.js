$(function () {
  $('#TablaMisActividades').DataTable({
    responsive: true,
    pageLength: 10,
    lengthMenu: [10, 25, 50, 100],
    language: {
      url: 'https://cdn.datatables.net/plug-ins/2.3.4/i18n/es-ES.json'
    }
  });
});

$(document).on('click', '.btn-desinscribirse', function () {
  var id = $(this).data('id');
  var titulo = $(this).data('titulo');

  Swal.fire({
    title: '¿Desinscribirse?',
    text: titulo,
    icon: 'question',
    showCancelButton: true,
    confirmButtonText: 'Sí, desinscribirme',
    cancelButtonText: 'No'
  }).then(function (result) {
    if (!result.isConfirmed) return;

    $.ajax({
      url: '/CatalogoActividades/Desinscribirse',
      method: 'POST',
      data: { id: id },
      dataType: 'json',
      success: function (data) {
        Swal.fire({
          title: 'Información',
          text: data,
          icon: 'info',
          confirmButtonText: 'Aceptar'
        }).then(function () {
          location.reload();
        });
      }
    });
  });
});

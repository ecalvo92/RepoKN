$(function () {
  $('#TablaActividades').DataTable({
    responsive: true,
    pageLength: 10,
    lengthMenu: [10, 25, 50, 100],
    language: {
      url: 'https://cdn.datatables.net/plug-ins/2.3.4/i18n/es-ES.json'
    }
  });
});

$(document).on("click", ".btn-cancelar", function () {

  var id = $(this).data("id"); 
  var titulo = $(this).data("titulo");

  swal.fire({
    title: "¿Cancelar Actividad?",
    text: titulo,
    icon: "question",
    showCancelButton: true,
    confirmButtonText: "Sí",
    cancelButtonText: "No"
  }).then(function (result) {

    if (!result.isConfirmed)
      return;

    $.ajax({
      url: '/Actividad/CancelarActividad',
      method: "POST",
      data: {
        id : id
      },
      dataType: "json",
      success: function (data) {
        location.reload();
      }
    });

  });

});
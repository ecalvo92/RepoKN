$(function () {
  $('#buscarActividad').on('input', function () {
    var query = $(this).val().toLowerCase();
    $('.tarjeta-actividad').each(function () {
      var titulo = $(this).find('.titulo-actividad').text().toLowerCase();
      $(this).toggle(titulo.includes(query));
    });
  });
});


$(document).on('click', '.btn-inscribirse', function () {

  var id = $(this).data('id');
  var titulo = $(this).data('titulo');

  Swal.fire({
    title: '¿Inscribirte en esta actividad?',
    text: titulo,
    icon: 'question',
    showCancelButton: true,
    confirmButtonText: 'Sí',
    cancelButtonText: 'No'
  }).then(function (result) {

    if (!result.isConfirmed)
      return;

    $.ajax({
      url: '/CatalogoActividades/Inscribirse',
      method: 'POST',
      data: {
        id : id
      },
      dataType: 'json',
      success: function (data) {

        Swal.fire({
          title: "Información",
          text: data,
          icon: "info",
          confirmButtonText: "Aceptar"
        }).then(() => {
          location.reload();
        });
        
      }
    });

  });

});

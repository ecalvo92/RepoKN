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
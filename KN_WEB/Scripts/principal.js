$(function () {

  var cal = document.getElementById("calendario");

  var calendario = new FullCalendar.Calendar(cal, {
    initialView: "dayGridMonth",
    locale: "es",
    buttonText: {
      today: "Hoy",
      month: "Mes",
      week: "Semana",
      day: "Día",
      list: "Lista"
    },
    headerToolbar: {
      left: "prev,today,next",
      center: "title",
      right: "dayGridMonth,timeGridWeek"
    },
    events: "/Home/ObtenerActividadesCalendario",
    eventTimeFormat: {
      hour: "2-digit",
      minute: "2-digit",
      hour12: true
    }
  });

  calendario.render();

});
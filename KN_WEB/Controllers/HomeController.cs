using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    public class HomeController : Controller
    {
        /*
            Action = Eventos disparados por el usuario desde una vista
            Método = Funciones pública o privada Centralizar Código y Reutilizarlo
            Instancia = Trabajar con clases (objeto, entidad) externas
            Tipos de datos = Trabajar con información
        */

        public ActionResult Index()
        {
            return View();
        }

        

    }
}
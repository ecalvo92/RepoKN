using KN_WEB.Models;
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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region

        [HttpGet]
        public ActionResult Registro()
        {
            //Me permite abrir una vista, se dispara en un redireccionamiento o hipervínculo

            return View();
        }

        [HttpPost]
        public ActionResult Registro(UsuarioModel model)
        {
            //Me permite programar una acción en una vista, se dispara al presionar un botón de tipo 'submit'

            return View();
        }

        #endregion

        [HttpGet]
        public ActionResult RecuperarAcceso()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Principal()
        {
            return View();
        }

    }
}
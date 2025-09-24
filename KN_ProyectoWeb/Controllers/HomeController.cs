using KN_ProyectoWeb.Models;
using System.Web.Mvc;

namespace KN_ProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        #region Iniciar Sesión

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            /*Progra para validar si usuario.CorreoElectronico y usuario.Contrasenna*/

            return RedirectToAction("Principal", "Home");
        }

        #endregion

        #region Registro

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            /*Progra para ir a guardar el usuario en la BD*/

            return View();
        }

        #endregion

        #region Recuperar Acceso

        [HttpGet]
        public ActionResult RecuperarAcceso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarAcceso(Usuario usuario)
        {
            /*Validar si el usuario existe, generarle un contraseña tmp, enviarle esa clave tmp*/

            return View();
        }

        #endregion

        [HttpGet]
        public ActionResult Principal()
        {
            return View();
        }

    }
}
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult ConsultarPerfil()
        {
            return View();
        }

    }
}
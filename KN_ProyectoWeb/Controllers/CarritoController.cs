using KN_ProyectoWeb.Services;
using System.Web.Mvc;

namespace KN_ProyectoWeb.Controllers
{
    [Seguridad]
    public class CarritoController : Controller
    {
        [HttpGet]
        public ActionResult VerMiCarrito()
        {
            return View();
        }
    }
}
using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Services;
using System.Linq;
using System.Web.Mvc;

namespace KN_ProyectoWeb.Controllers
{
    [Seguridad]
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Principal()
        {
            if (Session["ConsecutivoPerfil"].ToString() != "1")
                return RedirectToAction("Principal", "Home");

            using (var context = new BD_KNEntities())
            {
                var usuarios = context.tbUsuario.Where(x => x.ConsecutivoPerfil != 1).ToList();
                var productos = context.tbProducto.ToList();

                ViewBag.CantidadUsuariosActivos = usuarios.Where(x => x.Estado == true).Count();
                ViewBag.CantidadUsuariosInactivos = usuarios.Where(x => x.Estado == false).Count();
                ViewBag.CantidadProductosActivos = productos.Where(x => x.Estado == true).Count();
                ViewBag.CantidadProductosInactivos = productos.Where(x => x.Estado == false).Count();

                return View();
            }
        }
    }
}
using KN_ProyectoWeb.EF;
using System.Linq;
using System.Web.Mvc;

namespace KN_ProyectoWeb.Controllers
{
    public class ProductosController : Controller
    {
        [HttpGet]
        public ActionResult VerProductos()
        {
            using (var context = new BD_KNEntities())
            {
                var resultado = context.tbProducto.Include("tbCategoria").ToList();

                return View(resultado);
            }
        }
    }
}
using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
using KN_ProyectoWeb.Services;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_ProyectoWeb.Controllers
{
    [Seguridad]
    public class ProductosController : Controller
    {
        [HttpGet]
        public ActionResult VerProductos()
        {
            using (var context = new BD_KNEntities())
            {
                //Tomar el objeto de la BD
                var resultado = context.tbProducto.Include("tbCategoria").ToList();

                //Convertirlo en un objeto Propio
                var datos = resultado.Select(p => new Producto
                {
                    ConsecutivoProducto = p.ConsecutivoProducto,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    NombreCategoria = p.tbCategoria.Nombre,
                    Estado = p.Estado,
                    Imagen = p.Imagen
                }).ToList();

                return View(datos);
            }
        }

        #region AgregarProductos

        [HttpGet]
        public ActionResult AgregarProductos()
        {
            CargarValoresCategoria();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProductos(Producto producto, HttpPostedFileBase ImgProducto)
        {
            return View();
        }

        #endregion

        private void CargarValoresCategoria()
        {
            using (var context = new BD_KNEntities())
            {
                //Tomar el objeto de la BD
                var resultado = context.tbCategoria.ToList();

                //Convertirlo en un objeto SelectListItem
                var datos = resultado.Select(c => new SelectListItem
                {
                    Value = c.ConsecutivoCategoria.ToString(),
                    Text = c.Nombre
                }).ToList();

                datos.Insert(0, new SelectListItem
                {
                    Value = string.Empty,
                    Text = "Seleccione"
                });

                ViewBag.ListaCategorias = datos;
            }
        }

    }
}
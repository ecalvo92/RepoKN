using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
using KN_ProyectoWeb.Services;
using System.Linq;
using System.Web.Mvc;

namespace KN_ProyectoWeb.Controllers
{
    [Seguridad]
    public class CarritoController : Controller
    {
        Utilitarios utilitarios = new Utilitarios();

        [HttpGet]
        public ActionResult VerMiCarrito()
        {
            using (var context = new BD_KNEntities())
            {
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                //Tomar el objeto de la BD
                var resultado = context.tbCarrito.Include("tbProducto").Where(x => x.ConsecutivoUsuario == consecutivo).ToList();

                //Convertirlo en un objeto Propio
                var datos = resultado.Select(p => new Carrito
                {
                    ConsecutivoProducto = p.ConsecutivoProducto,
                    Nombre = p.tbProducto.Nombre,
                    Precio = p.tbProducto.Precio,
                    Cantidad = p.Cantidad,
                    SubTotal = p.tbProducto.Precio * p.Cantidad,
                    Impuesto = ((p.tbProducto.Precio * p.Cantidad) * 0.13M),
                    Total = ((p.tbProducto.Precio * p.Cantidad) * 1.13M)
                }).ToList();

                return View(datos);
            }
        }

        [HttpGet]
        public ActionResult RemoverProductoCarrito(int q)
        {
            var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

            using (var context = new BD_KNEntities())
            {
                //Tomar el objeto de la BD
                var resultadoConsulta = context.tbCarrito.Where(x => x.ConsecutivoProducto == q && x.ConsecutivoUsuario == consecutivo).FirstOrDefault();

                //Si existe se manda a actualizar
                if (resultadoConsulta != null)
                {
                    context.tbCarrito.Remove(resultadoConsulta);
                    context.SaveChanges();
                    utilitarios.CalcularResumenCarritoActual();
                }

                return RedirectToAction("VerMiCarrito", "Carrito");
            }
        }

        [HttpPost]
        public ActionResult RealizarPago(Pago pago)
        {
            var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

            using (var context = new BD_KNEntities())
            {
                //Un procedimiento almacenado que realiza el pago
                context.RealizarPago(consecutivo, pago.MetodoPago);
                return RedirectToAction("Principal", "Home");
            }
        }

    }
}
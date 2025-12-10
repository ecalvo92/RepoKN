using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
using KN_ProyectoWeb.Services;
using System.Collections.Generic;
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
                //consulta de usuarios y productos
                var usuarios = context.tbUsuario.Where(x => x.ConsecutivoPerfil != 1).ToList();
                var productos = context.tbProducto.ToList();

                ViewBag.CantidadUsuariosActivos = usuarios.Where(x => x.Estado == true).Count();
                ViewBag.CantidadUsuariosInactivos = usuarios.Where(x => x.Estado == false).Count();
                ViewBag.CantidadProductosActivos = productos.Where(x => x.Estado == true).Count();
                ViewBag.CantidadProductosInactivos = productos.Where(x => x.Estado == false).Count();


                //consulta de usuarios más frecuentes
                var usuariosFrecuentes = context.tbFactura
                    .GroupBy(x => x.ConsecutivoUsuario)
                    .OrderByDescending(y => y.Count())
                    .Take(5)
                    .ToList();

                var variableUsuariosFrecuentes = new List<UsuariosMasFrecuentes>();
                foreach (var item in usuariosFrecuentes)
                {
                    variableUsuariosFrecuentes.Add(new UsuariosMasFrecuentes
                    { 
                        NombreCliente = context.tbUsuario.FirstOrDefault(x => x.ConsecutivoUsuario == item.Key).Nombre,
                        CantidadVisitas = item.Count() 
                    });
                }


                //consulta de productos más vendidos
                var productosMasVendidos = context.tbDetalle
                    .GroupBy(x => x.ConsecutivoProducto)
                    .OrderByDescending(y => y.Sum(z => z.CantidadUnidades))
                    .Take(5)
                    .ToList();

                var variableProductosMasVendidos = new List<ProductosMasVendidos>();
                foreach (var item in productosMasVendidos)
                {
                    variableProductosMasVendidos.Add(new ProductosMasVendidos
                    {
                        NombreProducto = context.tbProducto.FirstOrDefault(x => x.ConsecutivoProducto == item.Key).Nombre,
                        CantidadVendida = item.Sum(x => x.CantidadUnidades)
                    });
                }


                var admin = new Admin();
                admin.listaUsuariosFrecuentes = variableUsuariosFrecuentes;
                admin.listaProductosMasVendidos = variableProductosMasVendidos;

                return View(admin);
            }
        }

        [HttpGet]
        public ActionResult ConsultaGrafico()
        {
            using (var context = new BD_KNEntities())
            {
                var ventas = context.ConsultarVentas().ToList();
                return Json(ventas, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
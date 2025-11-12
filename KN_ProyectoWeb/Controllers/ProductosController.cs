using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
using KN_ProyectoWeb.Services;
using System;
using System.IO;
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
            using (var context = new BD_KNEntities())
            {
                var nuevoProducto = new tbProducto
                {
                    ConsecutivoProducto = 0,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    ConsecutivoCategoria = producto.ConsecutivoCategoria,
                    Estado = true,
                    Imagen = string.Empty
                };

                context.tbProducto.Add(nuevoProducto);
                var resultadoInsercion = context.SaveChanges();

                if (resultadoInsercion > 0)
                {
                    //Guardar la imagen
                    var ext = Path.GetExtension(ImgProducto.FileName);
                    var ruta = AppDomain.CurrentDomain.BaseDirectory + "ImgProductos\\" + nuevoProducto.ConsecutivoProducto + ext;
                    ImgProducto.SaveAs(ruta);

                    //Actualizar la ruta de la imagen
                    nuevoProducto.Imagen = "/ImgProductos/" + nuevoProducto.ConsecutivoProducto + ext;
                    context.SaveChanges();

                    return RedirectToAction("VerProductos", "Productos");
                }
            }

            CargarValoresCategoria();
            ViewBag.Mensaje = "La información no se ha podido registrar";
            return View();
        }

        #endregion

        #region ActualizarProductos

        [HttpGet]
        public ActionResult ActualizarProductos(int q)
        {
            using (var context = new BD_KNEntities())
            {
                //Tomar el objeto de la BD
                var resultado = context.tbProducto.Where(x => x.ConsecutivoProducto == q).ToList();

                //Convertirlo en un objeto Propio
                var datos = resultado.Select(p => new Producto
                {
                    ConsecutivoProducto = p.ConsecutivoProducto,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    ConsecutivoCategoria = p.ConsecutivoCategoria,
                    Imagen = p.Imagen
                }).FirstOrDefault();

                CargarValoresCategoria();
                return View(datos);
            }
        }

        [HttpPost]
        public ActionResult ActualizarProductos(Producto producto, HttpPostedFileBase ImgProducto)
        {
            using (var context = new BD_KNEntities())
            {
                //Tomar el objeto de la BD
                var resultadoConsulta = context.tbProducto.Where(x => x.ConsecutivoProducto == producto.ConsecutivoProducto).FirstOrDefault();

                //Si existe se manda a actualizar
                if (resultadoConsulta != null)
                {
                    //Actualizar los campos del formulario
                    resultadoConsulta.Nombre = producto.Nombre;
                    resultadoConsulta.Descripcion = producto.Descripcion;
                    resultadoConsulta.Precio = producto.Precio;
                    resultadoConsulta.ConsecutivoCategoria = producto.ConsecutivoCategoria;
                    var resultadoactualizacion = context.SaveChanges();

                    if (resultadoactualizacion > 0)
                    {
                        if (ImgProducto != null)
                        {
                            //Guardar la imagen
                            var ext = Path.GetExtension(ImgProducto.FileName);
                            var ruta = AppDomain.CurrentDomain.BaseDirectory + "ImgProductos\\" + producto.ConsecutivoProducto + ext;
                            ImgProducto.SaveAs(ruta);
                        }

                        return RedirectToAction("VerProductos", "Productos");
                    }
                }

                CargarValoresCategoria();
                ViewBag.Mensaje = "La información no se ha podido actualizar";
                return View(producto);
            }
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
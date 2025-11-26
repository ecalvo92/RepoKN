using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
using KN_ProyectoWeb.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace KN_ProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        Utilitarios utilitarios = new Utilitarios();

        #region Iniciar Sesión

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            using (var context = new BD_KNEntities())
            {
                var resultado = context.tbUsuario.Where(x => x.CorreoElectronico == usuario.CorreoElectronico
                                                                   && x.Contrasenna == usuario.Contrasenna
                                                                   && x.Estado == true).FirstOrDefault();

                //var resultado = context.ValidarUsuarios(usuario.CorreoElectronico, usuario.Contrasenna).FirstOrDefault();

                if (resultado != null)
                {
                    Session["ConsecutivoUsuario"] = resultado.ConsecutivoUsuario;
                    Session["NombreUsuario"] = resultado.Nombre;
                    Session["PerfilUsuario"] = resultado.tbPerfil.Nombre;
                    Session["ConsecutivoPerfil"] = resultado.ConsecutivoPerfil;
                    return RedirectToAction("Principal", "Home");
                }

                ViewBag.Mensaje = "La información no se ha podido autenticar";
                return View();
            }
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
            using (var context = new BD_KNEntities())
            {
                //Se valida si el usuario ya existe
                var resultadoConsulta = context.tbUsuario.Where(x => x.Identificacion == usuario.Identificacion
                                                          || x.CorreoElectronico == usuario.CorreoElectronico).FirstOrDefault();

                //Si no existe se manda a crear
                if (resultadoConsulta == null)
                {
                    var nuevoUsuario = new tbUsuario
                    {
                        Identificacion = usuario.Identificacion,
                        Nombre = usuario.Nombre,
                        CorreoElectronico = usuario.CorreoElectronico,
                        Contrasenna = usuario.Contrasenna,
                        ConsecutivoPerfil = 2,
                        Estado = true
                    };

                    context.tbUsuario.Add(nuevoUsuario);
                    var resultadoInsercion = context.SaveChanges();

                    //var resultado = context.CrearUsuarios(usuario.Identificacion, usuario.Nombre, usuario.CorreoElectronico, usuario.Contrasenna);

                    if (resultadoInsercion > 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ViewBag.Mensaje = "La información no se ha podido registrar";
                return View();
            }
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
            using (var context = new BD_KNEntities())
            {
                //Se valida si el usuario ya existe
                var resultadoConsulta = context.tbUsuario.Where(x => x.CorreoElectronico == usuario.CorreoElectronico).FirstOrDefault();

                //Si existe se manda a recupear el acceso
                if (resultadoConsulta != null)
                {
                    var contrasennaGenerada = utilitarios.GenerarContrasenna();

                    //Actualizar la nueva contraseña
                    resultadoConsulta.Contrasenna = contrasennaGenerada;
                    var resultadoactualizacion = context.SaveChanges();

                    //Envía el correo electrónico
                    if (resultadoactualizacion > 0)
                    {
                        //StringBuilder mensaje = new StringBuilder();
                        //mensaje.Append("Estimado(a) " + resultadoConsulta.Nombre + "<br>");
                        //mensaje.Append("Se ha generado una solicitud de recuperación de acceso a su nombre" + "<br><br>");
                        //mensaje.Append("Su nueva contraseña de acceso es: <b>" + contrasennaGenerada + "</b><br><br>");
                        //mensaje.Append("Procure realizar el cambio de su contraseña una vez ingrese al sistema" + "<br><br>");
                        //mensaje.Append("Muchas gracias");

                        string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                        string path = Path.Combine(projectRoot, "TemplateRecuperacion.html");

                        // Leer todo el HTML
                        string htmlTemplate = System.IO.File.ReadAllText(path);

                        // Reemplazar placeholders
                        string mensaje = htmlTemplate
                            .Replace("{{Nombre}}", resultadoConsulta.Nombre)
                            .Replace("{{Contrasena}}", contrasennaGenerada);

                        utilitarios.EnviarCorreo("Contraseña de acceso", mensaje, resultadoConsulta.CorreoElectronico);
                        return RedirectToAction("Index", "Home");
                    }
                }

                ViewBag.Mensaje = "La información no se ha podido reestablecer";
                return View();
            }
        }

        #endregion

        [Seguridad]
        [HttpGet]
        public ActionResult Principal()
        {
            if (Session["ConsecutivoPerfil"].ToString() == "1")
                return RedirectToAction("Principal", "Admin");

            CalcularResumenCarritoActual();

            var datos = ConsultarDatosVender();
            return View(datos);
        }

        [Seguridad]
        [HttpPost]
        public ActionResult AgregarProductoCarrito(Producto producto)
        {
            using (var context = new BD_KNEntities())
            {
                var disponibilidad = context.tbProducto.Where(x => x.ConsecutivoProducto == producto.ConsecutivoProducto).FirstOrDefault();

                if (producto.Cantidad > disponibilidad.Cantidad)
                {
                    ViewBag.Mensaje = "No contamos con la cantidad de productos solicitados, productos en inventario: " + disponibilidad.Cantidad;
                    return View("Principal", ConsultarDatosVender());
                }

                var consecutivoUsuario = int.Parse(Session["ConsecutivoUsuario"].ToString());
                var resultado = context.tbCarrito.Where(x => x.ConsecutivoProducto == producto.ConsecutivoProducto && x.ConsecutivoUsuario == consecutivoUsuario).FirstOrDefault();

                if (resultado == null)
                {
                    var nuevoCarrito = new tbCarrito
                    {
                        ConsecutivoUsuario = consecutivoUsuario,
                        ConsecutivoProducto = producto.ConsecutivoProducto,
                        Cantidad = producto.Cantidad.Value,
                        Fecha = DateTime.Now
                    };

                    context.tbCarrito.Add(nuevoCarrito);
                    context.SaveChanges();
                }
                else
                {
                    resultado.Cantidad = producto.Cantidad.Value;
                    resultado.Fecha = DateTime.Now;
                    context.SaveChanges();
                }

                return RedirectToAction("Principal","Home");
            }
        }

        [Seguridad]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        private List<Producto> ConsultarDatosVender()
        {
            using (var context = new BD_KNEntities())
            {
                //Tomar el objeto de la BD
                var resultado = context.tbProducto.Include("tbCategoria")
                    .Where(x => x.Estado == true
                        && x.Cantidad > 0).ToList();

                //Convertirlo en un objeto Propio
                var datos = resultado.Select(p => new Producto
                {
                    ConsecutivoProducto = p.ConsecutivoProducto,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Cantidad = p.Cantidad,
                    NombreCategoria = p.tbCategoria.Nombre,
                    Estado = p.Estado,
                    Imagen = p.Imagen
                }).ToList();

                return datos;
            }
        }

        private void CalcularResumenCarritoActual()
        {
            using (var context = new BD_KNEntities())
            {
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                //Tomar el objeto de la BD
                var resultado = context.tbCarrito.Include("tbProducto").Where(x => x.ConsecutivoUsuario == consecutivo).ToList();

                var subTotal = resultado.Sum(x => x.tbProducto.Precio * x.Cantidad);

                Session["Total"] = subTotal * 1.13M;
                Session["Cantidad"] = resultado.Sum(x => x.Cantidad);
            }
        }
    }
}
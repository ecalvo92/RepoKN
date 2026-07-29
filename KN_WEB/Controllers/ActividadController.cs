using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Servicios;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    [LogActionFilter]
    [TutorActionFilter]
    public class ActividadController : Controller
    {
        readonly UtilitarioService utilitario = new UtilitarioService();

        [HttpGet]
        public ActionResult VerActividades()
        {
            try
            {
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                using (var context = new KN_BDEntities())
                {
                    var actividades = (from A in context.tbActividad.Include("tbEstados")
                                       where A.ConsecutivoUsuario == consecutivo
                                       select A).ToList();

                    return View(actividades);
                }
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        #region Agregar

        [HttpGet]
        public ActionResult AgregarActividad()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AgregarActividad(tbActividad model, HttpPostedFileBase Imagen)
        {
            try
            {
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                using (var context = new KN_BDEntities())
                {
                    model.Imagen = string.Empty;
                    model.FechaRegistro = DateTime.Now;
                    model.ConsecutivoEstado = 1;
                    model.ConsecutivoUsuario = consecutivo;

                    context.tbActividad.Add(model);
                    context.SaveChanges();

                    if (Imagen != null && Imagen.ContentLength > 0)
                    {
                        var extension = Path.GetExtension(Imagen.FileName).ToLower();
                        var carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ActividadesIMG");

                        if (!Directory.Exists(carpeta))
                            Directory.CreateDirectory(carpeta);

                        var nombreArchivo = $"{model.Consecutivo}{extension}";
                        var ruta = Path.Combine(carpeta, nombreArchivo);
                        Imagen.SaveAs(ruta);

                        model.Imagen = nombreArchivo;
                        context.SaveChanges();
                    }
                }

                return RedirectToAction("VerActividades");
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        #endregion

        #region Actualizar

        [HttpGet]
        public ActionResult ActualizarActividad(int id)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var actividad = (from A in context.tbActividad.Include("tbEstados")
                                     where A.Consecutivo == id
                                     select A).FirstOrDefault();

                    return View(actividad);
                }
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult ActualizarActividad(tbActividad model, HttpPostedFileBase Imagen)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var existeActividad = (from U in context.tbActividad
                                           where U.Consecutivo == model.Consecutivo
                                           select U).FirstOrDefault();

                    if (existeActividad == null)
                    {
                        ViewBag.Mensaje = "La información de la actividad no se pudo cargar";
                        return View(model);
                    }

                    existeActividad.Titulo = model.Titulo;
                    existeActividad.Inicio = model.Inicio;
                    existeActividad.Fin = model.Fin;
                    context.SaveChanges();

                    if (Imagen != null && Imagen.ContentLength > 0)
                    {
                        var extension = Path.GetExtension(Imagen.FileName).ToLower();
                        var carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ActividadesIMG");

                        if (!Directory.Exists(carpeta))
                            Directory.CreateDirectory(carpeta);

                        var nombreArchivo = $"{model.Consecutivo}{extension}";
                        var ruta = Path.Combine(carpeta, nombreArchivo);
                        Imagen.SaveAs(ruta);

                        model.Imagen = nombreArchivo;
                        context.SaveChanges();
                    }
                }

                return RedirectToAction("VerActividades");
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        #endregion

        [HttpPost]
        public ActionResult CancelarActividad(int id)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var actividad = (from A in context.tbActividad
                                     where A.Consecutivo == id
                                     select A).FirstOrDefault();

                    if (actividad != null)
                    {
                        actividad.ConsecutivoEstado = 3;
                        context.SaveChanges();
                    }
                }

                return Json("Ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

    }
}
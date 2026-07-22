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
                    var actividades = (from A in context.tbActividad
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
                    model.Estado = 0;
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

    }
}
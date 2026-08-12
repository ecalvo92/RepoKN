using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    [LogActionFilter]
    public class CatalogoActividadesController : Controller
    {
        readonly UtilitarioService utilitario = new UtilitarioService();

        [HttpGet]
        public ActionResult VerActividadesDisponibles()
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                    var actividades = (from A in context.tbActividad
                                       .Include("tbUsuario")
                                       where A.ConsecutivoEstado == 1
                                          && A.Inicio >= DateTime.Now
                                          && !A.EstudiantesActividades.Any(e => e.ConsecutivoUsuario == consecutivo)
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

        [HttpPost]
        public ActionResult Inscribirse(int id)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                    //Insertar una matricula nueva
                    context.EstudiantesActividades.Add(new EstudiantesActividades
                    {
                        ConsecutivoUsuario = consecutivo,
                        ConsecutivoActividad = id,
                        FechaInscripcion = DateTime.Now
                    });

                    context.SaveChanges();
                }

                return Json("Inscripción Completada", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult MisActividades()
        {
            try
            {
                int consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                using (KN_BDEntities context = new KN_BDEntities())
                {
                    List<EstudiantesActividades> misActividades = context.EstudiantesActividades
                        .Include("tbActividad")
                        .Include("tbActividad.tbUsuario")
                        .Include("tbActividad.tbEstados")
                        .Where(e => e.ConsecutivoUsuario == consecutivo)
                        .OrderByDescending(e => e.tbActividad.Inicio)
                        .ToList();

                    return View(misActividades);
                }
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Desinscribirse(int id)
        {
            try
            {
                int consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                using (KN_BDEntities context = new KN_BDEntities())
                {
                    EstudiantesActividades inscripcion = context.EstudiantesActividades
                        .Include("tbActividad")
                        .FirstOrDefault(e => e.ConsecutivoActividad == id && e.ConsecutivoUsuario == consecutivo);

                    if (inscripcion == null)
                        return Json("Inscripción no encontrada", JsonRequestBehavior.AllowGet);

                    if (inscripcion.tbActividad.Inicio <= DateTime.Now)
                        return Json("No es posible desinscribirse de una actividad que ya inició", JsonRequestBehavior.AllowGet);

                    context.EstudiantesActividades.Remove(inscripcion);
                    context.SaveChanges();
                }

                return Json("Desinscripción completada", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return Json("Error al procesar la solicitud", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
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
                    var actividades = (from A in context.tbActividad.Include("tbEstados").Include("tbUsuario")
                                       where A.ConsecutivoEstado == 1
                                          && A.Inicio >= DateTime.Now
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
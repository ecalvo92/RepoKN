using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Servicios;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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

        [HttpGet]
        public ActionResult AgregarActividad()
        {
            return View();
        }
    }
}
using KN_WEB.Servicios;
using Microsoft.Ajax.Utilities;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    public class UsuarioController : Controller
    {
        readonly UtilitarioService utilitario = new UtilitarioService();

        [HttpGet]
        public ActionResult ConsultarPerfil()
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

        #region Cambiar Contraseña

        [HttpGet]
        public ActionResult Seguridad()
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

        #endregion

    }
}
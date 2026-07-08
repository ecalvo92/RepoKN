using KN_WEB.Models;
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

        #region Configuracion

        [HttpGet]
        public ActionResult Configuracion()
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
        public ActionResult CambiarContrasenna(UsuarioModel model)
        {
            try
            {
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                //Actualizar la contraseña del usuario en la base de datos

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
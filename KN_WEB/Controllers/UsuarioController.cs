using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Servicios;
using System;
using System.Linq;
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
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                using (var context = new KN_BDEntities())
                {
                    var existeUsuario = (from U in context.tbUsuario
                                         where U.Consecutivo == consecutivo
                                         select U).FirstOrDefault();

                    if (existeUsuario == null)
                    {
                        ViewBag.Mensaje = "La información no se ha podido validar";
                        return View();
                    }

                    return View(new UsuarioModel 
                    {
                        Nombre = existeUsuario.Nombre,
                        CorreoElectronico = existeUsuario.CorreoElectronico
                    });
                }
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

                using (var context = new KN_BDEntities())
                {
                    var existeUsuario = (from U in context.tbUsuario
                                         where U.Consecutivo == consecutivo
                                         select U).FirstOrDefault();

                    if (existeUsuario == null)
                    {
                        ViewBag.Mensaje = "La información no se ha podido validar";
                        return View();
                    }

                    //Actualizar la información de un usuario
                    existeUsuario.Contrasenna = model.Contrasenna;
                    existeUsuario.TieneContrasennaTemp = false;
                    var response = context.SaveChanges();

                    if (response <= 0)
                    {
                        ViewBag.Mensaje = "No se ha podido actualizar la información";
                        return View("Configuracion", model);
                    }

                    return RedirectToAction("CerrarSesion", "Home");
                }
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult CambiarPerfil(UsuarioModel model)
        {
            try
            {
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                using (var context = new KN_BDEntities())
                {
                    var existeUsuario = (from U in context.tbUsuario
                                         where U.Consecutivo == consecutivo
                                         select U).FirstOrDefault();

                    if (existeUsuario == null)
                    {
                        ViewBag.Mensaje = "La información no se ha podido validar";
                        return View();
                    }

                    //Actualizar la información de un usuario
                    existeUsuario.Nombre = model.Nombre;
                    existeUsuario.CorreoElectronico = model.CorreoElectronico;
                    var response = context.SaveChanges();

                    if (response <= 0)
                    {
                        ViewBag.Mensaje = "No se ha podido actualizar la información";
                        return View();
                    }

                    ViewBag.Mensaje = "Su información se ha actualizado correctamente";
                    return View("Configuracion", model);
                }
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
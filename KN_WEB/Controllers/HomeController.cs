using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Servicios;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    public class HomeController : Controller
    {
        /*
            Action = Eventos disparados por el usuario desde una vista
            Método = Funciones pública o privada Centralizar Código y Reutilizarlo
            Instancia = Trabajar con clases (objeto, entidad) externas
            Tipos de datos = Trabajar con información
        */

        readonly UtilitarioService utilitario = new UtilitarioService();

        #region Autenticación de usuarios

        [HttpGet]
        public ActionResult Index()
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
        public ActionResult Index(UsuarioModel model)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var response = (from U in context.tbUsuario
                                    where U.CorreoElectronico == model.CorreoElectronico
                                    && U.Contrasenna == model.Contrasenna
                                    && U.Estado == true
                                    select U).FirstOrDefault();

                    if (response == null)
                    {
                        ViewBag.Mensaje = "La información no se ha podido autenticar";
                        return View();
                    }

                    if(response.TieneContrasennaTemp && response.VigenciaContrasennaTemp < DateTime.Now)
                    {
                        ViewBag.Mensaje = "Su contraseña temporal ya no es válida";
                        return View();
                    }

                    Session["NombreUsuario"] = response.Nombre;
                    Session["ConsecutivoUsuario"] = response.Consecutivo;
                    return RedirectToAction("Principal", "Home");
                }
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        #endregion

        #region Registro de usuarios

        [HttpGet]
        public ActionResult Registro()
        {
            try
            {
                //Me permite abrir una vista, se dispara en un redireccionamiento o hipervínculo
                return View();
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Registro(UsuarioModel model)
        {
            try
            {
                //Me permite programar una acción en una vista, se dispara al presionar un botón de tipo 'submit'
                using (var context = new KN_BDEntities())
                {
                    //Validar que la identificación o el correo no estén en uso 
                    var existeUsuario = (from U in context.tbUsuario
                                         where U.Identificacion == model.Identificacion
                                         || U.CorreoElectronico == model.CorreoElectronico
                                         select U).FirstOrDefault();

                    if (existeUsuario != null)
                    {
                        ViewBag.Mensaje = "La información no se ha podido registrar";
                        return View();
                    }

                    //Insertar un usuario nuevo
                    context.tbUsuario.Add(new tbUsuario
                    {
                        Identificacion = model.Identificacion,
                        Nombre = model.Nombre,
                        CorreoElectronico = model.CorreoElectronico,
                        Contrasenna = model.Contrasenna,
                        Estado = true
                    });

                    var response = context.SaveChanges();

                    if (response <= 0)
                    {
                        ViewBag.Mensaje = "La información no se ha podido registrar";
                        return View();
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        #endregion

        #region Recuperar acceso al sistema

        [HttpGet]
        public ActionResult RecuperarAcceso()
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
        public ActionResult RecuperarAcceso(UsuarioModel model)
        {
            try
            {
                using (var context = new KN_BDEntities())
                {
                    var existeUsuario = (from U in context.tbUsuario
                                         where U.CorreoElectronico == model.CorreoElectronico
                                         && U.Estado == true
                                         select U).FirstOrDefault();

                    if (existeUsuario == null)
                    {
                        ViewBag.Mensaje = "La información no se ha podido validar";
                        return View();
                    }

                    var temporal = utilitario.GenerarContraseña();

                    //Actualizar la información de un usuario
                    existeUsuario.Contrasenna = temporal;
                    existeUsuario.TieneContrasennaTemp = true;
                    existeUsuario.VigenciaContrasennaTemp = DateTime.Now.AddMinutes(15);
                    var response = context.SaveChanges();

                    if (response > 0)
                    {
                        //Enviar un correo electrónico al usuario con la contraseña temporal y vigencia de 15 minutos
                        utilitario.EnviarCorreo(existeUsuario.CorreoElectronico, 
                            "Recuperación de acceso", 
                            $"Su contraseña temporal es: {temporal}. Esta contraseña es válida por 15 minutos.");

                        return RedirectToAction("Index", "Home");
                    }
                }

                ViewBag.Mensaje = "Su acceso no se ha podido recuperar";
                return View();
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

        #endregion

        [HttpGet]
        public ActionResult Principal()
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

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            try
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, MethodBase.GetCurrentMethod().Name);
                return View("Error");
            }
        }

    }
}
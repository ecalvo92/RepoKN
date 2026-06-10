using KN_WEB.EF;
using KN_WEB.Models;
using KN_WEB.Servicios;
using System;
using System.Linq;
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

        UtilitarioService utilitario = new UtilitarioService();

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
                utilitario.RegistrarErrorBitacora(ex.Message, "Registro", 0);
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
                    var infoUsuario = (from U in context.tbUsuario
                                       where U.CorreoElectronico == model.CorreoElectronico
                                       && U.Contrasenna == model.Contrasenna
                                       && U.Estado == true
                                       select U).FirstOrDefault();

                    if (infoUsuario == null)
                    {
                        return View();
                    }

                    return RedirectToAction("Principal", "Home");
                }
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, "Registro", 0);
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
                utilitario.RegistrarErrorBitacora(ex.Message, "Registro", 0);
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
                    context.tbUsuario.Add(new tbUsuario
                    {
                        Identificacion = model.Identificacion,
                        Nombre = model.Nombre,
                        CorreoElectronico = model.CorreoElectronico,
                        Contrasenna = model.Contrasenna,
                        Estado = true
                    });

                    context.SaveChanges();
                    return View();
                }
            }
            catch (Exception ex)
            {
                utilitario.RegistrarErrorBitacora(ex.Message, "Registro", 0);
                return View("Error");
            }
        }

        #endregion

        [HttpGet]
        public ActionResult RecuperarAcceso()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Principal()
        {
            return View();
        }

    }
}
using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
using System.Linq;
using System.Web.Mvc;

namespace KN_ProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        #region Iniciar Sesión

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            using (var context = new BD_KNEntities())
            {
                var resultado = context.tbUsuario.Where(x => x.CorreoElectronico == usuario.CorreoElectronico
                                                                   && x.Contrasenna == usuario.Contrasenna
                                                                   && x.Estado == true).FirstOrDefault();

                //var resultado = context.ValidarUsuarios(usuario.CorreoElectronico, usuario.Contrasenna).FirstOrDefault();

                if (resultado != null)
                {
                    return RedirectToAction("Principal", "Home");
                }

                ViewBag.Mensaje = "La información no se ha podido autenticar";
                return View();
            }
        }

        #endregion

        #region Registro

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            using (var context = new BD_KNEntities())
            {
                //Se valida si el usuario ya existe
                var resultadoConsulta = context.tbUsuario.Where(x => x.Identificacion == usuario.Identificacion
                                                          || x.CorreoElectronico == usuario.CorreoElectronico).FirstOrDefault();

                //Si no existe se manda a crear
                if (resultadoConsulta == null)
                {
                    var nuevoUsuario = new tbUsuario
                    {
                        Identificacion = usuario.Identificacion,
                        Nombre = usuario.Nombre,
                        CorreoElectronico = usuario.CorreoElectronico,
                        Contrasenna = usuario.Contrasenna,
                        ConsecutivoPerfil = 2,
                        Estado = true
                    };

                    context.tbUsuario.Add(nuevoUsuario);
                    var resultadoInsercion = context.SaveChanges();

                    //var resultado = context.CrearUsuarios(usuario.Identificacion, usuario.Nombre, usuario.CorreoElectronico, usuario.Contrasenna);

                    if (resultadoInsercion > 0)
                    {
                        return RedirectToAction("Index", "home");
                    }
                }               

                ViewBag.Mensaje = "La información no se ha podido registrar";
                return View();
            }            
        }

        #endregion

        #region Recuperar Acceso

        [HttpGet]
        public ActionResult RecuperarAcceso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarAcceso(Usuario usuario)
        {
            using (var context = new BD_KNEntities())
            {
                //Se valida si el usuario ya existe
                var resultadoConsulta = context.tbUsuario.Where(x => x.CorreoElectronico == usuario.CorreoElectronico).FirstOrDefault();

                //Si existe se manda a recupear el acceso
                if (resultadoConsulta != null)
                {

                }

                ViewBag.Mensaje = "La información no se ha podido reestablecer";
                return View();
            }
        }

        #endregion

        [HttpGet]
        public ActionResult Principal()
        {
            return View();
        }

    }
}
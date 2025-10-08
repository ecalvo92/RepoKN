using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
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
            /*Progra para validar si usuario.CorreoElectronico y usuario.Contrasenna*/

            return RedirectToAction("Principal", "Home");
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
                //var nuevoUsuario = new tbUsuario
                //{
                //    Identificacion = usuario.Identificacion,
                //    Nombre = usuario.Nombre,
                //    CorreoElectronico = usuario.CorreoElectronico,
                //    Contrasenna = usuario.Contrasenna,
                //    ConsecutivoPerfil = 2,
                //    Estado = true
                //};

                //context.tbUsuario.Add(nuevoUsuario);
                //var resultado = context.SaveChanges();

                var resultado = context.CrearUsuarios(usuario.Identificacion, usuario.Nombre, usuario.CorreoElectronico, usuario.Contrasenna);

                if (resultado > 0)
                {
                    return RedirectToAction("Index", "home");
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
            /*Validar si el usuario existe, generarle un contraseña tmp, enviarle esa clave tmp*/

            return View();
        }

        #endregion

        [HttpGet]
        public ActionResult Principal()
        {
            return View();
        }

    }
}
using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
using KN_ProyectoWeb.Services;
using System.Linq;
using System.Web.Mvc;

namespace KN_ProyectoWeb.Controllers
{
    [Seguridad]
    //[OutputCache(Duration = 0, Location = OutputCacheLocation.None, NoStore = true, VaryByParam = "*")]
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult VerPerfil()
        {
            using (var context = new BD_KNEntities())
            {
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                //Tomar el objeto de la BD
                var resultado = context.tbUsuario.Include("tbPerfil").Where(x => x.ConsecutivoUsuario == consecutivo).ToList();

                //Convertirlo en un objeto Propio
                var datos = resultado.Select(p => new Usuario
                {
                    Identificacion = p.Identificacion,
                    Nombre = p.Nombre,
                    CorreoElectronico = p.CorreoElectronico,
                    NombrePerfil = p.tbPerfil.Nombre
                }).FirstOrDefault();

                return View(datos);
            }
        }
    }
}
using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
using KN_ProyectoWeb.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KN_ProyectoWeb.Controllers
{
    [Seguridad]
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

        [HttpPost]
        public ActionResult VerPerfil(Usuario usuario)
        {
            ViewBag.Mensaje = "La información no se actualizó correctamente";
           
            using (var context = new BD_KNEntities())
            {
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                //Tomar el objeto de la BD
                var resultadoConsulta = context.tbUsuario.Where(x => x.ConsecutivoUsuario == consecutivo).FirstOrDefault();

                //Si existe se manda a actualizar
                if (resultadoConsulta != null)
                {
                    //Actualizar los campos del formulario
                    resultadoConsulta.Identificacion = usuario.Identificacion;
                    resultadoConsulta.Nombre = usuario.Nombre;
                    resultadoConsulta.CorreoElectronico = usuario.CorreoElectronico;
                    var resultadoactualizacion = context.SaveChanges();

                    if (resultadoactualizacion > 0)
                    {
                        ViewBag.Mensaje = "La información se actualizó correctamente";
                        Session["NombreUsuario"] = usuario.Nombre;
                    }
                }

                return View();
            }
        }


        [HttpGet]
        public ActionResult CambiarAcceso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarAcceso(Usuario usuario)
        {
            ViewBag.Mensaje = "La información no se actualizó correctamente";

            using (var context = new BD_KNEntities())
            {
                var consecutivo = int.Parse(Session["ConsecutivoUsuario"].ToString());

                //Tomar el objeto de la BD
                var resultadoConsulta = context.tbUsuario.Where(x => x.ConsecutivoUsuario == consecutivo).FirstOrDefault();

                //Si existe se manda a actualizar
                if (resultadoConsulta != null)
                {
                    //Actualizar los campos del formulario
                    resultadoConsulta.Contrasenna = usuario.Contrasenna;
                    var resultadoactualizacion = context.SaveChanges();

                    if (resultadoactualizacion > 0)
                        ViewBag.Mensaje = "La información se actualizó correctamente";
                }

                return View();
            }
        }


        [HttpGet]
        public ActionResult VerUsuarios()
        {
            using (var context = new BD_KNEntities())
            {
                //Tomar el objeto de la BD
                var resultado = ConsultarUsuarios();
                return View(resultado);
            }
        }

        [HttpGet]
        public ActionResult ActualizarEstadoUsuario(int q)
        {
            using (var context = new BD_KNEntities())
            {
                //Tomar el objeto de la BD
                var resultadoConsulta = context.tbUsuario.Where(x => x.ConsecutivoUsuario == q).FirstOrDefault();

                //Si existe se manda a actualizar
                if (resultadoConsulta != null)
                {
                    //Elimino
                    //context.tbProducto.Remove(resultadoConsulta);

                    //Inactivando
                    resultadoConsulta.Estado = resultadoConsulta.Estado ? false : true;

                    var resultadoactualizacion = context.SaveChanges();

                    if (resultadoactualizacion > 0)
                        return RedirectToAction("VerUsuarios", "Usuario");
                }

                var resultado = ConsultarUsuarios();
                ViewBag.Mensaje = "La información no se ha podido actualizar";
                return View("VerUsuarios", resultado);
            }
        }

        private List<tbUsuario> ConsultarUsuarios()
        {
            using (var context = new BD_KNEntities())
            {
                var datos = context.tbUsuario.Where(x => x.ConsecutivoPerfil == 2).ToList();
                return datos;
            }
        }

    }
}
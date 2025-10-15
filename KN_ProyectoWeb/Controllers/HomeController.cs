using KN_ProyectoWeb.EF;
using KN_ProyectoWeb.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
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
                    var contrasennaGenerada = GenerarContrasenna();

                    //Actualizar la nueva contraseña
                    resultadoConsulta.Contrasenna = contrasennaGenerada;
                    var resultadoactualizacion = context.SaveChanges();

                    //Envía el correo electrónico
                    if (resultadoactualizacion > 0)
                    {
                        //StringBuilder mensaje = new StringBuilder();
                        //mensaje.Append("Estimado(a) " + resultadoConsulta.Nombre + "<br>");
                        //mensaje.Append("Se ha generado una solicitud de recuperación de acceso a su nombre" + "<br><br>");
                        //mensaje.Append("Su nueva contraseña de acceso es: <b>" + contrasennaGenerada + "</b><br><br>");
                        //mensaje.Append("Procure realizar el cambio de su contraseña una vez ingrese al sistema" + "<br><br>");
                        //mensaje.Append("Muchas gracias");

                        string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                        string path = Path.Combine(projectRoot, "TemplateRecuperacion.html");

                        // Leer todo el HTML
                        string htmlTemplate = System.IO.File.ReadAllText(path);

                        // Reemplazar placeholders
                        string mensaje = htmlTemplate
                            .Replace("{{Nombre}}", resultadoConsulta.Nombre)
                            .Replace("{{Contrasena}}", contrasennaGenerada);

                        EnviarCorreo("Contraseña de acceso", mensaje, resultadoConsulta.CorreoElectronico);
                        return RedirectToAction("Index","Home");
                    }
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


        private string GenerarContrasenna()
        {
            int longitud = 8;
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] resultado = new char[longitud];

            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[sizeof(uint)];

                for (int i = 0; i < longitud; i++)
                {
                    rng.GetBytes(buffer);
                    uint num = BitConverter.ToUInt32(buffer, 0);
                    resultado[i] = caracteres[(int)(num % (uint)caracteres.Length)];
                }
            }

            return new string(resultado);
        }

        private void EnviarCorreo(string asunto, string contenido, string destinatario)
        {
            var correoSMTP = ConfigurationManager.AppSettings["CorreoSMTP"];
            var contrasennaSMTP = ConfigurationManager.AppSettings["ContrasennaSMTP"];

            var smtp = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(correoSMTP, contrasennaSMTP),
                EnableSsl = true
            };

            var mensaje = new MailMessage
            {
                From = new MailAddress(correoSMTP),
                Subject = asunto,
                Body = contenido,
                IsBodyHtml = true
            };

            mensaje.To.Add(destinatario);
            smtp.Send(mensaje);
        }
    }
}
using KN_WEB.EF;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace KN_WEB.Servicios
{
    public class UtilitarioService
    {
        public void RegistrarErrorBitacora(string mensaje, string lugar)
        {
            using (var context = new KN_BDEntities())
            {
                var usuario = 0;
                if(HttpContext.Current.Session["ConsecutivoUsuario"] != null)
                    usuario = (int)HttpContext.Current.Session["ConsecutivoUsuario"];

                //var usuario = HttpContext.Current.Session["ConsecutivoUsuario"] != null
                // ? (int)HttpContext.Current.Session["ConsecutivoUsuario"]
                // : 0;

                //var usuario = (int?)HttpContext.Current.Session["ConsecutivoUsuario"] ?? 0;

                context.spRegistrarError(mensaje, DateTime.Now, lugar, usuario);
            }
        }

        public string GenerarContraseña()
        {
            var random = new Random();
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const string especiales = "!@#$%&*";

            char[] password = Enumerable.Repeat(caracteres, 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray();

            // Reemplaza un carácter por un especial
            password[random.Next(password.Length)] = especiales[random.Next(especiales.Length)];

            return new string(password);
        }

        public void EnviarCorreo(string destinatario, string asunto, string cuerpo)
        {
            var CorreoSalida = ConfigurationManager.AppSettings["CorreoSalida"];
            var ContrasennaCorreoSalida = ConfigurationManager.AppSettings["ContrasennaCorreoSalida"];

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(CorreoSalida);
                mail.To.Add(destinatario);
                mail.Subject = asunto;
                mail.Body = cuerpo;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(CorreoSalida, ContrasennaCorreoSalida);
                    smtp.EnableSsl = true;

                    if (!string.IsNullOrEmpty(ContrasennaCorreoSalida))
                    {
                        smtp.Send(mail);
                    }
                }
            }
        }

    }
}
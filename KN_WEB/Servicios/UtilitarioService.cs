using KN_WEB.EF;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace KN_WEB.Servicios
{
    public class UtilitarioService
    {
        public void RegistrarErrorBitacora(string mensaje, string lugar, int usuario)
        {
            using (var context = new KN_BDEntities())
            {
                context.spRegistrarError(mensaje, DateTime.Now, lugar, usuario);
            }
        }

        public string GenerarContraseña()
        {
            var random = new Random();
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(caracteres, 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
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

                using (SmtpClient smtp = new SmtpClient("smtp.office365.com", 587))
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
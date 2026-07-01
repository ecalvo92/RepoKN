using KN_WEB.EF;
using System;
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
            string servidorSmtp = "smtp.office365.com";
            int puerto = 587;
            string correoOrigen = "ecalvo90415@ufide.ac.cr";
            string contraseña = "XXXXXXXXXXX";

            using (var mensaje = new MailMessage(correoOrigen, destinatario, asunto, cuerpo))
            {
                mensaje.IsBodyHtml = true;

                using (var cliente = new SmtpClient(servidorSmtp, puerto))
                {
                    cliente.EnableSsl = true;
                    cliente.Credentials = new NetworkCredential(correoOrigen, contraseña);
                    cliente.Send(mensaje);
                }
            }
        }

    }
}
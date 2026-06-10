using KN_WEB.EF;
using System;

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

    }
}
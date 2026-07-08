namespace KN_WEB.Models
{
    public class UsuarioModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasenna { get; set; }

        public string ConfirmarContrasenna { get; set; }
    }
}
namespace KN_ProyectoWeb.Models
{
    public class Producto
    {
        public int ConsecutivoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int ConsecutivoCategoria { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
    }
}
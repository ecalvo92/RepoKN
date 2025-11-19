using System;

namespace KN_ProyectoWeb.Models
{
    public class Carrito
    {
        public int ConsecutivoCarrito { get; set; }
        public int ConsecutivoProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
    }
}
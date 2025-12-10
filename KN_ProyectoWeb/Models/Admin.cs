using System.Collections.Generic;

namespace KN_ProyectoWeb.Models
{
    public class Admin
    {
        public List<UsuariosMasFrecuentes> listaUsuariosFrecuentes { get; set; }
        public List<ProductosMasVendidos> listaProductosMasVendidos { get; set; }
    }

    public class UsuariosMasFrecuentes
    {
        public string NombreCliente { get; set; }
        public int CantidadVisitas { get; set; }
    }

    public class ProductosMasVendidos
    {
        public string NombreProducto { get; set; }
        public int CantidadVendida { get; set; }
    }

}
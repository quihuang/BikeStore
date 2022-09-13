using System;

namespace BikeStore.App.Dominio
{
    public class Inventario
    {
        public int Id { get; set; }
        public int ProductoId { get; set; } // antes era "public Producto Producto { get; set; }"
        public int Existencias { get; set; }
        public int NumeroRefCompra { get; set; }
        public Double PrecioUniVenta { get; set; }
        public Double PrecioUniCompra { get; set; }
    }
}

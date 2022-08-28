using System;

namespace BikeStore.App.Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadProducto { get; set; }
        public int ValorVenta { get; set; }
        public Comercial Comercial { get; set; }
        public Cliente Cliente { get; set; }
        public Inventario Inventario { get; set; }
    }
}

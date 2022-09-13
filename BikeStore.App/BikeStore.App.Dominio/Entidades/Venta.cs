using System;

namespace BikeStore.App.Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadProducto { get; set; }
        public int ValorVenta { get; set; }
        public int TrabajadorId { get; set; }   // antes era "public Trabajador Trabajador { get; set; }"
        public int ClienteId { get; set; }      // antes era "public Cliente Cliente { get; set; }"
        public int InventarioId { get; set; }   // antes era "public Inventario Inventario { get; set; }"
    }
}

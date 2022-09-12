using System;

namespace BikeStore.App.Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadProducto { get; set; }
        public int ValorVenta { get; set; }
        public int TrabajadorId { get; set; }
        public int ClienteId { get; set; }
        public int InventarioId { get; set; }
    }
}

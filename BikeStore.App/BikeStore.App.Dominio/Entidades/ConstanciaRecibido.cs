using System;

namespace BikeStore.App.Dominio
{
    public class ConstanciaRecibido
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Bodeguero Bodeguero { get; set; }
        public Inventario Inventario { get; set; }
    }
}

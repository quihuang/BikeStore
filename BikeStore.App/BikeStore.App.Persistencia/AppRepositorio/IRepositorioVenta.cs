using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public interface IRepositorioVenta
    {
        IEnumerable<Venta> GetAllVentas();
        Venta GetVenta(int idVenta);
        int AddVenta(Venta Venta);
        int UpdateVenta(Venta Venta);
        int DeleteVenta(Venta Venta);
        long GetTotalGanancia();
        long GetTotalVendidos();
    } 
}
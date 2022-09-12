using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public interface IRepositorioInventario
    {
        IEnumerable<Inventario> GetAllInventarios();
        Inventario GetInventario(int idInventario);
        int AddInventario(Inventario Inventario);
        int UpdateInventario(Inventario Inventario);
        int DeleteInventario(Inventario Inventario);
    } 
}
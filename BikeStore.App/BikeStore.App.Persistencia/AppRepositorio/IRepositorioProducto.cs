using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public interface IRepositorioProducto
    {
        IEnumerable<Producto> GetAllProducto();
        Producto GetProducto(int idProducto);                       // Buscar
        IEnumerable<Producto> GetAllProductosForName(string name);
        int AddProducto(Producto Producto);
        int UpdateProducto(Producto Producto);
        void DeleteProducto(Producto Producto);
    } 
}
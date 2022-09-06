using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public interface IRepositorioProducto
    {
        IEnumerable<Producto> GetAllProductos();
        Producto GetProducto(int idProducto);
        IEnumerable<Producto> GetAllProductosForName(string name);
        int AddProducto(Producto Producto);
        int UpdateProducto(Producto Producto);
        int DeleteProducto(Producto Producto);
    } 
}
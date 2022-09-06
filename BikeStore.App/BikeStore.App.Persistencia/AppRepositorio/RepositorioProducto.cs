using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public class RepositorioProducto : IRepositorioProducto
    {

        private readonly AppContext _appContext;

        public RepositorioProducto(AppContext context){
            _appContext = context;
        }

        // Método para buscar todos los registros
        IEnumerable<Producto> IRepositorioProducto.GetAllProductos(){
             return _appContext.Productos;
        }

        // Método para buscar por id
        Producto IRepositorioProducto.GetProducto(int id){
            return _appContext.Productos.Find(id);
        }

        // Método para buscar por nombre
        IEnumerable<Producto> IRepositorioProducto.GetAllProductosForName (string name) {
            var producto = _appContext.Productos.Where( p => p.Nombre == name );
            //var producto = _appContext.Productos.Where( p => p.Nombre.contains(name));
            return producto;
        }

        // Método para Crear un Producto
        int IRepositorioProducto.AddProducto(Producto producto){
            var productoLocal = _appContext.Productos.Add(producto);
            var result = _appContext.SaveChanges();
            return result;
        }

        // Método para Actualizar un Producto
        int IRepositorioProducto.UpdateProducto(Producto producto){
            _appContext.Productos.Update(producto);
            return _appContext.SaveChanges();
        }

        // Método para Eliminar un Producto
        int IRepositorioProducto.DeleteProducto(Producto producto){
            _appContext.Productos.Remove(producto);
            return _appContext.SaveChanges();
        }
    }
}
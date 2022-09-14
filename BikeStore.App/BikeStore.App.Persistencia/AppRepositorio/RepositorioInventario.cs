using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public class RepositorioInventario : IRepositorioInventario
    {

        private readonly AppContext _appContext;

        public RepositorioInventario(AppContext context){
            _appContext = context;
        }

        // Método para buscar todos los registros
        IEnumerable<Inventario> IRepositorioInventario.GetAllInventarios(){
             return _appContext.Inventarios;
        }

        // Método para buscar por id
        Inventario IRepositorioInventario.GetInventario(int id){
            return _appContext.Inventarios.Find(id);
        }

        // Método para Crear un Inventario
        int IRepositorioInventario.AddInventario(Inventario inventario){
            _appContext.Inventarios.Add(inventario);
            var result = _appContext.SaveChanges();
            return result;
        }

        // Método para Actualizar un Inventario
        int IRepositorioInventario.UpdateInventario(Inventario inventario){
            _appContext.Inventarios.Update(inventario);
            return _appContext.SaveChanges();
        }

        // Método para Eliminar un Inventario
        int IRepositorioInventario.DeleteInventario(Inventario inventario){
            _appContext.Inventarios.Remove(inventario);
            return _appContext.SaveChanges();
        }

        // Metodo para traer los productos que no esten en el inventario
        IEnumerable<Inventario> IRepositorioInventario.GetAllInventarioProducto () {
            var productoIds = _appContext.Productos.Select(p => p.Id).ToArray();
            var inventario = _appContext.Inventarios.Where( x => productoIds.Contains(x.ProductoId) );

            return inventario;
        }
    
    }
}
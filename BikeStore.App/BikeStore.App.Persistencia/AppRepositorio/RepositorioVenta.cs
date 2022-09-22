using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public class RepositorioVenta : IRepositorioVenta
    {

        private readonly AppContext _appContext;

        public RepositorioVenta(AppContext context){
            _appContext = context;
        }

        // Método para buscar todos los registros
        IEnumerable<Venta> IRepositorioVenta.GetAllVentas(){
             return _appContext.Venta;
        }

        // Método para buscar por id
        Venta IRepositorioVenta.GetVenta(int id){
            return _appContext.Venta.Find(id);
        }

        // Método para buscar por objeto tipo Cliente
        

        // Método para Crear un Venta
        int IRepositorioVenta.AddVenta(Venta venta){
            var ventaLocal = _appContext.Venta.Add(venta);
            var result = _appContext.SaveChanges();
            return result;
        }

        // Método para Actualizar un Venta
        int IRepositorioVenta.UpdateVenta(Venta venta){
            _appContext.Venta.Update(venta);
            return _appContext.SaveChanges();
        }

        // Método para Eliminar un Venta
        int IRepositorioVenta.DeleteVenta(Venta venta){
            _appContext.Venta.Remove(venta);
            return _appContext.SaveChanges();
        }

        long IRepositorioVenta.GetTotalGanancia(){

              var totalVentas = _appContext.Venta.Sum(x=> x.ValorVenta);
            
             return (long) totalVentas;
        }

        long IRepositorioVenta.GetTotalVendidos(){

              var totalVendidos = _appContext.Venta.Sum(x=> x.CantidadProducto);
            
             return (long) totalVendidos;
        }
    }
}
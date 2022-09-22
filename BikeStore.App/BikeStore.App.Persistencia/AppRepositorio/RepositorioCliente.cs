using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public class RepositorioCliente : IRepositorioCliente
    {

        private readonly AppContext _appContext;

        public RepositorioCliente(AppContext context){
            _appContext = context;
        }

        // Método para buscar todos los registros
        IEnumerable<Cliente> IRepositorioCliente.GetAllClientes(){
             return _appContext.Clientes;
        }

        // Método para buscar por id
        Cliente IRepositorioCliente.GetCliente(int id){
            return _appContext.Clientes.Find(id);
        }

        // Método para buscar por nombre
        IEnumerable<Cliente> IRepositorioCliente.GetAllClientesForName (string name) {
            var cliente = _appContext.Clientes.Where( p => p.Nombre == name );
            //var cliente = _appContext.Clientes.Where( p => p.Nombre.contains(name));
            return cliente;
        }

        // Método para Crear un Cliente
        int IRepositorioCliente.AddCliente(Cliente cliente){
            _appContext.Clientes.Add(cliente);
            var result = _appContext.SaveChanges();
            return result;
        }

        // Método para Actualizar un Cliente
        int IRepositorioCliente.UpdateCliente(Cliente cliente){
            _appContext.Clientes.Update(cliente);
            return _appContext.SaveChanges();
        }

        // Método para Eliminar un Cliente
        int IRepositorioCliente.DeleteCliente(Cliente cliente){
            _appContext.Clientes.Remove(cliente);
            return _appContext.SaveChanges();
        }

        long IRepositorioCliente.GetTotalClientes(){

              var totalVendidos = _appContext.Clientes.Count();
            
             return (long) totalVendidos;
        }
    }
}
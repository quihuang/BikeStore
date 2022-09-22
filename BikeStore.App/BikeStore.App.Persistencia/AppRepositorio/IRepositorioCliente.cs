using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public interface IRepositorioCliente
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetCliente(int idCliente);
        IEnumerable<Cliente> GetAllClientesForName(string name);
        int AddCliente(Cliente Cliente);
        int UpdateCliente(Cliente Cliente);
        int DeleteCliente(Cliente Cliente);
        long GetTotalClientes();
    } 
}
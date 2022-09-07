using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public interface IRepositorioConstanciaRecibido
    {
        IEnumerable<ConstanciaRecibido> GetAllConstanciaRecibidos();
        ConstanciaRecibido GetConstanciaRecibido(int idConstanciaRecibido);
        IEnumerable<ConstanciaRecibido> GetAllConstanciaRecibidosForName(string name);
        int AddConstanciaRecibido(ConstanciaRecibido ConstanciaRecibido);
        int UpdateConstanciaRecibido(ConstanciaRecibido ConstanciaRecibido);
        int DeleteConstanciaRecibido(ConstanciaRecibido ConstanciaRecibido);
    } 
}
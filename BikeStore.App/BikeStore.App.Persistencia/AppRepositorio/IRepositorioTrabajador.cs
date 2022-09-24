using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public interface IRepositorioTrabajador
    {
        IEnumerable<Trabajador> GetAllTrabajadores();
        Trabajador GetTrabajador(int idTrabajador);
        IEnumerable<Trabajador> GetAllTrabajadoresForName(string name);
        Trabajador GetTrabajadoresForUser(string user);
        int AddTrabajador(Trabajador Trabajador);
        int UpdateTrabajador(Trabajador Trabajador);
        int DeleteTrabajador(Trabajador Trabajador);
    } 
}
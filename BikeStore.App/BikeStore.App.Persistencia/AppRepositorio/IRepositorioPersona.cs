using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public interface IRepositorioPersona
    {
        IEnumerable<Persona> GetAllPersonas();
        int AddPersona(Persona Persona);
        int UpdatePersona(Persona Persona);
        void DeletePersona(int idPersona);
        Persona GetPersona(int idPersona);
        IEnumerable<Persona> GetAllPersonasForName(string name);
        int AddTrabajador(Trabajador Trabajador);
        int ActualizarTrabajador(Trabajador Trabajador);
        Trabajador Buscar(int id);
        int EliminarTrabajador(Trabajador Trabajador);

    } 
}
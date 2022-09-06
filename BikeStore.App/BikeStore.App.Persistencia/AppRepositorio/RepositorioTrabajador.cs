using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public class RepositorioTrabajador : IRepositorioTrabajador
    {

        private readonly AppContext _appContext;

        public RepositorioTrabajador(AppContext context){
            _appContext = context;
        }

        // Método para buscar todos los registros
        IEnumerable<Trabajador> IRepositorioTrabajador.GetAllTrabajadores(){
             return _appContext.Trabajadores;
        }

        // Método para buscar por id
        Trabajador IRepositorioTrabajador.GetTrabajador(int id){
            return _appContext.Trabajadores.Find(id);
        }

        // Método para buscar por nombre
        IEnumerable<Trabajador> IRepositorioTrabajador.GetAllTrabajadoresForName (string name) {
            var trabajador = _appContext.Trabajadores.Where( p => p.Nombre == name );
            //var trabajador = _appContext.Trabajadores.Where( p => p.Nombre.contains(name));
            return trabajador;
        }

        // Método para Crear un Trabajador
        int IRepositorioTrabajador.AddTrabajador(Trabajador trabajador){
            _appContext.Trabajadores.Add(trabajador);
            var result = _appContext.SaveChanges();
            return result;
        }

        // Método para Actualizar un Trabajador
        int IRepositorioTrabajador.UpdateTrabajador(Trabajador trabajador){
            _appContext.Trabajadores.Update(trabajador);
            return _appContext.SaveChanges();
        }

        // Método para Eliminar un Trabajador
        int IRepositorioTrabajador.DeleteTrabajador(Trabajador trabajador){
            _appContext.Trabajadores.Remove(trabajador);
            return _appContext.SaveChanges();
        }
    }
}
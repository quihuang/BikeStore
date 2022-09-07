using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public class RepositorioPersona : IRepositorioPersona
    {

        private readonly AppContext _appContext;

        public RepositorioPersona(AppContext context){
            _appContext = context;
        }

        // Método para buscar Trabajador por id
        Trabajador IRepositorioPersona.Buscar(int id){
            return _appContext.Trabajadores.Find(id);
        }

        // Método para buscar todos los registros de Personas
        IEnumerable<Persona> IRepositorioPersona.GetAllPersonas(){
             return _appContext.Personas;
        }

        // Método para Crear una Persona
        int IRepositorioPersona.AddPersona(Persona persona){
            var personaLocal = _appContext.Personas.Add(persona);
            var result = _appContext.SaveChanges();
            
            return result;
        }

        // Método para Crear un Trabajador
        int IRepositorioPersona.AddTrabajador(Trabajador Trabajador){
            
            var TrabajadorLocal = _appContext.Trabajadores.Add(Trabajador); // // Pregunta: porque es necesario guardar el resultado del método en la variable "TrabajadorLocal", ya que no se hace nada con esa variable
            var result = _appContext.SaveChanges();
            
            return result;
        }

        // Método para buscar Persona por nombre
        IEnumerable<Persona> IRepositorioPersona.GetAllPersonasForName (string name) {
            var persona = _appContext.Personas.Where( p => p.Nombre == name ); // // Pregunta: porque es necesario guardar el resultado del método en la variable "persona", ya que no se hace nada con esa variable
            //var persona = _appContext.Personas.Where( p => p.Nombre.contains(name));
            return persona;
        }

        // Método para Actualizar una Persona
        int IRepositorioPersona.UpdatePersona(Persona persona){
            return 0;
        }
        
        // Método para Eliminar una Persona
        void IRepositorioPersona.DeletePersona(int idPersona){

        }
        
        // Método para buscar una Persona por id
        Persona IRepositorioPersona.GetPersona(int idPersona){ 
            return null;
        }

        // Método para Actualizar un Trabajador
        int IRepositorioPersona.ActualizarTrabajador(Trabajador trabajador){
            _appContext.Trabajadores.Update(trabajador);
            return _appContext.SaveChanges();
        }

        // Método para Eliminar un Trabajador
        int IRepositorioPersona.EliminarTrabajador(Trabajador trabajador){
            _appContext.Trabajadores.Remove(trabajador);
            return _appContext.SaveChanges();
        }
    } 
}
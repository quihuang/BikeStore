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

        IEnumerable<Persona> IRepositorioPersona.GetAllPersonas(){
            return null;
        }
        int IRepositorioPersona.AddPersona(Persona persona){
            var personaLocal = _appContext.Personas.Add(persona);
            var result = _appContext.SaveChanges();
            
            return result;
        }
        int IRepositorioPersona.UpdatePersona(Persona persona){
            return 0;
        }
        void IRepositorioPersona.DeletePersona(int idPersona){

        }
        Persona IRepositorioPersona.GetPersona(int idPersona){ 
            return null;
        }
    } 
}
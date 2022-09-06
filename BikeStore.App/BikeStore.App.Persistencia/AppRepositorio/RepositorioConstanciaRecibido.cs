using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public class RepositorioConstanciaRecibido : IRepositorioConstanciaRecibido
    {

        private readonly AppContext _appContext;

        public RepositorioConstanciaRecibido(AppContext context){
            _appContext = context;
        }

        // Método para buscar todos los registros
        IEnumerable<ConstanciaRecibido> IRepositorioConstanciaRecibido.GetAllConstanciaRecibidos(){
             return _appContext.ConstanciaRecibidos;
        }

        // Método para buscar por id
        ConstanciaRecibido IRepositorioConstanciaRecibido.GetConstanciaRecibido(int id){
            return _appContext.ConstanciaRecibidos.Find(id);
        }

        // Método para buscar por nombre
        IEnumerable<ConstanciaRecibido> IRepositorioConstanciaRecibido.GetAllConstanciaRecibidosForName (string name) {
            var constanciaRecibido = _appContext.ConstanciaRecibidos.Where( p => p.Nombre == name );
            //var constanciaRecibido = _appContext.ConstanciaRecibidos.Where( p => p.Nombre.contains(name));
            return constanciaRecibido;
        }

        // Método para Crear un ConstanciaRecibido
        int IRepositorioConstanciaRecibido.AddConstanciaRecibido(ConstanciaRecibido constanciaRecibido){
            _appContext.ConstanciaRecibidos.Add(constanciaRecibido);
            var result = _appContext.SaveChanges();
            return result;
        }

        // Método para Actualizar un ConstanciaRecibido
        int IRepositorioConstanciaRecibido.UpdateConstanciaRecibido(ConstanciaRecibido constanciaRecibido){
            _appContext.ConstanciaRecibidos.Update(constanciaRecibido);
            return _appContext.SaveChanges();
        }

        // Método para Eliminar un ConstanciaRecibido
        int IRepositorioConstanciaRecibido.DeleteConstanciaRecibido(ConstanciaRecibido constanciaRecibido){
            _appContext.ConstanciaRecibidos.Remove(constanciaRecibido);
            return _appContext.SaveChanges();
        }
    }
}
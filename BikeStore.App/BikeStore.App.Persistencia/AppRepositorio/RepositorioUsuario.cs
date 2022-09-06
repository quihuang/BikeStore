using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        private readonly AppContext _appContext;

        public RepositorioUsuario(AppContext context){
            _appContext = context;
        }

        // Método para buscar todos los registros
        IEnumerable<Usuario> IRepositorioUsuario.GetAllUsuarios(){
             return _appContext.Usuarios;
        }

        // Método para buscar por id
        Usuario IRepositorioUsuario.GetUsuario(int id){
            return _appContext.Usuarios.Find(id);
        }

        // Método para buscar por nombre
        IEnumerable<Usuario> IRepositorioUsuario.GetAllUsuariosForName (string name) {
            var usuario = _appContext.Usuarios.Where( p => p.Nombre == name );
            //var usuario = _appContext.Usuarios.Where( p => p.Nombre.contains(name));
            return usuario;
        }

        // Método para Crear un Usuario
        int IRepositorioUsuario.AddUsuario(Usuario usuario){
            _appContext.Usuarios.Add(usuario);
            var result = _appContext.SaveChanges();
            return result;
        }

        // Método para Actualizar un Usuario
        int IRepositorioUsuario.UpdateUsuario(Usuario usuario){
            _appContext.Usuarios.Update(usuario);
            return _appContext.SaveChanges();
        }

        // Método para Eliminar un Usuario
        int IRepositorioUsuario.DeleteUsuario(Usuario usuario){
            _appContext.Usuarios.Remove(usuario);
            return _appContext.SaveChanges();
        }
    }
}
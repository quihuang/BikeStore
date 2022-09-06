using System;
using System.Collections.Generic;
using System.Linq;
using BikeStore.App.Dominio;

namespace BikeStore.App.Persistencia
{
    public interface IRepositorioUsuario
    {
        IEnumerable<Usuario> GetAllUsuarios();
        Usuario GetUsuario(int idUsuario);
        IEnumerable<Usuario> GetAllUsuariosForName(string name);
        int AddUsuario(Usuario Usuario);
        int UpdateUsuario(Usuario Usuario);
        int DeleteUsuario(Usuario Usuario);
    } 
}
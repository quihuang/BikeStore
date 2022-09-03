using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;

namespace BikeStore.App.Web
{
    public class UsuariosModel : PageModel
    {
        private static IRepositorioPersona _repositorioPersona = new RepositorioPersona( new Persistencia.AppContext() );
        
        public void OnGet()
        {
        }

        public void OnPost(){

            var cedula = Request.Form["cedula"];
            var nombre = Request.Form["nombre"];
            var apellido = Request.Form["apellido"];
            var telefono = Request.Form["telefono"];
            var nombreUsuario = Request.Form["nombreUsuario"];
        }
    }
}

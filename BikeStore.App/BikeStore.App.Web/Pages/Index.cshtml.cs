using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;
using System.Collections;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace BikeStore.App.Web.Pages
{
    public class IndexModel : PageModel
    {
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new BikeStore.App.Persistencia.AppContext() );
        //private readonly ILogger<IndexModel> _logger;
        public string mensaje;
        public List<Trabajador> consultaTrabajadores { get; set; }
        public string _sessionIdUser = "_IdUser";
        public string _sessionIdRol = "_idRol";
        public IHttpContextAccessor _httpContextAccessor;

        public IndexModel(IHttpContextAccessor httpContextAccessor){
            _httpContextAccessor = httpContextAccessor;
        }

        // public IndexModel(ILogger<IndexModel> logger)
        // {
        //     _logger = logger;
        // }

        public void OnGet(string cerrar)
        {
            if(cerrar == "1"){

                _httpContextAccessor.HttpContext.Session.Remove(_sessionIdUser);
                _httpContextAccessor.HttpContext.Session.Remove(_sessionIdRol);
                _httpContextAccessor.HttpContext.Session.Clear();
                Console.WriteLine("sesion terminada");
            }  
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./Bienvenida/Inicio");
        }

        public IActionResult OnPostValidateLogin([FromBody]Trabajador trabajador)
        {

            var rolValidate = "0";

            if(trabajador.NombreUsuario != null || trabajador.NombreUsuario != "" && trabajador.Contraseña != null || trabajador.Contraseña != ""){

                var consultaTrabajador = _repositorioTrabajador.GetTrabajadoresForUser(trabajador.NombreUsuario);

                string validateExist = consultaTrabajador.NombreUsuario;
                string validatePassword = consultaTrabajador.Contraseña;

                if(Equals(validateExist,"null")){
                   mensaje = rolValidate;
                }else{

                    if(Equals(validateExist,trabajador.NombreUsuario) && Equals(validatePassword,trabajador.Contraseña)){

                        var userId = validateExist;
                        var rolId = consultaTrabajador.Rol;

                        _httpContextAccessor.HttpContext.Session.SetString(_sessionIdUser, userId);
                        _httpContextAccessor.HttpContext.Session.SetString(_sessionIdRol, rolId.ToString());

                        Console.WriteLine(_httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser));
                        Console.WriteLine(_httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol));

                        mensaje = rolId.ToString();

                    }else{
                        mensaje = rolValidate;
                    }
                    
                }
                
            }else{
                mensaje = "El usuario y la contraseña son requeridos para poder iniciar sesion";
            }

            Console.WriteLine(mensaje);

            return Content(mensaje);
            
        }
    }
}

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

namespace BikeStore.App.Web.Pages
{
    public class IndexModel : PageModel
    {
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new BikeStore.App.Persistencia.AppContext() );
        private readonly ILogger<IndexModel> _logger;
        public string mensaje;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./Bienvenida/Inicio");
        }

        public IActionResult OnPostValidateLogin([FromBody]Trabajador trabajador)
        {
            if(trabajador.NombreUsuario != null || trabajador.NombreUsuario != "" && trabajador.Contraseña != null || trabajador.Contraseña != ""){
                mensaje = "Correcto";
                RedirectToPage("./Bienvenida/Inicio");
            }else{
                mensaje = "Usuario y/o contraseña incorrectos";
            }

            return Content(mensaje);
            
        }
    }
}

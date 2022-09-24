using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace BikeStore.App.Web.Pages
{
    public class InicioModel : PageModel
    {
        private readonly ILogger<InicioModel> _logger;
        public string _sessionIdUser = "_IdUser";
        public string _sessionIdRol = "_idRol";
        public IHttpContextAccessor _httpContextAccessor;

        public InicioModel(ILogger<InicioModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            Console.WriteLine("Constructor Inicio");    
            Console.WriteLine(_httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser));
            Console.WriteLine(_httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol));
        }
        
        public IActionResult OnGet()
        {
            if( string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser)) ||
                string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol)))
            {
                Console.WriteLine("Acceso Ilegal");
                return RedirectToPage("/Index");
            }else{
                Console.WriteLine("Tiene permiso");
                return Page();
            }
        }
    }
}

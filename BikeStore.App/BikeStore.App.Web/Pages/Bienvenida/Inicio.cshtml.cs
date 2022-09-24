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
        public string rolValidateSession;

        public InicioModel(ILogger<InicioModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public IActionResult OnGet()
        {
            var userValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser);
            rolValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol);

            if( string.IsNullOrEmpty(userValidateSession) || string.IsNullOrEmpty(rolValidateSession))
            {
                
                return RedirectToPage("/Index");
                    
            }else if(rolValidateSession == "1" || rolValidateSession == "2" || rolValidateSession ==  "3"){

                return Page();

            }else{

                return RedirectToPage("/Index");

            }
        }
    }
}

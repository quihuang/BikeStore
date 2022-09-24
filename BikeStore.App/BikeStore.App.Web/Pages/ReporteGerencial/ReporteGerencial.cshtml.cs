using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace BikeStore.App.Web.Pages
{
    public class ReporteGerencialModel : PageModel
    {
                // private readonly ILogger<UsuariosModel> _logger;
        public string _sessionIdUser = "_IdUser";
        public string _sessionIdRol = "_idRol";
        public IHttpContextAccessor _httpContextAccessor;
        public string rolValidateSession;

        public ReporteGerencialModel(ILogger<ReporteGerencialModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        private IRepositorioVenta _repositorioVenta = new RepositorioVenta( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioCliente _repositorioCliente = new RepositorioCliente( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioInventario _repositorioInventario = new RepositorioInventario( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioProducto _repositorioProducto = new RepositorioProducto( new BikeStore.App.Persistencia.AppContext() );

        public long totalInversion;
        public long totalVentas;
        public long totalProductosVendidos;
        public long totalClientes;


        public IActionResult OnGet()
        {
            var userValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser);
            rolValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol);

            if( string.IsNullOrEmpty(userValidateSession) || string.IsNullOrEmpty(rolValidateSession))
            {
            return RedirectToPage("/Error");

            }else if(rolValidateSession == "2"){
                totalInversion = _repositorioInventario.GetTotalInversion();
                totalVentas = _repositorioVenta.GetTotalGanancia();
                totalProductosVendidos = _repositorioVenta.GetTotalVendidos();
                totalClientes = _repositorioCliente.GetTotalClientes();
                return Page();
            }else{
                return RedirectToPage("/Error");
            }
        }
    }
}

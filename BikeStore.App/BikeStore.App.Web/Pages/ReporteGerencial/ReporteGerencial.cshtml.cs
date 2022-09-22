using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;

namespace BikeStore.App.Web.Pages
{
    public class ReporteGerencialModel : PageModel
    {

        private IRepositorioVenta _repositorioVenta = new RepositorioVenta( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioCliente _repositorioCliente = new RepositorioCliente( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioInventario _repositorioInventario = new RepositorioInventario( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioProducto _repositorioProducto = new RepositorioProducto( new BikeStore.App.Persistencia.AppContext() );

        public long totalInversion;
        public long totalVentas;
        public long totalProductosVendidos;
        public long totalClientes;


        public void OnGet()
        {
            totalInversion = _repositorioInventario.GetTotalInversion();
            totalVentas = _repositorioVenta.GetTotalGanancia();
            totalProductosVendidos = _repositorioVenta.GetTotalVendidos();
            totalClientes = _repositorioCliente.GetTotalClientes();
        }
    }
}

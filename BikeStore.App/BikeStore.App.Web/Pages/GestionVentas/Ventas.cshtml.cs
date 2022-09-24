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
    public class VentasModel : PageModel
    {

        //private readonly ILogger<VentasModel> _logger;
        public string _sessionIdUser = "_IdUser";
        public string _sessionIdRol = "_idRol";
        public IHttpContextAccessor _httpContextAccessor;
        public string rolValidateSession;

         public VentasModel(ILogger<VentasModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            //var login = 
            _httpContextAccessor = httpContextAccessor;
        }

        // video 02/09 min 2:30:20 y en el minuto 2:41:27
        // Instanciar el repositorio, igual como se hizo en la capa Consola
        private IRepositorioVenta _repositorioVenta = new RepositorioVenta( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioTrabajador _repositorioTrabajador = new RepositorioTrabajador( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioCliente _repositorioCliente = new RepositorioCliente( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioInventario _repositorioInventario = new RepositorioInventario( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioProducto _repositorioProducto = new RepositorioProducto( new BikeStore.App.Persistencia.AppContext() );

        // video 02/09 min 2:49:30
        // crear una variable tipo List que reciba la totalidad de los registros consultados de la DB, debe ser público para que la interface gráfica pueda acceder a él
        public List<Venta> listadoVenta { get; set; }
        public List<Trabajador> listadoTrabajador { get; set; }
        public List<Cliente> listadoCliente { get; set; }
        public List<Inventario> listadoInventario { get; set; }
        public Producto producto { get; set; }
        public List<Producto> listadoProductos { get; set; }
        DateTime fechaActual = DateTime.Now;

        public string mensaje;


        public IActionResult OnGet()
        {

            var userValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser);
            rolValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol);

            if( string.IsNullOrEmpty(userValidateSession) || string.IsNullOrEmpty(rolValidateSession))
            {
                
                return RedirectToPage("/Error");
            
            }else if(rolValidateSession == "1" || rolValidateSession == "2"){

                // Método para listar todas las Ventas y mostrarlas en la tabla
                listadoVenta = new List<Venta>(); // se instancia vacío
                listadoVenta = _repositorioVenta.GetAllVentas().ToList();

                // Método para listar los trabajadores y mostrarlos en una lista desplegable en la ventana Modal de Crear Venta
                listadoTrabajador = new List<Trabajador>(); // se instancia vacío
                listadoTrabajador = _repositorioTrabajador.GetAllTrabajadores().ToList();

                // Método para listar los trabajadores y mostrarlos en una lista desplegable en la ventana Modal de Crear Venta
                listadoCliente = new List<Cliente>();
                listadoCliente = _repositorioCliente.GetAllClientes().ToList();

                listadoInventario = new List<Inventario>();
                listadoInventario = _repositorioInventario.GetAllInventarios().ToList();

                listadoProductos = new List<Producto>();
                listadoProductos = _repositorioProducto.GetAllProductos().ToList();

                // PARA MOSTRAR UN MENSAJE - PENDIENTE POR PROBAR
                if(ViewData["mensaje"] != null){
                    mensaje = ViewData["mensaje"].ToString();
                } else {
                    mensaje = "";
                }
                return Page();
            }else{
                return RedirectToPage("/Error");
            }
            
        }


        // video 02/09 min 2:09:20
        // // METODO PARA POST DE CREAR
        public IActionResult OnPost()
        {
            var inventario = Request.Form["inventario"];
            var cantidadProducto = Request.Form["cantidadProducto"];
            var inventarioUpdate = _repositorioInventario.GetInventario(int.Parse(inventario));
            Double restaInventario = inventarioUpdate.Existencias - Double.Parse(cantidadProducto);

            if(restaInventario > 0){
                // aquí se debe poner entre [] el nombre de cada campo del formulario
                var fecha = fechaActual;
                var trabajador = Request.Form["trabajador"];
                var cliente = Request.Form["cliente"];        

                Double valorVentaCal = inventarioUpdate.PrecioUniVenta * Double.Parse(cantidadProducto);

                inventarioUpdate.Existencias = (int) restaInventario;
    
                var resultInventario = _repositorioInventario.UpdateInventario(inventarioUpdate);

                // Creamos el objeto Venta y le pasamos los datos del formulario
                var venta = new Venta{
                    Fecha = fecha,
                    CantidadProducto = int.Parse(cantidadProducto),
                    ValorVenta = (int) valorVentaCal,
                    TrabajadorId = int.Parse(trabajador),
                    ClienteId = int.Parse(cliente),
                    InventarioId = int.Parse(inventario)
                };

                // video 02/09 min 2:23:15
                // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            
                var result = _repositorioVenta.AddVenta(venta);

                // video del 09/09 min 2:53:00
                if( result > 0){
                    mensaje = "Creación realizada con éxito";
                    return RedirectToPage();
                }else{
                    mensaje = "Falla en el método de creación";
                    return RedirectToPage("Error");
                }

            }else{
                mensaje = "No hay inventario disponible";
                return RedirectToPage("Error");
            }

        }

         public IActionResult OnPostCreateJson([FromBody]Venta venta)
        {
            var inventario = venta.InventarioId;
            var cantidadProducto = venta.CantidadProducto;
            var fecha = fechaActual;
            var trabajador = venta.TrabajadorId;
            var cliente = venta.ClienteId; 
            var inventarioUpdate = _repositorioInventario.GetInventario(inventario);
            Double restaInventario = inventarioUpdate.Existencias - cantidadProducto;

            if(restaInventario >= 0){
                // aquí se debe poner entre [] el nombre de cada campo del formulario       

                Double valorVentaCal = inventarioUpdate.PrecioUniVenta * cantidadProducto;

                inventarioUpdate.Existencias = (int) restaInventario;
    
                var resultInventario = _repositorioInventario.UpdateInventario(inventarioUpdate);

                // Creamos el objeto Venta y le pasamos los datos del formulario
                var NewVenta = new Venta{
                    Fecha = fecha,
                    CantidadProducto = cantidadProducto,
                    ValorVenta = (int) valorVentaCal,
                    TrabajadorId = trabajador,
                    ClienteId = cliente,
                    InventarioId = inventario
                };

                // video 02/09 min 2:23:15
                // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            
                var result = _repositorioVenta.AddVenta(NewVenta);

                // video del 09/09 min 2:53:00
                if( result > 0){
                    mensaje = "Creación realizada con éxito";
                }else{
                    mensaje = "Falla en el método de creación";
                }

            }else{
                mensaje = "No hay inventario disponible";
            }

            return Content(mensaje);

        }


        // // METODO PARA POST DE ACTUALIZAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostUpdateJson([FromBody]Venta venta)
        {
            var ventaResult = _repositorioVenta.GetVenta( venta.Id );
            var inventario = venta.InventarioId;
            var cantidadProducto = venta.CantidadProducto;

            var mensaje = "";

            if( ventaResult != null)
            {
                
                var inventarioUpdate = _repositorioInventario.GetInventario(inventario);
                
                inventarioUpdate.Existencias = inventarioUpdate.Existencias + ventaResult.CantidadProducto;

                _repositorioInventario.UpdateInventario(inventarioUpdate);

                //Nuevo inventario Actualizado

                var inventarioUpdatetwo = _repositorioInventario.GetInventario(inventario);

                Double valorVentaCal = inventarioUpdatetwo.PrecioUniVenta * cantidadProducto;

                Double restaInventario = inventarioUpdatetwo.Existencias - cantidadProducto;

                if(restaInventario >= 0){

                    inventarioUpdatetwo.Existencias = (int) restaInventario;

                    _repositorioInventario.UpdateInventario(inventarioUpdatetwo);

                    ventaResult.CantidadProducto = venta.CantidadProducto;
                    ventaResult.ValorVenta = (int) valorVentaCal;
                    ventaResult.TrabajadorId = venta.TrabajadorId;
                    ventaResult.ClienteId = venta.ClienteId;
                    ventaResult.InventarioId = venta.InventarioId;

                    var result = _repositorioVenta.UpdateVenta(ventaResult);

                    if( result > 0){
                        mensaje = "Se actualizó correctamente";
                    }else{
                        mensaje = "No se pudo actualizar";
                    }
                    
                }else{
                    mensaje = "No hay inventario disponible";
                }

            }else{
                mensaje = "La consulta no encontró ningún registro";
            }

            return Content(mensaje);
        } 


        // // METODO PARA POST DE ELIMINAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostDeleteJson([FromBody]Venta venta)
        {
            var ventaResult = _repositorioVenta.GetVenta( venta.Id );
            var inventario = venta.InventarioId;

            var mensaje = "";

            if( ventaResult != null)
            {
                var inventarioUpdate = _repositorioInventario.GetInventario(inventario);
                inventarioUpdate.Existencias = inventarioUpdate.Existencias + ventaResult.CantidadProducto;
                _repositorioInventario.UpdateInventario(inventarioUpdate);

                var result = _repositorioVenta.DeleteVenta(ventaResult);

                if( result > 0){
                    mensaje = "Se realizo la devolución correctamente";
                }else{
                    mensaje = "No se pudo realizar la devolución";
                }

            }else{
                mensaje = "La consulta no encontró ningún registro";
            }

            return Content(mensaje);
        }
    }
}

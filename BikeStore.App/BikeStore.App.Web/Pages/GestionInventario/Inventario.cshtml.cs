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
    public class InventarioModel : PageModel
    { 
        public string _sessionIdUser = "_IdUser";
        public string _sessionIdRol = "_idRol";
        public IHttpContextAccessor _httpContextAccessor;
        public string rolValidateSession;

        public InventarioModel(ILogger<InventarioModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
  
        }

        private IRepositorioProducto _repositorioProducto = new RepositorioProducto( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioInventario _repositorioInventario = new RepositorioInventario( new BikeStore.App.Persistencia.AppContext() );

        public List<Inventario> listadoInventario { get; set; }
        public List<Producto> listadoProducto { get; set; }

        public List<Producto> listadoInvPro {get; set; }

        public string mensaje;

        public IActionResult OnGet()
        {
            var userValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdUser);
            rolValidateSession = _httpContextAccessor.HttpContext.Session.GetString(_sessionIdRol);

            if( string.IsNullOrEmpty(userValidateSession) || string.IsNullOrEmpty(rolValidateSession))
            {
                return RedirectToPage("/Error");

            }else if(rolValidateSession == "2" || rolValidateSession == "3"){
                // video 02/09 min 2:50:22
                // debo inicializar el objeto listado____ dentro de OnGet para que lo pueda interpretar
                listadoInventario = new List<Inventario>(); // se instancia vacío

                // llenamos la variable listado____ a traves del método GetAll____()
                // al final se usa el método ToList para convertir a Lista el IEnumerable que genera el método GetAll____.
                listadoInventario = _repositorioInventario.GetAllInventarios().ToList();
                
                // Método para listar los Productos y mostrarlos en una lista desplegable en la ventana Modal
                listadoProducto = new List<Producto>(); // se instancia vacío
                listadoProducto = _repositorioProducto.GetAllProductos().ToList();

                listadoInvPro = new List<Producto>();
                listadoInvPro = _repositorioInventario.GetAllInventarioProducto().ToList();            
                
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


        // // METODO PARA POST DE CREAR
        public IActionResult OnPost()
        {
            // aquí se debe poner entre [] el nombre de cada campo del formulario
            var producto = Request.Form["producto"];
            var existencias = Request.Form["existencias"];
            var numeroRefCompra = Request.Form["numerorefcompra"];
            var precioUniVenta = Request.Form["preciouniventa"];
            var precioUniCompra = Request.Form["preciounicompra"];

            // Creamos el objeto y le pasamos los datos del formulario
            var inventario = new Inventario{
                ProductoId = int.Parse(producto),
                Existencias = int.Parse(existencias),
                NumeroRefCompra = int.Parse(numeroRefCompra),
                PrecioUniVenta = double.Parse(precioUniVenta),
                PrecioUniCompra = double.Parse(precioUniCompra)
            };

            // video 02/09 min 2:23:15
            // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            var result = _repositorioInventario.AddInventario(inventario);

            // video del 09/09 min 2:53:00
            if( result > 0){
                mensaje = "Creación realizada con éxito";
                return RedirectToPage();
            }else{
                mensaje = "Falla en el método de creación";
                return RedirectToPage("Error");
            }
        }


        // // METODO PARA POST DE ACTUALIZAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostUpdateJson([FromBody]Inventario inventario)
        {
            var inventarioResult = _repositorioInventario.GetInventario( inventario.Id );

            var mensaje = "";

            if( inventarioResult != null){

                inventarioResult.ProductoId = inventario.ProductoId;
                inventarioResult.Existencias = inventario.Existencias;
                inventarioResult.NumeroRefCompra = inventario.NumeroRefCompra;
                inventarioResult.PrecioUniVenta = inventario.PrecioUniVenta;
                inventarioResult.PrecioUniCompra = inventario.PrecioUniCompra;

                var result = _repositorioInventario.UpdateInventario(inventarioResult);

                if( result > 0){
                    mensaje = "Se actualizó correctamente";
                }else{
                    mensaje = "No se pudo actualizar";
                }

            }else{
                mensaje = "La consulta no encontró ningún registro";
            }

            return Content(mensaje);
        }


        // // METODO PARA POST DE ELIMINAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostDeleteJson([FromBody]Inventario inventario)
        {
            var inventarioResult = _repositorioInventario.GetInventario( inventario.Id );

            var mensaje = "";

            if( inventarioResult != null){

                var result = _repositorioInventario.DeleteInventario(inventarioResult);

                if( result > 0){
                    mensaje = "Se eliminó correctamente";
                }else{
                    mensaje = "No se pudo eliminar";
                }

            }else{
                mensaje = "La consulta no encontró ningún registro";
            }

            return Content(mensaje);
        }
    }
}

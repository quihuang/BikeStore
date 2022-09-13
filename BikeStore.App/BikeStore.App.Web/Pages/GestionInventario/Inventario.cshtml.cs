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
    public class InventarioModel : PageModel
    {
        private IRepositorioProducto _repositorioProducto = new RepositorioProducto( new BikeStore.App.Persistencia.AppContext() );
        private IRepositorioInventario _repositorioInventario = new RepositorioInventario( new BikeStore.App.Persistencia.AppContext() );

        public List<Inventario> listadoInventario { get; set; }
        public List<Producto> listadoProducto { get; set; }

        public string mensaje;

        public void OnGet()
        {
            // Método para listar todo el Inventario y mostrarlo en la tabla
            listadoInventario = new List<Inventario>(); // se instancia vacío
            listadoInventario = _repositorioInventario.GetAllInventarios().ToList();
            
            // Método para listar los Productos y mostrarlos en una lista desplegable en la ventana Modal
            listadoProducto = new List<Producto>(); // se instancia vacío
            listadoProducto = _repositorioProducto.GetAllProductos().ToList();
        }

        // // Método para capturar el Post del formulario CREAR
        public IActionResult OnPost()
        {
            // aquí se debe poner entre [] el nombre de cada campo del formulario
            var producto = Request.Form["producto"];
            var existencias = Request.Form["existencias"];
            var numeroRefCompra = Request.Form["numerorefcompra"];
            var precioUniVenta = Request.Form["preciouniventa"];
            var precioUniCompra = Request.Form["preciounicompra"];

            // Creamos el objeto Inventario y le pasamos los datos del formulario
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
            if( result > 0){
                //TODO Mostrar este mensaje por alert en el Front
                // Console.WriteLine("Se creó con éxito el registro en el Inventario");
                mensaje = "Se creó con éxito el registro en el Inventario";
                
                Page(); // retorna la misma página donde está

            }else{
                //TODO Mostrar este mensaje por alert en el Front
                // Console.WriteLine("Falló el método para crear el registro en el Inventario");
                mensaje = "Falló el método para crear el registro en el Inventario";

                RedirectToPage("./Inventario");
            }
            return Content(mensaje);
        }

        // // Método para capturar el Post del formulario ACTUALIZAR
        public IActionResult OnPostUpdateJson([FromBody]Inventario inventario)
        {
            // @item.Id','@item.Producto','@item.Existencias','@item.NumeroRefCompra','@item.PrecioUniVenta','@item.PrecioUniCompra'
            Console.WriteLine("INVENTARIO.cs: Para ver su contenido se imprime el objeto inventario: " + "inventario Id: " + inventario.Id + ", inventario Producto: " + inventario.ProductoId + ", inventario Existencias: " + inventario.Existencias + ", inventario NumeroRefCompra: " + inventario.NumeroRefCompra + ", inventario PrecioUniVenta: " + inventario.PrecioUniVenta + ", inventario PrecioUniCompra: " + inventario.PrecioUniCompra);
            Console.WriteLine("INVENTARIO.cs: Para ver su contenido se imprime el objeto inventario :" + inventario + " ;");

            var inventarioResult = _repositorioInventario.GetInventario( inventario.Id );

            var mensaje = "";

            if( inventarioResult != null){

                inventarioResult.ProductoId = inventario.ProductoId;
                inventarioResult.Existencias = inventario.Existencias;

                var result = _repositorioInventario.UpdateInventario(inventarioResult);

                if( result > 0){
                    mensaje = "Se actualizó correctamente";
                }else{
                    mensaje = "No se pudo actualizar";
                }

            }else{
                mensaje = "El inventario a actualizar no existe";
            }

            //return new JsonResult(persona);

            return Content(mensaje);

        }
    }
}

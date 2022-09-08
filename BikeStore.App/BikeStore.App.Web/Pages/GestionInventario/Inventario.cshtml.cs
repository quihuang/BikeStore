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

        public void OnGet()
        {
            // Método para listar todo el Inventario y mostrarlo en la tabla
            listadoInventario = new List<Inventario>(); // se instancia vacío
            listadoInventario = _repositorioInventario.GetAllInventarios().ToList();
            
            // Método para listar los Productos y mostrarlos en una lista desplegable en la ventana Modal
            listadoProducto = new List<Producto>(); // se instancia vacío
            listadoProducto = _repositorioProducto.GetAllProductos().ToList();
        }

        // // Método para capturar el Post del formulario
        public void OnPost()
        {
            // aquí se debe poner entre [] el nombre de cada campo del formulario
            var producto = Request.Form["producto"];
            var existencias = Request.Form["existencias"];
            var numeroRefCompra = Request.Form["numerorefcompra"];
            var precioUniVenta = Request.Form["preciouniventa"];
            var precioUniCompra = Request.Form["preciounicompra"];

            // // Creamos el objeto Inventario y le pasamos los datos del formulario
            var inventario = new Inventario{
                // Producto = producto,
                // Producto = int.Parse(producto),
                // Producto = int.Parse(producto),
                // Existencias = existencias,
                Existencias = int.Parse(existencias),
                NumeroRefCompra = int.Parse(numeroRefCompra),
                PrecioUniVenta = double.Parse(precioUniVenta),
                PrecioUniCompra = double.Parse(precioUniCompra)
            };
            // inventario[Producto] = int.Parse(producto);   // intentando agregar el atributo Producto al Inventario
            // inventario[Producto] = producto;   // intentando agregar el atributo Producto al Inventario

            // video 02/09 min 2:23:15
            // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            var result = _repositorioInventario.AddInventario(inventario);
            if( result > 0){
                Console.WriteLine("Se creó con éxito el registro en el Inventario");
            }else{
                Console.WriteLine("Falló el registro en el Inventario");
            }
        }
    }
}

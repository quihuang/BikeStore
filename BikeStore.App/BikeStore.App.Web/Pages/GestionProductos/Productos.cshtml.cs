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
    public class ProductosModel : PageModel
    {
        // video 02/09 min 2:30:20 y en el minuto 2:41:27
        // Instanciar el repositorio, igual como se hizo en la capa Consola
        private IRepositorioProducto _repositorioProducto = new RepositorioProducto( new BikeStore.App.Persistencia.AppContext() );

        // video 02/09 min 2:49:30
        // crear una variable tipo List que reciba la totalidad de los registros consultados de la DB, debe ser público para que la interface gráfica pueda acceder a él
        public List<Producto> listadoProducto { get; set; }

        //public Producto productoResult = new Producto();

        public string mensaje;


        public void OnGet()
        {
            //producto = _repositorioProducto.GetProducto(Id);

            // video 02/09 min 2:50:22
            // debo inicializar el objeto listadoProducto dentro de OnGet para que lo pueda interpretar
            listadoProducto = new List<Producto>(); // se instancia vacío

            // video 02/09 min 2:52:16
            // llenamos la variable listadoProducto a traves del método GetAllProducto()
            // al final se usa el método ToList para convertir a Lista el IEnumerable que genera el método GetAllProductos.

            listadoProducto = _repositorioProducto.GetAllProductos().ToList();
            
            if(ViewData["mensaje"] != null){
                mensaje = ViewData["mensaje"].ToString();
            } else {
                mensaje = "";
            }
        }




        // video 02/09 min 2:09:20
        // // Método para capturar el Post del formulario
        public IActionResult OnPost(){
            // aquí se debe poner entre [] el nombre de cada campo del formulario
            var nombre = Request.Form["nombre"];
            var descripcion = Request.Form["descripcion"];

            // // Creamos el objeto Producto y le pasamos los datos del formulario
            var producto = new Producto{
                Nombre = nombre,
                Descripcion = descripcion
            };

            // video 02/09 min 2:23:15
            // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            var result = _repositorioProducto.AddProducto(producto);

            // video del 09/09 min 2:53:00
            if( result > 0){
                //TODO Mostrar este mensaje por alert en el Front
                Console.WriteLine("Se creó con éxito el producto");
                mensaje = "Se creó con éxito el producto";
                
                Page(); // retorna la misma página donde está
            }else{
                //TODO Mostrar este mensaje por alert en el Front
                Console.WriteLine("No se creó con éxito el producto");
                mensaje = "No se creó con éxito el producto";

                RedirectToPage("Error");
            }
            return Content(mensaje);
        }

        public IActionResult OnPostUpdateJson([FromBody]Producto producto)
        {
            Console.WriteLine("PRODUCTOS.cs: Para ver su contenido se imprime el objeto producto: " + "\nproducto Id: " + producto.Id + "\nproducto Nombre: " + producto.Nombre + "\nproducto Description: " + producto.Descripcion);
            Console.WriteLine("PRODUCTOS.cs: Para ver su contenido se imprime el objeto producto: " + producto + ";");

            var productoResult = _repositorioProducto.GetProducto( producto.Id );

            var mensaje = "";

            if( productoResult != null){

                productoResult.Nombre = producto.Nombre;
                productoResult.Descripcion = producto.Descripcion;
                //personaResult.Genero = (persona.Genero == "0" ? Genero.Femenino : Genero.Masculino);

                var result = _repositorioProducto.UpdateProducto(productoResult);

                if( result > 0){
                    mensaje = "Se actualizo correctamente";
                }else{
                    mensaje = "No se pudo actualizar";
                }

            }else{
                mensaje = "el producto a actualizar no existe";
            }

            //return new JsonResult(persona);

            return Content(mensaje);

        } 
    }
}

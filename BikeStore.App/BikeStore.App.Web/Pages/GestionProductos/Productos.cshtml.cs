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

            if(ViewData["mensaje"] != null)
                mensaje = ViewData["mensaje"].ToString();
            else
                mensaje = "";


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
            if( result > 0){
                Console.WriteLine("Se creó con éxito el producto");
                return RedirectToPage("./Productos");
            }else{
                Console.WriteLine("No se creó con éxito el producto");
            }

            return RedirectToPage("./Productos");
            
            // TODO validar los datos que se reciben desde el front, pueden ser con condicionales, bootstrap o expresiones regulares
            // TODO Mostrara al Front el resultado de la operación

        }

        public IActionResult OnPostUpdateJson([FromBody]Producto producto)
        {
            //Console.WriteLine("producto ID " + producto.Id + "producto name " + producto.Nombre + "producto description" + producto.Descripcion);
            Console.WriteLine("producto :" + producto + ";");

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
                mensaje = "La persona a actualizar no existe";
            }

            //return new JsonResult(persona);

            return Content(mensaje);

        } 
        
    }
}

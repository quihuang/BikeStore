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

        public string mensaje;


        public void OnGet()
        {
            // video 02/09 min 2:50:22
            // debo inicializar el objeto listado____ dentro de OnGet para que lo pueda interpretar
            listadoProducto = new List<Producto>(); // se instancia vacío

            // llenamos la variable listado____ a traves del método GetAll____()
            // al final se usa el método ToList para convertir a Lista el IEnumerable que genera el método GetAll____.
            listadoProducto = _repositorioProducto.GetAllProductos().ToList();

            // PARA MOSTRAR UN MENSAJE - PENDIENTE POR PROBAR
            if(ViewData["mensaje"] != null){
                mensaje = ViewData["mensaje"].ToString();
            } else {
                mensaje = "";
            }
        }


        // video 02/09 min 2:09:20
        // // METODO PARA POST DE CREAR
        public IActionResult OnPost(){
            // aquí se debe poner entre [] el nombre de cada campo del formulario
            var nombre = Request.Form["nombre"];
            var descripcion = Request.Form["descripcion"];

            // Creamos el objeto y le pasamos los datos del formulario
            var producto = new Producto{
                Nombre = nombre,
                Descripcion = descripcion
            };

            // video 02/09 min 2:23:15
            // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            var result = _repositorioProducto.AddProducto(producto);

            // video del 09/09 min 2:53:00
            if( result > 0){
                mensaje = "Creación realizada con éxito";
                return RedirectToPage();
            }else{
                mensaje = "Falla en el método de creación";
                return RedirectToPage("Error");
            }
        }


        // METODO PARA POST DE ACTUALIZAR MEDIANTE AJAX CON DATOS CRUDOS
        public IActionResult OnPostUpdate()
        {
            return Content("Se ejecuto el consumo del metodo Update via ajax con datos crudos");
        }


        // // METODO PARA POST DE ACTUALIZAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostUpdateJson([FromBody]Producto producto)
        {
            var productoResult = _repositorioProducto.GetProducto( producto.Id );

            var mensaje = "";

            if( productoResult != null){

                productoResult.Nombre = producto.Nombre;
                productoResult.Descripcion = producto.Descripcion;

                var result = _repositorioProducto.UpdateProducto(productoResult);

                if( result > 0){
                    mensaje = "Se actualizó correctamente";
                }else{
                    mensaje = "No se pudo actualizar";
                }

            }else{
                mensaje = "La consulta no encontró ningún registro";
            }

            // RedirectToPage("./Productos");

            //return new JsonResult(persona);

            return Content(mensaje);
        } 

        // // METODO PARA POST DE ELIMINAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostDeleteJson([FromBody]Producto producto)
        {
            var productoResult = _repositorioProducto.GetProducto( producto.Id );

            var mensaje = "";

            if( productoResult != null){

                var result = _repositorioProducto.DeleteProducto(productoResult);

                if( result > 0){
                    mensaje = "Se eliminó correctamente";
                }else{
                    mensaje = "No se pudo eliminar";
                }

            }else{
                mensaje = "La consulta no encontró ningún registro";
            }

            // RedirectToPage("./Productos");

            //return new JsonResult(persona);

            return Content(mensaje);
        }
    }
}

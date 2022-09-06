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

        public void OnGet()
        {
            // video 02/09 min 2:50:22
            // debo inicializar el objeto listadoProducto dentro de OnGet para que lo pueda interpretar
            listadoProducto = new List<Producto>(); // se instancia vacío

            // video 02/09 min 2:52:16
            // llenamos la variable listadoProducto a traves del método GetAllProducto()
            listadoProducto = _repositorioProducto.GetAllProductos().ToList(); // al final se usa el método ToList para convertir a Lista el IEnumerable que genera el método GetAllProductos.
        }

        // video 02/09 min 2:09:20
        // // Método para capturar el Post del formulario
        public void OnPost(){
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
            }else{
                Console.WriteLine("Se creó con éxito el producto");
            }
            
            // TODO validar los datos que se reciben desde el front, pueden ser con condicionales, bootstrap o expresiones regulares
            // TODO Mostrara al Front el resultado de la operación

        }
    }
}

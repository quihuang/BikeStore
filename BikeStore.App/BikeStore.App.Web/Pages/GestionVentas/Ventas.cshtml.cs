using System;
//using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.App.Dominio;
using BikeStore.App.Persistencia;
using System.Collections;
//dotnet add reference ..\System.Web.Script.Serialization\
namespace BikeStore.App.Web.Pages
{
    public class VentasModel : PageModel
    {
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
        public List<Producto> listadoProductos { get; set; }
        public Producto producto { get; set; }
        DateTime fechaActual = DateTime.Now;
        ArrayList repetidos = new ArrayList();
        public String htmlConcat;

        public string mensaje;

        public void OnGet()
        {
            // video 02/09 min 2:50:22
            // debo inicializar el objeto listado_____ dentro de OnGet para que lo pueda interpretar
            listadoVenta = new List<Venta>(); // se instancia vacío
            
            // llenamos la variable listado____ a traves del método GetAll____()
            // al final se usa el método ToList para convertir a Lista el IEnumerable que genera el método GetAll____.
            listadoVenta = _repositorioVenta.GetAllVentas().ToList();

            // Métodos para listar los diferentes objetos y mostrarlos en las listas desplegables en las ventanas Modales
            listadoTrabajador = new List<Trabajador>(); // se instancia vacío
            listadoTrabajador = _repositorioTrabajador.GetAllTrabajadores().ToList();

            listadoCliente = new List<Cliente>();
            listadoCliente = _repositorioCliente.GetAllClientes().ToList();

            listadoInventario = new List<Inventario>();
            listadoInventario = _repositorioInventario.GetAllInventarios().ToList();

            listadoProductos = new List<Producto>();
            listadoProductos = _repositorioProducto.GetAllProductos().ToList();

            foreach (var productos in listadoProductos)
            {
                foreach (var inventario in listadoInventario)
                {
                    repetidos.Add(productos.Nombre);
                } 
            }
            foreach (var productos in listadoProductos)
            {
                foreach (var inventario in listadoInventario)
                {
                    foreach(var repetido in repetidos){
                        if(repetido.Equals(productos.Nombre)){
                            continue;
                        }else{
                            Console.WriteLine("<option value='"+inventario.Id+"'>"+productos.Nombre+"</option>");
                        }
                    }
                } 
            }

            // PARA MOSTRAR UN MENSAJE - PENDIENTE POR PROBAR
            if(ViewData["mensaje"] != null){
                mensaje = ViewData["mensaje"].ToString();
            } else {
                mensaje = "";
            }
        }

        // video 02/09 min 2:09:20
        // // Método para capturar el Post del formulario CREAR
        public IActionResult OnPost()
        {
            // aquí se debe poner entre [] el nombre de cada campo del formulario
            var fecha = fechaActual;
            var cantidadProducto = Request.Form["cantidadProducto"]; // ! Error: al capturar el dato, lo recibe string
            var valorVenta = Request.Form["valorVenta"]; // ! Error: al capturar el dato, lo recibe string
            var trabajador = Request.Form["trabajador"];
            var cliente = Request.Form["cliente"];
            var inventario = Request.Form["inventario"];

            Console.WriteLine("\n\nfecha: "+ fecha);
            Console.WriteLine("cantidadProducto: " + cantidadProducto);
            Console.WriteLine("valorVenta: " + valorVenta);
            Console.WriteLine("trabajador: " + trabajador);
            Console.WriteLine("cliente: " + cliente);
            Console.WriteLine("inventario: " + inventario);

            // Creamos el objeto y le pasamos los datos del formulario
            var venta = new Venta{
               Fecha = fecha,
               CantidadProducto = int.Parse(cantidadProducto),
               ValorVenta = int.Parse(valorVenta),
               TrabajadorId = int.Parse(trabajador),
               ClienteId = int.Parse(cliente),
               InventarioId = int.Parse(inventario)
            };

            // video 02/09 min 2:23:15
            // llamamos el método del Repositorio y le pasamos por parámetro el objeto que acabamos de crear, y el resultado del método lo almacenamos en la variable result.
            var result = _repositorioVenta.AddVenta(venta);

            // video del 09/09 min 2:53:00
            if( result > 0){
                //ToDo Mostrar este mensaje por alert en el Front
                Console.WriteLine("Creación realizada con éxito");
                mensaje = "Creación realizada con éxito";
            }else{
                //ToDo Mostrar este mensaje por alert en el Front
                Console.WriteLine("Falla en el método de creación");
                mensaje = "Falla en el método de creación";
            }
            return Content(mensaje);
        }

        // METODO PARA POST DE ACTUALIZAR MEDIANTE AJAX CON DATOS CRUDOS
        public IActionResult OnPostUpdate()
        {
            return Content("Se ejecuto el consumo del metodo Update via ajax con datos crudos");
        }

        // // METODO PARA POST DE ACTUALIZAR MEDIANTE AJAX CON JSON
        public IActionResult OnPostUpdateJson([FromBody]Venta venta)
        {
            var ventaResult = _repositorioVenta.GetVenta( venta.Id );

            var mensaje = "";

            if( ventaResult != null){

                ventaResult.CantidadProducto = venta.CantidadProducto;
                ventaResult.ValorVenta = venta.ValorVenta;
                ventaResult.TrabajadorId = venta.TrabajadorId;
                ventaResult.ClienteId = venta.ClienteId;
                ventaResult.InventarioId = venta.InventarioId;

                var result = _repositorioVenta.UpdateVenta(ventaResult);

                if( result > 0){
                    mensaje = "Se actualizo correctamente";
                }else{
                    mensaje = "No se pudo actualizar";
                }

            }else{
                mensaje = "La consulta no encontró ningún registro";
            }

            //return new JsonResult(persona);

            return Content(mensaje);
        } 
    }
}
